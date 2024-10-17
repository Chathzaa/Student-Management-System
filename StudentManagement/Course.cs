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
    public partial class Course : Form
    {
        public Course()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into course_tab values (@course_id,@course_name,@duration,@coordinator)", con);

            cnn.Parameters.AddWithValue("@Course_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Course_Name", textBox4.Text);

            cnn.Parameters.AddWithValue("@Duration", textBox3.Text);

            cnn.Parameters.AddWithValue("@Coordinator", textBox2.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete course_tab where course_id=@course_id", con);

            cnn.Parameters.AddWithValue("@Course_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void Course_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from course_tab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void RefreshDataGridView()
        {
            // Refresh the DataGridView by re-loading data from the database
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from course_tab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
                textBox1.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";

        }
    }
}
