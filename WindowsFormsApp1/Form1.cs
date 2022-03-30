using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string idcontacto;
        private bool editarse = false;

        E_cat objEntidad = new E_cat();
        N_cat objNegocio = new N_cat();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionTabla();
        }
        public void accionTabla()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 170;

            dataGridView1.ClearSelection();

        }

        public void mostrarBuscarTabla(string Buscar)
        {
            N_cat objNegocio = new N_cat();

            dataGridView1.DataSource = objNegocio.ListarContactos(Buscar);

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            mostrarBuscarTabla(buscartxt.text);
        }
        public void Limpiar()
        {
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcelular.Text = "";
            txtnombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editarse = true;
                idcontacto = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtapellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtcelular.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                bdtp.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
            else { MessageBox.Show("Seleccione una fila para continuar"); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {

                    objEntidad.Nombre = txtnombre.Text.ToUpper();
                    objEntidad.Apellido = txtapellido.Text.ToUpper();
                    objEntidad.Celular = Convert.ToInt32(txtcelular.Text);
                    objEntidad.Fecha_nacimiento = Convert.ToDateTime(bdtp.Text);

                    objNegocio.InsertarCategoria(objEntidad);
                    MessageBox.Show("Registro agregado satsfactoriamente");
                    mostrarBuscarTabla("");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El registro no se ha agregado correctamente" + ex);
                }
            }
            if (editarse == true)
            {
                try
                {
                    objEntidad.Idcontactos = Convert.ToInt32(idcontacto);
                    objEntidad.Nombre = txtnombre.Text.ToUpper();
                    objEntidad.Apellido = txtapellido.Text.ToUpper();
                    objEntidad.Celular = Convert.ToInt32(txtcelular.Text);
                    objEntidad.Fecha_nacimiento = Convert.ToDateTime(bdtp.Text);

                    objNegocio.EditandoCategoria(objEntidad);
                    MessageBox.Show("Registro se ha editado satsfactoriamente");
                    mostrarBuscarTabla("");
                    editarse = false;
                    Limpiar();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("El registro no se ha editado correctamente" + ex);
                }
            }
            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objEntidad.Idcontactos = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                mostrarBuscarTabla("");


            }
            else { MessageBox.Show("Seleccione la fila que desea eliminar"); }

        }

        private void bdtp_onValueChanged(object sender, EventArgs e)
        {
          
        }
    }
}
