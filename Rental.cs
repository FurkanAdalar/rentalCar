using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentalCar
{
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30 ");
        private void fillcombo()
        {
            conn.Open();
            string query = "select RegNum from CarTbl where Available = '"+"YES"+"'"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            CarRegCB.ValueMember = "RegNum";
            CarRegCB.DataSource = dt;
            conn.Close();
        }
        private void fillcustomer()
        {
            conn.Open();
            string query = "select CustId from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(string));
            dt.Load(rdr);
            custCB.ValueMember = "CustId";
            custCB.DataSource = dt;
            conn.Close();
        }
        private void fetchCustName()
        {
            conn.Open();
            string query = "select * from CustomerTbl where CustId = "+custCB.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            conn.Close();
        }
        private void populate()
        {
            conn.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentalDVG.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void TelefonTb_TextChanged(object sender, EventArgs e)
        {

        }
        private  void UpdateonRent()
        {
            conn.Open();
            String query = "update CarTbl set Available = '" + "NO" + "' where RegNum = '" + CarRegCB.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Araba Başarıyla Güncellendi");
            conn.Close();
        }
        private void UpdateonRentDelete()
        {
            conn.Open();
            String query = "update CarTbl set Available = '" + "YES" + "' where RegNum = '" + CarRegCB.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Araba Başarıyla Güncellendi");
            conn.Close();
        }
        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillcustomer();
            populate();
        }

        private void CarRegCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void custCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarRegCB_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void custCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || feeTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "insert into RentalTbl values ('" + IdTb.Text + "','" + CarRegCB.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + rentDate.Value.ToString("yyyy-MM-dd") + "','"+ returnDate.Value.ToString("yyyy-MM-dd") + "','"+ feeTb.Text +"')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araba Başarıyla Kiralandı");
                    conn.Close();
                    UpdateonRent();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    conn.Close();
                }
            }
        }

        private void AdresTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
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
                    String query = "delete from RentalTbl where RentId = " + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kiralama Başarıyla Silindi");
                    conn.Close();
                    UpdateonRentDelete();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                    conn.Close();
                }
            }
        }

        private void RentalDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentalDVG.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCB.SelectedValue = RentalDVG.SelectedRows[0].Cells[1].Value.ToString();
            feeTb.Text = RentalDVG.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
