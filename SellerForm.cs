using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace ProiectPAWGestiune
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }


        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\proiectBaza.mdf;Integrated Security=True;Connect Timeout=30");

        private void populareTabel()
        {
            conn.Open();
            string query = "SELECT nume_prod,cant_prod FROM ProdTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewSeller1.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void SellerForm_Load(object sender, EventArgs e)
        {
            populareTabel();
            populareTabel3();
        }

        private void dataGridViewSeller1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datalbl.Text = DateTime.Today.Day.ToString()+"/"+DateTime.Today.Month.ToString()+"/"+DateTime.Today.Year;
            //Oralbl.Text = Datalbl.Text = DateTime.Now.ToString();
        }

        private void Oralbl_Click(object sender, EventArgs e)
        {

        }

        private void Datalbl_Click(object sender, EventArgs e)
        {

        }
        // initializat global pentru a realiza suma totala
        int GrdT = 0;
        int n = 0;
        private void label13_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(tb_Pretp.Text) * Convert.ToInt32(tb_Cantitateap.Text);
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridView2);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = tb_Numep.Text;
            newRow.Cells[2].Value = tb_Pretp.Text;
            newRow.Cells[3].Value = tb_Cantitateap.Text;
            newRow.Cells[4].Value = Convert.ToInt32(tb_Pretp.Text)*Convert.ToInt32(tb_Cantitateap.Text);
            dataGridView2.Rows.Add(newRow);
            GrdT += total;
            lbl_Suma.Text = "" + GrdT;
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Show();
        }

        private void populareTabel3()
        {
            conn.Open();
            string query = "SELECT * FROM FormularPrintat";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void label21_Click(object sender, EventArgs e)
        {
            // add - pentru formularul printat
            try
            {
                conn.Open();


                // introducere in baza de date
                string query = "INSERT INTO FormularPrintat VALUES(" + tbID_p.Text + ",'" + Datalbl.Text + "'," + lbl_Suma.Text + ",'" + tb_Numep.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tranzactia a fost introdusa cu succes!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu a reusit introducerea in tabel!");
            }
            finally
            {
                conn.Close();
                populareTabel3();
            }
        }

        private void lbl_Suma_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            // PRINT
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }  
         
            
            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Alexandru Robert-Mihai", new Font("Berlin Sans FB", 15, FontStyle.Italic),Brushes.DarkOrange, new Point(230));
            e.Graphics.DrawString("GESTIUNEA TRANZACTIILOR", new Font("Berlin Sans FB", 25, FontStyle.Italic), Brushes.OrangeRed, new Point(230,50));

           


            e.Graphics.DrawString("ID-ul Tranzactiei: " + dataGridView3.Rows[0].Cells[0].Value.ToString(), 
                new Font("Berlin Sans FB", 15, FontStyle.Regular), Brushes.OrangeRed, new Point(70, 70));


        }
    }
}


