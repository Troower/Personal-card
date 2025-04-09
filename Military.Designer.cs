namespace PersonalCard
{
    partial class Military
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Military));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            comboBox1 = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 24);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Категория запаса";
            textBox1.Size = new Size(618, 29);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 80);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Воинское звание*";
            textBox2.Size = new Size(618, 29);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 136);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Состав(Профиль)";
            textBox3.Size = new Size(618, 29);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(3, 360);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Кодовое значение ВУС*";
            textBox4.Size = new Size(618, 29);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(3, 192);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Категория годности*";
            textBox5.Size = new Size(618, 29);
            textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(3, 304);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Наименование вон. ком. по месту жительства*";
            textBox6.Size = new Size(618, 29);
            textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(3, 248);
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "Дополнительная информация к типу воинского учета";
            textBox7.Size = new Size(618, 29);
            textBox7.TabIndex = 6;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(3, 451);
            textBox8.Name = "textBox8";
            textBox8.PlaceholderText = "Отметка о снятии с воинского учета";
            textBox8.Size = new Size(618, 29);
            textBox8.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Общий", "Специальный" });
            comboBox1.Location = new Point(3, 395);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(618, 29);
            comboBox1.TabIndex = 8;
            comboBox1.Text = "Тип воинского учета";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 486);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(627, 63);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(43, 64, 80);
            button1.BackgroundImage = Properties.Resources.Buttonphon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.White;
            button1.Location = new Point(318, 8);
            button1.Margin = new Padding(5, 8, 5, 8);
            button1.Name = "button1";
            button1.Size = new Size(304, 47);
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
            button2.Size = new Size(303, 47);
            button2.TabIndex = 4;
            button2.Text = "Отмена";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(textBox2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(textBox3);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(textBox5);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(textBox7);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(textBox6);
            flowLayoutPanel1.Controls.Add(label7);
            flowLayoutPanel1.Controls.Add(textBox4);
            flowLayoutPanel1.Controls.Add(comboBox1);
            flowLayoutPanel1.Controls.Add(label8);
            flowLayoutPanel1.Controls.Add(textBox8);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(627, 486);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(145, 21);
            label1.TabIndex = 9;
            label1.Text = "Категория запаса:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 56);
            label2.Name = "label2";
            label2.Size = new Size(151, 21);
            label2.TabIndex = 10;
            label2.Text = "Воинское звание*:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 112);
            label3.Name = "label3";
            label3.Size = new Size(147, 21);
            label3.TabIndex = 11;
            label3.Text = "Состав(Профиль):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 168);
            label4.Name = "label4";
            label4.Size = new Size(173, 21);
            label4.TabIndex = 12;
            label4.Text = "Категория годности*:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 224);
            label5.Name = "label5";
            label5.Size = new Size(328, 21);
            label5.TabIndex = 13;
            label5.Text = "Доп информация к типу воинского учета:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 280);
            label6.Name = "label6";
            label6.Size = new Size(369, 21);
            label6.TabIndex = 14;
            label6.Text = "Наименование вон. ком. по месту жительства*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 336);
            label7.Name = "label7";
            label7.Size = new Size(191, 21);
            label7.TabIndex = 15;
            label7.Text = "Кодовое значение ВУС*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 427);
            label8.Name = "label8";
            label8.Size = new Size(285, 21);
            label8.TabIndex = 16;
            label8.Text = "Отметка о снятии с воинского учета";
            // 
            // Military
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(627, 549);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Military";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Military";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private ComboBox comboBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}