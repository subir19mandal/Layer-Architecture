using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProductEntryApp.BLL;
using ProductEntryApp.DAL.DAO;

namespace ProductEntryApp.UI
{
    public partial class ProductEntryUI : Form
    {
        ProductManager aProductManager = new ProductManager();
        public ProductEntryUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.ProductCode = productCodeTextBox.Text;
            aProduct.Description = descriptionTextBox.Text;
            aProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
            
            ProductManager aProductManager =new ProductManager();
            string message = aProductManager.Save(aProduct);
            MessageBox.Show(message);
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            productListView.Items.Clear();
            ListViewItem aListViewItem = new ListViewItem();
            List<Product> aProducList = aProductManager.GetAll();
            foreach (Product product in aProducList)
            {
                aListViewItem = new ListViewItem();

                aListViewItem.Text = product.ProductCode;
                aListViewItem.SubItems.Add(product.Description);
                aListViewItem.SubItems.Add(product.Quantity.ToString());

                productListView.Items.Add(aListViewItem);
            }

            totalQuantityTextBox.Text = aProductManager.GetTotalQuantity().ToString();
        }
    }
}
