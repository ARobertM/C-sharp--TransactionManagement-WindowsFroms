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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        private void populareTabel()
        {
            conn.Open();
            string query = "SELECT * FROM ProdTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\proiectBaza.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillcombo()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT nume_categ FROM CategTbl", conn);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("nume_categ", typeof(string));
            dt.Load(sdr);
            cbProd.ValueMember = "nume_categ";
            cbProd.DataSource = dt;

            conn.Close();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbID_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {
            fillcombo();
            populareTabel();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

           
                // introducere in baza de date
                string query = "INSERT INTO ProdTbl VALUES(" + tbID_prod.Text + ",'" + tbNume_prod.Text + "','" + tbCantitate_prod.Text + "','"+tbPret_prod.Text+"','"+ cbProd.SelectedValue.ToString()+ "')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produsul a fost introdus cu succes!");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                populareTabel();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            s.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbID_prod.Text == "")
                {
                    MessageBox.Show("Alegeti produsul pe care doriti sa-l stergeti!");
                }
                else
                {
                    conn.Open();
                    string query = "DELETE FROM CategTbl WHERE id_categ=" + tbID_prod.Text + "";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoria a fost stearsa cu succes!");
                    string query2 = "SELECT * FROM CategTbl";
                    SqlDataAdapter sda = new SqlDataAdapter(query2, conn);
                    SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();
                    populareTabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                populareTabel();
            }
        }
    }
}
