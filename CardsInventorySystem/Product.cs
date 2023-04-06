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
    public partial class Product : MetroForm
    {

        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        DatabaseController DataC = new DatabaseController();
        string tablequery;
        
        public Product()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(tablequery, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void Product_Load(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_productinfo";
            LoadData();
        }
        private void ClearTextBox()
        {
            Product_IdTextBox.Clear();
            SerialNoTxtBox.Clear();
            ProdNameTxtBox.Clear();
            DeltypeTxtBox.Clear();
            ExpireTxtBox.Clear();
            QuantityTxtBox.Clear();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home A = new Home();
            A.Show();
           
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery B = new Delivery();
            B.Show();
         
        }

        private void PopulateButton_Click(object sender, EventArgs e)
        {

        }
       
        private void PListButton_Click(object sender, EventArgs e)
        {
            ModifyPanel.Hide();
            ListPanel.Show();

            LoadData();
        }

        private void MListButton_Click(object sender, EventArgs e)
        {
            ListPanel.Hide();
            ModifyPanel.Show();
        }

        private void ListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Product_IdTextBox.Text == "" || SerialNoTxtBox.Text == "" || ProdNameTxtBox.Text == "" || DeltypeTxtBox.Text == "" || ExpireTxtBox.Text == "" || QuantityTxtBox.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                DataC.query = "UPDATE tb_productinfo SET serialno = '" + SerialNoTxtBox.Text + "', productname = '" + ProdNameTxtBox.Text + "', producttype = '" + DeltypeTxtBox.Text + "', productexpiry = '" + ExpireTxtBox.Text + "', Quantity = '" + QuantityTxtBox.Text + "' , user_id = '" + DataC.CurrentUser() + "' WHERE product_id = '" + Product_IdTextBox.Text + "'";
                DataC.UpdaterunQuery();
                ClearTextBox();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (Product_IdTextBox.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                DataC.arrayquery[5] = "serialno";
                DataC.arrayquery[6] = "productname";
                DataC.arrayquery[7] = "producttype";
                DataC.arrayquery[8] = "productexpiry";
                DataC.arrayquery[9] = "Quantity";
                DataC.query = "select * from tb_productinfo WHERE product_id = " + Product_IdTextBox.Text + "";
                DataC.Readrunquery();
                SerialNoTxtBox.Text = DataC.arrayquery[0];
                ProdNameTxtBox.Text = DataC.arrayquery[1];
                DeltypeTxtBox.Text = DataC.arrayquery[2];
                ExpireTxtBox.Text = DataC.arrayquery[3];
                QuantityTxtBox.Text = DataC.arrayquery[4];

            }
        }

        private void ModifyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_productinfo";
            LoadData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryRequest X = new DeliveryRequest();
            X.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListPanel.Hide();
            ModifyPanel.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ModifyPanel.Hide();
            ListPanel.Show();
        }

        private void testbutton_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to delete the product", "Product Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (Product_IdTextBox.Text == "" || SerialNoTxtBox.Text == "" || ProdNameTxtBox.Text == "" || DeltypeTxtBox.Text == "" || ExpireTxtBox.Text == "" || QuantityTxtBox.Text == "")
                {
                    MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
                }
                else
                {
                    if (DataC.arrayquery[4] == "0")
                    {
                        DataC.query = "DELETE FROM tb_productinfo WHERE product_id = '" + Product_IdTextBox.Text + "'";
                        DataC.SuccessMessage = "Product Deleted Successfully.";
                        DataC.FailedMessage = "Product Delete Failed Successfully.";
                        DataC.DeleterunQuery();
                        ClearTextBox();
                    }
                    else
                    {
                        MessageBox.Show("Product currently has quantity please finish it up first.");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tablequery = "SELECT * FROM tb_productinfo ORDER BY product_id DESC";
            LoadData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablequery = "SELECT * FROM tb_productinfo ORDER BY product_id ASC";
            LoadData();
        }

        private void ProdListButton_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Product A = new Product();
            A.Show();
        }

        private void ListSearchButton_Click(object sender, EventArgs e)
        {
            tablequery = "SELECT * FROM tb_productinfo WHERE(product_id = '" + ListSearchtxtbox.Text + "' OR serialno = '" + ListSearchtxtbox.Text + "' OR productname = '" + ListSearchtxtbox.Text + "' OR producttype = '" + ListSearchtxtbox.Text + "' OR productexpiry = '" + ListSearchtxtbox.Text + "' OR Quantity = '" + ListSearchtxtbox.Text + "' OR user_id = '"+ ListSearchtxtbox.Text + "')";
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

        private void QuantityTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

