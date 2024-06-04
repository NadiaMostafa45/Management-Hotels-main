using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class RoomCategory : Form
    {
        Model1 model1 = new Model1();
        public RoomCategory()
        {
            InitializeComponent();
        }

        private void RoomCategory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dbContext = new Model1();

            var totalRoom = dbContext.Customers.Count();
            var tripleRoomCount = dbContext.Rooms.Count(c => c.roomSize == "triple");
            var SingleRoomCount = dbContext.Rooms.Count(c => c.roomSize == "Single");
            var doubleRoomCount = dbContext.Rooms.Count(c => c.roomSize == "double");
       
            double tripleRoomPercentage = (tripleRoomCount / (double)totalRoom) * 100;
            double SingleRoomPercentage = (SingleRoomCount / (double)totalRoom) *100;
            double doubleRoomPercentage = (doubleRoomCount / (double)totalRoom) *100;
            
            chart1.Series.Clear();
            Series series = new Series("PercentageSeries");
            series.ChartType = SeriesChartType.Pie;
            series.Points.AddXY("SingleRoom", SingleRoomPercentage);
            series.Points.AddXY("doubleRoom", doubleRoomPercentage);
            series.Points.AddXY("tripleRoom", tripleRoomPercentage);
          
            chart1.Series.Add(series);
            series.Color = System.Drawing.Color.BlueViolet;
         
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Categories";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Count";
            chart1.Titles.Add("The number of each room type booked ");



        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                this.Hide();

                Marketing marketing = new Marketing();
                marketing.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
