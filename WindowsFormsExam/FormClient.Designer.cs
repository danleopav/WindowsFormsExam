
namespace WindowsFormsExam
{
    partial class FormClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            this.labelWelcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRentingNow = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.pictureBoxProfilePhoto = new System.Windows.Forms.PictureBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(151, 20);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(158, 35);
            this.labelWelcome.TabIndex = 2;
            this.labelWelcome.Text = "Welcome,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Next payment:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(438, 185);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(38, 25);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "$0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(259, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Renting time:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(438, 248);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(67, 25);
            this.labelTime.TabIndex = 7;
            this.labelTime.Text = "0.0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Renting now:";
            // 
            // labelRentingNow
            // 
            this.labelRentingNow.AutoSize = true;
            this.labelRentingNow.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRentingNow.Location = new System.Drawing.Point(438, 124);
            this.labelRentingNow.Name = "labelRentingNow";
            this.labelRentingNow.Size = new System.Drawing.Size(41, 25);
            this.labelRentingNow.TabIndex = 9;
            this.labelRentingNow.Text = "No";
            // 
            // buttonFind
            // 
            this.buttonFind.Image = ((System.Drawing.Image)(resources.GetObject("buttonFind.Image")));
            this.buttonFind.Location = new System.Drawing.Point(492, 12);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(66, 65);
            this.buttonFind.TabIndex = 17;
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // pictureBoxProfilePhoto
            // 
            this.pictureBoxProfilePhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProfilePhoto.Location = new System.Drawing.Point(12, 92);
            this.pictureBoxProfilePhoto.Name = "pictureBoxProfilePhoto";
            this.pictureBoxProfilePhoto.Size = new System.Drawing.Size(200, 220);
            this.pictureBoxProfilePhoto.TabIndex = 16;
            this.pictureBoxProfilePhoto.TabStop = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(12, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(66, 65);
            this.buttonSettings.TabIndex = 0;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(546, 53);
            this.button1.TabIndex = 18;
            this.button1.Text = "Stop renting";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.pictureBoxProfilePhoto);
            this.Controls.Add(this.labelRentingNow);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.labelWelcome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClient";
            this.Text = "My personal account";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelRentingNow;
        private System.Windows.Forms.PictureBox pictureBoxProfilePhoto;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button button1;
    }
}