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
    public partial class room_data : Form
    {
        Model1 db = new Model1();
        public room_data()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login i = new Login();
            i.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Room rooms = new Room();
            //var room = from r in db.Rooms
            //           where r.cleaningState == "dirty"
            //           select r.roomId;
            //dataGridView1.DataSource = rooms;
            var uncleaningRooms = from room in db.Rooms
                                  where !db.staffRooms.Select(uncleaninRoom => uncleaninRoom.roomId).Contains(room.roomId)
                                 && room.cleaningState == "Dirty"
                                  select new { room.roomId };
            dataGridView1.DataSource = uncleaningRooms.ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffRoom cr = new staffRoom();
            if (int.TryParse(textBox1.Text, out int idstaff))
            {
                

                cr.staffId = idstaff;
            }
            if (int.TryParse(textBox2.Text, out int roomId))
            {
                // staffRoom c = new staffRoom();

                cr.roomId = roomId;
            }
            var employeeExist = from em in db.Staffs
                                where em.staffId == idstaff
                             select em;
            var RoomExist = from r in db.Rooms
                                where r.roomId == roomId
                            select r;
            int flag = 0;
            if (employeeExist.Any()&& RoomExist.Any())
            {
                
                    cr.staffId = idstaff;
                    cr.roomId = roomId;
            }
           
            else if (textBox1.Text=="" || textBox2.Text == "")
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
                db.staffRooms.Add(cr);
                db.SaveChanges();
                MessageBox.Show("Done");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Staff rooms = new Staff();
            //var emp = from em in db.Staffs
            //          where em.departmentType == "Room Service" && em.position == "Employee"
            //          select em.staffId;

            //dataGridView2.DataSource = rooms;
            var empTask = from emp in db.Staffs
                          where !db.staffRooms.Select(employee => employee.staffId).Contains(emp.staffId)
                         && emp.departmentType == "Room Service" && emp.position == "Employee"
                          select new { emp.staffId };
              dataGridView2.DataSource = empTask.ToList();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l= new Login();   
            l.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            staffRoom cr = new staffRoom();
            if (int.TryParse(textBox3.Text, out int roomId))
            {
                dataGridView3.Visible = true;
                cr.roomId = roomId;
                var room = from bridge in db.staffRooms
                           join S in db.Staffs
                           on bridge.staffId equals S.staffId
                           where S.position == "Employee" && bridge.roomId == roomId
                           select new { bridge.staffId };
                dataGridView3.DataSource = room.ToList();



            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
