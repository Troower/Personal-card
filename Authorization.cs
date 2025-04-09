﻿using PersonalCard.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalCard
{
    public partial class Authorization : Form
    {
        public Authorization()
        {

            InitializeComponent();
            ConfigConnection cc=ConfigReader.ReadConfig();
            MessageBox.Show(cc.Database+cc.Uid);
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
