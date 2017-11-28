using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrunoFontes.Portifolio.Repository.Standard;
using BrunoFontes.Portifolio.Domain;
using BrunoFontes.Portifolio.Repository.ProdBrnd.EF;
using BrunoFontes.Portifolio.WinFormView.ViewModels;

namespace BrunoFontes.Portifolio.WinFormView
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FillDataGridViewBrandsAsync();
            FillDataGridViewProducsAsync();
        }

        private async void FillDataGridViewBrandsAsync()
        {
            IRepositoryGeneric<Brand> repositoryBrands = new RepositoryBrand();
            List<Brand> brands = await repositoryBrands.SelectAll();
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
            dgvBrands.Invoke((MethodInvoker)delegate
            {
                dgvBrands.DataSource = brandViewModels;
                dgvBrands.Refresh();
            });

        }

        private async void FillDataGridViewProducsAsync()
        {
            IRepositoryGeneric<Product> repositoryProducts = new RepositoryProduct();
            List<Product> products = await repositoryProducts.SelectAll();
            List<ProductsViewModel> productsViewModels = new List<ProductsViewModel>();

            foreach (Product product in products)
            {
                ProductsViewModel viewModel = new ProductsViewModel
                {
                    Id = product.Id,
                    BrandId = product.BrandId,
                    Brand = product.Brand.Name,
                    Name = product.Name
                };
                productsViewModels.Add(viewModel);
            }
            dgvProducts.Invoke((MethodInvoker)delegate
           {
               dgvProducts.DataSource = productsViewModels;
               dgvProducts.Refresh();
           });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmBrand frmBrand = new FrmBrand();
            frmBrand.ShowDialog();
            FillDataGridViewBrandsAsync();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FrmProduct frmProduct = new FrmProduct();
            frmProduct.ShowDialog();
            FillDataGridViewProducsAsync();
        }

        private void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            if (dgvBrands.SelectedRows.Count > 0)
            {
                int idSelectedBrand = Convert.ToInt32(dgvBrands.SelectedRows[0].Cells[0].Value);
                IRepositoryGeneric<Brand> repositoryBrand = new RepositoryBrand();
                Brand brandToBeChanged = repositoryBrand.SelectById(idSelectedBrand);
                FrmBrand frmBrand = new FrmBrand(brandToBeChanged);
                frmBrand.ShowDialog();
                FillDataGridViewBrandsAsync();
                FillDataGridViewProducsAsync();
            }
            else
            {
                MessageBox.Show("Please select one brand first.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int idSelectedProduct = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value);
                IRepositoryGeneric<Product> repositoryProduct = new RepositoryProduct();
                Product productToBeChanged = repositoryProduct.SelectById(idSelectedProduct);
                FrmProduct frmProduct = new FrmProduct(productToBeChanged);
                frmProduct.ShowDialog();
                FillDataGridViewProducsAsync();
            }
            else
            {
                MessageBox.Show("Please select one product first.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveBrand_Click(object sender, EventArgs e)
        {
            DialogResult myResult;
            myResult = MessageBox.Show("Are you sure that you want exclude this brand ?", "Warning", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Warning);
            if (myResult == DialogResult.OK)
            {
                if (dgvBrands.SelectedRows.Count > 0)
                {
                    int idSelectedBrand = Convert.ToInt32(dgvBrands.SelectedRows[0].Cells[0].Value);
                    IRepositoryGeneric<Brand> repositoryBrand = new RepositoryBrand();
                    Brand brandToBeExcluded = repositoryBrand.SelectById(idSelectedBrand);
                    repositoryBrand.Remove(brandToBeExcluded);
                    FillDataGridViewBrandsAsync();
                }
                else
                {
                    MessageBox.Show("Please select one brand to be exclued", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }


        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            DialogResult myResult;

            myResult = MessageBox.Show("Are you sure that you want to exclude this product", "Caution",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (myResult == DialogResult.OK)
            {
                if (dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select one product to be excluded", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else { 

                    int idSelectedProduct = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells[0].Value);
                    IRepositoryGeneric<Product> repositoryProduct = new RepositoryProduct();
                    Product productToBeExcluded = repositoryProduct.SelectById(idSelectedProduct);
                    repositoryProduct.Remove(productToBeExcluded);
                    FillDataGridViewBrandsAsync();
                    FillDataGridViewProducsAsync();
                }
            }

            
        }
    }
}
