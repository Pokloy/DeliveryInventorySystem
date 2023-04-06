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
    public partial class Delivery : MetroForm
    {
        public Delivery()
        {
            InitializeComponent();
        }
        DatabaseController DataC = new DatabaseController();
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        string tablequery;
        private void LoadData()
        {
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(tablequery, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView2.DataSource = dtbl;

        }
        private void ClearTextBox()
        {
            textboxstatus.Clear();
            textboxprodname.Clear();
            textboxQuantity.Clear();
            richTextBoxRemarks.Clear();
        }
        private void User_Load(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_deliverytab";
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryRequest Edit = new DeliveryRequest();
            Edit.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            Home MainWindow = new Home(); 
            MainWindow.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product ProdWindows = new Product();
            ProdWindows.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryRequest Edit = new DeliveryRequest();
            Edit.MovetoDelConfirPanel();
            Edit.Show();
            
        }

        private void PListButton_Click(object sender, EventArgs e)
        {
            PModifyPanel.Hide();
            PListPanel.Hide();
            DListPanel.Show();
            tablequery = "Select * From tb_deliverytab";
            LoadData();
        }

        private void PLButton_Click(object sender, EventArgs e)
        {
            PModifyPanel.Hide();
            DListPanel.Hide();
            PListPanel.Show();
            tablequery = "Select * From tb_pendproduct";
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeliveryRequest X = new DeliveryRequest();
            X.Show();

        }

        private void DListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_deliverytab";
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeliveryRequest X = new DeliveryRequest();
            X.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
           
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_pendproduct";
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_deliverytab ORDER BY delivery_id DESC";
            LoadData();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Delivery X = new Delivery();
            X.Show();
        }

        private void DelAscButton_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_deliverytab ORDER BY delivery_id ASC";
            LoadData();
        }

        private void DelSearchButton_Click(object sender, EventArgs e)
        {
            tablequery = "SELECT* FROM `tb_deliverytab` WHERE(delivery_id = '"+TextBoxDelSearch.Text+ "' OR delivery_date = '" + TextBoxDelSearch.Text + "' OR delivery_status = '" + TextBoxDelSearch.Text + "' OR Location = '" + TextBoxDelSearch.Text + "' OR user_id = '" + TextBoxDelSearch.Text + "' OR pending_id = '" + TextBoxDelSearch.Text + "')";
            LoadData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_pendproduct ORDER BY pending_id DESC";
            LoadData();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PListPanel.Hide();
            DListPanel.Hide();
            PModifyPanel.Show();
        }

        private void PenAscButton_Click(object sender, EventArgs e)
        {
            tablequery = "Select * From tb_pendproduct ORDER BY pending_id ASC";
            LoadData();
        }

        private void PenSearchButton_Click(object sender, EventArgs e)
        {
            tablequery = "SELECT* FROM `tb_pendproduct` WHERE(pending_id = '" + TxtBoxPenSearch.Text + "' OR requestprod = '" + TxtBoxPenSearch.Text + "' OR productname = '" + TxtBoxPenSearch.Text + "' OR Quantity = '" + TxtBoxPenSearch.Text + "' OR Remarks = '" + TxtBoxPenSearch.Text + "' OR user_id = '" + TxtBoxPenSearch.Text + "')";
            LoadData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Delivery X = new Delivery();
            X.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            PModifyPanel.Hide();
            PListPanel.Hide();
            DListPanel.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            if (txtboxpenid.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                DataC.arrayquery[5] = "requestprod";
                DataC.arrayquery[6] = "productname";
                DataC.arrayquery[7] = "Quantity";
                DataC.arrayquery[8] = "Remarks";
                DataC.arrayquery[9] = "user_id";
                DataC.query = "select * from tb_pendproduct WHERE pending_id = " + txtboxpenid.Text + "";
                DataC.Readrunquery();
                textboxstatus.Text = DataC.arrayquery[0];
                textboxprodname.Text = DataC.arrayquery[1];
                textboxQuantity.Text = DataC.arrayquery[2];
                richTextBoxRemarks.Text = DataC.arrayquery[3];
                DataC.arrayquery[10] = DataC.arrayquery[4];
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {


            if (txtboxpenid.Text == "" || textboxstatus.Text == "" || textboxprodname.Text == "" || textboxQuantity.Text == "" || richTextBoxRemarks.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete pending item", "Pending Status Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (textboxstatus.Text == "Pending" || textboxstatus.Text == "PENDING" || textboxstatus.Text == "Delivered/In Stored")
                    {
                        DataC.query = "DELETE FROM tb_pendproduct WHERE pending_id = '" + txtboxpenid.Text + "'";
                        DataC.SuccessMessage = "Product Deleted Successfully.";
                        DataC.FailedMessage = "Product Delete Failed Successfully.";
                        try
                        {
                            DataC.DeleterunQuery();
                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("Cannot delete the pending item " + textboxprodname.Text + ".\nPlease delete the delivery item 1st based on delivery id: " + txtboxpenid.Text, "Pending Warning");
                        }
                        ClearTextBox();

                    }
                    else
                    {
                        MessageBox.Show("Item is currently in delivery. Unable to delete at the moment. Ask your manager for any instructions");
                    }

                }
                else
                {

                    MessageBox.Show("Action Canceled");


                }
            }


        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (txtboxpenid.Text == "" || textboxstatus.Text == "" || textboxprodname.Text == "" || textboxQuantity.Text == "" || richTextBoxRemarks.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                DataC.query = "UPDATE tb_pendproduct SET requestprod = '" + textboxstatus.Text + "', productname = '" + textboxprodname.Text + "', Quantity = '" + textboxQuantity.Text + "', Remarks = '" + richTextBoxRemarks.Text + "', user_id = '" + DataC.CurrentUser() + "'  WHERE pending_id = '" + txtboxpenid.Text + "'";
                DataC.UpdaterunQuery();
                ClearTextBox();
            }

           
        }

        private void PModifyPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void PenCancelButton_Click(object sender, EventArgs e)
        {
            PModifyPanel.Hide();
            PListPanel.Hide();
            DListPanel.Show();
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

        private void PListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DButton_Click(object sender, EventArgs e)
        {
            DeliveryRequest X = new DeliveryRequest();
            X.Show();
        }
    }
}
