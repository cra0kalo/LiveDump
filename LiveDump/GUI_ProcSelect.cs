using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Management;

namespace LiveDump
{
    public partial class GUI_ProcSelect : Form
    {
        private ImageList iconList;
        private CProcess _proc;

        private bool formClosed;


        public CProcess SelectedProcess
        {
            get
            {
                return _proc;
            }
        }


        public GUI_ProcSelect()
        {
            InitializeComponent();

            iconList = new ImageList();
            iconList.ImageSize = new Size(32, 32);
            iconList.ColorDepth = ColorDepth.Depth32Bit;


            //setup procList ListView
            procListView.Columns.Add("Process", 200, HorizontalAlignment.Left);
            procListView.Columns.Add("Path", 400, HorizontalAlignment.Left);

            procListView.SmallImageList = iconList;
            procListView.LargeImageList = iconList;

            procListView.MultiSelect = false;
            procListView.FullRowSelect = true;
            procListView.HideSelection = false;
            procListView.View = View.Details;
            procListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            PopulateProcessList();
        }

        private void GUI_ProcSelect_Load(object sender, EventArgs e)
        {

        }


        private void PopulateProcessList()
        {

            //grab the list of processes
            Process[] proc_list = Process.GetProcesses();
            List<CProcess> Raw_procList = new List<CProcess>(proc_list.Length); //can only be as much as the proclist and less

            //grab their icons
            for (int p = 0; p < proc_list.Length; p++)
            {
                Process proc = proc_list[p];
                try
                {
                    String filePID = String.Format("{0}-{1}", Utilities.ToHexPID(proc.Id), proc.ProcessName);
                    String filePath = proc.Modules[0].FileName;
                    Icon proc_icon = IconTools.GetIconForFile(filePath, ShellIconSize.LargeIcon);
                    if (proc_icon == null)
                        throw new Exception("unable to get icon for proc");
                    Raw_procList.Add(new CProcess(proc, proc_icon));
                }
                catch
                {
                    //Console.WriteLine("Populate Process List Exception: " + ex.Message + "=>" + proc.ProcessName);
                }
            }

            //sort by PID
            List<CProcess> Sorted_procList = Raw_procList.OrderBy(o => o.iProcess.Id).ToList();

            //finally populate the list
            for (int i = 0; i < Sorted_procList.Count; i++)
            {
                CProcess current = Sorted_procList[i];

                //Format a nice name to display
                String ProcName = String.Format("{0}-{1}", Utilities.ToHexPID(current.iProcess.Id), current.iProcess.ProcessName);

                //add the icon to our imagelist
                iconList.Images.Add(current.IconAsBitmap);

                ListViewItem list_item = new ListViewItem(ProcName, iconList.Images.Count - 1); //(ICON) Name
                ListViewItem.ListViewSubItem sub_item_Path = new ListViewItem.ListViewSubItem(list_item, current.iProcess.Modules[0].FileName);

                list_item.SubItems.Add(sub_item_Path); //add subItem
                list_item.Tag = current; //add our proc as a Tag

                procListView.Items.Add(list_item); //add to list

            }

            //select the first item
            if(procListView.Items.Count > 0)
            {
                procListView.Items[0].Selected = true;
                procListView.Select();
            }

        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (procListView.SelectedItems.Count > 0)
            {
                ListViewItem itm = procListView.SelectedItems[0];
                _proc = (CProcess)itm.Tag;
            }
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            _proc = null;
            this.Close();
        }


        private void procListView_DoubleClick(object sender, EventArgs e)
        {
            if (procListView.SelectedItems.Count > 0)
            {
                ListViewItem itm = procListView.SelectedItems[0];
                _proc = (CProcess)itm.Tag;
            }

            this.Close();
        }

        private void CloseForm()
        {
            if (!formClosed)
            {
                this.formClosed = true;
                this.Close();
            }
        }


    }
}
