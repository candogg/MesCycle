namespace MesCycle.ClientApp.Forms
{
    partial class FrmMain
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
            this.LblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LstReceived = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LstSent = new System.Windows.Forms.ListBox();
            this.BtnReconnect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblStatus
            // 
            this.LblStatus.Location = new System.Drawing.Point(3, 23);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(667, 38);
            this.LblStatus.TabIndex = 0;
            this.LblStatus.Text = "-";
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnReconnect);
            this.groupBox1.Controls.Add(this.LblStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STATUS";
            // 
            // BtnSend
            // 
            this.BtnSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSend.Location = new System.Drawing.Point(206, 118);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(288, 34);
            this.BtnSend.TabIndex = 2;
            this.BtnSend.Text = "Send Random Message";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.LstReceived);
            this.groupBox2.Location = new System.Drawing.Point(12, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 225);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RECEIVED FROM API";
            // 
            // LstReceived
            // 
            this.LstReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstReceived.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstReceived.FormattingEnabled = true;
            this.LstReceived.ItemHeight = 14;
            this.LstReceived.Location = new System.Drawing.Point(3, 23);
            this.LstReceived.Name = "LstReceived";
            this.LstReceived.Size = new System.Drawing.Size(670, 199);
            this.LstReceived.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.LstSent);
            this.groupBox3.Location = new System.Drawing.Point(12, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(676, 141);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SENT TO API";
            // 
            // LstSent
            // 
            this.LstSent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstSent.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstSent.FormattingEnabled = true;
            this.LstSent.ItemHeight = 14;
            this.LstSent.Location = new System.Drawing.Point(3, 23);
            this.LstSent.Name = "LstSent";
            this.LstSent.Size = new System.Drawing.Size(670, 115);
            this.LstSent.TabIndex = 4;
            // 
            // BtnReconnect
            // 
            this.BtnReconnect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnReconnect.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReconnect.Location = new System.Drawing.Point(260, 69);
            this.BtnReconnect.Name = "BtnReconnect";
            this.BtnReconnect.Size = new System.Drawing.Size(156, 25);
            this.BtnReconnect.TabIndex = 5;
            this.BtnReconnect.Text = "Reconnect";
            this.BtnReconnect.UseVisualStyleBackColor = true;
            this.BtnReconnect.Visible = false;
            this.BtnReconnect.Click += new System.EventHandler(this.BtnReconnect_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(700, 542);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Communicating Agent";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LstReceived;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox LstSent;
        private System.Windows.Forms.Button BtnReconnect;
    }
}

