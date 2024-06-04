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
    public partial class Form5 : Form
    {
        Model1 c = new Model1();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room rooms = new Room();
            var room = from r in c.Rooms
                       where r.maintenanceState == "False"

                       select new { r.roomId };

            dataGridView1.DataSource = room.ToList();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Staff rooms = new Staff();
            var emp = from em in c.Staffs
                      where em.departmentType == "Maintenance" && em.position == "Employee"

                      select new { em.staffId };

            dataGridView2.DataSource = emp.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffRoom cr = new staffRoom();
            if (int.TryParse(textBox1.Text, out int employeId))
            {


                cr.staffId = employeId;
            }



            if (int.TryParse(textBox2.Text, out int roomId))
            {
                // staffRoom c = new staffRoom();

                var newRoom = c.Rooms.SingleOrDefault(r => r.roomId == roomId);
                if (newRoom != null)
                {
                    cr.roomId = roomId;
                    newRoom.maintenanceState = "True";
                    c.SaveChanges();
                }
                else
                {
                    MessageBox.Show(" This room not exist");
                }
            }
           
            var employeeExist = from em in c.Staffs
                                where em.staffId == employeId
                                select em;
            var RoomExist = from r in c.Rooms
                            where r.roomId == roomId
                            select r;
            int flag = 0;
            if (employeeExist.Any() && RoomExist.Any())
            {

                cr.staffId = employeId;
                cr.roomId = roomId;
            }

            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                flag = 1;
                MessageBox.Show("Please Enter Complete required Data");
            }
            else
            {
                flag = 1;

                MessageBox.Show("Data not vaild");
            }

            if (flag == 0)
            {
                c.staffRooms.Add(cr);
                c.SaveChanges();
                MessageBox.Show("Done");
            }


           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            staffRoom cr = new staffRoom();
            if (int.TryParse(textBox3.Text, out int roomId))
            {
                dataGridView3.Visible = true;
                cr.roomId = roomId;
                var room = from bridge in c.staffRooms
                           join S in c.Staffs
                           on bridge.staffId equals S.staffId
                           where S.position == "Employee" && bridge.roomId == roomId
                           select new { bridge.staffId };
                dataGridView3.DataSource = room.ToList();
            }
        }
    }
}
