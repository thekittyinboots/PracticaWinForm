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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            Logica.Persona objLogica = new Logica.Persona();
            dgvPersonas.DataSource = objLogica.MostrarTodos();
            btnAgregar.Click += botones;
            btnModificar.Click += botones;
            btnEliminar.Click += botones;
            btnRefrescar.Click += botones;
        }

        private void botones(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            switch (boton.Name)
            {
                case "btnAgregar":
                    frmAgregarModificar frmAgregar = new frmAgregarModificar();
                    frmAgregar.Show();
                    break;
                case "btnModificar":
                    int id = Convert.ToInt32(dgvPersonas.CurrentRow.Cells["Id"].Value);
                    frmAgregarModificar frmModificar = new frmAgregarModificar(id);
                    frmModificar.Show();
                    break;
                case "btnEliminar":
                    Logica.Persona objLogica = new Logica.Persona();
                    int pId = Convert.ToInt32(dgvPersonas.CurrentRow.Cells["Id"].Value);
                    objLogica.Eliminar(pId);
                    break;
                case "btnRefrescar":
                    Logica.Persona objLog = new Logica.Persona();
                    dgvPersonas.DataSource = objLog.MostrarTodos();

                    break;
            }
        }
    }
}
