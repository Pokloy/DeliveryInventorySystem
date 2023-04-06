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
    public partial class DeliveryRequest : MetroForm
    {
        public DeliveryRequest()
        {
            InitializeComponent();
        }
        DatabaseController Datac = new DatabaseController();
        string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=db_cardinventory";
         private void Cleartextbox()
        {
            Seraltxtbox.Clear();
            Dtype.Clear();
            ProdExpirytxtbox.Clear();
            AddPendIDtxtbox.Clear();
            AddDelIDtxtbox.Clear();
            pnametxtbox.Clear();
           
        }
        private void ProductEdit_Load(object sender, EventArgs e)
        {

        }
        
        private void RList_Click(object sender, EventArgs e)
        {
            AddProductPanel.Hide();
            DelArrivPanel.Hide();
            DelModPanel.Show();
            
        }
        public void MovetoDelConfirPanel()
        {
            AddProductPanel.Hide();
            DelModPanel.Hide();
            DelArrivPanel.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MovetoDelConfirPanel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult X = MessageBox.Show("Are you sure the product has arrived?", "Arrival Product Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (X == DialogResult.Yes)
            {
                if (Delivery_ID.Text == "" || Pend_IDtxtbox.Text == "" || ProdNametxtbox.Text == "" || Locationtxtbox.Text == "" || Quantxtbox.Text == "" || Delivertxtbox.Text == "" || Deliverstatstxtbox.Text == "" || Remarks.Text == "")
                {
                    MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
                }
                else
                {
                    Datac.query = "Update tb_deliverytab, tb_pendproduct Set tb_deliverytab.delivery_status = 'Delivered', tb_pendproduct.requestprod = 'In Stored/ Delivered' WHERE tb_deliverytab.delivery_id = '" + Delivery_ID.Text + "' AND tb_pendproduct.pending_id = '" + Pend_IDtxtbox.Text + "'";
                    Datac.runQuery();
                    pnametxtbox.Text = ProdNametxtbox.Text;
                    Quatxtbox.Text = Quantxtbox.Text;
                    AddPendIDtxtbox.Text = Pend_IDtxtbox.Text;
                    AddDelIDtxtbox.Text = Delivery_ID.Text;

                    DelArrivPanel.Hide();
                    DelModPanel.Hide();
                    AddProductPanel.Show();
                }
            }
            else
            {
                MessageBox.Show("Please wait for the delivery before inputting the information needed.");
            }



            
           



        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (ProductNametxtbox.Text == "" || QuantityTxtBox.Text == "" || RemarksTxtBox.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                Datac.SuccessMessage = "Delivery Request Sent Successfully!";
                Datac.FailedMessage = "Delivery Request Sent Successfully!";
                Datac.query = "INSERT INTO tb_pendproduct(requestprod,productname,Quantity,Remarks,user_id) VALUES('Pending','" + ProductNametxtbox.Text + "','" + QuantityTxtBox.Text + "','" + RemarksTxtBox.Text + "','" + Datac.CurrentUser() + "')";
                Datac.AddrunQuery();
                ProductNametxtbox.Clear();
                QuantityTxtBox.Clear();
                RemarksTxtBox.Clear();
            }
           


        }
        
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (Delivery_ID.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                Datac.SuccessMessage = "Product Found.";
                Datac.FailedMessage = "Product Not Found";
                Datac.arrayquery[5] = "delivery_date";
                Datac.arrayquery[6] = "delivery_status";
                Datac.arrayquery[7] = "Location";
                Datac.arrayquery[8] = "pending_id";
                Datac.arrayquery[9] = "user_id";
                Datac.query = "select * from tb_deliverytab WHERE delivery_id = " + Delivery_ID.Text + "";
                Datac.Readrunquery();
                Delivertxtbox.Text = Datac.arrayquery[0];
                Deliverstatstxtbox.Text = Datac.arrayquery[1];
                Locationtxtbox.Text = Datac.arrayquery[2];
                Pend_IDtxtbox.Text = Datac.arrayquery[3];
                Datac.arrayquery[10] = Datac.arrayquery[4];
            }
        }

        private void Pend_IDtxtbox_TextChanged(object sender, EventArgs e)
        {
            if (Pend_IDtxtbox.Text != string.Empty)
            {
                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                MySqlCommand commandDatabase = new MySqlCommand("select * from tb_pendproduct WHERE pending_id = " + Pend_IDtxtbox.Text + "", databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myreader = commandDatabase.ExecuteReader();
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        ProdNametxtbox.Text = myreader["productname"].ToString();
                        Quantxtbox.Text = myreader["Quantity"].ToString();
                        Remarks.Text = myreader["Remarks"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Product not found");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (AddPendIDtxtbox.Text == "" || AddDelIDtxtbox.Text == "" || Seraltxtbox.Text == "" || pnametxtbox.Text == "" || Dtype.Text == "" || ProdExpirytxtbox.Text == ""|| Quatxtbox.Text == "")
            {
                MessageBox.Show("Please Fill out all information needed.\n We notice a few textbox are missing.");
            }
            else
            {
                Datac.SuccessMessage = "Product Added Successfully!";
                Datac.FailedMessage = "Product Not Added Successfully!";
                Datac.query = "INSERT INTO tb_productinfo(serialno,productname,producttype,productexpiry,Quantity,user_id) VALUES('" + Seraltxtbox.Text + "','" + pnametxtbox.Text + "','" + Dtype.Text + "','" + ProdExpirytxtbox.Text + "','" + Quatxtbox.Text + "','" + Datac.CurrentUser() + "') ";
                Datac.AddrunQuery();
                Cleartextbox();
                MovetoDelConfirPanel();
            }


        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H = new Home();
            H.Show();
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product P = new Product();
            P.Show();
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery D = new Delivery();
            D.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery D = new Delivery();
            D.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult X = MessageBox.Show("Are you sure you dont want to add item?", "Add Product Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (X == DialogResult.Yes)
            {
                Datac.query = "Update tb_deliverytab, tb_pendproduct Set tb_deliverytab.delivery_status = 'In Delivery', tb_pendproduct.requestprod = 'Approved' WHERE tb_deliverytab.delivery_id = '" + Delivery_ID.Text + "' AND tb_pendproduct.pending_id = '" + Pend_IDtxtbox.Text + "'";
                Datac.runQuery();
                AddProductPanel.Hide();
                DelArrivPanel.Show();
            }
            else
            {
                Cleartextbox();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DialogResult X = MessageBox.Show("Are you sure you dont want to request item?", "Request Product Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (X == DialogResult.Yes)
            {
                this.Hide();
                Delivery Y = new Delivery();
                Y.Show();
            }
            else
            {
                Cleartextbox();
            }
           
        }

        private void AddDelIDtxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DelArrivPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Datac.UserAuditLog_Out();
            if (Datac.Question == DialogResult.Yes)
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
