using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentalCar
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            conn.Open();
            string query = "select * from CarTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDVG.DataSource = ds.Tables[0];
            conn.Close();
        }


        private void Uid_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (RegNoTb.Text == "" || MarkaTb.Text == "" || ModelTb.Text == "" || FiyatTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "insert into CarTbl values ('" + RegNoTb.Text + "','" + MarkaTb.Text + "','" + ModelTb.Text + "','"+AvailableCB.SelectedItem.ToString()+"','" + FiyatTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araba Başarıyla Eklendi");
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
        private void Car_Load(object sender, EventArgs e)
        {
            populate();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (RegNoTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "delete from CarTbl where RegNum = '" + RegNoTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Başarıyla Silindi");
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

        private void CarsDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNoTb.Text = CarsDVG.SelectedRows[0].Cells[0].Value.ToString();
            MarkaTb.Text = CarsDVG.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarsDVG.SelectedRows[0].Cells[2].Value.ToString();
            FiyatTb.Text = CarsDVG.SelectedRows[0].Cells[4].Value.ToString();
            AvailableCB.SelectedItem = CarsDVG.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (RegNoTb.Text == "" || MarkaTb.Text == "" || ModelTb.Text == "" || FiyatTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "update CarTbl set Brand = '" + MarkaTb.Text + "', Model = '" + ModelTb.Text + "', Available = '"+AvailableCB.SelectedItem.ToString()+"',Price = '"+FiyatTb.Text+"' where RegNum = '" + RegNoTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araba Başarıyla Güncellendi");
                    conn.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string flag = "";
            if(Search.SelectedItem.ToString() == "Available")
            {
                flag = "Yes";
            }
            else
            {
                flag = "No";
            }
            conn.Open();
            string query = "select * from CarTbl where Available = '"+ flag +"'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDVG.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
