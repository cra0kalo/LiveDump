namespace LiveDump
{
    partial class GUI_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_Main));
            this.group_proc = new System.Windows.Forms.GroupBox();
            this.proc_txtbox_name = new System.Windows.Forms.TextBox();
            this.proc_picbox_icon = new System.Windows.Forms.PictureBox();
            this.proc_btn_select = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.group_mem = new System.Windows.Forms.GroupBox();
            this.label1_end = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mem_dump_Size = new System.Windows.Forms.TextBox();
            this.mem_dump_Address = new System.Windows.Forms.TextBox();
            this.mem_dumpFrequency = new System.Windows.Forms.TextBox();
            this.btn_DumpOnce = new System.Windows.Forms.Button();
            this.btn_BeginDump = new System.Windows.Forms.Button();
            this.btn_About = new System.Windows.Forms.Button();
            this.group_proc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proc_picbox_icon)).BeginInit();
            this.group_mem.SuspendLayout();
            this.SuspendLayout();
            //
            // group_proc
            //
            this.group_proc.Controls.Add(this.proc_txtbox_name);
            this.group_proc.Controls.Add(this.proc_picbox_icon);
            this.group_proc.Controls.Add(this.proc_btn_select);
            this.group_proc.Location = new System.Drawing.Point(12, 12);
            this.group_proc.Name = "group_proc";
            this.group_proc.Size = new System.Drawing.Size(430, 77);
            this.group_proc.TabIndex = 0;
            this.group_proc.TabStop = false;
            this.group_proc.Text = "Process";
            //
            // proc_txtbox_name
            //
            this.proc_txtbox_name.Location = new System.Drawing.Point(65, 29);
            this.proc_txtbox_name.Name = "proc_txtbox_name";
            this.proc_txtbox_name.ReadOnly = true;
            this.proc_txtbox_name.Size = new System.Drawing.Size(288, 21);
            this.proc_txtbox_name.TabIndex = 0;
            //
            // proc_picbox_icon
            //
            this.proc_picbox_icon.BackColor = System.Drawing.Color.Transparent;
            this.proc_picbox_icon.Image = global::LiveDump.Properties.Resources.AppWindow;
            this.proc_picbox_icon.Location = new System.Drawing.Point(17, 29);
            this.proc_picbox_icon.Name = "proc_picbox_icon";
            this.proc_picbox_icon.Size = new System.Drawing.Size(32, 32);
            this.proc_picbox_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.proc_picbox_icon.TabIndex = 1;
            this.proc_picbox_icon.TabStop = false;
            //
            // proc_btn_select
            //
            this.proc_btn_select.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.proc_btn_select.ImageKey = "select_proc.png";
            this.proc_btn_select.ImageList = this.imageList1;
            this.proc_btn_select.Location = new System.Drawing.Point(359, 27);
            this.proc_btn_select.Name = "proc_btn_select";
            this.proc_btn_select.Size = new System.Drawing.Size(65, 23);
            this.proc_btn_select.TabIndex = 1;
            this.proc_btn_select.Text = "Select";
            this.proc_btn_select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.proc_btn_select.UseVisualStyleBackColor = true;
            this.proc_btn_select.Click += new System.EventHandler(this.proc_btn_select_Click);
            //
            // imageList1
            //
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "begin_dump.png");
            this.imageList1.Images.SetKeyName(1, "stop_dump.png");
            this.imageList1.Images.SetKeyName(2, "dumpOnce.png");
            this.imageList1.Images.SetKeyName(3, "about.png");
            this.imageList1.Images.SetKeyName(4, "select_proc.png");
            //
            // group_mem
            //
            this.group_mem.Controls.Add(this.label1_end);
            this.group_mem.Controls.Add(this.label3);
            this.group_mem.Controls.Add(this.label2);
            this.group_mem.Controls.Add(this.label1);
            this.group_mem.Controls.Add(this.mem_dump_Size);
            this.group_mem.Controls.Add(this.mem_dump_Address);
            this.group_mem.Controls.Add(this.mem_dumpFrequency);
            this.group_mem.Enabled = false;
            this.group_mem.Location = new System.Drawing.Point(12, 95);
            this.group_mem.Name = "group_mem";
            this.group_mem.Size = new System.Drawing.Size(430, 116);
            this.group_mem.TabIndex = 1;
            this.group_mem.TabStop = false;
            this.group_mem.Text = "Memory Options";
            //
            // label1_end
            //
            this.label1_end.AutoSize = true;
            this.label1_end.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_end.Location = new System.Drawing.Point(165, 30);
            this.label1_end.Name = "label1_end";
            this.label1_end.Size = new System.Drawing.Size(20, 12);
            this.label1_end.TabIndex = 3;
            this.label1_end.Text = "ms";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dump every";
            //
            // mem_dump_Size
            //
            this.mem_dump_Size.Location = new System.Drawing.Point(86, 80);
            this.mem_dump_Size.Name = "mem_dump_Size";
            this.mem_dump_Size.Size = new System.Drawing.Size(338, 21);
            this.mem_dump_Size.TabIndex = 4;
            //
            // mem_dump_Address
            //
            this.mem_dump_Address.Location = new System.Drawing.Point(86, 53);
            this.mem_dump_Address.Name = "mem_dump_Address";
            this.mem_dump_Address.Size = new System.Drawing.Size(338, 21);
            this.mem_dump_Address.TabIndex = 3;
            //
            // mem_dumpFrequency
            //
            this.mem_dumpFrequency.Location = new System.Drawing.Point(86, 26);
            this.mem_dumpFrequency.Name = "mem_dumpFrequency";
            this.mem_dumpFrequency.Size = new System.Drawing.Size(73, 21);
            this.mem_dumpFrequency.TabIndex = 2;
            this.mem_dumpFrequency.Text = "500";
            //
            // btn_DumpOnce
            //
            this.btn_DumpOnce.Enabled = false;
            this.btn_DumpOnce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DumpOnce.ImageKey = "dumpOnce.png";
            this.btn_DumpOnce.ImageList = this.imageList1;
            this.btn_DumpOnce.Location = new System.Drawing.Point(121, 217);
            this.btn_DumpOnce.Name = "btn_DumpOnce";
            this.btn_DumpOnce.Size = new System.Drawing.Size(103, 31);
            this.btn_DumpOnce.TabIndex = 6;
            this.btn_DumpOnce.Text = "Dump Once";
            this.btn_DumpOnce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DumpOnce.UseVisualStyleBackColor = true;
            this.btn_DumpOnce.Click += new System.EventHandler(this.btn_DumpOnce_Click);
            //
            // btn_BeginDump
            //
            this.btn_BeginDump.Enabled = false;
            this.btn_BeginDump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BeginDump.ImageKey = "begin_dump.png";
            this.btn_BeginDump.ImageList = this.imageList1;
            this.btn_BeginDump.Location = new System.Drawing.Point(12, 217);
            this.btn_BeginDump.Name = "btn_BeginDump";
            this.btn_BeginDump.Size = new System.Drawing.Size(103, 31);
            this.btn_BeginDump.TabIndex = 5;
            this.btn_BeginDump.Text = "Begin Dump";
            this.btn_BeginDump.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BeginDump.UseVisualStyleBackColor = true;
            this.btn_BeginDump.Click += new System.EventHandler(this.btn_BeginDump_Click);
            //
            // btn_About
            //
            this.btn_About.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_About.ImageKey = "about.png";
            this.btn_About.ImageList = this.imageList1;
            this.btn_About.Location = new System.Drawing.Point(377, 217);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(65, 31);
            this.btn_About.TabIndex = 7;
            this.btn_About.Text = "About";
            this.btn_About.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click);
            //
            // GUI_Main
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 256);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.btn_DumpOnce);
            this.Controls.Add(this.group_mem);
            this.Controls.Add(this.group_proc);
            this.Controls.Add(this.btn_BeginDump);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GUI_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiveDump - Memory Dumper by Cra0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_Main_FormClosing);
            this.Load += new System.EventHandler(this.GUI_Main_Load);
            this.group_proc.ResumeLayout(false);
            this.group_proc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proc_picbox_icon)).EndInit();
            this.group_mem.ResumeLayout(false);
            this.group_mem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_proc;
        private System.Windows.Forms.GroupBox group_mem;
        private System.Windows.Forms.PictureBox proc_picbox_icon;
        private System.Windows.Forms.Button proc_btn_select;
        private System.Windows.Forms.TextBox proc_txtbox_name;
        private System.Windows.Forms.TextBox mem_dumpFrequency;
        private System.Windows.Forms.Label label1_end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_BeginDump;
        private System.Windows.Forms.Button btn_DumpOnce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mem_dump_Address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mem_dump_Size;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.ImageList imageList1;
    }
}

