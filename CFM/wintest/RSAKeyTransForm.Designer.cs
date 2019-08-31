namespace wintest
{
    partial class RSAKeyTransForm
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
            this.buttonJavaToNetPub = new System.Windows.Forms.Button();
            this.textBoxJavakey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNetKey = new System.Windows.Forms.TextBox();
            this.buttonNetToJavaPri = new System.Windows.Forms.Button();
            this.buttonNetToJavaPub = new System.Windows.Forms.Button();
            this.buttonJavaToNetPri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonJavaToNetPub
            // 
            this.buttonJavaToNetPub.Location = new System.Drawing.Point(198, 415);
            this.buttonJavaToNetPub.Name = "buttonJavaToNetPub";
            this.buttonJavaToNetPub.Size = new System.Drawing.Size(132, 23);
            this.buttonJavaToNetPub.TabIndex = 0;
            this.buttonJavaToNetPub.Text = "Java->Net公钥";
            this.buttonJavaToNetPub.UseVisualStyleBackColor = true;
            this.buttonJavaToNetPub.Click += new System.EventHandler(this.buttonJavaToNetPub_Click);
            // 
            // textBoxJavakey
            // 
            this.textBoxJavakey.Location = new System.Drawing.Point(140, 12);
            this.textBoxJavakey.Multiline = true;
            this.textBoxJavakey.Name = "textBoxJavakey";
            this.textBoxJavakey.Size = new System.Drawing.Size(404, 364);
            this.textBoxJavakey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Java密钥";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Net密钥";
            // 
            // textBoxNetKey
            // 
            this.textBoxNetKey.Location = new System.Drawing.Point(617, 12);
            this.textBoxNetKey.Multiline = true;
            this.textBoxNetKey.Name = "textBoxNetKey";
            this.textBoxNetKey.Size = new System.Drawing.Size(416, 364);
            this.textBoxNetKey.TabIndex = 3;
            // 
            // buttonNetToJavaPri
            // 
            this.buttonNetToJavaPri.Location = new System.Drawing.Point(685, 415);
            this.buttonNetToJavaPri.Name = "buttonNetToJavaPri";
            this.buttonNetToJavaPri.Size = new System.Drawing.Size(132, 23);
            this.buttonNetToJavaPri.TabIndex = 5;
            this.buttonNetToJavaPri.Text = "Net->Java私钥";
            this.buttonNetToJavaPri.UseVisualStyleBackColor = true;
            this.buttonNetToJavaPri.Click += new System.EventHandler(this.buttonNetToJavaPri_Click);
            // 
            // buttonNetToJavaPub
            // 
            this.buttonNetToJavaPub.Location = new System.Drawing.Point(533, 415);
            this.buttonNetToJavaPub.Name = "buttonNetToJavaPub";
            this.buttonNetToJavaPub.Size = new System.Drawing.Size(132, 23);
            this.buttonNetToJavaPub.TabIndex = 6;
            this.buttonNetToJavaPub.Text = "Net->Java公钥";
            this.buttonNetToJavaPub.UseVisualStyleBackColor = true;
            this.buttonNetToJavaPub.Click += new System.EventHandler(this.buttonNetToJavaPub_Click);
            // 
            // buttonJavaToNetPri
            // 
            this.buttonJavaToNetPri.Location = new System.Drawing.Point(360, 415);
            this.buttonJavaToNetPri.Name = "buttonJavaToNetPri";
            this.buttonJavaToNetPri.Size = new System.Drawing.Size(132, 23);
            this.buttonJavaToNetPri.TabIndex = 7;
            this.buttonJavaToNetPri.Text = "Java->Net私钥";
            this.buttonJavaToNetPri.UseVisualStyleBackColor = true;
            this.buttonJavaToNetPri.Click += new System.EventHandler(this.buttonJavaToNetPri_Click);
            // 
            // RSAKeyTransForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 462);
            this.Controls.Add(this.buttonJavaToNetPri);
            this.Controls.Add(this.buttonNetToJavaPub);
            this.Controls.Add(this.buttonNetToJavaPri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNetKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxJavakey);
            this.Controls.Add(this.buttonJavaToNetPub);
            this.Name = "RSAKeyTransForm";
            this.Text = "RSAKeyTransForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonJavaToNetPub;
        private System.Windows.Forms.TextBox textBoxJavakey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNetKey;
        private System.Windows.Forms.Button buttonNetToJavaPri;
        private System.Windows.Forms.Button buttonNetToJavaPub;
        private System.Windows.Forms.Button buttonJavaToNetPri;
    }
}