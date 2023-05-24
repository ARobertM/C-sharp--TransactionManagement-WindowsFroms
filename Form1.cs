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
using System.Diagnostics.Eventing.Reader;

namespace ProiectPAWGestiune
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {           
            Application.Exit();
        }

        private void btClear(object sender, EventArgs e)
        {
            tbPassword.Clear();
            tbUsername.Clear();
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Vă rog, introduceți datele!");
                errorProvider1.SetError(tbUsername, "Pentru a va loga in contul de admin folositi contul ADMIN cu urmatoarele date : admin, admin!");
            }
            else
            {
                if (cbRol.SelectedItem.ToString() == "ADMIN")
                {
                    if (tbUsername.Text == "admin" && tbPassword.Text == "admin")
                    {
                        Category c = new Category();
                        c.Show();
                        this.Hide();
                    }
                }
            }
            if(cbRol.SelectedItem.ToString() == "SELLER")
            {
                MessageBox.Show("Esti logat ca seller!");
                SellerForm sf = new SellerForm();
                sf.Show();
                this.Hide();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reviews r = new Reviews();
            r.Show();
        }
    }
}
