namespace PersonalCard
{
    partial class FAQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAQ));
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            button5 = new Button();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(298, 173);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основная информация";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(292, 145);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(5, 5);
            label1.Margin = new Padding(5);
            label1.Name = "label1";
            label1.Size = new Size(281, 128);
            label1.TabIndex = 1;
            label1.Text = "Разработчик: Арепьев Илья\r\nНачало разработки: 01.04.2025\r\nПоследнее обновление: 07.04.2025\r\nВерсия: 0.01\r\nПочта для обратной связи: Arepiew333@gmail.com";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(43, 64, 80);
            button5.BackgroundImage = Properties.Resources.Buttonphon;
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Dock = DockStyle.Bottom;
            button5.ForeColor = Color.White;
            button5.Location = new Point(0, 173);
            button5.Name = "button5";
            button5.Size = new Size(298, 57);
            button5.TabIndex = 3;
            button5.Text = "Закрыть";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // FAQ
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(43, 64, 80);
            ClientSize = new Size(298, 230);
            Controls.Add(groupBox1);
            Controls.Add(button5);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "FAQ";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FAQ";
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Button button5;
    }
}