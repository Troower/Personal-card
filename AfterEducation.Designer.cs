namespace PersonalCard
{
    partial class AfterEducation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AfterEducation));
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            textBox6 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label6 = new Label();
            textBox5 = new TextBox();
            textBox7 = new TextBox();
            label7 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 448);
            tableLayoutPanel1.Margin = new Padding(6, 8, 6, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(588, 78);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(43, 64, 80);
            button1.BackgroundImage = Properties.Resources.Buttonphon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White;
            button1.Location = new Point(300, 11);
            button1.Margin = new Padding(6, 11, 6, 11);
            button1.Name = "button1";
            button1.Size = new Size(282, 56);
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
            button2.Location = new Point(6, 11);
            button2.Margin = new Padding(6, 11, 6, 11);
            button2.Name = "button2";
            button2.Size = new Size(282, 56);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Аспирантура", "Адъюнктура", "Докторантура" });
            comboBox1.Location = new Point(6, 15);
            comboBox1.Margin = new Padding(5, 6, 5, 14);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(576, 29);
            comboBox1.TabIndex = 7;
            comboBox1.Text = "Тип образования*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 134);
            label2.Name = "label2";
            label2.Size = new Size(187, 21);
            label2.TabIndex = 12;
            label2.Text = "Наименование док-та*:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 159);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Наименование документа*";
            textBox1.Size = new Size(576, 29);
            textBox1.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 201);
            label4.Name = "label4";
            label4.Size = new Size(125, 21);
            label4.TabIndex = 14;
            label4.Text = "Номер док-та*:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 226);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Номер документа*";
            textBox3.Size = new Size(576, 29);
            textBox3.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 324);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 21);
            label1.TabIndex = 16;
            label1.Text = "Год окончания*";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(6, 349);
            textBox6.Margin = new Padding(4);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Год окончания*";
            textBox6.Size = new Size(576, 29);
            textBox6.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(6, 283);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(210, 29);
            dateTimePicker1.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 259);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(161, 21);
            label3.TabIndex = 19;
            label3.Text = "Дата выдачи док-та:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 390);
            label6.Name = "label6";
            label6.Size = new Size(273, 21);
            label6.TabIndex = 20;
            label6.Text = "Направление или специальность*:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 415);
            textBox5.Margin = new Padding(4);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Направление или специальность*";
            textBox5.Size = new Size(576, 29);
            textBox5.TabIndex = 21;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(6, 92);
            textBox7.Margin = new Padding(4);
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "Наименование обр. учреждения*:";
            textBox7.Size = new Size(576, 29);
            textBox7.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 67);
            label7.Name = "label7";
            label7.Size = new Size(272, 21);
            label7.TabIndex = 23;
            label7.Text = "Наименование обр. учреждения*:";
            // 
            // AfterEducation
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(588, 526);
            Controls.Add(label7);
            Controls.Add(textBox7);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox6);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "AfterEducation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AfterEducation";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox6;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label6;
        private TextBox textBox5;
        private TextBox textBox7;
        private Label label7;
    }
}