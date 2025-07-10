using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Globalization;
using Project_akhir;
using UASS;
using projekfix;

namespace distro
{
    public partial class LaporanPenjualan : Form
    {
        private distroshopDataContext dbContext;
        private PrintDocument printDoc;
        private PrintPreviewDialog printPreviewDialog;
        private int currentRow;
        private pengguna _akun;

        public LaporanPenjualan(pengguna akun)
        {
            InitializeComponent();
            InitializePrinting();
            _akun = akun;

            // ⬇️ Masukkan nama ke label
            lblNamaAdmin.Text = $"Halo, {_akun.NamaLengkap}";
        }

        private void InitializePrinting()
        {
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDoc;
        }

        private void LaporanPenjualan_Load(object sender, EventArgs e)
        {
            LoadLaporanPenjualan(null);
        }

        private void LoadLaporanPenjualan(string keyword)
        {
            try
            {
                using (dbContext = new distroshopDataContext())
                {
                    var query = from p in dbContext.pesanans
                                join dp in dbContext.detailpesanans on p.IdPesanan equals dp.IdPesanan
                                join vp in dbContext.varianproduks on dp.IdVarian equals vp.IdVarian
                                join prod in dbContext.produks on vp.IdProduk equals prod.IdProduk
                                join k in dbContext.kategoris on prod.IdKategori equals k.IdKategori
                                join pel in dbContext.pelanggans on p.IdPelanggan equals pel.IdPelanggan
                                select new { p, dp, vp, prod, k, pel };

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        string lowerKeyword = keyword.ToLower();

                  
                        DateTime searchDate;
                        bool isFullDate = DateTime.TryParse(keyword, out searchDate);

              
                        int searchYear;
                        bool isYear = int.TryParse(keyword, out searchYear) && keyword.Length == 4;

               
                        int searchMonth;
                        bool isMonthNumber = int.TryParse(keyword, out searchMonth) && searchMonth >= 1 && searchMonth <= 12;


                        bool isMonthName = false;
                        int monthFromName = 0;
                        for (int i = 1; i <= 12; i++)
                        {
                            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                            if (dtfi.GetMonthName(i).ToLower().Contains(lowerKeyword) ||
                                dtfi.GetAbbreviatedMonthName(i).ToLower().Contains(lowerKeyword))
                            {
                                isMonthName = true;
                                monthFromName = i;
                                break;
                            }
                        }

                        decimal searchDecimal;
                        bool isDecimal = decimal.TryParse(keyword, out searchDecimal);

                        int searchInt;
                        bool isInt = int.TryParse(keyword, out searchInt);

                        query = query.Where(item =>
                            item.prod.Nama.ToLower().Contains(lowerKeyword) || // Search by Product Name
                            item.pel.Nama.ToLower().Contains(lowerKeyword) || // Search by Customer Name
                            item.k.NamaKategori.ToLower().Contains(lowerKeyword) || // Search by Category Name
                            (item.vp.Ukuran != null && item.vp.Ukuran.ToLower().Contains(lowerKeyword)) || // Search by variant size
                            (item.vp.Warna != null && item.vp.Warna.ToLower().Contains(lowerKeyword)) || // Search by variant color

                            // --- Pencarian Tanggal (tanggal lengkap, bulan, atau tahun) ---
                            (item.p.Tanggal.HasValue && isFullDate && item.p.Tanggal.Value.Date == searchDate.Date) || // Pencarian tanggal lengkap
                            (item.p.Tanggal.HasValue && isYear && item.p.Tanggal.Value.Year == searchYear) || // Pencarian berdasarkan tahun
                            (item.p.Tanggal.HasValue && isMonthNumber && item.p.Tanggal.Value.Month == searchMonth) || // Pencarian berdasarkan nomor bulan
                            (item.p.Tanggal.HasValue && isMonthName && item.p.Tanggal.Value.Month == monthFromName) || // Pencarian berdasarkan nama bulan

                            // Fallback for date parts as string (less efficient but broad)
                            (item.p.Tanggal.HasValue && (
                                item.p.Tanggal.Value.Year.ToString().Contains(lowerKeyword) ||
                                item.p.Tanggal.Value.Month.ToString().Contains(lowerKeyword) ||
                                item.p.Tanggal.Value.Day.ToString().Contains(lowerKeyword)
                            )) ||
                            // --- Akhir Pencarian Tanggal ---

                            (isInt && item.dp.Jumlah == searchInt) || // Exactly match quantity
                            (isDecimal && item.dp.HargaSatuan == searchDecimal) || // Exactly match unit price
                            (isDecimal && item.dp.SubTotal == searchDecimal) || // Exactly match sub total
                            (isDecimal && item.p.TotalHarga == searchDecimal) || // Exactly match total price

    
                            item.dp.Jumlah.ToString().Contains(lowerKeyword) ||
                            item.dp.HargaSatuan.ToString().Contains(lowerKeyword) ||
                            item.dp.SubTotal.ToString().Contains(lowerKeyword) ||
                            item.p.TotalHarga.ToString().Contains(lowerKeyword)
                        );
                    }

                    var laporan = query.Select(item => new
                    {
                        TanggalPesanan = item.p.Tanggal,
                        NamaPelanggan = item.pel.Nama,
                        NamaProduk = item.prod.Nama,
        
                        Varian = (item.vp.Ukuran + " " + item.vp.Warna).Trim(),
                        NamaKategori = item.k.NamaKategori,
                        Jumlah = item.dp.Jumlah,
                        HargaSatuan = item.dp.HargaSatuan,
                        SubTotalDetail = item.dp.SubTotal,
                        TotalHargaPesanan = item.p.TotalHarga
                    });

                    dgvLaporanPenjualan.DataSource = laporan.ToList();


                    decimal totalPenjualan = laporan.Sum(item => item.SubTotalDetail ?? 0m);
                    lblTotalPenjualan.Text = $"Total Penjualan: Rp. {totalPenjualan:N0}"; 
                   
                    dgvLaporanPenjualan.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
        
                MessageBox.Show($"Terjadi kesalahan saat memuat laporan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCariProdukPesanan_TextChanged(object sender, EventArgs e)
        {

            LoadLaporanPenjualan(txtCariProdukPesanan.Text.Trim());
        }

        private void btnTampilkanLaporan_Click(object sender, EventArgs e)
        {

            LoadLaporanPenjualan(txtCariProdukPesanan.Text.Trim());
        }



        private void LaporanPenjualan_FormClosing(object sender, FormClosingEventArgs e)
        {
   
        }

        private void btnInputPemasok_Click(object sender, EventArgs e)
        {
            FormPemasok frm = new FormPemasok(_akun);
            frm.Show();
            this.Hide();
        }


        private void btnCetak_Click(object sender, EventArgs e)
        {
            currentRow = 0;
            printPreviewDialog.ShowDialog();
        }

      
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font headerFont = new Font("Arial", 10, FontStyle.Bold);
            Font dataFont = new Font("Arial", 9); 
            float headerFontHeight = headerFont.GetHeight();
            float dataFontHeight = dataFont.GetHeight();
            int startX = e.MarginBounds.Left;
            int startY = e.MarginBounds.Top;
            int offset = 0;

            graphics.DrawString("Laporan Penjualan", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, startX, startY + offset);
            offset += 30;

            graphics.DrawString($"Total Penjualan: {lblTotalPenjualan.Text}", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, startX, startY + offset);
            offset += 50; 
            Dictionary<string, int> columnWidths = new Dictionary<string, int>
            {
                { "TanggalPesanan", 100 },
                { "NamaPelanggan", 120 },
                { "NamaProduk", 120 },
                { "Varian", 80 },
                { "NamaKategori", 100 },
                { "Jumlah", 60 },
                { "HargaSatuan", 100 },
                { "SubTotalDetail", 100 },
                { "TotalHargaPesanan", 100 }
            };
            int totalColumnsWidth = columnWidths.Values.Sum();
            if (totalColumnsWidth > e.MarginBounds.Width)
            {
                MessageBox.Show("Total lebar kolom melebihi lebar halaman. Beberapa data mungkin terpotong.", "Peringatan Cetak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            int currentX = startX;
            foreach (DataGridViewColumn col in dgvLaporanPenjualan.Columns)
            {
                string headerText = col.HeaderText;
                if (columnWidths.ContainsKey(col.Name))
                {
                    int colWidth = columnWidths[col.Name];
                    RectangleF headerRect = new RectangleF(currentX, startY + offset, colWidth, headerFontHeight);
                    graphics.DrawString(headerText, headerFont, Brushes.Black, headerRect, new StringFormat { Trimming = StringTrimming.EllipsisCharacter });
                    currentX += colWidth;
                }
                else
                {
                    graphics.DrawString(headerText, headerFont, Brushes.Black, currentX, startY + offset);
                    currentX += col.Width + 10;
                }
            }
            offset += (int)headerFontHeight + 10;


            while (currentRow < dgvLaporanPenjualan.Rows.Count)
            {
                if (startY + offset + dataFontHeight > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                DataGridViewRow row = dgvLaporanPenjualan.Rows[currentRow];
                currentX = startX;

                foreach (DataGridViewColumn col in dgvLaporanPenjualan.Columns)
                {
                    DataGridViewCell cell = row.Cells[col.Index];
                    string cellValue = "";

                    if (col.Name == "TanggalPesanan" && cell.Value is DateTime)
                    {
                        cellValue = ((DateTime)cell.Value).ToShortDateString();
                    }
                    else
                    {
               
                        cellValue = cell.Value != null ? cell.Value.ToString() : "";
                    }

                    if (columnWidths.ContainsKey(col.Name))
                    {
                        int colWidth = columnWidths[col.Name];
                        RectangleF cellRect = new RectangleF(currentX, startY + offset, colWidth, dataFontHeight);
                        graphics.DrawString(cellValue, dataFont, Brushes.Black, cellRect, new StringFormat { Trimming = StringTrimming.EllipsisCharacter });
                        currentX += colWidth;
                    }
                    else
                    {
                        graphics.DrawString(cellValue, dataFont, Brushes.Black, currentX, startY + offset);
                        currentX += col.Width + 10;
                    }
                }
                offset += (int)dataFontHeight + 5;
                currentRow++;
            }
            e.HasMorePages = false;
        }

        private void btnVarianProduk_Click(object sender, EventArgs e)
        {
            using (var frm = new VarianProdukkaryawan(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void btnInputProduk_Click(object sender, EventArgs e)
        {
            using (var frm = new InputProduk(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void btnDetailPembelian_Click(object sender, EventArgs e)
        {
            using (var frm = new Detailbeli(_akun))
            {
                this.Close();

                frm.ShowDialog();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var frm = new LoginForm())
            {
                this.Close();

                frm.ShowDialog();

            }
        }
    }
}