using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Userform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-336DJLI\SQLEXPRESS;Initial Catalog=Information;Integrated Security=True");
        public string Username;
        private void Form1_Load(object sender, EventArgs e)
        {
            GetRecord();
        }

        private void GetRecord()
        {
           
            SqlCommand cmd = new SqlCommand("Select * from UserDetail", con);
            DataTable dt = new DataTable();
            con.Open(); 
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            RecordDataGridView.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Username))
                {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM UserDetail WHERE Username=@Username ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", this.Username);
                
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                MessageBox.Show("User deleted from the database", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetRecord();
                ResetFormField();

            }
            else
            {
                MessageBox.Show("select a user to delete", "select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                if (con.State != ConnectionState.Open) // Check if the connection is not already open
                {
                    con.Open(); // Open the connection
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO UserDetail VALUES (@Username,@Fullname,@Password,@DOB,@Age,@Gender,@Email,@Address,@State, @District) ",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", textusername.Text);
                cmd.Parameters.AddWithValue("@Fullname", txtname.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@State", txtstate.Text);
                cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
              
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                MessageBox.Show("Succesfully Added new User ", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetRecord();
                ResetFormField();
            }
        }

        private bool IsValid()
        {
            if (textusername.Text == string.Empty)
            {
                MessageBox.Show("User Name is Required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true; }
            private void txtpassword_TextChanged(object sender, EventArgs e)
        { }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormField();

        }

        private void ResetFormField()
        {   
            textusername.Clear();
            txtname.Clear();
            txtpassword.Clear();
            txtdob.Clear();
            txtage.Clear();
            txtgender.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            txtstate.Clear();
            txtdistrict.Clear();

            txtname.Focus();
        }

        private void RecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Username = RecordDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = RecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtpassword.Text = RecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtdob.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtage.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtgender.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtemail.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtaddress.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtstate.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtdistrict.Text = RecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                    if (con.State != ConnectionState.Open) 
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE UserDetail SET Fullname=@Fullname,Password=@Password,DOB=@DOB,Age=@Age,Gender=@Gender,Email=@Email,Address=@Address,State=@State, District=@District WHERE Username=@Username", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Username", this.Username);
                    cmd.Parameters.AddWithValue("@Fullname", txtname.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
                    cmd.Parameters.AddWithValue("@Age", txtage.Text);
                    cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@State", txtstate.Text);
                    cmd.Parameters.AddWithValue("@District", txtdistrict.Text);

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }


                    MessageBox.Show("User data Updated ", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetRecord();
                    ResetFormField();
                }
            else
            {
                MessageBox.Show("Select a user to update Information ", "select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();

            
            form2.Show();
            

        }
    }
}
