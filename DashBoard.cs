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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30 ");

        private void DashBoard_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CarLbl.Text = dt.Rows[0][0].ToString();

            string querycust = "select Count(*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            CustLbl.Text = dt1.Rows[0][0].ToString();

            string queryuser = "select Count(*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, conn);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserLbl.Text = dt2.Rows[0][0].ToString();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
