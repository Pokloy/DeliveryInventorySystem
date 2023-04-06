using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace CardsInventorySystem
{
    public partial class Home : MetroForm
    {

        public Home()
        {
            InitializeComponent();
            TextBox txtbox = new TextBox();
        }
        DatabaseController DataC = new DatabaseController();
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        string queryX;

        private string PenNo()
        {

            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand("SELECT COUNT(pending_id) FROM tb_pendproduct;", databaseConnection);
            databaseConnection.Open();
            int count = Convert.ToInt32(commandDatabase.ExecuteScalar());
            databaseConnection.Close();
            PenNoLabel.Text = "Number of Pending: " + count.ToString();
            return PenNoLabel.Text;
        }
        private string DelNo()
        {
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand("SELECT COUNT(pending_id) FROM tb_deliverytab;", databaseConnection);
            databaseConnection.Open();
            int count = Convert.ToInt32(commandDatabase.ExecuteScalar());
            databaseConnection.Close();
            DelNolabel.Text = "Number of Deliveries: "+ count.ToString(); 
            return DelNolabel.Text;
        }
        private void LoadData()
        {
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(queryX, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void User_Welcome_Page_Load(object sender, EventArgs e)
        {
            queryX = "Select * From tb_deliverytab";
            LoadData();
            DelNo();
            PenNo();
            DataC.query = "SELECT username FROM `tb_users` WHERE user_id = ";
            UsernameLabel.Text = "Welcome " + DataC.GetCurrentUserName();
        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            
        }

        private void HomePanel_MouseHover(object sender, EventArgs e)
        {

            

           
        }

        private void HomePanel_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void TabsPanel_MouseEnter(object sender, EventArgs e)
        {
        }

        private void TabsPanel_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void TabsPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button1_Clickx(object sender, EventArgs e)
        {
            
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            Product ProdWindows = new Product();
            ProdWindows.Show();
     
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery DelivWindows = new Delivery();
            DelivWindows.Show();

        }

        private void HButton_Click(object sender, EventArgs e)
        {
           

        }
 


        private void LButton_Click(object sender, EventArgs e)
        {
         
        }

        private void DButton_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            queryX = "Select * From tb_deliverytab";
            LoadData();
            DelNo();
            PenNo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelNo();
            PenNo();
            queryX = "SELECT * FROM tb_deliverytab ORDER BY delivery_id DESC";
            LoadData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AscendButton_Click(object sender, EventArgs e)
        {
            DelNo();
            PenNo();
            queryX = "SELECT * FROM tb_deliverytab ORDER BY delivery_id ASC";
            LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            queryX = "SELECT* FROM `tb_deliverytab` WHERE(delivery_id = '"+Searchtxtbox.Text+ "' OR delivery_date = '" + Searchtxtbox.Text + "' OR delivery_status = '" + Searchtxtbox.Text + "' OR Location = '" + Searchtxtbox.Text + "' OR user_id = '" + Searchtxtbox.Text + "' OR pending_id = '" + Searchtxtbox.Text + "')";
            LoadData();
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
