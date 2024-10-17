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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        registerdbEntities dbcontext = new registerdbEntities();

        private void label2_Click(object sender, EventArgs e)
        {
           try
            {
                if(dbcontext.TBL_USERS.Where(r=>r.USERNAME== textbox1.Text && r.PASSWORD== textbox2.Text).Count()>0)
                {
                    MessageBox.Show("Login Successful");
                    Main ma = new Main();
                    ma.ShowDialog();
                }
                else 
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
            catch (Exception ert)
            {
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textbox1.Text = "";
            textbox2.Text = "";
        }
    }
}
