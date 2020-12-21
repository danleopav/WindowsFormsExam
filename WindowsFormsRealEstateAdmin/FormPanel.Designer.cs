
namespace WindowsFormsRealEstateAdmin
{
    partial class FormPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPanel));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPagePanel = new System.Windows.Forms.TabPage();
            this.buttonManageClients = new System.Windows.Forms.Button();
            this.buttonManageApartments = new System.Windows.Forms.Button();
            this.tabPagePending = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.listBoxPendingClients = new System.Windows.Forms.ListBox();
            this.pictureBoxBell = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPagePanel.SuspendLayout();
            this.tabPagePending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBell)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Admin Panel";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 163);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage clients";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 163);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage apartments";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPagePanel);
            this.tabControl.Controls.Add(this.tabPagePending);
            this.tabControl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(8, 54);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(476, 405);
            this.tabControl.TabIndex = 11;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPagePanel
            // 
            this.tabPagePanel.Controls.Add(this.buttonManageClients);
            this.tabPagePanel.Controls.Add(this.buttonManageApartments);
            this.tabPagePanel.Controls.Add(this.groupBox2);
            this.tabPagePanel.Controls.Add(this.groupBox1);
            this.tabPagePanel.Location = new System.Drawing.Point(4, 27);
            this.tabPagePanel.Name = "tabPagePanel";
            this.tabPagePanel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePanel.Size = new System.Drawing.Size(468, 374);
            this.tabPagePanel.TabIndex = 0;
            this.tabPagePanel.Text = "Panel";
            this.tabPagePanel.UseVisualStyleBackColor = true;
            // 
            // buttonManageClients
            // 
            this.buttonManageClients.Image = global::WindowsFormsRealEstateAdmin.Properties.Resources.people;
            this.buttonManageClients.Location = new System.Drawing.Point(21, 42);
            this.buttonManageClients.Name = "buttonManageClients";
            this.buttonManageClients.Size = new System.Drawing.Size(413, 133);
            this.buttonManageClients.TabIndex = 7;
            this.buttonManageClients.UseVisualStyleBackColor = true;
            this.buttonManageClients.Click += new System.EventHandler(this.buttonManageClients_Click);
            // 
            // buttonManageApartments
            // 
            this.buttonManageApartments.Image = global::WindowsFormsRealEstateAdmin.Properties.Resources.apartment;
            this.buttonManageApartments.Location = new System.Drawing.Point(28, 218);
            this.buttonManageApartments.Name = "buttonManageApartments";
            this.buttonManageApartments.Size = new System.Drawing.Size(413, 133);
            this.buttonManageApartments.TabIndex = 8;
            this.buttonManageApartments.UseVisualStyleBackColor = true;
            this.buttonManageApartments.Click += new System.EventHandler(this.buttonManageApartments_Click);
            // 
            // tabPagePending
            // 
            this.tabPagePending.Controls.Add(this.buttonCancel);
            this.tabPagePending.Controls.Add(this.buttonAccept);
            this.tabPagePending.Controls.Add(this.listBoxPendingClients);
            this.tabPagePending.ForeColor = System.Drawing.Color.Black;
            this.tabPagePending.Location = new System.Drawing.Point(4, 27);
            this.tabPagePending.Name = "tabPagePending";
            this.tabPagePending.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePending.Size = new System.Drawing.Size(468, 374);
            this.tabPagePending.TabIndex = 1;
            this.tabPagePending.Text = "Pending";
            this.tabPagePending.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(235, 322);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(227, 38);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccept.Location = new System.Drawing.Point(6, 322);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(223, 38);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // listBoxPendingClients
            // 
            this.listBoxPendingClients.FormattingEnabled = true;
            this.listBoxPendingClients.ItemHeight = 18;
            this.listBoxPendingClients.Location = new System.Drawing.Point(6, 6);
            this.listBoxPendingClients.Name = "listBoxPendingClients";
            this.listBoxPendingClients.Size = new System.Drawing.Size(456, 310);
            this.listBoxPendingClients.TabIndex = 0;
            // 
            // pictureBoxBell
            // 
            this.pictureBoxBell.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBell.Image")));
            this.pictureBoxBell.Location = new System.Drawing.Point(426, 24);
            this.pictureBoxBell.Name = "pictureBoxBell";
            this.pictureBoxBell.Size = new System.Drawing.Size(51, 51);
            this.pictureBoxBell.TabIndex = 12;
            this.pictureBoxBell.TabStop = false;
            // 
            // FormPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 465);
            this.Controls.Add(this.pictureBoxBell);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPanel";
            this.Text = "Admin";
            this.tabControl.ResumeLayout(false);
            this.tabPagePanel.ResumeLayout(false);
            this.tabPagePending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonManageApartments;
        private System.Windows.Forms.Button buttonManageClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPagePanel;
        private System.Windows.Forms.TabPage tabPagePending;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ListBox listBoxPendingClients;
        private System.Windows.Forms.PictureBox pictureBoxBell;
    }
}

