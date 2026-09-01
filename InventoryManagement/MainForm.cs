using AutoUpdaterDotNET;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net; // Ditambahkan untuk WebClient & ServicePointManager
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class MainForm : Form
    {
        private readonly string githubToken = "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";

        public MainForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void btnCOA_Click(object sender, EventArgs e)
        {
            openChildForm(new PurchaseForm());
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            openChildForm(new StockMoveForm());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void CheckForUpdates()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // 1. Set Auth Token untuk membaca XML/JSON dan saat mengunduh ZIP
                AutoUpdater.BasicAuthXML = new BasicAuthentication("", githubToken);
                AutoUpdater.BasicAuthDownload = new BasicAuthentication("", githubToken);

                // 2. Hubungkan Event Parser JSON
                AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;

                // 3. Panggil URL RAW update.json
                string jsonUrl = "https://raw.githubusercontent.com/Nathanaelhend/inventory-management-testing/main/update.json";

                // Eksekusi AutoUpdater (Dialog bawaan akan muncul, lalu otomatis mendownload & extract)
                AutoUpdater.Start(jsonUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengecek update: {ex.Message}");
            }
        }

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args.RemoteData))
                {
                    // Parsing JSON dari GitHub
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(args.RemoteData);

                    args.UpdateInfo = new UpdateInfoEventArgs
                    {
                        CurrentVersion = json.version,
                        DownloadURL = json.url,
                        ChangelogURL = json.changelog
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menguraikan JSON update: " + ex.Message);
            }
        }
    }
}