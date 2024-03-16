using System.Windows.Forms;
using System.Xml.Linq;

namespace products
{
    public partial class Form1 : Form
    {
        DB db;
        int productsCount = 0;
        int offset = 0;
        public Form1()
        {
            InitializeComponent();
            db = new DB("Server=localhost;Port=5432;Database=products;Username=postgres;Password=postgres;");
            List<Product> products = db.getProducts();
            productsCount = products.Count;
            fillDataGridView();
            fillTypesSelect();
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void filterSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            offset = 0;
            fillDataGridView();
        }

        private void sortSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void sortDirectionSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            fillDataGridView();
        }

        private void fillDataGridView()
        {
            string searchString = searchInput.Text;
            string sortFieldSelectText = sortFieldSelect.Text;
            string sortDirectionSelectText = sortDirectionSelect.Text;
            string type = filterSelect.Text == "��� ����" ? "" : filterSelect.Text;
            int itemsPerPage = productsCount > 10 ? 5 : productsCount;

            string orderField;
            if (sortFieldSelectText == "�� �����") orderField = "name";
            else if (sortFieldSelectText == "�� ������ ����") orderField = "workshopnumber";
            else orderField = "price";

            string orderDirection;
            if (sortDirectionSelectText == "�� �����������") orderDirection = "ASC";
            else orderDirection = "DESC";

            List<Product> filteredProducts = db.getProducts(searchString, orderField, orderDirection, type);
            productsCount = filteredProducts.Count;

            productsDataGridView.Rows.Clear();
            List<Product> products = db.getProducts(searchString, orderField, orderDirection, type, offset, itemsPerPage);
            for (int i = 0; i < products.Count; i++)
            {
                productsDataGridView.Rows.Add(products[i].vendorCode, products[i].workshopNumber, products[i].price, products[i].name, products[i].type, products[i].img);
            }
        }

        private void fillTypesSelect()
        {
            List<Product> products = db.getProducts();
            List<string> types = products.Select(product => product.type).Distinct().ToList();
            filterSelect.Items.AddRange(types.ToArray());
        }

        private void DrawBarcode(string code, int resolution = 20) // resolution - �������� �� ���������
        {
            int numberCount = 15; // ���������� ����
            float height = 25.93f * resolution; // ������ ����� ����
            float lineHeight = 22.85f * resolution; // ������ ������
            float leftOffset = 3.63f * resolution; // ��������� ���� �����
            float rightOffset = 2.31f * resolution; // ��������� ���� ������
                                                    //������, ������� �������� ������ � ����� �������������� �����,
                                                    //� ����� ����������� �������������� ���� ������ ���� �������� ���� �� 1,65��
            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 1.5f * resolution; // ������ ����
            float lineToFontOffset = 0.165f * resolution; // ����������� ������ �� �������� ���� ���� �� ������� ���� �������
            float lineWidthDelta = 0.15f * resolution; // ������ 0.15*{�����}
            float lineWidthFull = 1.35f * resolution; // ������ ����� ������� ��� 0 ��� 0.15*9
            float lineOffset = 0.2f * resolution; // ����� �������� ������ ���� ���������� � 0.2��

            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset); // ������ �����-����

            Bitmap bitmap = new Bitmap((int)width, (int)height); // �������� �������� ������ ��������
            Graphics g = Graphics.FromImage(bitmap); // �������� �������

            Font font = new Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel); // �������� ������

            StringFormat fontFormat = new StringFormat(); // ������������� ������
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;

            float x = leftOffset; // ������� ��������� �� x
            for (int i = 0; i < numberCount; i++)
            {
                int number = Convert.ToInt32(code[i].ToString()); // ����� �� ����
                if (number != 0)
                {
                    g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight); // ������ �����
                }
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight); // ����� ��� �����
                g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat); // ������ �����
                x += lineWidthFull + lineOffset; // ������� ������� ��������� �� x

                if (i == 0 && i == numberCount / 2 && i == numberCount - 1) // ���� ��� ������, �������� ��� ����� ���� ������ �����������
                {
                    for (int j = 0; j < 2; j++) // ������ 2 ����� �����������
                    {
                        g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight); // ������ ������� �����
                        x += lineWidthDelta + lineOffset; // ������� ������� ��������� �� x
                    }
                }
                barCodePictureBox.SizeMode = PictureBoxSizeMode.Zoom; // ������ ����� �������� ���������� � pictureBox
                barCodePictureBox.Image = bitmap; // ������������� ��������
            }
        }

        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(barCodePictureBox.Width, barCodePictureBox.Height);
            barCodePictureBox.DrawToBitmap(myBitmap1, new Rectangle(0, 0, barCodePictureBox.Width, barCodePictureBox.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }

        private void prevPageBtn_Click(object sender, EventArgs e)
        {
            if (productsCount > 10 && offset > 0)
            {
                offset -= 5;
                fillDataGridView();
            }
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            if (productsCount > 10 && offset < productsCount - 5)
            {
                offset += 5;
                fillDataGridView();
            }
        }

        private void productsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string vendorCode = productsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            DrawBarcode(vendorCode, 200);
            string imgUrl = productsDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            pictureBox.Load(imgUrl);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
            myPrinDialog1.Document = myPrintDocument1;
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
        }

        private void barCodePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
