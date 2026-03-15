using System;
using System.Windows.Forms;
using BibliotecaApp.Data;
using BibliotecaApp.Models;

namespace BibliotecaApp.Forms
{
    public partial class FormUsuario : Form
    {
        private readonly bool _esEdicion;
        private readonly int _usuarioId;

        public FormUsuario()
        {
            InitializeComponent();
            _esEdicion = false;
            this.Text = "Agregar Usuario";
            lblTitulo.Text = "Nuevo Usuario";
        }

        public FormUsuario(Usuario usuario)
        {
            InitializeComponent();
            _esEdicion = true;
            _usuarioId = usuario.Id;
            this.Text = "Editar Usuario";
            lblTitulo.Text = "Editar Usuario";

            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtCorreo.Text = usuario.Correo;
            txtTelefono.Text = usuario.Telefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                { MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (string.IsNullOrWhiteSpace(apellido))
                { MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
                { MessageBox.Show("Ingrese un correo electrónico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (_esEdicion)
                    BibliotecaDB.Instancia.ActualizarUsuario(_usuarioId, nombre, apellido, correo, telefono);
                else
                    BibliotecaDB.Instancia.AgregarUsuario(nombre, apellido, correo, telefono);

                MessageBox.Show(_esEdicion ? "Usuario actualizado correctamente." : "Usuario registrado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
