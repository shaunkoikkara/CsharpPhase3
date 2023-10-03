using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Userform
{
    using System.Data.SqlClient;
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-336DJLI\SQLEXPRESS;Initial Catalog=Information;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Username, Password;
            Username = txtusername.Text;
            Password = txtpassword.Text;

            try
            {
                String detail = "SELECT * FROM UserDetail WHERE Username = '" + txtusername.Text + "' AND Password = '" + txtpassword.Text + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(detail, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Username = txtusername.Text;
                    Password = txtpassword.Text;
                    Menuform form3 = new Menuform();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusername.Clear();
                    txtpassword.Clear();
                    txtusername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Username or Password");
            }

            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.Show();

            this.Close();
        }
    }
}
