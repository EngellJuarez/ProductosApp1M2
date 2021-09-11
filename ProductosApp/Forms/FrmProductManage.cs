using Domain.Entities;
using Domain.Enums;
using Infraestructure.Productos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Forms
{
    public partial class FrmProductManage : Form
    {
        private ProductoModel productoModel;

        public FrmProductManage()
        {
            productoModel = new ProductoModel();
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    pnlId.Visible = true;
                    pnlMeasureUnit.Visible = false;
                    pnlPriceRange.Visible = false;
                    pnlCaducity.Visible = false;
                    break;
                case 1:
                    pnlId.Visible = false;
                    pnlMeasureUnit.Visible = true;
                    pnlPriceRange.Visible = false;
                    pnlCaducity.Visible = false;
                    break;
                case 2:
                    pnlId.Visible = false;
                    pnlMeasureUnit.Visible = false;
                    pnlPriceRange.Visible = true;
                    pnlCaducity.Visible = false;
                    break;
                case 3:
                    pnlId.Visible = false;
                    pnlMeasureUnit.Visible = false;
                    pnlPriceRange.Visible = false;
                    pnlCaducity.Visible = true;
                    break;
            }
        }

        private void FrmProductManage_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>().ToArray()
                                         );
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.ProductoModel = productoModel;
            frmProducto.ShowDialog();

            rtbProductView.Text = productoModel.GetProductosAsJson();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(txtId.Text);
                Producto p = productoModel.GetProductoById(ID);
                if (p != null)
                {
                    rtbProductView.Text = $"El producto con ID: {ID} es: \n";
                    rtbProductView.Text += JsonConvert.SerializeObject(p);
                    txtId.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Producto no agregado", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error","Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
