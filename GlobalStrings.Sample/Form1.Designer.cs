
namespace GlobalStrings.Sample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChangeLang = new System.Windows.Forms.Button();
            this.cmbLanguages = new System.Windows.Forms.ComboBox();
            this.lblTextPlaceholder = new System.Windows.Forms.Label();
            this.btnSizeDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeLang
            // 
            this.btnChangeLang.Location = new System.Drawing.Point(228, 415);
            this.btnChangeLang.Name = "btnChangeLang";
            this.btnChangeLang.Size = new System.Drawing.Size(96, 23);
            this.btnChangeLang.TabIndex = 0;
            this.btnChangeLang.Text = "Mudar idioma";
            this.btnChangeLang.UseVisualStyleBackColor = true;
            this.btnChangeLang.Click += new System.EventHandler(this.btnChangeLang_Click);
            // 
            // cmbLanguages
            // 
            this.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguages.FormattingEnabled = true;
            this.cmbLanguages.Items.AddRange(new object[] {
            "Português (Brasil)",
            "Ingles"});
            this.cmbLanguages.Location = new System.Drawing.Point(104, 367);
            this.cmbLanguages.Name = "cmbLanguages";
            this.cmbLanguages.Size = new System.Drawing.Size(121, 23);
            this.cmbLanguages.TabIndex = 1;
            // 
            // lblTextPlaceholder
            // 
            this.lblTextPlaceholder.AutoSize = true;
            this.lblTextPlaceholder.Location = new System.Drawing.Point(114, 9);
            this.lblTextPlaceholder.Name = "lblTextPlaceholder";
            this.lblTextPlaceholder.Size = new System.Drawing.Size(93, 15);
            this.lblTextPlaceholder.TabIndex = 2;
            this.lblTextPlaceholder.Text = "Text Placeholder";
            // 
            // btnSizeDemo
            // 
            this.btnSizeDemo.Location = new System.Drawing.Point(12, 53);
            this.btnSizeDemo.Name = "btnSizeDemo";
            this.btnSizeDemo.Size = new System.Drawing.Size(109, 23);
            this.btnSizeDemo.TabIndex = 3;
            this.btnSizeDemo.Text = "btnPlaceHolder";
            this.btnSizeDemo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 450);
            this.Controls.Add(this.btnSizeDemo);
            this.Controls.Add(this.lblTextPlaceholder);
            this.Controls.Add(this.cmbLanguages);
            this.Controls.Add(this.btnChangeLang);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GlobalStrings.Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeLang;
        private System.Windows.Forms.ComboBox cmbLanguages;
        private System.Windows.Forms.Label lblTextPlaceholder;
        private System.Windows.Forms.Button btnSizeDemo;
    }
}

