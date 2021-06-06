
namespace YazılımMimarisi
{
    partial class DiyetYöntemiEkle
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbox_name = new System.Windows.Forms.TextBox();
            this.txtbox_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbox_food = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_box_food = new System.Windows.Forms.ListBox();
            this.bttn_add_food = new System.Windows.Forms.Button();
            this.cmb_box_foods = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Diyet Yöntemi Adı";
            // 
            // txtbox_name
            // 
            this.txtbox_name.Location = new System.Drawing.Point(59, 61);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(211, 20);
            this.txtbox_name.TabIndex = 3;
            // 
            // txtbox_description
            // 
            this.txtbox_description.Location = new System.Drawing.Point(59, 113);
            this.txtbox_description.Name = "txtbox_description";
            this.txtbox_description.Size = new System.Drawing.Size(211, 20);
            this.txtbox_description.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Açıklama";
            // 
            // txtbox_food
            // 
            this.txtbox_food.Location = new System.Drawing.Point(59, 210);
            this.txtbox_food.Name = "txtbox_food";
            this.txtbox_food.Size = new System.Drawing.Size(130, 20);
            this.txtbox_food.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Farklı Yemek";
            // 
            // lst_box_food
            // 
            this.lst_box_food.FormattingEnabled = true;
            this.lst_box_food.Location = new System.Drawing.Point(59, 245);
            this.lst_box_food.Name = "lst_box_food";
            this.lst_box_food.Size = new System.Drawing.Size(211, 95);
            this.lst_box_food.TabIndex = 8;
            // 
            // bttn_add_food
            // 
            this.bttn_add_food.Location = new System.Drawing.Point(195, 207);
            this.bttn_add_food.Name = "bttn_add_food";
            this.bttn_add_food.Size = new System.Drawing.Size(75, 23);
            this.bttn_add_food.TabIndex = 9;
            this.bttn_add_food.Text = "Listeye Ekle";
            this.bttn_add_food.UseVisualStyleBackColor = true;
            this.bttn_add_food.Click += new System.EventHandler(this.bttn_add_food_Click);
            // 
            // cmb_box_foods
            // 
            this.cmb_box_foods.Enabled = false;
            this.cmb_box_foods.FormattingEnabled = true;
            this.cmb_box_foods.Location = new System.Drawing.Point(59, 160);
            this.cmb_box_foods.Name = "cmb_box_foods";
            this.cmb_box_foods.Size = new System.Drawing.Size(211, 21);
            this.cmb_box_foods.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(56, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Yemek Listesi";
            // 
            // DiyetYöntemiEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 395);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_box_foods);
            this.Controls.Add(this.bttn_add_food);
            this.Controls.Add(this.lst_box_food);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbox_food);
            this.Controls.Add(this.txtbox_description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DiyetYöntemiEkle";
            this.Text = "DiyetYöntemiEkle";
            this.Load += new System.EventHandler(this.DiyetYöntemiEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_name;
        private System.Windows.Forms.TextBox txtbox_description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbox_food;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_box_food;
        private System.Windows.Forms.Button bttn_add_food;
        private System.Windows.Forms.ComboBox cmb_box_foods;
        private System.Windows.Forms.Label label4;
    }
}