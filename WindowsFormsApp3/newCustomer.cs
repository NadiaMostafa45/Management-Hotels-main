using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class insert : Form
    {
        Model1 db = new Model1();
        public insert()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            resp r = new resp();
            r.Show();
        }

        private void insert_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();

            if (int.TryParse(textBox2.Text, out int idCustomer))
            {

                c.customerId = idCustomer;
            }


            c.customerName = textBox3.Text;

            if (int.TryParse(textBox4.Text, out int age))
            {
                if (age <= 0)
                    MessageBox.Show(" Age not valid");
                else
                    c.customerAge = age;
            }

            c.customerType = comboBox1.Text;

            if (textBox6.Text.Length == 11)
                c.phone = textBox6.Text;
            else
                MessageBox.Show("wrong phone number");

            if (int.TryParse(textBox7.Text, out int idRoom))
            {
                var newRoom = db.Rooms.SingleOrDefault(r => r.roomId == idRoom);
                if (newRoom != null)
                {
                    c.roomId = idRoom;
                    newRoom.reservationState = "Reserved";
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show(" This room not exist");
                }
            }




            customerRoom cr = new customerRoom();

            if (int.TryParse(textBox2.Text, out int idCustomer2))
            {

                cr.customerId = idCustomer2;
            }

            cr.roomId = idRoom;

            if (DateTime.TryParse(textBox9.Text, out DateTime start))
            {

                DateTime trueDate = DateTime.Today;
                if (start == trueDate)
                    cr.startReservation = start;
                else
                    MessageBox.Show("this is wrong date");
            }


            if (DateTime.TryParse(textBox10.Text, out DateTime end))
            {

                DateTime currentDate = DateTime.Today;
                if (end >= currentDate)
                    cr.finishReservation = end;
                else
                    MessageBox.Show("this is wrong date");
            }

            if (int.TryParse(textBox1.Text, out int durat))
            {

                cr.duration = durat;
            }

            if (cr.duration != null && cr.startReservation != null && cr.finishReservation != null && cr.customerId != null && cr.roomId != null
                && c.customerId != null && c.roomId != null && c.customerAge != null && c.customerName != null && c.customerType != null && c.phone != null)
            {
                db.Customers.Add(c);
                db.customerRooms.Add(cr);
                db.SaveChanges();
                MessageBox.Show("Done Successfully");
            }
            else
            {
                MessageBox.Show("Please inter right data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var emptyRoom = from e_room in db.Rooms
                            where e_room.reservationState == "Available"
                            select new { e_room.roomId, e_room.roomType, e_room.roomSize, e_room.price };
            dataGridView2.DataSource = emptyRoom.ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
