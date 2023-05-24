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

namespace ProiectPAWGestiune
{
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\proiectBaza.mdf;Integrated Security=True;Connect Timeout=30");

        private void populareTabel()
        {
            conn.Open();
            string query = "SELECT * FROM VanzatorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewSeller.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void Seller_Load(object sender, EventArgs e)
        {
            populareTabel();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //aici
            if (dataGridViewSeller.SelectedRows.Count > 0 && dataGridViewSeller.SelectedRows[0].Cells.Count > 2)
            {
                sID.Text = dataGridViewSeller.SelectedRows[0].Cells[0].Value.ToString();
                sNume.Text = dataGridViewSeller.SelectedRows[0].Cells[1].Value.ToString();
                sVarsta.Text = dataGridViewSeller.SelectedRows[0].Cells[2].Value.ToString();
                sNrTel.Text = dataGridViewSeller.SelectedRows[0].Cells[3].Value.ToString();
                sParola.Text = dataGridViewSeller.SelectedRows[0].Cells[4].Value.ToString();
            }
            
        }

        private void btLogin_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            // add seller
            try
            {
                conn.Open();

                // verificare daca exista deja aceste produse
                string checkQuery = "SELECT COUNT(*) FROM VanzatorTbl WHERE id_vanzator=" + sID.Text + " OR nume_vanzator='" + sNume.Text + "'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                int existingRecordsCount = (int)checkCmd.ExecuteScalar();

                if (existingRecordsCount > 0)
                {
                    MessageBox.Show("Nu se poate. Există deja acest vanzator!");
                    return;
                }
                // introducere in baza de date
                string query = "INSERT INTO VanzatorTbl VALUES(" + sID.Text + ",'" + sNume.Text + "','" + sVarsta.Text + "','"+ sNrTel.Text +"','"+ sParola + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vanzatorul a fost introdus cu succes!");

                string query5 = "SELECT * FROM VanzatorTbl";
                SqlDataAdapter sda = new SqlDataAdapter(query5, conn);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridViewSeller.DataSource = ds.Tables[0];


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

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tbCantitate_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tbNume_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tbID_p_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            this.Hide();
            s.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Category categ = new Category();
            this.Hide();
            categ.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            this.Hide();
            p.Show();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
