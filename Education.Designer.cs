namespace PersonalCard
{
    partial class Education
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Education));
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            textBox5 = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            tableLayoutPanel1.Location = new Point(0, 406);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(630, 85);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(43, 64, 80);
            button1.BackgroundImage = Properties.Resources.Buttonphon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White;
            button1.Location = new Point(320, 8);
            button1.Margin = new Padding(5, 8, 5, 8);
            button1.Name = "button1";
            button1.Size = new Size(305, 69);
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
            button2.Size = new Size(305, 69);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(comboBox1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(textBox2);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(textBox3);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox6);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(textBox4);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(textBox5);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(630, 406);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Начальное (общее) образование", "Основное общее образование", "Среднее (полное)общее образование", "Начальное профессиональное образование", "Среднее профессиональное образование", "Неполное высшее образование", "Высшее образование", "Послевузовское образование" });
            comboBox1.Location = new Point(4, 4);
            comboBox1.Margin = new Padding(4, 4, 4, 10);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(621, 29);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "Тип образования*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 43);
            label2.Name = "label2";
            label2.Size = new Size(187, 21);
            label2.TabIndex = 11;
            label2.Text = "Наименование док-та*:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(4, 68);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Наименование документа*";
            textBox1.Size = new Size(621, 29);
            textBox1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 101);
            label3.Name = "label3";
            label3.Size = new Size(120, 21);
            label3.TabIndex = 12;
            label3.Text = "Серия док-та*:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(4, 126);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Серия документа*";
            textBox2.Size = new Size(621, 29);
            textBox2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 159);
            label4.Name = "label4";
            label4.Size = new Size(125, 21);
            label4.TabIndex = 13;
            label4.Text = "Номер док-та*:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(4, 184);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Номер документа*";
            textBox3.Size = new Size(621, 29);
            textBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(4, 217);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(130, 23);
            label1.TabIndex = 10;
            label1.Text = "Год окончания*";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(4, 244);
            textBox6.Margin = new Padding(4);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Год окончания*";
            textBox6.Size = new Size(621, 29);
            textBox6.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 277);
            label5.Name = "label5";
            label5.Size = new Size(208, 21);
            label5.TabIndex = 14;
            label5.Text = "Квалификация по док-ту*:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(4, 302);
            textBox4.Margin = new Padding(4);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Квалификация по документу";
            textBox4.Size = new Size(621, 29);
            textBox4.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 335);
            label6.Name = "label6";
            label6.Size = new Size(273, 21);
            label6.TabIndex = 15;
            label6.Text = "Направление или специальность*:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(4, 360);
            textBox5.Margin = new Padding(4);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Направление или специальность*";
            textBox5.Size = new Size(621, 29);
            textBox5.TabIndex = 5;
            // 
            // Education
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(630, 491);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Education";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Образование";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox6;
    }
}