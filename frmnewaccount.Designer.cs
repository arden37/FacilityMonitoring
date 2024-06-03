
namespace FacilityMonitoring
{
    partial class frmnewaccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmnewaccount));
            this.btnback = new System.Windows.Forms.Button();
            this.lblinformation = new System.Windows.Forms.Label();
            this.lblsatus = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.cmbusertype = new System.Windows.Forms.ComboBox();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkshowpass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnback.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnback.Location = new System.Drawing.Point(237, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(54, 27);
            this.btnback.TabIndex = 58;
            this.btnback.Text = "cancel";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lblinformation
            // 
            this.lblinformation.AutoEllipsis = true;
            this.lblinformation.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblinformation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblinformation.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinformation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblinformation.Location = new System.Drawing.Point(186, 226);
            this.lblinformation.Name = "lblinformation";
            this.lblinformation.Size = new System.Drawing.Size(55, 26);
            this.lblinformation.TabIndex = 56;
            this.lblinformation.Text = "STATUS";
            this.lblinformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblinformation.Click += new System.EventHandler(this.lblinformation_Click);
            // 
            // lblsatus
            // 
            this.lblsatus.AutoEllipsis = true;
            this.lblsatus.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblsatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblsatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblsatus.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblsatus.Location = new System.Drawing.Point(37, 226);
            this.lblsatus.Name = "lblsatus";
            this.lblsatus.Size = new System.Drawing.Size(83, 26);
            this.lblsatus.TabIndex = 55;
            this.lblsatus.Text = "USERTYPE";
            this.lblsatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(56, 177);
            this.txtpassword.Multiline = true;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(197, 32);
            this.txtpassword.TabIndex = 49;
            this.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(56, 101);
            this.txtusername.Multiline = true;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(197, 32);
            this.txtusername.TabIndex = 48;
            this.txtusername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbusertype
            // 
            this.cmbusertype.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbusertype.FormattingEnabled = true;
            this.cmbusertype.Items.AddRange(new object[] {
            "User",
            "Technical",
            "Admin"});
            this.cmbusertype.Location = new System.Drawing.Point(37, 256);
            this.cmbusertype.Name = "cmbusertype";
            this.cmbusertype.Size = new System.Drawing.Size(110, 31);
            this.cmbusertype.TabIndex = 59;
            // 
            // cmbstatus
            // 
            this.cmbstatus.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "Active"});
            this.cmbstatus.Location = new System.Drawing.Point(186, 256);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(83, 31);
            this.cmbstatus.TabIndex = 60;
            this.cmbstatus.Text = "Active";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Gold;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsave.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.Location = new System.Drawing.Point(220, 321);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(71, 33);
            this.btnsave.TabIndex = 61;
            this.btnsave.Text = "Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Highlight;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(90, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 63;
            this.label5.Text = "PASSWORD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Highlight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(89, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 62;
            this.label4.Text = "USERNAME";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkshowpass
            // 
            this.chkshowpass.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkshowpass.BackColor = System.Drawing.Color.White;
            this.chkshowpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkshowpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkshowpass.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkshowpass.ForeColor = System.Drawing.Color.Black;
            this.chkshowpass.Image = ((System.Drawing.Image)(resources.GetObject("chkshowpass.Image")));
            this.chkshowpass.Location = new System.Drawing.Point(220, 176);
            this.chkshowpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkshowpass.Name = "chkshowpass";
            this.chkshowpass.Size = new System.Drawing.Size(33, 33);
            this.chkshowpass.TabIndex = 64;
            this.chkshowpass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkshowpass.UseVisualStyleBackColor = false;
            this.chkshowpass.CheckedChanged += new System.EventHandler(this.chkshowpass_CheckedChanged);
            // 
            // frmnewaccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnback;
            this.ClientSize = new System.Drawing.Size(303, 366);
            this.Controls.Add(this.chkshowpass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.cmbusertype);
            this.Controls.Add(this.btnback);
            this.Controls.Add(this.lblinformation);
            this.Controls.Add(this.lblsatus);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmnewaccount";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lblinformation;
        private System.Windows.Forms.Label lblsatus;
        public System.Windows.Forms.TextBox txtpassword;
        public System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.ComboBox cmbusertype;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkshowpass;
    }
}