
namespace WindowsFormsRealEstateAdmin
{
    partial class FormClientManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientManager));
            this.buttonBan = new System.Windows.Forms.Button();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEvict = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBan
            // 
            this.buttonBan.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBan.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonBan.Location = new System.Drawing.Point(15, 494);
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(457, 34);
            this.buttonBan.TabIndex = 6;
            this.buttonBan.Text = "Ban";
            this.buttonBan.UseVisualStyleBackColor = true;
            this.buttonBan.Click += new System.EventHandler(this.buttonBan_Click);
            // 
            // listBoxClients
            // 
            this.listBoxClients.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.ItemHeight = 25;
            this.listBoxClients.Location = new System.Drawing.Point(12, 80);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(460, 404);
            this.listBoxClients.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Clients";
            // 
            // buttonEvict
            // 
            this.buttonEvict.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEvict.ForeColor = System.Drawing.Color.IndianRed;
            this.buttonEvict.Location = new System.Drawing.Point(15, 534);
            this.buttonEvict.Name = "buttonEvict";
            this.buttonEvict.Size = new System.Drawing.Size(457, 34);
            this.buttonEvict.TabIndex = 13;
            this.buttonEvict.Text = "Evict";
            this.buttonEvict.UseVisualStyleBackColor = true;
            this.buttonEvict.Click += new System.EventHandler(this.buttonEvict_Click);
            // 
            // FormClientManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 577);
            this.Controls.Add(this.buttonEvict);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClientManager";
            this.Text = "Client manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBan;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEvict;
    }
}