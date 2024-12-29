using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace rentalCar
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MyComp\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Chart_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT Available, COUNT(*) AS Count FROM CarTbl GROUP BY Available";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Pie Chart Ayarları
                chart1.Series.Clear();
                chart1.Series.Add("Availability");
                chart1.Series["Availability"].ChartType = SeriesChartType.Pie;

                while (reader.Read())
                {
                    string available = reader["Available"].ToString().ToLower(); // Veriyi küçük harfe dönüştür
                    int count = Convert.ToInt32(reader["Count"]);

                    // Türkçe etiket oluşturma
                    string labelText = available == "yes" ? "Kiralanabilir" : "Kiralandı";

                    // Veri noktası oluşturma ve ekleme
                    DataPoint point = new DataPoint();
                    point.AxisLabel = labelText; // Pie chart üzerinde gösterilecek dilim etiketi
                    point.YValues = new double[] { count }; // Sayıyı ekliyoruz
                    point.Label = $"{labelText}: {count}"; // Dilimde gösterilecek etiket

                    chart1.Series["Availability"].Points.Add(point);
                }

                // Ek Görünüm Ayarları
                chart1.Series["Availability"]["PieLabelStyle"] = "Outside"; // Etiketlerin dışarıda görünmesi
                chart1.Series["Availability"].SmartLabelStyle.Enabled = true;

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
