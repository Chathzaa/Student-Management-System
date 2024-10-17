using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void studentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Studentinfo si = new Studentinfo();
            si.ShowDialog();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register re = new Register();
            re.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Course cs = new Course();
            cs.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher tr = new Teacher();
            tr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fee fe = new Fee();
            fe.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                
                Application.Exit();
            }
        }
    
        
    }
}
