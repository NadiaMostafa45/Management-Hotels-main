using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Stafff : Form
    {
        Model1 db = new Model1();
        public Stafff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            staffRoom cr = new staffRoom();
            if (int.TryParse(textBox1.Text, out int idstaff))
            {


                cr.staffId = idstaff;
            }
            var employeeExist = from em in db.Staffs
                                where em.staffId == idstaff
                                select em;
            
            int flag = 0;
            if (employeeExist.Any())
            {

                if (int.TryParse(textBox1.Text, out int intValue))
                {
                    cr.staffId = intValue;
                }

                var task = from tasks in db.staffRooms
                           where tasks.staffId == intValue
                           select new { tasks.roomId };
                dataGridView1.DataSource = task.ToList();

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show(" Please Enter Your ID");
            }
             
            else
            {
                MessageBox.Show("Data not vaild");
            }
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            staffRoom cr = new staffRoom();
            if (int.TryParse(textBox2.Text, out int roomId))
            {
                // staffRoom c = new staffRoom();

                cr.roomId = roomId;
            }
       
            var RoomExist = from r in db.Rooms
                            where r.roomId == roomId
                            select r;
            int flag = 0;
            if (RoomExist.Any())
            {  if (this.textBox1.Text != "" && this.textBox2.Text != "")
                {
                    if (int.TryParse(textBox2.Text, out int idRoom))
                    {
                        var complete = db.Rooms.SingleOrDefault(r => r.roomId == idRoom);
                        if (complete != null)
                        {
                            complete.cleaningState = "Clean";
                            db.SaveChanges();

                            if (int.TryParse(textBox1.Text, out int idsttaf))
                            {
                                cr.staffId = idsttaf;

                                var CompleteTask = db.staffRooms.FirstOrDefault(task => task.staffId == idsttaf && task.roomId == idRoom);
                                if (CompleteTask != null)
                                {
                                    db.staffRooms.Remove(CompleteTask);
                                    db.SaveChanges();
                                    MessageBox.Show(" Done ");
                                }
                                else
                                    MessageBox.Show("This room aleardy confirmed");
                            }





                        }

                        else
                        {
                            MessageBox.Show(" This room not exist");
                        }
                    }
                    }
                    else
                        MessageBox.Show("ID is needed");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show(" Please Enter Room ID");
            }
            else
            {
                MessageBox.Show("Data not vaild");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
