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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into student_tab values (@student_id,@student_name,@course,@score)", con);

            cnn.Parameters.AddWithValue("@Student_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Student_Name", textBox4.Text);

            cnn.Parameters.AddWithValue("@Course", comboBox1.SelectedItem.ToString());

            cnn.Parameters.AddWithValue("@Score", textBox2.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            PopulateCourseDropdown();
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from student_tab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
            RefreshDataGridView();
        }

        private void PopulateCourseDropdown()
        {
            // Clear existing items in the dropdown
            comboBox1.Items.Clear();

            // Establish connection to the database
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            try
            {
                con.Open();

                // Select course names from the database
                SqlCommand cmd = new SqlCommand("SELECT course_name FROM course_tab", con);

                SqlDataReader reader = cmd.ExecuteReader();

                // Add course names to the dropdown
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["course_name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("update student_tab set student_name=@student_name,course=@course,score=@score where student_id=@student_id", con);

            cnn.Parameters.AddWithValue("@Student_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Student_Name", textBox4.Text);

            cnn.Parameters.AddWithValue("@Course", comboBox1.SelectedItem.ToString());

            cnn.Parameters.AddWithValue("@Score", textBox2.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete student_tab where student_id=@student_id", con);

            cnn.Parameters.AddWithValue("@Student_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            // Refresh the DataGridView by re-loading data from the database
            using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cnn = new SqlCommand("SELECT * FROM student_tab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            entryload(e);
        }

        public void entryload(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    textBox1.Text = row.Cells[0].Value.ToString();
                }
                else textBox1.Text = "";

                if (row.Cells[1].Value != null)
                {
                    textBox4.Text = row.Cells[1].Value.ToString();
                }
                else textBox4.Text = "";

                if (row.Cells[2].Value != null)
                {
                    comboBox1.SelectedItem = row.Cells[2].Value.ToString();
                }
                else comboBox1.SelectedItem = "-1";

                if (row.Cells[3].Value != null)
                {
                    textBox2.Text = row.Cells[3].Value.ToString();
                }
                else textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
