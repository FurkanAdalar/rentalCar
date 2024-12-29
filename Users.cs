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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            conn.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDVG.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || UnameLabel.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "insert into UserTbl values ('" + Uid.Text + "','" + Uname.Text + "','" + Upass.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Eklendi");
                    conn.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "delete from UserTbl where ID = "+Uid.Text+";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi");
                    conn.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void UserDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uid.Text = UserDVG.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = UserDVG.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = UserDVG.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Uid.Text == "" || UnameLabel.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    conn.Open();
                    String query = "update UserTbl set Uname = '"+Uname.Text+"', Upass = '"+Upass.Text+"' where ID = "+Uid.Text+";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Güncellendi");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Uid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Upass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Uname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UnameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
