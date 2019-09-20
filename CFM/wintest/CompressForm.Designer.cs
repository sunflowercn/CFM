namespace wintest
{
    partial class CompressForm
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
            this.textBox压缩前 = new System.Windows.Forms.TextBox();
            this.textBox压缩后 = new System.Windows.Forms.TextBox();
            this.button压缩 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button解压 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox压缩前
            // 
            this.textBox压缩前.Location = new System.Drawing.Point(102, 12);
            this.textBox压缩前.MaxLength = 32767000;
            this.textBox压缩前.Multiline = true;
            this.textBox压缩前.Name = "textBox压缩前";
            this.textBox压缩前.Size = new System.Drawing.Size(1110, 235);
            this.textBox压缩前.TabIndex = 0;
            // 
            // textBox压缩后
            // 
            this.textBox压缩后.Location = new System.Drawing.Point(102, 253);
            this.textBox压缩后.MaxLength = 32767000;
            this.textBox压缩后.Multiline = true;
            this.textBox压缩后.Name = "textBox压缩后";
            this.textBox压缩后.Size = new System.Drawing.Size(1110, 272);
            this.textBox压缩后.TabIndex = 1;
            // 
            // button压缩
            // 
            this.button压缩.Location = new System.Drawing.Point(809, 545);
            this.button压缩.Name = "button压缩";
            this.button压缩.Size = new System.Drawing.Size(75, 23);
            this.button压缩.TabIndex = 2;
            this.button压缩.Text = "压缩";
            this.button压缩.UseVisualStyleBackColor = true;
            this.button压缩.Click += new System.EventHandler(this.button压缩_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "压缩前";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "压缩后";
            // 
            // button解压
            // 
            this.button解压.Location = new System.Drawing.Point(912, 545);
            this.button解压.Name = "button解压";
            this.button解压.Size = new System.Drawing.Size(75, 23);
            this.button解压.TabIndex = 5;
            this.button解压.Text = "解压";
            this.button解压.UseVisualStyleBackColor = true;
            this.button解压.Click += new System.EventHandler(this.button解压_Click);
            // 
            // CompressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 593);
            this.Controls.Add(this.button解压);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button压缩);
            this.Controls.Add(this.textBox压缩后);
            this.Controls.Add(this.textBox压缩前);
            this.Name = "CompressForm";
            this.Text = "CompressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox压缩前;
        private System.Windows.Forms.TextBox textBox压缩后;
        private System.Windows.Forms.Button button压缩;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button解压;
    }
}