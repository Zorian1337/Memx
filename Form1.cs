using Memx.Extensions;
using Memx.Struct;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using static Memx.Struct.Client;

namespace Memx
{
    public partial class Form1 : Form
    {

        public Client client = new Client();
        public bool IsConnected = false;

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);
        public Form1()
        {
            InitializeComponent();

            // setup process grid view
            gridProcessList.AutoGenerateColumns = false;
            gridProcessList.AllowUserToAddRows = false;
            gridProcessList.ReadOnly = true;
            gridProcessList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridProcessList.MultiSelect = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // uses udp to capture broadcast response from console
            Discover.DetectLocalConsoles();
            _ = ServiceWatch();
        }

        public List<ScanResultFirstDisplay> ScanResults = new List<ScanResultFirstDisplay>();
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (!IsConnected) { MessageBox.Show("Connect to the server and try again...", "Client is not connected to PSDebug", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (SelectedProcess is null) { MessageBox.Show("Select from the process list and click attack to start.", "Must attach to a process first.", MessageBoxButtons.OK, MessageBoxIcon.Error);  return; }
            if (!client.GetProcessMap(SelectedProcess.pid, out List<VM_Entry> entries)) return;

            
            // make this selection come from the memory region 
            var RW = entries.Where(x => x.name == "executable").ToList();

            foreach (var item in RW)
            {
                Debug.WriteLine($"{item.name} : {item.prot}");
            }
            cmbProcessRegions.DataSource = RW;
            cmbProcessRegions.DisplayMember = "name";
            Debug.WriteLine($"Matched: {RW.Count}");

            List<ScanResult> Total = new List<ScanResult>();
            foreach (var item in RW)
            {
                //Debug.WriteLine($"{item.name} : {item.start} - {item.end} : {item.prot.ToString()}");
                var results = client.StartScan(uint.Parse(txtPID.Text), item.start, item.end, "8", 0, 0);
                Total.AddRange(results);
            }

            Debug.WriteLine($"after scan");

            ScanResults = Total.Select(x => x.ToFirstDisplay(Struct.ValueType.valTypeInt32)).ToList();

            Debug.WriteLine($"total {Total.Count()}");
            Debug.WriteLine($"results {ScanResults.Count()}");
            foreach (var item in ScanResults)
            {
                Debug.WriteLine($"result -> {item.Address} : {item.Value} - {item.Previous} : {item.First}");
            }


            dgScanResults.Columns.Clear();
            //dgScanResults.AutoGenerateColumns = false;
            dgScanResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Address",
                DataPropertyName = nameof(ScanResultFirstDisplay.Address),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "X8" }
            });
            dgScanResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Value",
                DataPropertyName = nameof(ScanResultFirstDisplay.Value),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgScanResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Previous",
                DataPropertyName = nameof(ScanResultFirstDisplay.Previous),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgScanResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "First",
                DataPropertyName = nameof(ScanResultFirstDisplay.First),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgScanResults.DataSource = new BindingList<ScanResultFirstDisplay>(ScanResults);
        }

        public List<ProcessList> _ProcessList = new List<ProcessList>();
        private void tsbtnConnect_Click(object sender, EventArgs e)
        {

            string c = IPAddress.Parse(tstxtIP.Text).ToString();
            Debug.WriteLine(c);
            IsConnected = client.Connect();
            //MessageBox.Show($"IsConnected: {IsConnected}");
            if (IsConnected)
            {
                tslblConnectionStatus.Text = "Status: Connected";

                // command to test out new features
                client.IsAuthenticated = client.Authenticate();
                if (client.GetProcessList(out _ProcessList))
                {
                    gridProcessList.Columns.Clear();

                    gridProcessList.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Name",
                        DataPropertyName = nameof(ProcessList.name),
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });
                    gridProcessList.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "PID",
                        DataPropertyName = nameof(ProcessList.pid),
                        Width = 80,
                        DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                    });

                    gridProcessList.DataSource = new BindingList<ProcessList>(_ProcessList);
                }
            }
        }

        private async Task ServiceWatch()
        {
            PeriodicTimer timer = new PeriodicTimer(new TimeSpan(0, 0, 5));
            while(await timer.WaitForNextTickAsync())
            {
                if (!IsConnected || client?.Connection?.Connected == false)
                {
                    tslblConnectionStatus.Text = "Status: Disconnected";
                }
            }
            
        }

        public ProcessList? SelectedProcess = null;
        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (!IsConnected) { MessageBox.Show("Connect to the server and try again...", "Client is not connected to PSDebug", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            var item = (ProcessList)gridProcessList.CurrentRow.DataBoundItem;

            if (item is null) { MessageBox.Show("Select from the process list", "Must select a process first to attach.", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            Debug.WriteLine($"Selected PID -> {item.pid} : {item.name}");
            SelectedProcess = item;

            // unlock buttons now that we are attached (not really attached but at least have a target)
            btnScan.Enabled = true;

        }

        private void txtProcessFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (_ProcessList is null || _ProcessList.Count() == 0) return;

            var newProcesses = _ProcessList.Where(x => x.name.ToLower().Contains(txtProcessFilter.Text.ToLower())).ToList();
            gridProcessList.DataSource = new BindingList<ProcessList>(newProcesses);
            //gridProcessList.Rows.
        }
    }
}
