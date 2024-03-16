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
            string type = filterSelect.Text == "Все типы" ? "" : filterSelect.Text;
            int itemsPerPage = productsCount > 10 ? 5 : productsCount;

            string orderField;
            if (sortFieldSelectText == "По имени") orderField = "name";
            else if (sortFieldSelectText == "По номеру цеха") orderField = "workshopnumber";
            else orderField = "price";

            string orderDirection;
            if (sortDirectionSelectText == "По возрастанию") orderDirection = "ASC";
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

        private void DrawBarcode(string code, int resolution = 20) // resolution - пикселей на миллиметр
        {
            int numberCount = 15; // количество цифр
            float height = 25.93f * resolution; // высота штрих кода
            float lineHeight = 22.85f * resolution; // высота штриха
            float leftOffset = 3.63f * resolution; // свободная зона слева
            float rightOffset = 2.31f * resolution; // свободная зона справа
                                                    //штрихи, которые образуют правый и левый ограничивающие знаки,
                                                    //а также центральный ограничивающий знак должны быть удлинены вниз на 1,65мм
            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 1.5f * resolution; // высота цифр
            float lineToFontOffset = 0.165f * resolution; // минимальный размер от верхнего края цифр до нижнего края штрихов
            float lineWidthDelta = 0.15f * resolution; // ширина 0.15*{цифра}
            float lineWidthFull = 1.35f * resolution; // ширина белой полоски при 0 или 0.15*9
            float lineOffset = 0.2f * resolution; // между штрихами должно быть расстояние в 0.2мм

            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset); // ширина штрих-кода

            Bitmap bitmap = new Bitmap((int)width, (int)height); // создание картинки нужных размеров
            Graphics g = Graphics.FromImage(bitmap); // создание графики

            Font font = new Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel); // создание шрифта

            StringFormat fontFormat = new StringFormat(); // Центрирование текста
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;

            float x = leftOffset; // позиция рисования по x
            for (int i = 0; i < numberCount; i++)
            {
                int number = Convert.ToInt32(code[i].ToString()); // число из кода
                if (number != 0)
                {
                    g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight); // рисуем штрих
                }
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight); // рамки для буквы
                g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat); // рисуем букву
                x += lineWidthFull + lineOffset; // смещаем позицию рисования по x

                if (i == 0 && i == numberCount / 2 && i == numberCount - 1) // если это начало, середина или конец кода рисуем разделители
                {
                    for (int j = 0; j < 2; j++) // рисуем 2 линии разделителя
                    {
                        g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight); // рисуем длинный штрих
                        x += lineWidthDelta + lineOffset; // смещаем позицию рисования по x
                    }
                }
                barCodePictureBox.SizeMode = PictureBoxSizeMode.Zoom; // делаем чтобы картинка помещалась в pictureBox
                barCodePictureBox.Image = bitmap; // устанавливаем картинку
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
