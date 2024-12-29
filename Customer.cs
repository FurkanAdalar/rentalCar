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

namespace rentalCar
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            conn.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDVG.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || İsimTb.Text == "" || AdresTb.Text == "" || TelefonTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "insert into CustomerTbl values ('" + IdTb.Text + "','" + İsimTb.Text + "','" + AdresTb.Text + "','" + TelefonTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Eklendi");
                    conn.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    conn.Close();
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "delete from CustomerTbl where CustId = " + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Silindi");
                    conn.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    conn.Close();
                }
            }
        }

        private void CustomerDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomerDVG.SelectedRows[0].Cells[0].Value.ToString();
            İsimTb.Text = CustomerDVG.SelectedRows[0].Cells[1].Value.ToString();
            AdresTb.Text = CustomerDVG.SelectedRows[0].Cells[2].Value.ToString();
            TelefonTb.Text = CustomerDVG.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || İsimTb.Text == "" || AdresTb.Text == "" || TelefonTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "update CustomerTbl set CustName = '" + İsimTb.Text + "', CustAdd = '" + AdresTb.Text + "', Phone = '" + TelefonTb.Text + "' where CustId = '" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Güncellendi");
                    conn.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
}
