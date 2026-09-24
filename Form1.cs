using Memx.Extensions;
using Memx.Struct;
using System.ComponentModel;

namespace Memx
{
    public partial class Form1 : Form
    {
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Struct.Client client = new Struct.Client();
            bool IsConnected = client.Connect();
            //MessageBox.Show($"IsConnected: {IsConnected}");
            if (IsConnected)
            {
                // command to test out new features
                if(client.GetProcessMap(160, out List<VM_Entry> Entries))
                {
                    MessageBox.Show($"Loaded -> Entries: {Entries.Count}");
                }
                //string Hex = client.Read(160, 0x1b42a90, 20).ToHex();
                //MessageBox.Show($"Read result: {Hex}");

                if (client.GetProcessList(out List<ProcessList> list))
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

                    gridProcessList.DataSource = new BindingList<ProcessList>(list);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        private void Form1_Load(object sender, EventArgs e)
        {
            // uses udp to capture broadcast response from console
            Discover.DetectLocalConsoles();
        }

        private void txtFilterpListgrid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
