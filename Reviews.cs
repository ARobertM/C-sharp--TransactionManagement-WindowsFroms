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
    public partial class Reviews : Form
    {
        public Reviews()
        {
            InitializeComponent();
        }

        private void schimbareCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                //this.BackColor = dlg.Color;
                contextMenuStrip1.SourceControl.BackColor = dlg.Color;
        }

        private void Reviews_Load(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int nota = Convert.ToInt32(cbNota.Text);
        //        string descriere = tbReview.Text;

        //        MessageBox.Show("Feedback-ul a fost adaugat cu succes!");
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        tbReview.Clear();
        //        cbNota.Text = "";
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            //this.chart1.Series["Nota"].Points.AddXY(" ", cbNota);
            //this.chart1.Series[0].Points.AddXY(cbNota.Text);
            int nota = Convert.ToInt32(cbNota.Text);
            chart1.Series[0].Points.AddY(nota);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReviewText rt = new ReviewText();
            rt.textBox1.Text += tbReview.Text.ToString()+ "\n";
            rt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {     
                string descriere = tbReview.Text;
                MessageBox.Show("Feedback-ul a fost adaugat cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tbReview.Clear();
                cbNota.Text = "";
            }
        }
    }
}
