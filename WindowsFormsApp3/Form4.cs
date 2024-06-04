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
    public partial class Form4 : Form
    {
        Model1 dc=new Model1();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="")
            {
                MessageBox.Show(" Please Enter Your ID");
            }
            else
            {
                if (int.TryParse(textBox1.Text, out int employeId))
                {
                    staffRoom c = new staffRoom();

                    c.staffId = employeId;
                }

                var mytask = from t in dc.staffRooms
                             where t.staffId == employeId

                             select new { t.roomId };
                dataGridView1.DataSource = mytask.ToList();
                //foreach (var j in mytask) {
                //    listBox1.Items.Add(j);    
                //}
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Model1 db=new Model1();
            if (textBox2.Text == "")
            {
                MessageBox.Show(" Please Enter Room ID");
            }
            else
            {

                if (int.TryParse(textBox2.Text, out int idRoom))
                {
                    var complete = db.Rooms.SingleOrDefault(r => r.roomId == idRoom);
                    if (complete != null)
                    {
                        complete.maintenanceState = "True";
                        db.SaveChanges();
                        MessageBox.Show(" Done ");

                    }

                    else
                    {
                        MessageBox.Show(" This room not exist");
                    }
                }
            }
        }
    }
}
