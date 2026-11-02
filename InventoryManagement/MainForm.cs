using AutoUpdaterDotNET;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class MainForm : Form
    {
        private Form activeForm = null;
        private Button currentNavButton = null;

        public MainForm()
        {
            InitializeComponent();
            InitSidebarStyles();
        }

        private void InitSidebarStyles()
        {
            Button[] navButtons = new Button[]
            {
                btnNavProduct, btnNavCustomer, btnNavCategories, btnNavUser,
                btnNavPurchase, btnNavOrder, btnNavStockMove, btnNavDelivery,
                btnNavBill, btnNavPayment, btnNavCOA
            };

            foreach (var btn in navButtons)
            {
                UITheme.StyleSidebarButton(btn, false);
            }
        }

        public void openChildForm(Form childForm, Button navButton = null, string title = "", string subtitle = "")
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (navButton != null)
            {
                if (currentNavButton != null)
                {
                    UITheme.SetSidebarActive(currentNavButton, false);
                }
                currentNavButton = navButton;
                UITheme.SetSidebarActive(currentNavButton, true);
            }

            if (!string.IsNullOrEmpty(title))
            {
                lblModuleTitle.Text = title;
                lblModuleSubtitle.Text = subtitle;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Default view: Buka Data Produk
            openChildForm(new ProductForm(), btnNavProduct, "Data Produk", "Manajemen data barang, stok, dan harga");
            CheckForUpdates();
        }

        // Navigation Handlers: Master Data
        private void btnNavProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm(), btnNavProduct, "Data Produk", "Manajemen data barang, stok, dan harga");
        }

        private void btnNavCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm(), btnNavCustomer, "Partner & Customer", "Daftar vendor dan customer rekanan bisnis");
        }

        private void btnNavCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm(), btnNavCategories, "Kategori Produk", "Klasifikasi dan pengelompokan barang inventaris");
        }

        private void btnNavUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm(), btnNavUser, "Manajemen Pengguna", "Kelola akun pengguna, hak akses, dan password");
        }

        // Navigation Handlers: Transaksi & Logistik
        private void btnNavPurchase_Click(object sender, EventArgs e)
        {
            openChildForm(new PurchaseForm(), btnNavPurchase, "Purchase Order", "Pencatatan pembelian barang dan penerimaan faktur dari vendor");
        }

        private void btnNavOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm(), btnNavOrder, "Sales Order", "Pencatatan transaksi penjualan dan pemesanan pelanggan");
        }

        private void btnNavStockMove_Click(object sender, EventArgs e)
        {
            openChildForm(new StockMoveForm(), btnNavStockMove, "Stock Move", "Mutasi perpindahan stok barang antar lokasi/gudang");
        }

        private void btnNavDelivery_Click(object sender, EventArgs e)
        {
            openChildForm(new DeliveryForm(), btnNavDelivery, "Pengiriman (Delivery)", "Pelacakan dan status surat jalan pengiriman");
        }

        // Navigation Handlers: Keuangan & Akuntansi
        private void btnNavBill_Click(object sender, EventArgs e)
        {
            openChildForm(new VendorBillForm(), btnNavBill, "Vendor Bill", "Tagihan faktur vendor dan jadwal jatuh tempo pembayaran");
        }

        private void btnNavPayment_Click(object sender, EventArgs e)
        {
            openChildForm(new VendorPaymentForm(), btnNavPayment, "Vendor Payment", "Pelunasan tagihan vendor dan rekonsiliasi kas/bank");
        }

        private void btnNavCOA_Click(object sender, EventArgs e)
        {
            openChildForm(new MasterCoaForm(), btnNavCOA, "Master Chart of Accounts (COA)", "Struktur bagan akun akuntansi standar");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panelTopHeader_Paint(object sender, PaintEventArgs e)
        {
            // Garis pembatas halus di bawah header
            using (Pen pen = new Pen(UITheme.Border, 1))
            {
                e.Graphics.DrawLine(pen, 0, panelTopHeader.Height - 1, panelTopHeader.Width, panelTopHeader.Height - 1);
            }
        }

        private void panelBottomStatus_Paint(object sender, PaintEventArgs e)
        {
            // Garis pembatas halus di atas status bar
            using (Pen pen = new Pen(UITheme.Border, 1))
            {
                e.Graphics.DrawLine(pen, 0, 0, panelBottomStatus.Width, 0);
            }
        }

        private void CheckForUpdates()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                AutoUpdater.ParseUpdateInfoEvent += AutoUpdaterOnParseUpdateInfoEvent;
                string jsonUrl = "https://raw.githubusercontent.com/Nathanaelhend/inventory-management-testing/main/update.json";
                AutoUpdater.Start(jsonUrl);
            }
            catch (Exception ex)
            {
                // Silent fail or log so update check doesn't block UI
                System.Diagnostics.Debug.WriteLine($"Update check error: {ex.Message}");
            }
        }

        private void AutoUpdaterOnParseUpdateInfoEvent(ParseUpdateInfoEventArgs args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args.RemoteData))
                {
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(args.RemoteData);
                    bool isMandatory = json.mandatory != null && json.mandatory.value != null ? (bool)json.mandatory.value : false;
                    args.UpdateInfo = new UpdateInfoEventArgs
                    {
                        CurrentVersion = json.version,
                        DownloadURL = json.url,
                        ChangelogURL = json.changelog,
                        Mandatory = new Mandatory
                        {
                            Value = isMandatory
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Update json parse error: {ex.Message}");
            }
        }

        private void lblStatusText_Click(object sender, EventArgs e)
        {

        }
    }
}