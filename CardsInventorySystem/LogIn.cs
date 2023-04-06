using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;



namespace CardsInventorySystem
{
    public partial class LogIn : MetroForm
    {
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );
        public LogIn()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
        }
        DatabaseController DataC = new DatabaseController();
        string username;
        private void ClearTextbox()
        {
            UserNTextBox.Clear();
            PassWTextBox.Clear();
            txtboxUserName.Clear();
            textBoxRecovA.Clear();
            textBoxNewPass.Clear();
            textBoxConfirmP.Clear();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginPanel.Hide();
            Recoverypass2.Hide();
            Recoverypass1.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";          
            string user_id, usertype, username, password, recoveryQ, recoveryA;
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            AdminHome Adminhome = new AdminHome();
            Home UserHome = new Home();


            if (UserNTextBox.Text != "" && PassWTextBox.Text != "")
            {

                string query = "select user_id,usertype,username,password,recoveryQ,recoveryA from tb_users WHERE username ='" + UserNTextBox.Text + "' AND password ='" + PassWTextBox.Text + "'";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();

                MySqlDataReader myreader = commandDatabase.ExecuteReader();
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        user_id = myreader["user_id"].ToString();
                        usertype = myreader["usertype"].ToString();
                        username = myreader["username"].ToString();
                        password = myreader["password"].ToString();
                        recoveryQ = myreader["recoveryQ"].ToString();
                        recoveryA = myreader["recoveryA"].ToString();


                        if (usertype == "User")
                        {
                            UserAuditLog_in(user_id);
                            MessageBox.Show("Welcome " + username);
                            UserHome.Show();
                            this.Hide();
                        }
                        else if (usertype == "Admin")
                        {
                            UserAuditLog_in(user_id);
                            MessageBox.Show("Welcome " + username);
                            Adminhome.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Drug User");
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Username and Password");
                }
            }
            else
            {
                MessageBox.Show("Please input username or password");
            }
        }
        private void UserAuditLog_in(string A)
        {
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
            string query = "Insert Into tb_loginhistory(timelogin,user_id) Values('"+DateTime.Now+"','"+A+"')";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
        }

        private void buttonrecov1cancel_Click(object sender, EventArgs e)
        {
            Recoverypass1.Hide();
            Recoverypass2.Hide();
            LoginPanel.Show();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
           if (txtboxUserName.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.");
            }
           else
            {
                
                MySqlConnection databaseConnection = new MySqlConnection(DataC.MySQLConnectionString);
                MySqlCommand commandDatabase = new MySqlCommand("select * from tb_users WHERE username = '" + txtboxUserName.Text + "'", databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myreader = commandDatabase.ExecuteReader();
                if (myreader.HasRows)
                {
                    username = txtboxUserName.Text;
                    MessageBox.Show("User Found");
                    while (myreader.Read())
                    {
                        labelrecovq.Text = myreader["recoveryQ"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("User not found");
                }
                databaseConnection.Close();
            }
        }

        private void buttonsubmitrecov1_Click(object sender, EventArgs e)
        {
            if (txtboxUserName.Text == "" || textBoxRecovA.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.");
            }
            else
            {
                
                string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                string query = "select recoveryA from tb_users WHERE recoveryA ='" + textBoxRecovA.Text + "'";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myreader = commandDatabase.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("Correct Answer Proceeding to Change Password");
                    while (myreader.Read())
                    {
                        Recoverypass1.Hide();
                        LoginPanel.Hide();
                        Recoverypass2.Show();
                        ClearTextbox();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Answer");
                }
            }
        }

        private void ButtonCcancel2_Click(object sender, EventArgs e)
        {
            ClearTextbox();
            Recoverypass1.Hide();
            Recoverypass2.Hide();            
            LoginPanel.Show();
        }

        private void ButtonCRecov2_Click(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == "" || textBoxConfirmP.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.");
            }
            else
            {
                if (textBoxNewPass.Text == textBoxConfirmP.Text)
                {
                    DataC.query = "UPDATE tb_users SET password = '" + textBoxConfirmP.Text + "' WHERE username = '"+username+ "'; ";
                    DataC.UpdaterunQuery();
                    ClearTextbox();
                    Recoverypass1.Hide();
                    Recoverypass2.Hide();
                    LoginPanel.Show();
                }
                else
                {
                    MessageBox.Show("Password Not Match Please Try Again.");
                }
            }
        }
    }

}

