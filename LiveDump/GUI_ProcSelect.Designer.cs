namespace LiveDump
{
    partial class GUI_ProcSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_ProcSelect));
            this.procListView = new System.Windows.Forms.ListView();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // procListView
            //
            this.procListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                        | System.Windows.Forms.AnchorStyles.Left)
                                        | System.Windows.Forms.AnchorStyles.Right)));
            this.procListView.Location = new System.Drawing.Point(12, 12);
            this.procListView.Name = "procListView";
            this.procListView.Size = new System.Drawing.Size(390, 297);
            this.procListView.TabIndex = 0;
            this.procListView.UseCompatibleStateImageBehavior = false;
            this.procListView.DoubleClick += new System.EventHandler(this.procListView_DoubleClick);
            //
            // btn_select
            //
            this.btn_select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_select.Location = new System.Drawing.Point(12, 317);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(125, 23);
            this.btn_select.TabIndex = 1;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            //
            // btn_close
            //
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Location = new System.Drawing.Point(277, 317);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(125, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            //
            // GUI_ProcSelect
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 352);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.procListView);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(293, 386);
            this.Name = "GUI_ProcSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LiveDump - Select Process";
            this.Load += new System.EventHandler(this.GUI_ProcSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView procListView;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_close;
    }
}