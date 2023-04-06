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
    public partial class AdminProduct : MetroForm
    {
        public AdminProduct()
        {
            InitializeComponent();
        }
        DatabaseController DataC = new DatabaseController();
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        string anyquery;
        private void LoadData()
        {
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(anyquery, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void AdminProduct_Load(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_productinfo";
            LoadData();
        }
        public void Cleartxtbox()
        {
            AdSerNotxtbox.Clear();
            AdProdNametxtbox.Clear();
            AdDelTypetxtbox.Clear();
            AdExpireDtxtbox.Clear();
            AdQuantitytxtbox.Clear();
            EPSeralnotxtbox.Clear();
            EDProdnametxtbox.Clear();
            EDprdtypetxtbox.Clear();
            EDExdatetxtbox.Clear();
            EProd_idtxtbox.Clear();
            EDQuantitytxtbox.Clear();
        }
        private void HButton_Click(object sender, EventArgs e)
        {
            AddProdPanel.Hide();
            ModProductPanel.Hide();
            ProdListPanel.Show();
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            AddProdPanel.Hide();
            ProdListPanel.Hide();
            ModProductPanel.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ProdListPanel.Hide();
            ModProductPanel.Hide();
            AddProdPanel.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AddProdPanel.Hide();
            ProdListPanel.Hide();
            ModProductPanel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddProdPanel.Hide();
            ProdListPanel.Hide();
            ModProductPanel.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DataC.SuccessMessage = "Product Added Successfully!";
            DataC.FailedMessage = "Product Failed to Save Successfully!";
            DataC.query = "INSERT INTO tb_productinfo(serialno, productname, producttype, productexpiry, Quantity, user_id) VALUES('" + AdSerNotxtbox.Text + "','" + AdProdNametxtbox.Text + "','" + AdDelTypetxtbox.Text + "','" + AdExpireDtxtbox.Text + "','" + AdQuantitytxtbox.Text + "','" + DataC.CurrentUser() + "');";
            DataC.AddrunQuery();
            Cleartxtbox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataC.arrayquery[5] = "serialno";
            DataC.arrayquery[6] = "productname";
            DataC.arrayquery[7] = "producttype";
            DataC.arrayquery[8] = "productexpiry";
            DataC.arrayquery[9] = "Quantity";
            DataC.query = "SELECT * FROM tb_productinfo WHERE product_id = '" + EProd_idtxtbox.Text + "'";
            DataC.Readrunquery();
            EPSeralnotxtbox.Text = DataC.arrayquery[0];
            EDProdnametxtbox.Text = DataC.arrayquery[1];
            EDprdtypetxtbox.Text = DataC.arrayquery[2];
            EDExdatetxtbox.Text = DataC.arrayquery[3];
            EDQuantitytxtbox.Text = DataC.arrayquery[4];
        }

        private void EUpdateButton_Click(object sender, EventArgs e)
        {
            if (EProd_idtxtbox.Text == string.Empty || EPSeralnotxtbox.Text == string.Empty || EDProdnametxtbox.Text == string.Empty || EDprdtypetxtbox.Text == string.Empty || EDExdatetxtbox.Text == string.Empty || EDQuantitytxtbox.Text == string.Empty)
            {
                MessageBox.Show("Please fill out all information needed.");
            }
            else
            {
                DataC.query = "UPDATE tb_productinfo SET serialno = '" + EPSeralnotxtbox.Text + "', productname = '" + EDProdnametxtbox.Text + "', producttype = '" + EDprdtypetxtbox.Text + "', productexpiry = '" + EDExdatetxtbox.Text + "', Quantity = '" + EDQuantitytxtbox.Text + "', user_id = '" + DataC.CurrentUser() + "' WHERE product_id = '" + EProd_idtxtbox.Text + "'; ";
                DataC.UpdaterunQuery();
                Cleartxtbox();
            }
                 
        }

        private void ModProductPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EDeleteButton_Click(object sender, EventArgs e)
        {
            if (EProd_idtxtbox.Text == string.Empty || EPSeralnotxtbox.Text == string.Empty || EDProdnametxtbox.Text == string.Empty || EDprdtypetxtbox.Text == string.Empty || EDExdatetxtbox.Text == string.Empty || EDQuantitytxtbox.Text == string.Empty)
            {
                MessageBox.Show("Please fill out all information needed.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to delete this item?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (DataC.arrayquery[4] == "0")
                    {
                        DataC.query = "DELETE FROM tb_productinfo WHERE product_id = '" + EProd_idtxtbox.Text + "'";
                        DataC.SuccessMessage = "Product Deleted Successfully.";
                        DataC.FailedMessage = "Product Delete Failed Successfully.";
                        DataC.DeleterunQuery();
                        Cleartxtbox();
                    }
                    else
                    {
                        MessageBox.Show("Product currently has quantity please finish it up first.");
                    }

                }
                else
                {
                    Cleartxtbox();
                }
            }



        }



        private void button4_Click(object sender, EventArgs e)
        {
            anyquery = "Select * From tb_productinfo";
            LoadData();
        }

        private void ButtonProdListDec_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_productinfo ORDER BY product_id DESC";
            LoadData();
        }

        private void ButtonProdListAsc_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT * FROM tb_productinfo ORDER BY product_id ASC";
            LoadData();
        }

        private void ButtonProdlistSearch_Click(object sender, EventArgs e)
        {
            anyquery = "SELECT* FROM tb_productinfo WHERE(product_id = '" + TextBoxProdlistSearch.Text + "' OR serialno = '" + TextBoxProdlistSearch.Text + "' OR productname = '" + TextBoxProdlistSearch.Text + "' OR producttype = '" + TextBoxProdlistSearch.Text + "' OR productexpiry = '" + TextBoxProdlistSearch.Text + "' OR Quantity = '" + TextBoxProdlistSearch.Text + "' OR user_id = '"+ TextBoxProdlistSearch.Text + "')";
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDelivery X = new AdminDelivery();
            X.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUsers X = new AdminUsers();
            X.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome X = new AdminHome();
            X.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminProduct X = new AdminProduct();
            X.Show();
        }

        private void ECancelButton_Click(object sender, EventArgs e)
        {
            AddProdPanel.Hide();
            ModProductPanel.Hide();
            ProdListPanel.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AddProdPanel.Hide();
            ModProductPanel.Hide();
            ProdListPanel.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
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
