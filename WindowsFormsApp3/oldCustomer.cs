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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Rec : Form
    {
        Model1 contex=new Model1();
        public Rec()
        {
            InitializeComponent();
        }

       

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            resp re = new resp();
            re.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerRoom CR = new customerRoom();

            if (int.TryParse(textBox1.Text, out int idCustomer))
            {

                CR.customerId = idCustomer;
            }

            if (int.TryParse(textBox2.Text, out int idRoom))
            {
                var newRoom = contex.Rooms.SingleOrDefault(r => r.roomId == idRoom);

                if (newRoom != null)
                {
                    CR.roomId = idRoom;
                   newRoom.reservationState = "Reserved";
                    contex.SaveChanges();
                }
                else
                {
                    MessageBox.Show(" This room not exist");
                }

            }

            if (DateTime.TryParse(textBox3.Text, out DateTime start))
            {
                DateTime trueDate = DateTime.Today;
                if (start == trueDate)
                    CR.startReservation = start;
                else
                    MessageBox.Show("this is wrong date");
            }

            if (DateTime.TryParse(textBox4.Text, out DateTime end))
            {
                DateTime currentDate = DateTime.Today;
                if (end >= currentDate)
                    CR.finishReservation = end;
                else
                    MessageBox.Show("this is wrong date");
            }

            if (int.TryParse(textBox5.Text, out int durat))
            {
                CR.duration = durat;
            }
            if (CR.duration == null || CR.startReservation == null || CR.finishReservation == null || CR.customerId == null || CR.roomId == null)
            {
                MessageBox.Show("Please inter right data");
            }
            else
            {
                contex.customerRooms.Add(CR);
                contex.SaveChanges();
                MessageBox.Show("Done Successfully");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var emptyRoom = from e_room in contex.Rooms
                            where e_room.reservationState == "Available"
                            select new { e_room.roomId, e_room.roomType, e_room.roomSize, e_room.price };
            dataGridView2.DataSource = emptyRoom.ToList();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
