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

namespace rentalCar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "select count (*) from UserTbl where Uname= '" + Uname.Text + "' and Upass= '" + PassTb.Text + "'";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlis kullanici adi veya sifre!");
            }
            conn.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            PassTb.Text = "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
