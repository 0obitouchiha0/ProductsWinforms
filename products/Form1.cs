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
            db = new DB("Server=localhost;Port=5432;Database=maks;Username=postgres;Password=postgres;");
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

            string orderField;
            if (sortFieldSelectText == "По имени") orderField = "title";
            else if (sortFieldSelectText == "По номеру цеха") orderField = "productionworkshopnumber";
            else orderField = "mincostforagent";

            string orderDirection;
            if (sortDirectionSelectText == "По возрастанию") orderDirection = "ASC";
            else orderDirection = "DESC";

            List<Product> filteredProducts = db.getProducts(searchString, orderField, orderDirection, type);
            productsCount = filteredProducts.Count;
            int itemsPerPage = productsCount > 20 ? 20 : productsCount;

            productsDataGridView.Rows.Clear();
            List<Product> products = db.getProducts(searchString, orderField, orderDirection, type, offset, itemsPerPage);
            for (int i = 0; i < products.Count; i++)
            {
                productsDataGridView.Rows.Add(products[i].id, products[i].title, products[i].type, products[i].articlenumber, products[i].description, products[i].image, products[i].productionpersoncount, products[i].productionworkshopnumber, products[i].mincostforagent);
            }
        }

        private void fillTypesSelect()
        {
            List<Product> products = db.getProducts();
            List<string> types = products.Select(product => product.type).Distinct().ToList();
            filterSelect.Items.AddRange(types.ToArray());
        }

        private void prevPageBtn_Click(object sender, EventArgs e)
        {
            if (productsCount > 20 && offset > 0)
            {
                offset -= 20;
                fillDataGridView();
            }
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            if (productsCount > 20 && offset < productsCount - 20)
            {
                offset += 20;
                fillDataGridView();
            }
        }
    }
}
