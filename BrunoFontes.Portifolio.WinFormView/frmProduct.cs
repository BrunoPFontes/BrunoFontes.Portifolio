using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrunoFontes.Portifolio.Domain;
using BrunoFontes.Portifolio.Repository.ProdBrnd.EF;
using BrunoFontes.Portifolio.Repository.Standard;
using BrunoFontes.Portifolio.WinFormView.ViewModels;

namespace BrunoFontes.Portifolio.WinFormView
{
    public partial class FrmProduct : Form
    {
        private Product productToBeChanged;
        public FrmProduct(Product product = null)
        {
            productToBeChanged = product;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void frmProduct_Load(object sender, EventArgs e)
        {
            RepositoryBrand repositoryBrand = new RepositoryBrand();
            List<Brand> brands = await repositoryBrand.SelectAll();
            List<BrandViewModel> brandViewModels = new List<BrandViewModel>();

            foreach (Brand brand in brands)
            {
                BrandViewModel viewModel = new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
                brandViewModels.Add(viewModel);
            }
            cmbBrands.DataSource = brandViewModels;
            cmbBrands.DisplayMember = "Name";
            cmbBrands.ValueMember = "Id";
            cmbBrands.Refresh();

            if (productToBeChanged != null)
            {
                txbProductName.Text = productToBeChanged.Name;
                cmbBrands.SelectedValue = productToBeChanged.BrandId;
            }
            else
            {
                txbProductName.Text = string.Empty;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IRepositoryGeneric<Product> repositoryProduct = new RepositoryProduct();
            if (productToBeChanged == null)
            {
                Product newProduct = new Product
                {
                    Name = txbProductName.Text.Trim(),
                    BrandId = Convert.ToInt32(cmbBrands.SelectedValue)
                };
                repositoryProduct.Insert(newProduct);
            }
            else
            {
                productToBeChanged.Name = txbProductName.Text;
                productToBeChanged.BrandId = Convert.ToInt32(cmbBrands.SelectedValue);
                repositoryProduct.Update(productToBeChanged);
            }
            Close();
        }
    }
}
