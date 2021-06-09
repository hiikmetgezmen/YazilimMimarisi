
namespace YazılımMimarisi
{
    partial class RaporOluştur
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
            this.cmb_box_patients = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rd_btn_html = new System.Windows.Forms.RadioButton();
            this.rd_btn_json = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_box_patients
            // 
            this.cmb_box_patients.FormattingEnabled = true;
            this.cmb_box_patients.Location = new System.Drawing.Point(44, 48);
            this.cmb_box_patients.Name = "cmb_box_patients";
            this.cmb_box_patients.Size = new System.Drawing.Size(169, 21);
            this.cmb_box_patients.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Rapor Oluştur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hasta Seciniz";
            // 
            // rd_btn_html
            // 
            this.rd_btn_html.AutoSize = true;
            this.rd_btn_html.Location = new System.Drawing.Point(28, 44);
            this.rd_btn_html.Name = "rd_btn_html";
            this.rd_btn_html.Size = new System.Drawing.Size(55, 17);
            this.rd_btn_html.TabIndex = 3;
            this.rd_btn_html.TabStop = true;
            this.rd_btn_html.Text = "HTML";
            this.rd_btn_html.UseVisualStyleBackColor = true;
            // 
            // rd_btn_json
            // 
            this.rd_btn_json.AutoSize = true;
            this.rd_btn_json.Location = new System.Drawing.Point(113, 44);
            this.rd_btn_json.Name = "rd_btn_json";
            this.rd_btn_json.Size = new System.Drawing.Size(53, 17);
            this.rd_btn_json.TabIndex = 3;
            this.rd_btn_json.TabStop = true;
            this.rd_btn_json.Text = "JSON";
            this.rd_btn_json.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd_btn_json);
            this.groupBox1.Controls.Add(this.rd_btn_html);
            this.groupBox1.Location = new System.Drawing.Point(28, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rapor Türü";
            // 
            // RaporOluştur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 253);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb_box_patients);
            this.Name = "RaporOluştur";
            this.Text = "RaporOluştur";
            this.Load += new System.EventHandler(this.RaporOluştur_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_box_patients;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rd_btn_html;
        private System.Windows.Forms.RadioButton rd_btn_json;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}