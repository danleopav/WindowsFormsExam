
namespace WindowsFormsAppRealEstateAdmin
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
            this.buttonManageApartments = new System.Windows.Forms.Button();
            this.buttonManageClients = new System.Windows.Forms.Button();
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
            this.groupBox1.Location = new System.Drawing.Point(26, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 163);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage clients";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(264, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 163);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage apartments";
            // 
            // buttonManageApartments
            // 
            this.buttonManageApartments.Image = global::WindowsFormsAppRealEstateAdmin.Properties.Resources.apartment;
            this.buttonManageApartments.Location = new System.Drawing.Point(273, 87);
            this.buttonManageApartments.Name = "buttonManageApartments";
            this.buttonManageApartments.Size = new System.Drawing.Size(182, 133);
            this.buttonManageApartments.TabIndex = 8;
            this.buttonManageApartments.UseVisualStyleBackColor = true;
            // 
            // buttonManageClients
            // 
            this.buttonManageClients.Image = global::WindowsFormsAppRealEstateAdmin.Properties.Resources.people;
            this.buttonManageClients.Location = new System.Drawing.Point(32, 87);
            this.buttonManageClients.Name = "buttonManageClients";
            this.buttonManageClients.Size = new System.Drawing.Size(182, 133);
            this.buttonManageClients.TabIndex = 7;
            this.buttonManageClients.UseVisualStyleBackColor = true;
            this.buttonManageClients.Click += new System.EventHandler(this.buttonManageClients_Click);
            // 
            // FormPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 242);
            this.Controls.Add(this.buttonManageApartments);
            this.Controls.Add(this.buttonManageClients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPanel";
            this.Text = "Admin panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonManageApartments;
        private System.Windows.Forms.Button buttonManageClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

