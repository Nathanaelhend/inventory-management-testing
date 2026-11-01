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

using System.Runtime.InteropServices;

namespace InventoryManagement
{
    public partial class MasterCoaForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\IMS Program\dbMS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public MasterCoaForm()
        {
            InitializeComponent();
            UITheme.StylePrimaryButton(btnSave);
            UITheme.StyleSecondaryButton(btnClear);
            btnClear.Click += (s, e) => Clear();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(UITheme.Border, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panelCard.Width - 1, panelCard.Height - 1);
            }
        }

        private void MasterCoaForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(UITheme.BorderDark, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
