using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagement
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into teacher_tab values (@teacher_id,@name,@age)", con);

            cnn.Parameters.AddWithValue("@Teacher_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Name", textBox4.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
           
            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from teacher_tab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
            RefreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("update teacher_tab set name=@name,age=@age where teacher_id=@teacher_id", con);

            cnn.Parameters.AddWithValue("@Teacher_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Name", textBox4.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete teacher_tab where teacher_id=@teacher_id", con);

            cnn.Parameters.AddWithValue("@Teacher_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            
            using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cnn = new SqlCommand("SELECT * FROM teacher_tab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }
    }
}
