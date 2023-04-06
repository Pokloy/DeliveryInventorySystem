
namespace CardsInventorySystem
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.forgotbutton = new System.Windows.Forms.Label();
            this.PassWTextBox = new MetroFramework.Controls.MetroTextBox();
            this.UserNTextBox = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Recoverypass1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonrecov1cancel = new System.Windows.Forms.Button();
            this.buttonsubmitrecov1 = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.txtboxUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRecovA = new System.Windows.Forms.TextBox();
            this.labelrecovq = new System.Windows.Forms.Label();
            this.Labelrecovery = new MetroFramework.Controls.MetroLabel();
            this.Recoverypass2 = new System.Windows.Forms.Panel();
            this.ButtonCcancel2 = new System.Windows.Forms.Button();
            this.ButtonCRecov2 = new System.Windows.Forms.Button();
            this.textBoxConfirmP = new System.Windows.Forms.TextBox();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Recoverypass1.SuspendLayout();
            this.Recoverypass2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.label4);
            this.LoginPanel.Controls.Add(this.label3);
            this.LoginPanel.Controls.Add(this.button1);
            this.LoginPanel.Controls.Add(this.forgotbutton);
            this.LoginPanel.Controls.Add(this.PassWTextBox);
            this.LoginPanel.Controls.Add(this.UserNTextBox);
            this.LoginPanel.Controls.Add(this.pictureBox1);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Location = new System.Drawing.Point(23, 33);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(308, 411);
            this.LoginPanel.TabIndex = 0;
            this.LoginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(27, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Username";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(186)))));
            this.button1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(55, 326);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // forgotbutton
            // 
            this.forgotbutton.AutoSize = true;
            this.forgotbutton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(186)))));
            this.forgotbutton.Location = new System.Drawing.Point(77, 374);
            this.forgotbutton.Name = "forgotbutton";
            this.forgotbutton.Size = new System.Drawing.Size(141, 19);
            this.forgotbutton.TabIndex = 6;
            this.forgotbutton.Text = "Forgot Password?";
            this.forgotbutton.Click += new System.EventHandler(this.label2_Click);
            // 
            // PassWTextBox
            // 
            this.PassWTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.PassWTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.PassWTextBox.Location = new System.Drawing.Point(21, 252);
            this.PassWTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PassWTextBox.Name = "PassWTextBox";
            this.PassWTextBox.PasswordChar = '*';
            this.PassWTextBox.Size = new System.Drawing.Size(269, 38);
            this.PassWTextBox.Style = MetroFramework.MetroColorStyle.Black;
            this.PassWTextBox.TabIndex = 4;
            this.PassWTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // UserNTextBox
            // 
            this.UserNTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.UserNTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.UserNTextBox.Location = new System.Drawing.Point(21, 190);
            this.UserNTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserNTextBox.Name = "UserNTextBox";
            this.UserNTextBox.Size = new System.Drawing.Size(269, 38);
            this.UserNTextBox.Style = MetroFramework.MetroColorStyle.Black;
            this.UserNTextBox.TabIndex = 3;
            this.UserNTextBox.Tag = "";
            this.UserNTextBox.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log-In";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Recoverypass1
            // 
            this.Recoverypass1.Controls.Add(this.label8);
            this.Recoverypass1.Controls.Add(this.buttonrecov1cancel);
            this.Recoverypass1.Controls.Add(this.buttonsubmitrecov1);
            this.Recoverypass1.Controls.Add(this.ButtonSearch);
            this.Recoverypass1.Controls.Add(this.txtboxUserName);
            this.Recoverypass1.Controls.Add(this.label6);
            this.Recoverypass1.Controls.Add(this.textBoxRecovA);
            this.Recoverypass1.Controls.Add(this.labelrecovq);
            this.Recoverypass1.Controls.Add(this.Labelrecovery);
            this.Recoverypass1.Location = new System.Drawing.Point(26, 28);
            this.Recoverypass1.Name = "Recoverypass1";
            this.Recoverypass1.Size = new System.Drawing.Size(308, 413);
            this.Recoverypass1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Recovery Question";
            // 
            // buttonrecov1cancel
            // 
            this.buttonrecov1cancel.Location = new System.Drawing.Point(158, 288);
            this.buttonrecov1cancel.Name = "buttonrecov1cancel";
            this.buttonrecov1cancel.Size = new System.Drawing.Size(97, 32);
            this.buttonrecov1cancel.TabIndex = 9;
            this.buttonrecov1cancel.Text = "Cancel";
            this.buttonrecov1cancel.UseVisualStyleBackColor = true;
            this.buttonrecov1cancel.Click += new System.EventHandler(this.buttonrecov1cancel_Click);
            // 
            // buttonsubmitrecov1
            // 
            this.buttonsubmitrecov1.Location = new System.Drawing.Point(55, 288);
            this.buttonsubmitrecov1.Name = "buttonsubmitrecov1";
            this.buttonsubmitrecov1.Size = new System.Drawing.Size(97, 32);
            this.buttonsubmitrecov1.TabIndex = 8;
            this.buttonsubmitrecov1.Text = "Submit";
            this.buttonsubmitrecov1.UseVisualStyleBackColor = true;
            this.buttonsubmitrecov1.Click += new System.EventHandler(this.buttonsubmitrecov1_Click);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(193, 98);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(97, 34);
            this.ButtonSearch.TabIndex = 7;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // txtboxUserName
            // 
            this.txtboxUserName.Location = new System.Drawing.Point(21, 110);
            this.txtboxUserName.Name = "txtboxUserName";
            this.txtboxUserName.Size = new System.Drawing.Size(167, 22);
            this.txtboxUserName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Username";
            // 
            // textBoxRecovA
            // 
            this.textBoxRecovA.Location = new System.Drawing.Point(21, 238);
            this.textBoxRecovA.Name = "textBoxRecovA";
            this.textBoxRecovA.Size = new System.Drawing.Size(269, 22);
            this.textBoxRecovA.TabIndex = 4;
            // 
            // labelrecovq
            // 
            this.labelrecovq.AutoSize = true;
            this.labelrecovq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelrecovq.Location = new System.Drawing.Point(18, 189);
            this.labelrecovq.Name = "labelrecovq";
            this.labelrecovq.Size = new System.Drawing.Size(0, 24);
            this.labelrecovq.TabIndex = 1;
            // 
            // Labelrecovery
            // 
            this.Labelrecovery.AutoSize = true;
            this.Labelrecovery.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Labelrecovery.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.Labelrecovery.Location = new System.Drawing.Point(36, 26);
            this.Labelrecovery.Name = "Labelrecovery";
            this.Labelrecovery.Size = new System.Drawing.Size(184, 25);
            this.Labelrecovery.TabIndex = 0;
            this.Labelrecovery.Text = "Password Recovery";
            // 
            // Recoverypass2
            // 
            this.Recoverypass2.Controls.Add(this.ButtonCcancel2);
            this.Recoverypass2.Controls.Add(this.ButtonCRecov2);
            this.Recoverypass2.Controls.Add(this.textBoxConfirmP);
            this.Recoverypass2.Controls.Add(this.textBoxNewPass);
            this.Recoverypass2.Controls.Add(this.label7);
            this.Recoverypass2.Controls.Add(this.label2);
            this.Recoverypass2.Controls.Add(this.metroLabel1);
            this.Recoverypass2.Location = new System.Drawing.Point(23, 28);
            this.Recoverypass2.Name = "Recoverypass2";
            this.Recoverypass2.Size = new System.Drawing.Size(313, 416);
            this.Recoverypass2.TabIndex = 2;
            // 
            // ButtonCcancel2
            // 
            this.ButtonCcancel2.Location = new System.Drawing.Point(150, 255);
            this.ButtonCcancel2.Name = "ButtonCcancel2";
            this.ButtonCcancel2.Size = new System.Drawing.Size(82, 35);
            this.ButtonCcancel2.TabIndex = 7;
            this.ButtonCcancel2.Text = "Cancel";
            this.ButtonCcancel2.UseVisualStyleBackColor = true;
            this.ButtonCcancel2.Click += new System.EventHandler(this.ButtonCcancel2_Click);
            // 
            // ButtonCRecov2
            // 
            this.ButtonCRecov2.Location = new System.Drawing.Point(60, 255);
            this.ButtonCRecov2.Name = "ButtonCRecov2";
            this.ButtonCRecov2.Size = new System.Drawing.Size(84, 35);
            this.ButtonCRecov2.TabIndex = 6;
            this.ButtonCRecov2.Text = "Submit";
            this.ButtonCRecov2.UseVisualStyleBackColor = true;
            this.ButtonCRecov2.Click += new System.EventHandler(this.ButtonCRecov2_Click);
            // 
            // textBoxConfirmP
            // 
            this.textBoxConfirmP.Location = new System.Drawing.Point(42, 190);
            this.textBoxConfirmP.Name = "textBoxConfirmP";
            this.textBoxConfirmP.PasswordChar = '*';
            this.textBoxConfirmP.Size = new System.Drawing.Size(227, 22);
            this.textBoxConfirmP.TabIndex = 5;
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Location = new System.Drawing.Point(42, 136);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.PasswordChar = '*';
            this.textBoxNewPass.Size = new System.Drawing.Size(227, 22);
            this.textBoxNewPass.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(42, 24);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(184, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Password Recovery";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 469);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.Recoverypass1);
            this.Controls.Add(this.Recoverypass2);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogIn";
            this.Padding = new System.Windows.Forms.Padding(20, 37, 20, 20);
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Recoverypass1.ResumeLayout(false);
            this.Recoverypass1.PerformLayout();
            this.Recoverypass2.ResumeLayout(false);
            this.Recoverypass2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox PassWTextBox;
        private MetroFramework.Controls.MetroTextBox UserNTextBox;
        private System.Windows.Forms.Label forgotbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Recoverypass1;
        private System.Windows.Forms.Button buttonrecov1cancel;
        private System.Windows.Forms.Button buttonsubmitrecov1;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.TextBox txtboxUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRecovA;
        private System.Windows.Forms.Label labelrecovq;
        private MetroFramework.Controls.MetroLabel Labelrecovery;
        private System.Windows.Forms.Panel Recoverypass2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Button ButtonCcancel2;
        private System.Windows.Forms.Button ButtonCRecov2;
        private System.Windows.Forms.TextBox textBoxConfirmP;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
    }
}

