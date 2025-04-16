namespace PersonalCard
{
    partial class AdvTraining
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvTraining));
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker3 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(14, 43);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 29);
            dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(220, 43);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 29);
            dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(14, 416);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(200, 29);
            dateTimePicker3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(14, 12);
            label1.Margin = new Padding(5);
            label1.Name = "label1";
            label1.Size = new Size(149, 23);
            label1.TabIndex = 6;
            label1.Text = "Начало обучения:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(220, 12);
            label2.Margin = new Padding(5);
            label2.Name = "label2";
            label2.Size = new Size(141, 23);
            label2.TabIndex = 7;
            label2.Text = "Конец обучения:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 385);
            label3.Margin = new Padding(5);
            label3.Name = "label3";
            label3.Size = new Size(133, 21);
            label3.TabIndex = 8;
            label3.Text = "Дата документа:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 112);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Вид повышения квалификации";
            textBox1.Size = new Size(406, 29);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 180);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Наименования образовательного учреждения";
            textBox2.Size = new Size(406, 29);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(14, 236);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Наименование документа";
            textBox3.Size = new Size(406, 29);
            textBox3.TabIndex = 11;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(14, 292);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Серия  документа";
            textBox4.Size = new Size(406, 29);
            textBox4.TabIndex = 12;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(15, 472);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Основание";
            textBox5.Size = new Size(406, 29);
            textBox5.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 509);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(429, 56);
            tableLayoutPanel1.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(43, 64, 80);
            button1.BackgroundImage = Properties.Resources.Buttonphon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White;
            button1.Location = new Point(219, 8);
            button1.Margin = new Padding(5, 8, 5, 8);
            button1.Name = "button1";
            button1.Size = new Size(205, 40);
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
            button2.Size = new Size(204, 40);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 84);
            label4.Name = "label4";
            label4.Size = new Size(260, 21);
            label4.TabIndex = 15;
            label4.Text = "Вид повышения квалификации*:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 156);
            label5.Name = "label5";
            label5.Size = new Size(272, 21);
            label5.TabIndex = 16;
            label5.Text = "Наименование обр. учреждения*:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 212);
            label6.Name = "label6";
            label6.Size = new Size(220, 21);
            label6.TabIndex = 17;
            label6.Text = "Наименование документа*:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 268);
            label7.Name = "label7";
            label7.Size = new Size(153, 21);
            label7.TabIndex = 18;
            label7.Text = "Серия документа*:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 448);
            label8.Name = "label8";
            label8.Size = new Size(105, 21);
            label8.TabIndex = 19;
            label8.Text = "Основание*:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(14, 348);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Номер документа";
            textBox6.Size = new Size(406, 29);
            textBox6.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 324);
            label9.Name = "label9";
            label9.Size = new Size(158, 21);
            label9.TabIndex = 21;
            label9.Text = "Номер документа*:";
            // 
            // AdvTraining
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(429, 565);
            Controls.Add(label9);
            Controls.Add(textBox6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker3);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "AdvTraining";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdvTraining";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox6;
        private Label label9;
    }
}