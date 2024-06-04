using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class resp : Form
    {
        Model1 context = new Model1();
        public resp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int idCustomer))
            {
                Customer c = new Customer();

                c.customerId = idCustomer;
            }
            var customerExist = from customer in context.Customers
                                where customer.customerId == idCustomer
                                select customer;
            if (customerExist.Any())
            {

                MessageBox.Show("This Is Old Customer");
            }
            else
            {
                MessageBox.Show("This Is New Customer");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rec rec = new Rec();
            rec.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            insert i=new insert();
            i.Show();   
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


       
        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int idRoom))
            {
                Room c = new Room();

                c.roomId = idRoom;
            }
            var checkOut = context.Rooms.SingleOrDefault(r => r.roomId == idRoom);
            if (checkOut != null)
            {
                checkOut.reservationState = "Available";
                context.SaveChanges();
                MessageBox.Show("Done Successfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
