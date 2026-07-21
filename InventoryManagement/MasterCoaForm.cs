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

namespace InventoryManagement
{
    public partial class MasterCoaForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public MasterCoaForm()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            txtCode.Clear();
            txtName.Clear();
            comboType.SelectedIndex = -1;
            comboNormBalance.SelectedIndex = -1;
            checkGroup.Checked = false;
            checkActive.Checked = false;
            txtDesc.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this record?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbAccount(code,name,type,normal_balance,is_group,is_active,description)VALUES(@code,@name,@type,@normal_balance,@is_group,@is_active,@description)", con);
                    cmd.Parameters.AddWithValue("@code", txtCode.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@type", comboType.Text);
                    cmd.Parameters.AddWithValue("@normal_balance", comboNormBalance.Text);
                    cmd.Parameters.AddWithValue("@is_group", checkGroup.Checked);
                    cmd.Parameters.AddWithValue("@is_active", checkActive.Checked);
                    cmd.Parameters.AddWithValue("@description", txtDesc.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Account Successfully Saved!");
                    Clear();
                    //this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
