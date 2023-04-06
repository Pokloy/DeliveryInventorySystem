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
    public partial class AdminHome : MetroForm
    {
        public AdminHome()
        {
            InitializeComponent();
        }
        DatabaseController DataC = new DatabaseController();
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        string anyquery;
        private string PenNo()
        {
            anyquery = "SELECT COUNT(pending_id) FROM tb_pendproduct;";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(anyquery, databaseConnection);
            databaseConnection.Open();
            int count = Convert.ToInt32(commandDatabase.ExecuteScalar());
            databaseConnection.Close();
            NPenlabel.Text = "Number of Pending: " + count.ToString();
            return NPenlabel.Text;
        }
        private string DelNo()
        {
            anyquery = "SELECT COUNT(pending_id) FROM tb_deliverytab;";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(anyquery, databaseConnection);
            databaseConnection.Open();
            int count = Convert.ToInt32(commandDatabase.ExecuteScalar());
            databaseConnection.Close();
            NDellabel.Text = "Number of Deliveries: " + count.ToString();
            return NDellabel.Text;
        }
        private void LoadData()
        {
            
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(anyquery, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void AdminHome_Load(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_pendproduct";
            LoadData();
            DelNo();
            PenNo();
            DataC.query = "SELECT username FROM `tb_users` WHERE user_id = ";
            UsernameLabel.Text = "Welcome " + DataC.GetCurrentUserName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminUsers Ahome = new AdminUsers();
            this.Hide();
            Ahome.Show();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_pendproduct";
            LoadData();
            DelNo();
            PenNo();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            AdminProduct AProduct = new AdminProduct();
            this.Hide();
            AProduct.Show();
        }

        private void DeliveryButton_Click(object sender, EventArgs e)
        {
            AdminDelivery ADelivery = new AdminDelivery();
            this.Hide();
            ADelivery.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_pendproduct ORDER BY delivery_id DESC";
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_pendproduct ORDER BY delivery_id ASC";
            LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT* FROM tb_pendproduct WHERE(pending_id = '" + Searchtxtbox.Text + "' OR requestprod = '" + Searchtxtbox.Text + "' OR productname = '" + Searchtxtbox.Text + "' OR Quantity = '" + Searchtxtbox.Text + "' OR Remarks = '" + Searchtxtbox.Text + "' OR user_id = '" + Searchtxtbox.Text + "')";
            LoadData();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

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
    }
}
