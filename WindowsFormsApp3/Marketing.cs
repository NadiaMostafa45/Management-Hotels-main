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

namespace WindowsFormsApp3
{
    public partial class Marketing : Form
    {
        Model1 mo=new Model1();
        public Marketing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RoomCategory roomCategory = new RoomCategory();
            roomCategory.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Staff staffs = new Staff();
            if (int.TryParse(textBox1.Text, out int idstaff))
            {


                staffs.staffId = idstaff;
            }
            var employeeExist = from em in mo.Staffs
                                where em.staffId == idstaff
                                select em;
            if (textBox1.Text == "")
            {
                MessageBox.Show(" Please Enter Your ID");
            }
            else if (textBox1.Text == "2345")
            {
                this.Hide();
                Main_Manager manager = new Main_Manager();
                manager.Show();
            }
            else if (employeeExist.Any())
            {

                this.Hide();
                Login login = new Login();
                login.Show();


            }
            else
            {
                MessageBox.Show(" Please Enter vaild Data");
            }


           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerType customerType = new CustomerType(); 
            customerType.Show();
        }

        private void Marketing_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
