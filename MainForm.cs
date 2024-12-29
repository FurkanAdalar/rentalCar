using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentalCar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental rental = new Rental();
            rental.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return ret = new Return();
            ret.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users users = new Users();
            users.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide() ;
            DashBoard board = new DashBoard();
            board.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chart chart1 = new Chart();
            chart1.Show();
        }
    }
}
