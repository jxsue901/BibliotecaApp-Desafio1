using System;
using System.Windows.Forms;
using BibliotecaApp.Data;
using BibliotecaApp.Models;

namespace BibliotecaApp.Forms
{
    public partial class FormPrestamo : Form
    {
        public FormPrestamo()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            cmbUsuario.DataSource = BibliotecaDB.Instancia.ObtenerUsuarios();
            cmbUsuario.DisplayMember = "NombreCompleto";
            cmbUsuario.ValueMember = "Id";

            var librosDisponibles = BibliotecaDB.Instancia.ObtenerLibros()
                .FindAll(l => l.CantidadDisponible > 0);
            cmbLibro.DataSource = librosDisponibles;
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "Id";

            dtpFechaPrestamo.Value = DateTime.Now;
            dtpFechaDevolucion.Value = DateTime.Now.AddDays(7);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsuario.SelectedItem == null)
                { MessageBox.Show("Seleccione un usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (cmbLibro.SelectedItem == null)
                { MessageBox.Show("Seleccione un libro.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                int usuarioId = (int)cmbUsuario.SelectedValue;
                int libroId = (int)cmbLibro.SelectedValue;
                DateTime fechaPrestamo = dtpFechaPrestamo.Value.Date;
                DateTime fechaDevolucion = dtpFechaDevolucion.Value.Date;

                BibliotecaDB.Instancia.AgregarPrestamo(usuarioId, libroId, fechaPrestamo, fechaDevolucion);

                MessageBox.Show("Préstamo registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
