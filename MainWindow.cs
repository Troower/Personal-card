namespace PersonalCard
{
    public partial class MainWindow : Form
    {
        string connectionString;
        public MainWindow(string connectionString)
        {
            InitializeComponent();
            toolStripStatusLabel3.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripButton5.Text = "Íàñòğîéêè ïîèñêà è\n ãîòîâûå ñïèñêè";
            this.connectionString = connectionString;
        }

        private void çàêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.Black;
        }

        private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)sender).ForeColor = Color.White;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = this.Width * 25 / 100;
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer1.Panel1.Width < 250) splitContainer1.Panel1Collapsed = true;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            new Sections((int a, int b, int c) =>
            {
                tabControl1.SelectTab(a);
                if (b == -1) return;
                if (b == 2) { tabControl2.SelectTab(c); return; }
                if (b == 3) { tabControl3.SelectTab(c); return; }
                if (b == 4) { tabControl4.SelectTab(c); return; }

            }).ShowDialog();

        }


        private void îáùèåÑâåäåíèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);

        }
        private void ñâåäåíèÿÎÂîèíñêîìÓ÷åòåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1); CheckedListBox.CheckForIllegalCrossThreadCalls = true;

        }
        private void ïğèåìÏåğåâîäÍàĞàáîòóToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);

        }
        private void êàäğîâîåĞàçâèòèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);

        }
        private void ëüãîòûÎòïóñêàÈÍàãğàäûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);

        }
        private void äîïîëíèòåëüíûåÑâåäåíèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);

        }
        private void óâîëüíåíèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);

        }




        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            splitContainer5.SplitterDistance = (splitContainer1.Panel1Collapsed ? this.Width - (this.Width * 15 / 100) : this.Width - (this.Width * 15 / 100) - splitContainer1.Panel1.Width);
            splitContainer5.Panel2Collapsed = !splitContainer5.Panel2Collapsed;
        }

        private void splitContainer5_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            splitContainer5.SplitterDistance = (splitContainer1.Panel1Collapsed ? this.Width - (this.Width * 15 / 100) : this.Width - (this.Width * 15 / 100) - splitContainer1.Panel1.Width);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new ListEmployee().ShowDialog();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            EditNavigation();
        }

        private void EditNavigation()
        {
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 0)
            {
                new EditPersonalInfo().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1)
            {
                new Education().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 2)
            {
                new Profesion().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3)
            {
                new Family().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                new Military().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                new HiringTransfer().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 0)
            {
                new Ñertification().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 1)
            {
                new AdvTraining().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 3 && tabControl3.SelectedIndex == 2)
            {
                new ProfTraining().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 0)
            {
                new Award().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 1)
            {
                new Vacation().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 4 && tabControl4.SelectedIndex == 2)
            {
                new Benefit().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 5)
            {
                new Additional().ShowDialog();
                return;
            }
            if (tabControl1.SelectedIndex == 6)
            {
                new Dissmisal().ShowDialog();
                return;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 1 ||
                tabControl1.SelectedIndex == 0 && tabControl2.SelectedIndex == 3 ||
                tabControl1.SelectedIndex == 2 ||
                tabControl1.SelectedIndex == 3 ||
                 tabControl1.SelectedIndex == 4) button12.Visible = true;
            else button12.Visible = false;
        }

        private void óïğàâëåíèåÏîëüçîâàòåëÿìèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Administration().ShowDialog();
        }

        private void îñíîâíàÿÈíôîğìàöèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FAQ().ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new EditPersonalInfo(1).ShowDialog();
        }
    }
}
