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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");
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
        private void populateRet()
        {
            conn.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDVG.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void deleteOneReturn()
        {
            int rentId;
            rentId = Convert.ToInt32(RentalDVG.SelectedRows[0].Cells[0].Value.ToString());
            conn.Open();
            String query = "delete from RentalTbl where RentId = " + rentId + ";";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Kiralama Başarıyla Silindi");
            conn.Close();
            //UpdateonRentDelete();
            populate();
        }
        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populateRet();
        }

        private void RentalDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            carIdTb.Text = RentalDVG.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentalDVG.SelectedRows[0].Cells[2].Value.ToString();
            returnDate.Text = RentalDVG.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = returnDate.Value.Date;
            DateTime d2 = DateTime.Now;
            TimeSpan t = d2 - d1;
            int NrOfDays = Convert.ToInt32(t.TotalDays);
            if (NrOfDays <= 0)
            {
                delayTb.Text = "No Delay";
                fineTb.Text = "0";
            }
            else
            {
                delayTb.Text = "" + NrOfDays;
                fineTb.Text = "" + (NrOfDays * 250);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || fineTb.Text == "" || delayTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "insert into ReturnTbl values ('" + IdTb.Text + "','" + carIdTb.Text + "','" + CustNameTb.Text + "','" + returnDate.Value.ToString("yyyy-MM-dd") + "','" + delayTb.Text + "','" + fineTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araba Başarıyla Geri Alındı");
                    conn.Close();
                    //UpdateonRent();
                    populateRet();
                    deleteOneReturn();
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

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
