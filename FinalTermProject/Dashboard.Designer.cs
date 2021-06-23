
namespace FinalTermProject
{
    partial class Dashboard
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
            this.tcpserver = new System.Windows.Forms.Button();
            this.tcpclient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.ipaddBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tcpserver
            // 
            this.tcpserver.BackColor = System.Drawing.SystemColors.Control;
            this.tcpserver.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcpserver.Location = new System.Drawing.Point(447, 61);
            this.tcpserver.Name = "tcpserver";
            this.tcpserver.Size = new System.Drawing.Size(317, 38);
            this.tcpserver.TabIndex = 9;
            this.tcpserver.Text = "Open TCP Server";
            this.tcpserver.UseVisualStyleBackColor = false;
            this.tcpserver.Click += new System.EventHandler(this.tcpserver_Click);
            // 
            // tcpclient
            // 
            this.tcpclient.BackColor = System.Drawing.Color.BurlyWood;
            this.tcpclient.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcpclient.Location = new System.Drawing.Point(239, 269);
            this.tcpclient.Name = "tcpclient";
            this.tcpclient.Size = new System.Drawing.Size(317, 38);
            this.tcpclient.TabIndex = 8;
            this.tcpclient.Text = "Open TCP Client";
            this.tcpclient.UseVisualStyleBackColor = false;
            this.tcpclient.Visible = false;
            this.tcpclient.Click += new System.EventHandler(this.tcpclient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 27);
            this.label2.TabIndex = 23;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 27);
            this.label1.TabIndex = 22;
            this.label1.Text = "Host";
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portBox.Location = new System.Drawing.Point(38, 152);
            this.portBox.Multiline = true;
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(172, 38);
            this.portBox.TabIndex = 21;
            // 
            // ipaddBox
            // 
            this.ipaddBox.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipaddBox.Location = new System.Drawing.Point(36, 61);
            this.ipaddBox.Multiline = true;
            this.ipaddBox.Name = "ipaddBox";
            this.ipaddBox.Size = new System.Drawing.Size(305, 38);
            this.ipaddBox.TabIndex = 20;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ipaddBox);
            this.Controls.Add(this.tcpserver);
            this.Controls.Add(this.tcpclient);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tcpserver;
        private System.Windows.Forms.Button tcpclient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.TextBox ipaddBox;
    }
}