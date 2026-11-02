using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class DeliveryDetailForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private readonly StockMoveService stockMoveService = new StockMoveService();

        //penampung datagridview
        List<StockMoveLine> ml = new List<StockMoveLine>();
        private string nameSM = null;

        public DeliveryDetailForm(string name)
        {
            InitializeComponent();

            nameSM = name;
            labelName.Text = nameSM;

            UITheme.ApplyGridStyle(dataGridDelivery);
            UITheme.StylePrimaryButton(btnConfirm);
            UITheme.StyleSecondaryButton(btnSave);

            dataGridDelivery.Columns["qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridDelivery.Columns["qty_real"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.Paint += (s, ev) =>
            {
                using (Pen pen = new Pen(UITheme.BorderDark, 1))
                {
                    ev.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            };

            panel1.MouseDown += (s, ev) =>
            {
                if (ev.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }

        private async void DeliveryDetailForm_Load(object sender, EventArgs e)
        {
            await LoadExisting();
        }

        private void ApplyStateUI(string state)
        {
            state = (state ?? "DRAFT").Trim().ToUpper();
            labelState.Text = state;

            if (state == "CONFIRM" || state == "DONE")
            {
                labelState.ForeColor = UITheme.Success;
                btnConfirm.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                labelState.ForeColor = UITheme.Primary;
                btnConfirm.Visible = true;
                btnSave.Visible = true;
            }
        }

        public async Task LoadExisting()
        {
            try
            {
                var detail = await stockMoveService.GetStockMoveByName(nameSM);

                if(detail?.lines != null)
                {
                    dataGridDelivery.Rows.Clear();

                    foreach(var line in detail.lines)
                    {
                        dataGridDelivery.Rows.Add(
                            line.pName,
                            line.qty,
                            line.qty_real,
                            line.@ref,
                            line.pcode,
                            line.state,
                            line.type_line
                        );
                    }
                }

                ApplyStateUI(detail?.state);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ml.Clear();

                foreach (DataGridViewRow row in dataGridDelivery.Rows)
                {
                    ml.Add(new StockMoveLine
                    {
                        pcode = row.Cells["pcode"].Value?.ToString(),
                        pName = row.Cells["pname"].Value?.ToString(),
                        qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
                        qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
                        @ref = row.Cells["ref"].Value?.ToString(),
                        state = row.Cells["state"].Value?.ToString(),
                        type_line = row.Cells["line_type"].Value?.ToString()
                    });
                }

                var payload = new StockMoveDetailResponse
                {
                    header = new StockMove
                    {
                        name = nameSM,
                    },
                    lines = ml
                };

                await stockMoveService.UpdateReceipt(nameSM, payload);

                MessageBox.Show($"Delivery {nameSM} updated successfully.");
                await LoadExisting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ml.Clear();

                foreach (DataGridViewRow row in dataGridDelivery.Rows)
                {
                    ml.Add(new StockMoveLine
                    {
                        pcode = row.Cells["pcode"].Value?.ToString(),
                        pName = row.Cells["pname"].Value?.ToString(),
                        qty = Convert.ToInt32(row.Cells["qty"].Value ?? 0),
                        qty_real = Convert.ToInt32(row.Cells["qty_real"].Value ?? 0),
                        @ref = row.Cells["ref"].Value?.ToString(),
                        state = "CONFIRM",
                        type_line = row.Cells["line_type"].Value?.ToString()
                    });
                }

                var payload = new StockMoveDetailResponse
                {
                    header = new StockMove
                    {
                        name = nameSM,
                    },
                    lines = ml
                };

                await stockMoveService.ConfirmReceipt(nameSM, payload);

                MessageBox.Show($"Delivery {nameSM} confirmed successfully.");
                await LoadExisting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
