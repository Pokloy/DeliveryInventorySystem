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
    public partial class AdminDelivery : MetroForm
    {
        public AdminDelivery()
        {
            InitializeComponent();
        }
        DatabaseController DataC = new DatabaseController();
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
        string query, pendingid;
        string[] nullcontainers = new string[10];
        private void LoadData()
        {
            MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString);
            sqlCon.Open();
            MySqlDataAdapter sqlDA = new MySqlDataAdapter(query, sqlCon);
            DataTable dtbl = new DataTable();
            sqlDA.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView2Pend.DataSource = dtbl;
        }
        public void ClearTextBox()
        {
            AddDPnametxtbox.Clear();
            AddDDelDatetxtbox.Clear();
            AddDQuantitytxtbox.Clear();
            AddDDelStatstxtbox.Clear();
            AddDLoctxtbox.Clear();
            APendingidtxtbox.Clear();
            AProdnametxtbox.Clear();
            AQualitytxtbox.Clear();
            ALocationtxtbox.Clear();
            ARemarkstxtbox.Clear();
            APendingStatstxtbox.Clear();
            ModDelDatetxtbox.Clear();
            ModDeliveryidtxtbox.Clear();
            ModDelStatstxtbox.Clear();
            ModLoctxtbox.Clear();
        }
        private void AdminDelivery_Load(object sender, EventArgs e)
        {
            query = "Select * From tb_deliverytab";
            LoadData();
        }

        private void PListButton_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_deliverytab";
            LoadData();
            DeliverGoodsPanel.Hide();
            ModDeliverPanel.Hide();
            PendListPanel.Hide();
            PendApprovalPanel.Hide();
            DListPanel.Show();
        }

        private void PLButton_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_pendproduct";
            LoadData();
            DeliverGoodsPanel.Hide();
            ModDeliverPanel.Hide();
            DListPanel.Hide();
            PendApprovalPanel.Hide();
            PendListPanel.Show();

        }

        private void RList_Click(object sender, EventArgs e)
        {
            DeliverGoodsPanel.Hide();
            ModDeliverPanel.Hide();
            DListPanel.Hide();
            PendListPanel.Hide();
            PendApprovalPanel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PendApprovalPanel.Hide();
            ModDeliverPanel.Hide();
            DListPanel.Hide();
            PendListPanel.Hide();
            DeliverGoodsPanel.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeliverGoodsPanel.Hide();
            PendListPanel.Hide();
            DListPanel.Hide();
            PendApprovalPanel.Hide();
            ModDeliverPanel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PendApprovalPanel.Hide();
            ModDeliverPanel.Hide();
            DListPanel.Hide();
            PendListPanel.Hide();
            DeliverGoodsPanel.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (APendingStatstxtbox.Text == "Pending")
            { 
                MessageBox.Show("Request information updated. Pending status in present");
            }
            else if (APendingStatstxtbox.Text == "Approved")
            {
                pendingid = APendingidtxtbox.Text;
                AddDPnametxtbox.Text = AProdnametxtbox.Text;
                AddDQuantitytxtbox.Text = AQualitytxtbox.Text;
                DataC.query = "UPDATE tb_pendproduct SET requestprod = '" + APendingStatstxtbox.Text + "' , productname = '" + AProdnametxtbox.Text + "' , Quantity = '" + AQualitytxtbox.Text + "' , Remarks = '" + ARemarkstxtbox.Text + "' , user_id = '" + DataC.CurrentUser() + "' WHERE pending_id = '" + APendingidtxtbox.Text + "'; ";
                DataC.UpdaterunQuery();
                MessageBox.Show("Delivery Request Approved. Will now proceed to Delivery Goods");
                PendApprovalPanel.Hide();
                ModDeliverPanel.Hide();
                DListPanel.Hide();
                PendListPanel.Hide();
                DeliverGoodsPanel.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("Please specify what is the Pending Status in this request.\n If yes it will be Approved if no it will be Pending", "Pending Status Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Since you choose yes the Pending Status will be filled with Approved");
                    APendingStatstxtbox.Text = "Approved";
                }
                else
                {

                    MessageBox.Show("Since you choose no the Pending Status will be filled with Pending");
                    APendingStatstxtbox.Text = "Pending";

                }
            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            DeliverGoodsPanel.Hide();
            ModDeliverPanel.Hide();
            DListPanel.Hide();
            PendApprovalPanel.Hide();
            PendListPanel.Show();
            ClearTextBox();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            AddDDelStatstxtbox.Text = "In Delivery";
            DataC.SuccessMessage = "Delivery added successfully";
            DataC.FailedMessage = "Delivery not added successfully";
            DataC.query = "INSERT INTO tb_deliverytab(delivery_date,delivery_status,Location,user_id,pending_id) VALUES ('" + AddDDelDatetxtbox.Text + "','"+AddDDelStatstxtbox.Text+"','" + AddDLoctxtbox.Text + "','"+DataC.CurrentUser()+"','"+pendingid+ "')";
            DataC.AddrunQuery();
            MessageBox.Show("Goods now be in delivery.");
            ClearTextBox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeliverGoodsPanel.Hide();
            PendListPanel.Hide();
            DListPanel.Hide();
            PendApprovalPanel.Hide();
            ModDeliverPanel.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome X = new AdminHome();
            X.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUsers X = new AdminUsers();
            X.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminProduct X = new AdminProduct();
            X.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_deliverytab";
            LoadData();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_pendproduct";
            LoadData();
        }

        private void AProdnametxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ASearchbutton_Click(object sender, EventArgs e)
        {
            DataC.arrayquery[5] = "requestprod";
            DataC.arrayquery[6] = "productname";
            DataC.arrayquery[7] = "Quantity";
            DataC.arrayquery[8] = "Remarks";
            DataC.arrayquery[9] = "user_id";
            DataC.query = "select * from tb_pendproduct WHERE pending_id = " + APendingidtxtbox.Text + "";
            DataC.Readrunquery();
            APendingStatstxtbox.Text = DataC.arrayquery[0];
            AProdnametxtbox.Text = DataC.arrayquery[1];
            AQualitytxtbox.Text = DataC.arrayquery[2];
            ARemarkstxtbox.Text = DataC.arrayquery[3];
            ALocationtxtbox.Text = DataC.arrayquery[4];


        }

        private void ModEditButton_Click(object sender, EventArgs e)
        {
            DataC.query = "UPDATE tb_deliverytab SET delivery_date = '" + ModDelDatetxtbox.Text + "' , delivery_status = '" + ModDelStatstxtbox.Text + "' , Location = '" + ModLoctxtbox.Text + "' , user_id = '" + DataC.CurrentUser() + "' WHERE delivery_id = '" + ModDeliveryidtxtbox.Text + "'; ";
            DataC.UpdaterunQuery();
            MessageBox.Show("Request information updated.");
            ClearTextBox();
        }

        private void ModDeleteButton_Click(object sender, EventArgs e)
        {

            if (ModDelStatstxtbox.Text == "In Delivery")
            {
                DialogResult result = MessageBox.Show("This is still currently in Delivery Means it is still in delivery. Would you like to proceed?", "Delivery Status Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Since you choose yes the Delivery Information you requested will be deleted");
                    DataC.query = "DELETE FROM tb_deliverytab WHERE delivery_id = '" + ModDeliveryidtxtbox.Text + "'; ";
                    DataC.FailedMessage = "Information Not Deleted Successfully";
                    DataC.SuccessMessage = "Information Deleted Successfully";
                    DataC.DeleterunQuery();
                    ClearTextBox();
                }
                else
                {

                    MessageBox.Show("Please double check on all the info you before you proceed.");
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delivery Status Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DataC.query = "DELETE FROM tb_deliverytab WHERE delivery_id = '" + ModDeliveryidtxtbox.Text + "'; ";
                    DataC.FailedMessage = "Information Not Deleted Successfully";
                    DataC.SuccessMessage = "Information Deleted Successfully";
                    DataC.DeleterunQuery();
                    ClearTextBox();
                }
                else
                {

                    MessageBox.Show("Please double check on all the info you before you proceed.");
                }
            }
        }

        private void ButtonDelDec_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM tb_deliverytab ORDER BY delivery_id DESC";
            LoadData();
        }

        private void ButtonDelAsc_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM tb_deliverytab ORDER BY delivery_id ASC";
            LoadData();
        }

        private void ButtonDelSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT* FROM `tb_deliverytab` WHERE(delivery_id = '" + TextBoxDelSearch.Text + "' OR delivery_date = '" + TextBoxDelSearch.Text + "' OR delivery_status = '" + TextBoxDelSearch.Text + "' OR Location = '" + TextBoxDelSearch.Text + "' OR user_id = '" + TextBoxDelSearch.Text + "' OR pending_id = '" + TextBoxDelSearch.Text + "')";
            LoadData();
        }

        private void DListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DelnewWindows_Click(object sender, EventArgs e)
        {
            AdminDelivery X = new AdminDelivery();
            X.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DeliverGoodsPanel.Hide();
            PendListPanel.Hide();
            ModDeliverPanel.Hide();
            PendApprovalPanel.Hide();
            DListPanel.Show();
        }

        private void PendAnotherWindowButton_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_pendproduct";
            LoadData();
            AdminDelivery X = new AdminDelivery();
            X.Show();

        }

        private void PendSortDButton_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM tb_pendproduct ORDER BY pending_id DESC";
            LoadData();
        }

        private void PendSortAButton_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM tb_pendproduct ORDER BY pending_id ASC";
            LoadData();
        }

        private void PendSearchButton_Click(object sender, EventArgs e)
        {
            query = "SELECT* FROM tb_pendproduct WHERE(pending_id = '" + TxtBoxPendSearch.Text + "' OR requestprod = '" + TxtBoxPendSearch.Text + "' OR productname = '" + TxtBoxPendSearch.Text + "' OR Quantity = '" + TxtBoxPendSearch.Text + "' OR Remarks = '" + TxtBoxPendSearch.Text + "' OR user_id = '" + TxtBoxPendSearch.Text + "')";
            LoadData();
        }

        private void PendDeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void PendEditButton_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_pendproduct";
            LoadData();
            DeliverGoodsPanel.Hide();
            ModDeliverPanel.Hide();
            DListPanel.Hide();
            PendApprovalPanel.Hide();
            PendListPanel.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            query = "Select * From tb_deliverytab";
            LoadData();
            DeliverGoodsPanel.Hide();
            ModDeliverPanel.Hide();
            PendListPanel.Hide();
            PendApprovalPanel.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {


            if (APendingidtxtbox.Text == "" || APendingStatstxtbox.Text == "" || AProdnametxtbox.Text == "" || AQualitytxtbox.Text == "" || ARemarkstxtbox.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete pending item", "Pending Status Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (APendingStatstxtbox.Text == "Pending" || APendingStatstxtbox.Text == "PENDING" || APendingStatstxtbox.Text == "Delivered/In Stored")
                    {
                        DataC.query = "DELETE FROM tb_pendproduct WHERE pending_id = '" + APendingidtxtbox.Text + "'";
                        DataC.SuccessMessage = "Product Deleted Successfully.";
                        DataC.FailedMessage = "Product Delete Failed Successfully.";
                        try
                        {
                            DataC.DeleterunQuery();
                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("Cannot delete the pending item "+ AProdnametxtbox.Text + ".\nPlease delete the delivery item 1st based on delivery id: "+ APendingidtxtbox.Text, "Pending Warning");
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

        private void button11_Click(object sender, EventArgs e)
        {
            DataC.arrayquery[5] = "delivery_date";
            DataC.arrayquery[6] = "delivery_status";
            DataC.arrayquery[7] = "Location";
            DataC.arrayquery[8] = "user_id";
            DataC.arrayquery[9] = "pending_id";
            DataC.query = "select * from tb_deliverytab WHERE delivery_id = " + ModDeliveryidtxtbox.Text + "";
            DataC.Readrunquery();
            ModDelDatetxtbox.Text = DataC.arrayquery[0];
            ModDelStatstxtbox.Text = DataC.arrayquery[1];
            ModLoctxtbox.Text = DataC.arrayquery[2];
            nullcontainers[0]= DataC.arrayquery[3];
            nullcontainers[1] = DataC.arrayquery[4];
        }
    }
}
