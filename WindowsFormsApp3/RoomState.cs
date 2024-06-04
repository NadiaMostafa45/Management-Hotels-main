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
    public partial class RoomState : Form
    {

        Model1 context = new Model1();

        public RoomState()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Manager manager = new Main_Manager();
            manager.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            var resevervation = from res in context.Rooms
                                where res.reservationState == "Available"
                                select res.reservationState;

            var resevervation1 = from res in context.Rooms
                                select res.roomId;
            double x = resevervation.Count();
            double x1 = resevervation1.Count();
            double ratio = (x / x1) * 100;

            textBox1.Text = ratio.ToString()+"%";
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            var maintenace = from res in context.Rooms
                                where res.maintenanceState == "False"
                             select res.maintenanceState;

            var resevervation1 = from res in context.Rooms
                                 select res.roomId;
            double x = maintenace.Count();
            double x1 = resevervation1.Count();
            double ratio = (x / x1) * 100;

            textBox2.Text = ratio.ToString() + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Room st = new Room();
            var room = from rm in context.Rooms
                      select new { rm.roomId, rm.roomType, rm.price };
           dataGridView1.DataSource = room.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = (from emp in context.Rooms
                         join dept in context.customerRooms
                         on emp.roomId equals dept.roomId
                         select emp.price * dept.duration).Sum();



            textBox3.Text = query.ToString();
        }

    }
}
