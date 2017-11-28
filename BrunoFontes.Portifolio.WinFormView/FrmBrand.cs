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

namespace BrunoFontes.Portifolio.WinFormView
{
    public partial class FrmBrand : Form
    {
        private Brand brandToBeChanged;
        public FrmBrand(Brand brand = null)
        {
            brandToBeChanged = brand;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IRepositoryGeneric<Brand> repositoryBrand = new RepositoryBrand();
            if (brandToBeChanged == null)
            {
                Brand newBrand = new Brand
                {
                    Name = txbBrandName.Text.Trim()
                };
                repositoryBrand.Insert(newBrand);
            }
            else
            {
                brandToBeChanged.Name = txbBrandName.Text.Trim();
                repositoryBrand.Update(brandToBeChanged);
            }
            Close();
        }

        private void FrmBrand_Load(object sender, EventArgs e)
        {
            txbBrandName.Text = brandToBeChanged != null ? brandToBeChanged.Name : string.Empty;
        }
    }
}
