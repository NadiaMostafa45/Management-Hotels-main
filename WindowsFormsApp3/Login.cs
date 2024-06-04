using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp3.Login;
using static WindowsFormsApp3.Register;
namespace WindowsFormsApp3
{
    public partial class Login : Form
    {
        Model1 db =new Model1();
        private readonly UserService userServic = new UserService();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Staff dc = new Staff();

            var user = db.Staffs.FirstOrDefault(u => u.username == textusernamelogin.Text
 && u.departmentType == comboBox1.Text && u.position == comboBox2.Text);

       bool isPasswordCorrect = userServic.VerifyPassword(textpasswordlogin.Text, user.password);



            if (user != null && isPasswordCorrect)
                {
                if (comboBox1.Text == "Receptionist")
                {
                    this.Hide();
                    resp re =new resp();
                    re.Show();
                }
                else if (comboBox1.Text == "Room Service" && comboBox2.Text == "Manager")
                {
                    this.Hide();
                    room_data re = new room_data();
                    re.Show();

                }
                else if (comboBox1.Text == "Room Service" && comboBox2.Text == "Employee")
                {
                    this.Hide();
                    Stafff em = new Stafff();
                    em.Show();

                }
                else if (comboBox1.Text == "Maintenance" && comboBox2.Text == "Employee")
                {
                    this.Hide();
                    Form4 em = new Form4();
                    em.Show();
                }
                else if (comboBox1.Text == "Maintenance" && comboBox2.Text == "Manager")
                {
                    this.Hide();
                    Form5 em = new Form5();
                    em.Show();
                }
                else if (comboBox1.Text == "Hotel Manager" )
                {
                    this.Hide();
                    Main_Manager em = new Main_Manager();
                    em.Show();
                }
                else if (comboBox1.Text == "Marketing" )
                {
                    this.Hide();
                    Marketing em = new Marketing();
                    em.Show();
                }
                //  return true;

            }

            else
            {
                string message = "you cannot continue";
                string title = "Login";
                MessageBox.Show(message, title);
                //  return false;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

       


    }
}
