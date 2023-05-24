using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProiectPAWGestiune
{
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbID_p_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\proiectBaza.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void label19_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // verificare daca exista deja aceste produse
                string checkQuery = "SELECT COUNT(*) FROM CategTbl WHERE id_categ=" + tbID_p.Text + " OR nume_categ='" + tbNume_p.Text + "'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                int existingRecordsCount = (int)checkCmd.ExecuteScalar();

                if (existingRecordsCount > 0)
                {
                    MessageBox.Show("Nu se poate. Există deja aceasta categorie de produse!");
                    return;
                }
                // introducere in baza de date
                string query = "INSERT INTO CategTbl VALUES("+tbID_p.Text+",'" + tbNume_p.Text + "','" + tbCantitate_p.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Categoria a fost introdusa cu succes!");

                string query5 = "SELECT * FROM CategTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query5, conn);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridCateg.DataSource = ds.Tables[0];


                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void populareTabel()
        {
            conn.Open();
            string query = "SELECT * FROM CategTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridCateg.DataSource = ds.Tables[0]; 
            conn.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridCateg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridCateg.SelectedRows.Count > 0 && dataGridCateg.SelectedRows[0].Cells.Count > 2)
            {
                tbID_p.Text = dataGridCateg.SelectedRows[0].Cells[0].Value.ToString();
                tbNume_p.Text = dataGridCateg.SelectedRows[0].Cells[1].Value.ToString();
                tbCantitate_p.Text = dataGridCateg.SelectedRows[0].Cells[2].Value.ToString();
            }
            //tbID_p.Text = dataGridCateg.SelectedRows[0].Cells[0].Value.ToString();
            //tbNume_p.Text = dataGridCateg.SelectedRows[0].Cells[1].Value.ToString();
            //tbCantitate_p.Text = dataGridCateg.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            populareTabel();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            // Edit Button
            try
            {   if(tbID_p.Text =="" || tbNume_p.Text=="" || tbCantitate_p.Text=="")
                {
                    MessageBox.Show("Nu se poate realiza actualizarea! (missing information)");
                }
                else
                {
                    conn.Open();
                    string query = "UPDATE CategTbl SET nume_categ='" + tbNume_p.Text + "',desc_categ='" + tbCantitate_p.Text + "' WHERE id_categ=" + tbID_p.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A fost actualizata categoria dorita!");
                    conn.Close();
                    string query2 = "SELECT * FROM CategTbl";
                    SqlDataAdapter sda = new SqlDataAdapter(query2, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridCateg.DataSource = ds.Tables[0];
                    conn.Close();
                    //populareTabel();
                }




            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbID_p.Text == "")
                {
                    MessageBox.Show("Alegeti produsul pe care doriti sa-l stergeti!");
                }
                else
                {
                    conn.Open();
                    string query = "DELETE FROM CategTbl WHERE id_categ=" + tbID_p.Text + "";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoria a fost stearsa cu succes!");
                    string query2 = "SELECT * FROM CategTbl";
                    SqlDataAdapter sda = new SqlDataAdapter(query2, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridCateg.DataSource = ds.Tables[0];
                    conn.Close();
                    populareTabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide(); 
            log.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Seller seller = new Seller();
            seller.Show(); 
            this.Hide();
        }
    }
}
