using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace CardsInventorySystem
{
    public partial class AdminUsers : MetroForm
    {
        public AdminUsers()
        {
            InitializeComponent();
        }
        string anyquery;
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        DatabaseController DataC = new DatabaseController();
        AdminHome Ahome = new AdminHome();
        AdminProduct AProduct = new AdminProduct();
        AdminDelivery ADelivery = new AdminDelivery();
        private void ClearTextbox()
        {
            Usernametxtbox.Clear();
            Passwordtxtbox.Clear();
            RQuestiontxtbox.Clear();
            AQuestiontxtbox.Clear();
            UserTypetxtbox.Clear();
            User_IDtxtbox.Clear();
            Ausernametxtbox.Clear();
            Apasswordtxtbox.Clear();
            ARquestiontxtbox.Clear();
            ARAnswertxtbox.Clear();
            AUserTypetxtbox.Clear();
            ACuseridtxtbox.Clear();
            ACusernametxtbox.Clear();
            ACpasswordtxtbox.Clear();
            ACrecoveryQtxtbox.Clear();
            ACRAnswertxtbox.Clear();
            ACusertypetxtbox.Clear();
        }
        private void LoadData()
        {
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(anyquery, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridViewLoginHistory.DataSource = dtbl;
        }

        private void AdminUsers_Load(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_users";
            LoadData();
            
        }

        private void HButton_Click(object sender, EventArgs e)
        {
            AddUserPanel.Hide();
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            AccountSetPanel.Hide();
            UserListPanel.Show();
        }

        private void DButton_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            UserListPanel.Hide();
            AddUserPanel.Hide();
            AccountSetPanel.Show();
            ACuseridtxtbox.Text = DataC.CurrentUser();
            DataC.arrayquery[5] = "username";
            DataC.arrayquery[6] = "password";
            DataC.arrayquery[7] = "recoveryQ";
            DataC.arrayquery[8] = "recoveryA";
            DataC.arrayquery[9] = "usertype";
            DataC.query = "select * from tb_users WHERE user_id = " + ACuseridtxtbox.Text + "";
            DataC.Readrunquery();
            ACusernametxtbox.Text = DataC.arrayquery[0];
            ACpasswordtxtbox.Text = DataC.arrayquery[1];
            ACrecoveryQtxtbox.Text = DataC.arrayquery[2];
            ACRAnswertxtbox.Text = DataC.arrayquery[3];
            ACusertypetxtbox.Text = DataC.arrayquery[4];
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            AccountSetPanel.Hide();
            UserListPanel.Hide();
            AddUserPanel.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DataC.query = "UPDATE tb_users SET username = '" + Usernametxtbox.Text + "', password = '" + Passwordtxtbox.Text + "', recoveryQ = '" + RQuestiontxtbox.Text + "', recoveryA = '" + AQuestiontxtbox.Text + "', usertype = '" + UserTypetxtbox.Text + "'  WHERE user_id = '" + User_IDtxtbox.Text + "'; ";
            DataC.UpdaterunQuery();
            ClearTextbox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide(); 
            AccountSetPanel.Hide();
            UserListPanel.Hide();
            AddUserPanel.Hide();
            ModDelPanel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide();
            AccountSetPanel.Hide();
            UserListPanel.Hide();
            AddUserPanel.Hide();
            ModDelPanel.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_users";
            LoadData();
        }

        private void Search1Button_Click(object sender, EventArgs e)
        {

        }

        private void Search1Button_Click_1(object sender, EventArgs e)
        {
            DataC.arrayquery[5] = "username";
            DataC.arrayquery[6] = "password";
            DataC.arrayquery[7] = "recoveryQ";
            DataC.arrayquery[8] = "recoveryA";
            DataC.arrayquery[9] = "usertype";
            DataC.query = "select * from tb_users WHERE user_id = " + User_IDtxtbox.Text + "";
            DataC.Readrunquery();
            Usernametxtbox.Text = DataC.arrayquery[0];
            Passwordtxtbox.Text = DataC.arrayquery[1];
            RQuestiontxtbox.Text = DataC.arrayquery[2];
            AQuestiontxtbox.Text = DataC.arrayquery[3];
            UserTypetxtbox.Text = DataC.arrayquery[4];

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DataC.FailedMessage = "User failed to delete successfully";
            DataC.SuccessMessage = "User deleted successfully";
            DataC.query = "DELETE FROM tb_users WHERE user_id = '"+User_IDtxtbox.Text+ "'; ";
            DataC.DeleterunQuery();
            ClearTextbox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataC.SuccessMessage = "User added successfully";
            DataC.FailedMessage = "User not added successfully";
            DataC.query = "INSERT INTO tb_users(username,password,recoveryQ,recoveryA,usertype) VALUES ('" + Ausernametxtbox.Text + "','" + Apasswordtxtbox.Text + "','" + ARquestiontxtbox.Text + "','" + ARAnswertxtbox.Text + "','" + AUserTypetxtbox.Text + "')";
            DataC.AddrunQuery();
            ClearTextbox();
        }

        private void AccountSetPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            DataC.CurrentUser();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            
            DialogResult X = MessageBox.Show("Are you sure you want to save changes?", "Admin Account Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (X == DialogResult.Yes)
            {
                DataC.query = "UPDATE tb_users SET username = '" + ACusertypetxtbox.Text + "' , password = '" + ACpasswordtxtbox.Text + "' , recoveryQ = '" + ACrecoveryQtxtbox.Text + "' , recoveryA = '" + ACRAnswertxtbox.Text + "' , usertype = '" + ACusertypetxtbox.Text + "' WHERE user_id = '" + ACuseridtxtbox.Text + "'; ";
                DataC.UpdaterunQuery();
                MessageBox.Show("Admin Account changes made successfully.");
                ClearTextbox();
            }
            else
            {
                AccountSetPanel.Hide();
                AccountSetPanel.Hide();
                ModDelPanel.Hide();
                AddUserPanel.Hide();
                UserListPanel.Show();
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide();
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            AddUserPanel.Hide();
            UserListPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_users ORDER BY user_id ASC";
            LoadData();
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_users ORDER BY user_id DESC";
            LoadData();
        }

        private void UserlistSearchButton_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_users WHERE(user_id = '" + textBoxUserlistSearch.Text + "' OR usertype = '" + textBoxUserlistSearch.Text + "' OR username = '" + textBoxUserlistSearch.Text + "' OR password = '" + textBoxUserlistSearch.Text + "' OR recoveryQ = '" + textBoxUserlistSearch.Text + "' OR recoveryA = '" + textBoxUserlistSearch.Text + "')";
            LoadData();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide();
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            AddUserPanel.Hide();
            UserListPanel.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AccountSetPanel.Hide();
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            AddUserPanel.Hide();
            UserListPanel.Show();
        }

        private void AnotherTabButton_Click(object sender, EventArgs e)
        {
            AdminUsers X = new AdminUsers();
            X.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome X = new AdminHome();
            X.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminProduct X = new AdminProduct();
            X.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDelivery X = new AdminDelivery();
            X.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DataC.UserAuditLog_Out();
            if (DataC.Question == DialogResult.Yes)
            {
                this.Close();
                LogIn Log = new LogIn();
                Log.Show();
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminUsers Use = new AdminUsers();
            Use.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserListPanel.Hide();
            AddUserPanel.Hide();
            AccountSetPanel.Hide();
            ModDelPanel.Hide();
            LoginHisPanel.Show();
            anyquery = "Select * From tb_loginhistory";
            LoadData();
        }

        private void ButtonRefHistory_Click(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_loginhistory";
            LoadData();
        }

        private void buttonHistoryDec_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_loginhistory ORDER BY userhistory_id DESC";
            LoadData();
        }

        private void buttonHistoryAsc_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_loginhistory ORDER BY userhistory_id ASC";
            LoadData();
        }

        private void buttonHistorySeacrh_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_loginhistory WHERE(userhistory_id = '" + textBoxSearchHistory.Text + "' OR timelogin = '" + textBoxSearchHistory.Text + "' OR timelogout = '" + textBoxSearchHistory.Text + "' OR user_id = '" + textBoxSearchHistory.Text + "' )";
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult X = MessageBox.Show("Are you sure you want to delete all record?\nWARNING: This will not be retievable anymore", "Delete All Record Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            {
                if (X == DialogResult.Yes)
                {
                    DataC.FailedMessage = "All records are not deleted";
                    DataC.SuccessMessage = "All records are deleted successfully";
                    DataC.query = "DELETE FROM tb_loginhistory";
                    DataC.DeleterunQuery();
                }
                else
                {
                    MessageBox.Show("Action canceled.", "Deletion Notification");
                }
            }

        }
    }
}

