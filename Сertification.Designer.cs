﻿namespace PersonalCard
{
    partial class Сertification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Сertification));
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 113);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Решение комиссии";
            textBox2.Size = new Size(399, 29);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 188);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Номер документа";
            textBox3.Size = new Size(399, 29);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 356);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Основание";
            textBox4.Size = new Size(399, 29);
            textBox4.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(12, 14);
            label1.Margin = new Padding(5);
            label1.Name = "label1";
            label1.Size = new Size(139, 23);
            label1.TabIndex = 5;
            label1.Text = "Дата аттестации:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(12, 246);
            label2.Margin = new Padding(5);
            label2.Name = "label2";
            label2.Size = new Size(135, 23);
            label2.TabIndex = 6;
            label2.Text = "Дата документа:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 29);
            dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(12, 277);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 29);
            dateTimePicker2.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 390);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(416, 56);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(43, 64, 80);
            button1.BackgroundImage = Properties.Resources.Buttonphon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White;
            button1.Location = new Point(213, 8);
            button1.Margin = new Padding(5, 8, 5, 8);
            button1.Name = "button1";
            button1.Size = new Size(198, 40);
            button1.TabIndex = 5;
            button1.Text = "Редактировать";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(43, 64, 80);
            button2.BackgroundImage = Properties.Resources.Buttonphon;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Dock = DockStyle.Fill;
            button2.ForeColor = Color.White;
            button2.Location = new Point(5, 8);
            button2.Margin = new Padding(5, 8, 5, 8);
            button2.Name = "button2";
            button2.Size = new Size(198, 40);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 89);
            label3.Name = "label3";
            label3.Size = new Size(168, 21);
            label3.TabIndex = 12;
            label3.Text = "Решение комиссии*:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 164);
            label4.Name = "label4";
            label4.Size = new Size(158, 21);
            label4.TabIndex = 13;
            label4.Text = "Номер документа*:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 332);
            label5.Name = "label5";
            label5.Size = new Size(105, 21);
            label5.TabIndex = 14;
            label5.Text = "Основание*:";
            // 
            // Сertification
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(416, 446);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Сertification";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Аттестация";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}