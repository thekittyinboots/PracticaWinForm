using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guseva_Marina
{
    public partial class frmAgregarModificar : Form
    {
        public frmAgregarModificar()
        {
            InitializeComponent();
            LlenarCb();
            btnModificar.Enabled = false;
            btnAgregar.Enabled = true;

            txtNombre.Validating += TxtNombre_Validating;
            txtNombre.Validated += TxtNombre_Validated;

            txtCreditoMaximo.Validating += TxtCreditoMaximo_Validating;
            txtCreditoMaximo.Validated += TxtCreditoMaximo_Validated;

        }

        private void TxtCreditoMaximo_Validated(object sender, EventArgs e)
        {
            epCreditoMax.SetError(txtCreditoMaximo, "");
        }

        private void TxtCreditoMaximo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreditoMaximo.Text))
            {
                epCreditoMax.SetError(txtCreditoMaximo, "Campo obligatorio");
                e.Cancel = true;
            }
        }

        private void TxtNombre_Validated(object sender, EventArgs e)
        {
            epNombre.SetError(txtNombre, "");
        }

        private void TxtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                epNombre.SetError(txtNombre, "Campo obligatorio");
                e.Cancel = true;
            }
        }

        public frmAgregarModificar(int pId)
        {
            InitializeComponent();
            LlenarCb();
            btnModificar.Enabled = true;
            btnAgregar.Enabled = false;
            ModificarMostrarUno(pId);
        }

        int ID = 0;
        public void ModificarMostrarUno(int pId)
        {
            Logica.Persona objLogica = new Logica.Persona();
            Modelos.Persona pers = objLogica.MostrarUno(pId);
            txtNombre.Text = pers.Nombre;
            dtpFechaNac.Value = pers.Fecha_Nacimiento;
            cbPais.SelectedValue = pers.Id_Pais;
            txtCreditoMaximo.Text = pers.Credito_Maximo.ToString();
            ID = pId;
        }

    

        private void LlenarCb()
        {
            Logica.Pais paises = new Logica.Pais();
            cbPais.DataSource = paises.MostrarPaises();
            cbPais.DisplayMember = "Descripcion";
            cbPais.ValueMember = "Id";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Logica.Persona objLogica = new Logica.Persona();
            Modelos.Persona persona = new Modelos.Persona();
            persona.Nombre = txtNombre.Text;
            persona.Fecha_Nacimiento = dtpFechaNac.Value;
            persona.Id_Pais = Convert.ToInt32(cbPais.SelectedValue);
            persona.Credito_Maximo = Convert.ToDecimal(txtCreditoMaximo.Text);
            objLogica.Agregar(persona);
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Logica.Persona objLogica = new Logica.Persona();
            Modelos.Persona persona = new Modelos.Persona();
            persona.Nombre = txtNombre.Text;
            persona.Fecha_Nacimiento = dtpFechaNac.Value;
            persona.Id_Pais = Convert.ToInt32(cbPais.SelectedValue);
            persona.Credito_Maximo = Convert.ToDecimal(txtCreditoMaximo.Text);
            objLogica.Modificar(ID, persona);
            Close();
        }
    }
}
