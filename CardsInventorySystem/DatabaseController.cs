using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace CardsInventorySystem
{
    class DatabaseController
    {

        public string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        public string query { get; set; }
        public string[] arrayquery = new string[20];
        public string SuccessMessage { get; set; }
        public string FailedMessage { get; set; }
        public DialogResult Question;
        public string CurrentUser()
        {

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand("SELECT user_id FROM tb_loginhistory ORDER BY userhistory_id DESC LIMIT 1; ", databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();
            if (myreader.Read())
            {
                return myreader["user_id"].ToString();
            }
            databaseConnection.Close();
            return "No result";
        }
        public string GetCurrentUserName()
        {
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query + CurrentUser(), databaseConnection);
            databaseConnection.Open();
            commandDatabase.Parameters.AddWithValue(CurrentUser(), 1);
            string attributeValue = Convert.ToString(commandDatabase.ExecuteScalar());
            databaseConnection.Close();
            return attributeValue;
        }
        public void AddrunQuery()
        {

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();

            if (myreader.HasRows)
            {
                MessageBox.Show(FailedMessage);

            }
            else
            {
                MessageBox.Show(SuccessMessage);
            }
            databaseConnection.Close();
        }

        public void DeleterunQuery()
        {
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();

            if (myreader.HasRows)
            {
                MessageBox.Show(FailedMessage);

            }
            else
            {
                MessageBox.Show(SuccessMessage);
            }
            databaseConnection.Close();
        }



        public void UpdaterunQuery()
        {

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();
            MessageBox.Show("Information Updated Successfully");
            databaseConnection.Close();
        }
       
        public string runQuery()
        {
            
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();
            databaseConnection.Close();
            return null;
        }
        public void Readrunquery()
        {

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            databaseConnection.Open();
            MySqlDataReader myreader = commandDatabase.ExecuteReader();

            if (myreader.HasRows)
            {
                while (myreader.Read())
                {
                    if (myreader.FieldCount == 7)
                    {
                        arrayquery[0] = myreader[arrayquery[5]].ToString();
                        arrayquery[1] = myreader[arrayquery[6]].ToString();
                        arrayquery[2] = myreader[arrayquery[7]].ToString();
                        arrayquery[3] = myreader[arrayquery[8]].ToString();
                        arrayquery[4] = myreader[arrayquery[9]].ToString();
                        MessageBox.Show("Information found with 7 criteria");
                    }
                    else if (myreader.FieldCount == 6)
                    {
                        arrayquery[0] = myreader[arrayquery[5]].ToString();
                        arrayquery[1] = myreader[arrayquery[6]].ToString();
                        arrayquery[2] = myreader[arrayquery[7]].ToString();
                        arrayquery[3] = myreader[arrayquery[8]].ToString();
                        arrayquery[4] = myreader[arrayquery[9]].ToString();
                        MessageBox.Show("Information found with 6 criteria");
                    }
                    else
                    {
                        MessageBox.Show("No information found");
                    }

                }
            }
            else
            {
                MessageBox.Show("Product not found");
            }
            databaseConnection.Close();
        }
        public void UserAuditLog_Out()
        {
            
            Question = MessageBox.Show("Are you sure you want to log-out?", "Log-Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Question == DialogResult.Yes)
                {
                    MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                    MySqlCommand commandDatabase = new MySqlCommand("UPDATE tb_loginhistory SET timelogout = '" + DateTime.Now + "' WHERE userhistory_id = (SELECT userhistory_id FROM tb_loginhistory ORDER BY userhistory_id DESC LIMIT 1);", databaseConnection);
                    databaseConnection.Open();
                    MySqlDataReader myreader = commandDatabase.ExecuteReader();
                    databaseConnection.Close();
                }
                else
                {
                    
                }
        }
    }



}
