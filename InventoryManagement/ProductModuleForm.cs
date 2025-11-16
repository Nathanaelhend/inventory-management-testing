using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace InventoryManagement
{
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboBoxCategory.Items.Clear();
            cmd = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read()) {
                comboBoxCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Clear()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtDesc.Clear();
            txtQty.Clear();
            comboBoxCategory.Items.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this record?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbProduct(pName,pQty,pPrice,pDescription,pCategory) VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", con);
                    cmd.Parameters.AddWithValue("@pname", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtQty.Text));
                    cmd.Parameters.AddWithValue("@pprice", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@pdescription", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@pcategory", comboBoxCategory.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been Successfully saved");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to update this record?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbProduct SET pName=@pname, pQty=@pqty, pPrice=@pprice, pDescription=@pdescription, pCategory=@pcategory WHERE pId LIKE '" + lblProductId.Text + "'", con);
                    cmd.Parameters.AddWithValue("@pname", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtQty.Text));
                    cmd.Parameters.AddWithValue("@pprice", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@pdescription", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@pcategory", comboBoxCategory.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been succesfully updated!");
                    Clear();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
