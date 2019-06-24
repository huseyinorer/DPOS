namespace impostemalı2
{
    partial class Sartname_Duzenle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(26, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 376);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(529, 249);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Makine Ekipman Eklendikten Sonra Düzenleme Yapıldığında Şartnameyi Elle Düzeltmel" +
    "isiniz.";
            // 
            // button1
            // 
            this.button1.Image = global::impostemalı2.Properties.Resources.done;
            this.button1.Location = new System.Drawing.Point(245, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bitir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Sartname_Duzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 446);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Sartname_Duzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sartname_Duzenle";
            this.Load += new System.EventHandler(this.Sartname_Duzenle_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}