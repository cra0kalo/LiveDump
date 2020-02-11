using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;

namespace LiveDump
{
    public partial class GUI_Main : Form
    {

        //Data
        private CProcess selected_proc;
        private GUI_ProcSelect gui_procSelector;

        private Dumper dmpr;
        private SaveFileDialog saveUI = new SaveFileDialog();
        private string LastSaveLocation = string.Empty;

        public GUI_Main()
        {
            InitializeComponent();
        }

        private void GUI_Main_Load(object sender, EventArgs e)
        {
            saveUI.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveUI.DefaultExt = "bin";
            saveUI.Filter = "Binary File (*.bin)|*.bin|All files (*.*)|*.*";

        }

        private void GUI_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dmpr != null)
                dmpr.Close();

        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            //create a new object and show the About pane
            GUI_About about_pane = new GUI_About();
            about_pane.ShowDialog();
        }

        private void proc_btn_select_Click(object sender, EventArgs e)
        {
            gui_procSelector = new GUI_ProcSelect();
            gui_procSelector.FormClosing += new FormClosingEventHandler(delegate (object ev_sender, FormClosingEventArgs ev_e)
            {
                selected_proc = gui_procSelector.SelectedProcess; //set the selected proc on close
                if (selected_proc != null)
                {
                    dmpr = new Dumper(selected_proc);
                    dmpr.DumpingStatusChanged += dmpr_DumpingStatusChanged;
                    dmpr.RaiseMessagebox += dmpr_RaiseMessagebox;
                    proc_picbox_icon.Image = gui_procSelector.SelectedProcess.IconAsBitmap;
                    proc_txtbox_name.Text = selected_proc.iProcess.ProcessName;
                    group_mem.Enabled = true;

                    btn_BeginDump.Enabled = true;
                    btn_DumpOnce.Enabled = true;

                }
                else
                {
                    dmpr = null;
                    proc_picbox_icon.Image = Properties.Resources.AppWindow;
                    proc_txtbox_name.Text = String.Empty;
                    group_mem.Enabled = false;

                    btn_BeginDump.Enabled = false;
                    btn_DumpOnce.Enabled = false;

                }
            });
            gui_procSelector.ShowDialog();

        }

        void dmpr_RaiseMessagebox(string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MethodInvoker method = null;
            if (this.InvokeRequired)
            {
                if (method == null)
                {
                    method = () => this.dmpr_RaiseMessagebox(message, buttons, icon);
                }
                this.Invoke(method);
            }
            else
            {
                MessageBox.Show(message, this.Text, buttons, icon);
            }
        }

        void dmpr_DumpingStatusChanged(Dumper.DUMPINGSTAT stat)
        {
            MethodInvoker method = null;
            if (this.InvokeRequired)
            {
                if (method == null)
                {
                    method = () => this.dmpr_DumpingStatusChanged(stat);
                }
                this.Invoke(method);
            }
            else
            {
                if (stat == Dumper.DUMPINGSTAT.DUMPING)
                {
                    btn_BeginDump.Text = "Stop Dump";
                    btn_BeginDump.ImageKey = "stop_dump.png";
                }
                else if (stat == Dumper.DUMPINGSTAT.IDLE)
                {
                    btn_BeginDump.Text = "Begin Dump";
                    btn_BeginDump.ImageKey = "begin_dump.png";
                }
            }
        }

        private void btn_BeginDump_Click(object sender, EventArgs e)
        {
            if (dmpr == null)
                return;

            if (dmpr.Dumping)
            {
                //lets stop
                dmpr.StopDumping();
            }
            else
            {
                //start dumping
                IntPtr address;
                Int32 size;
                Int32 cycle;

                bool xread = GetData(out address, out size);
                if (xread == false)
                    return;

                //get cycle
                bool parse_cycle = int.TryParse(mem_dumpFrequency.Text, out cycle);
                if (!parse_cycle)
                {
                    MessageBox.Show("Invalid frequency input", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                saveUI.FileName = "memdump_" + address.ToString("X8") + ".bin";

                if (LastSaveLocation != string.Empty)
                    saveUI.InitialDirectory = LastSaveLocation;

                DialogResult result = saveUI.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //savepath
                    LastSaveLocation = Path.GetDirectoryName(saveUI.FileName);

                    dmpr.DumpCycle(address, size, cycle, saveUI.FileName);
                }
            }
        }

        private void btn_DumpOnce_Click(object sender, EventArgs e)
        {
            if (dmpr == null)
                return;

            //do a single dump
            IntPtr address;
            Int32 size;

            bool xread = GetData(out address, out size);
            if (xread == false)
                return;

            //get the output filepath
            saveUI.FileName = "memdump_" + address.ToString("X8") + ".bin";

            if (LastSaveLocation != string.Empty)
                saveUI.InitialDirectory = LastSaveLocation;

            DialogResult result = saveUI.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //savepath
                LastSaveLocation = Path.GetDirectoryName(saveUI.FileName);

                bool dResult = dmpr.DumpOnce(address, size, saveUI.FileName);
                if (dResult)
                {
                    MessageBox.Show("Memory successfully dumped", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to dump memory", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        private bool GetData(out IntPtr address, out Int32 size)
        {
            address = IntPtr.Zero;
            size = 0;

            //grab required from UI
            string raw_address = mem_dump_Address.Text;
            string raw_size = mem_dump_Size.Text;


            if (Native.Is32BitProcess(selected_proc.iProcess))
            {
                //32bit use uint32
                Int32 cAddress32 = 0;
                if (raw_address.StartsWith("0x") && Int32.TryParse(raw_address.Substring(2),
                        System.Globalization.NumberStyles.AllowHexSpecifier,
                        null,
                        out cAddress32))
                {
                    //parsed hex
                }
                else
                {
                    bool parse_address = Int32.TryParse(raw_address, out cAddress32);
                    if (!parse_address)
                    {
                        MessageBox.Show("Invalid address input", "Invalid Data - Proc32", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

                address = new IntPtr(cAddress32); //set here
            }
            else
            {
                //64bit use uint64
                Int64 cAddress64 = 0;
                if (raw_address.StartsWith("0x") && Int64.TryParse(raw_address.Substring(2),
                        System.Globalization.NumberStyles.AllowHexSpecifier,
                        null,
                        out cAddress64))
                {
                    //parsed hex
                }
                else
                {
                    bool parse_address = Int64.TryParse(raw_address, out cAddress64);
                    if (!parse_address)
                    {
                        MessageBox.Show("Invalid address input", "Invalid Data - Proc64", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                address = new IntPtr(cAddress64); //set here
            }

            //SIZE
            if (raw_size.StartsWith("0x") && int.TryParse(raw_size.Substring(2),
                    System.Globalization.NumberStyles.AllowHexSpecifier,
                    null,
                    out size))
            {
                //parsed hex
            }
            else
            {
                bool parse_size = int.TryParse(mem_dump_Size.Text, out size);
                if (!parse_size)
                {
                    MessageBox.Show("Invalid size input", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            return true;
        }



    }
}
