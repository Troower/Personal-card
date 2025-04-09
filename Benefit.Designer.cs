namespace PersonalCard
{
    partial class Benefit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Benefit));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 37);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Наименование льготы";
            textBox1.Size = new Size(265, 29);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 110);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Номер документа";
            textBox2.Size = new Size(265, 29);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 240);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Основание";
            textBox3.Size = new Size(265, 29);
            textBox3.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(11, 181);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(265, 29);
            dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(12, 147);
            label1.Margin = new Padding(5);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 13;
            label1.Text = "Дата документа:";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 278);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(288, 56);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(43, 64, 80);
            button1.BackgroundImage = Properties.Resources.Buttonphon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White;
            button1.Location = new Point(149, 8);
            button1.Margin = new Padding(5, 8, 5, 8);
            button1.Name = "button1";
            button1.Size = new Size(134, 40);
            button1.TabIndex = 5;
            button1.Text = "Редактировать";
            button1.UseVisualStyleBackColor = false;
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
            button2.Size = new Size(134, 40);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(188, 21);
            label2.TabIndex = 21;
            label2.Text = "Наименование льготы*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 86);
            label3.Name = "label3";
            label3.Size = new Size(216, 21);
            label3.TabIndex = 22;
            label3.Text = "Наименование документа*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 213);
            label4.Name = "label4";
            label4.Size = new Size(94, 21);
            label4.TabIndex = 23;
            label4.Text = "Основание";
            // 
            // Benefit
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(288, 334);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Benefit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Benefit";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}