using System;
using System.Windows.Forms;
using BibliotecaApp.Data;
using BibliotecaApp.Models;

namespace BibliotecaApp.Forms
{
    public partial class FormLibro : Form
    {
        private readonly bool _esEdicion;
        private readonly int _libroId;

        public FormLibro()
        {
            InitializeComponent();
            _esEdicion = false;
            this.Text = "Agregar Libro";
            lblTitulo.Text = "Nuevo Libro";
        }

        public FormLibro(Libro libro)
        {
            InitializeComponent();
            _esEdicion = true;
            _libroId = libro.Id;
            this.Text = "Editar Libro";
            lblTitulo.Text = "Editar Libro";

            txtTitulo.Text = libro.Titulo;
            txtAutor.Text = libro.Autor;
            numAnio.Value = libro.Anio;
            txtISBN.Text = libro.ISBN;
            numCantidad.Value = libro.CantidadTotal;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = txtTitulo.Text.Trim();
                string autor = txtAutor.Text.Trim();
                int anio = (int)numAnio.Value;
                string isbn = txtISBN.Text.Trim();
                int cantidad = (int)numCantidad.Value;

                if (string.IsNullOrWhiteSpace(titulo))
                { MessageBox.Show("El título es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (string.IsNullOrWhiteSpace(autor))
                { MessageBox.Show("El autor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (_esEdicion)
                    BibliotecaDB.Instancia.ActualizarLibro(_libroId, titulo, autor, anio, isbn, cantidad);
                else
                    BibliotecaDB.Instancia.AgregarLibro(titulo, autor, anio, isbn, cantidad);

                MessageBox.Show(_esEdicion ? "Libro actualizado correctamente." : "Libro agregado correctamente.",
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
