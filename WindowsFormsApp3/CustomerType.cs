using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp3
{
    
    public partial class CustomerType : Form
    {
        Model1 model1=new Model1();
        public CustomerType()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                this.Hide();

                Marketing marketing = new Marketing();
                marketing.Show();

        
    }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dbContext = new Model1();

            var totalCustomers = dbContext.Customers.Count();
            var familyCount = dbContext.Customers.Count(c => c.customerType == "Family");
            var aloneCount = dbContext.Customers.Count(c => c.customerType == "Alone");
            var friendsCount = dbContext.Customers.Count(c => c.customerType == "Friends");

            double familyPercentage = (familyCount / (double)totalCustomers) * 100;
            double alonePercentage = (aloneCount / (double)totalCustomers) * 100;
            double friendsPercentage = (friendsCount / (double)totalCustomers) * 100;
            chart2.Series.Clear();
            Series series = new Series("PercentageSeries");
            series.ChartType = SeriesChartType.Pie;
            series.Points.AddXY("Family", familyPercentage);
            series.Points.AddXY("Alone", alonePercentage);
            series.Points.AddXY("Friends", friendsPercentage);

            chart2.Series.Add(series);
            series.Color = System.Drawing.Color.BlueViolet;
            chart2.ChartAreas["ChartArea1"].AxisX.Title = "Categories";
            chart2.ChartAreas["ChartArea1"].AxisY.Title = "Count";
            chart2.Titles.Add("The number of type customer");

        }
    }
}
