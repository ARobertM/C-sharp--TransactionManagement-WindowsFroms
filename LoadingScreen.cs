using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectPAWGestiune
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 4; //aici modificat loading screen-ul la 1 sau 4
            pgBar.Value = startpoint;
            if(pgBar.Value == 100)
            {
                pgBar.Value = 0;
                timer1.Stop();
                Form1 log = new Form1();
                this.Hide(); //aici aveam this.Hide();
                log.Show();
                //this.Close();
            }
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
