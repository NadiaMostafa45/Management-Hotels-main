using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static WindowsFormsApp3.Register;
using BCryptNet = BCrypt.Net.BCrypt;
namespace WindowsFormsApp3
{

    public partial class Register : Form
    {

        string imagepath;
        public Register()
        {
            InitializeComponent();
            //  MessageBox.Show(Environment.CurrentDirectory);
        }
        public class UserService
        {
            public bool VerifyPassword(string enteredPassword, string savedPasswordHash)
            {
                return BCryptNet.Verify(enteredPassword, savedPasswordHash);
            }

            public string HashPassword(string password)
            {
                return BCryptNet.HashPassword(password);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Model1 dc = new Model1();
            if (textid.Text == "" || textemail.Text == "" || textpassword.Text == "" ||
                passswordconfirm.Text == "" || textphone.Text == ""
                || textfirstn.Text == "" || textlastn.Text == ""
                 ||comboBox2.Text == "" || comboBox1.Text == ""  
                || textusername.Text == "")
            {
                MessageBox.Show("please enter data");
            }
            else
            {

                int flag = 0;

                if (int.TryParse(textid.Text, out int intValue))
                {
                    Staff newRecord = new Staff();

                    var id = from staff in dc.Staffs
                             where intValue == staff.staffId
                             select staff.staffId;
                    if (!(id.Any()))
                    {
                        newRecord.staffId = intValue;
                    }
                    else
                    {
                        MessageBox.Show("This Id Exist Before");
                        flag = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid integer value. Please enter a valid integer.");
                }
                Staff st = new Staff();


                if (textemail.Text.Contains("@gmail.com") && textemail.Text.Length > 9)
                {
                    st.email = textemail.Text;

                }
                else
                {
                    flag = 1;
                    MessageBox.Show("Email Not Vaild");

                }

                if ((textpassword.Text.Length == 8))
                {
                    UserService user = new UserService();
                    st.password = user.HashPassword(textpassword.Text);
                    //st.password = textpassword.Text;

                }
                else
                {
                    flag = 1;
                    MessageBox.Show("Password Not Vaild");
                }

                if ((passswordconfirm.Text != textpassword.Text))
                {

                    MessageBox.Show("Confirm Password Not Vaild");
                    flag = 1;
                }


                if ((textphone.Text.Length != 11))
                {
                    MessageBox.Show(" Phone Not Vaild");
                    flag = 1;

                }


                st.staffId = intValue;
                if (comboBox1.Text == "Receptionist")
                {
                    st.salary = 3000;
                }
                else if (comboBox1.Text == "Room Service" && comboBox2.Text == "Manager")
                {
                    st.salary = 6000;

                }
                else if (comboBox1.Text == "Room Service" && comboBox2.Text == "Employee")
                {
                    st.salary = 2000;

                }
                else if (comboBox1.Text == "Maintenance" && comboBox2.Text == "Employee")
                {
                    st.salary = 3000;
                }
                else if (comboBox1.Text == "Maintenance" && comboBox2.Text == "Manager")
                {
                    st.salary = 6000;
                }
               
                else if (comboBox1.Text == "Marketing" && comboBox2.Text == "Manager")
                {
                    st.salary = 5000;
                }
                
                st.firstName = textfirstn.Text;
                st.lastName = textlastn.Text;

                st.phone = textphone.Text;
                st.position = comboBox2.Text;
                st.departmentType = comboBox1.Text;
                st.username = textusername.Text;
                // st.images = imagepath;
                if (flag == 0)
                {
                    dc.Staffs.Add(st);
                    dc.SaveChanges();
                    MessageBox.Show("Done Successfully");

                    this.Hide();
                    Login form = new Login();
                    form.Show();
                }
              


            }

            //string newpaths = Environment.CurrentDirectory + st.staff_id + ".jpg";
            //File.Copy(imagepath, newpaths);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = openFileDialog.FileName;
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textdepartement_TextChanged(object sender, EventArgs e)
        {

        }

        private void textphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
