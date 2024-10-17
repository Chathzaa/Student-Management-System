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
    public partial class Studentinfo : Form
    {
        public Studentinfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");
           

            con.Open();

            SqlCommand cnn = new SqlCommand("insert into info_tab values (@student_id,@student_name,@age,@email_address,@mobile)", con);
            SqlCommand cnn2 = new SqlCommand("insert into student_tab (student_id, student_name) values (@student_id, @student_name)", con);

            cnn.Parameters.AddWithValue("@Student_ID", int.Parse(textBox1.Text));
            cnn2.Parameters.AddWithValue("@Student_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Student_Name", textBox2.Text);
            cnn2.Parameters.AddWithValue("@Student_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

            cnn.Parameters.AddWithValue("@Email_Address", textBox4.Text);

            cnn.Parameters.AddWithValue("@Mobile", textBox5.Text);

            cnn.ExecuteNonQuery();
            cnn2.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void Studentinfo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            SqlCommand cnn = new SqlCommand("select * from info_tab", con);

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

            SqlCommand cnn = new SqlCommand("update info_tab set student_name=@student_name,age=@age,email_address=@email_address,mobile=@mobile where student_id=@student_id", con);

            cnn.Parameters.AddWithValue("@Student_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Student_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));

            cnn.Parameters.AddWithValue("@Email_Address", textBox4.Text);

            cnn.Parameters.AddWithValue("@Mobile", textBox5.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDataGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=registerdb;Integrated Security=True;Encrypt=False");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete info_tab where student_id=@student_id", con);

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
                SqlCommand cnn = new SqlCommand("SELECT * FROM info_tab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void entryload(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                if (row.Cells[0].Value != null)
                {
                    
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }
    }
}
