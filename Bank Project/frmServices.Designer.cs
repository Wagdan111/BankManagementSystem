namespace bank_projet
{
    partial class frmServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServices));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnManageClients = new System.Windows.Forms.Button();
            this.btnClientsTransction = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnCurrencyExchange = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(303, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 447);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "System Bank Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(167, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password By";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbUser.Location = new System.Drawing.Point(99, 238);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(117, 24);
            this.lbUser.TabIndex = 4;
            this.lbUser.Text = "User Name";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.ForeColor = System.Drawing.Color.Gray;
            this.lbPassword.Location = new System.Drawing.Point(173, 406);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(101, 23);
            this.lbPassword.TabIndex = 5;
            this.lbPassword.Text = "Password ";
            // 
            // btnManageClients
            // 
            this.btnManageClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnManageClients.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageClients.Location = new System.Drawing.Point(349, 81);
            this.btnManageClients.Name = "btnManageClients";
            this.btnManageClients.Size = new System.Drawing.Size(268, 70);
            this.btnManageClients.TabIndex = 6;
            this.btnManageClients.Text = "Manage Clients";
            this.btnManageClients.UseVisualStyleBackColor = false;
            this.btnManageClients.Click += new System.EventHandler(this.btnManageClients_Click);
            // 
            // btnClientsTransction
            // 
            this.btnClientsTransction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClientsTransction.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientsTransction.Location = new System.Drawing.Point(349, 170);
            this.btnClientsTransction.Name = "btnClientsTransction";
            this.btnClientsTransction.Size = new System.Drawing.Size(268, 70);
            this.btnClientsTransction.TabIndex = 7;
            this.btnClientsTransction.Text = "Clients Transction";
            this.btnClientsTransction.UseVisualStyleBackColor = false;
            this.btnClientsTransction.Click += new System.EventHandler(this.btnClientsTransction_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnManageUsers.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.Location = new System.Drawing.Point(349, 252);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(268, 70);
            this.btnManageUsers.TabIndex = 8;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = false;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnCurrencyExchange
            // 
            this.btnCurrencyExchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCurrencyExchange.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCurrencyExchange.Location = new System.Drawing.Point(349, 328);
            this.btnCurrencyExchange.Name = "btnCurrencyExchange";
            this.btnCurrencyExchange.Size = new System.Drawing.Size(268, 70);
            this.btnCurrencyExchange.TabIndex = 9;
            this.btnCurrencyExchange.Text = "Currency Exchange";
            this.btnCurrencyExchange.UseVisualStyleBackColor = false;
            this.btnCurrencyExchange.Click += new System.EventHandler(this.btnCurrencyExchange_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "close.png");
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Transparent;
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.ForeColor = System.Drawing.Color.Blue;
            this.btnGoBack.Location = new System.Drawing.Point(12, 406);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(138, 36);
            this.btnGoBack.TabIndex = 18;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // frmServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(668, 450);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnCurrencyExchange);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnClientsTransction);
            this.Controls.Add(this.btnManageClients);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmServices";
            this.Load += new System.EventHandler(this.frmServices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnManageClients;
        private System.Windows.Forms.Button btnClientsTransction;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnCurrencyExchange;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnGoBack;
    }
}

