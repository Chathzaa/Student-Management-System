using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace StudentManagement
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into regis_tab values (@firstname,@lastname,@email_address,@password)", con);

           cnn.Parameters.AddWithValue("@FirstName", textBox1.Text);

            cnn.Parameters.AddWithValue("@LastName", textBox4.Text);

            cnn.Parameters.AddWithValue("@Email_Address", textBox2.Text);

            cnn.Parameters.AddWithValue("@Password", textBox3.Text);


            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Registration Successful", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}
