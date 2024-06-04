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
    public partial class Manager : Form
    {
        Model1 context = new Model1();

        public Manager()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Manager manager = new Main_Manager();

            manager.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stafff st = new Stafff();
            var emp = from em in context.Staffs
                      select new { em.firstName, em.lastName ,em.salary,em.departmentType,em.position };
            dataGridView1.DataSource = emp.ToList();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
