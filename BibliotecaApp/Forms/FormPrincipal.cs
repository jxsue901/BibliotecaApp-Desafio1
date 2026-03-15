using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaApp.Data;
using BibliotecaApp.Forms;
using BibliotecaApp.Models;

namespace BibliotecaApp.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            CargarLibros();
            CargarUsuarios();
            CargarPrestamos();
            ActualizarResumen();
            panelGraficos.Invalidate();
        }

        // ===================== LIBROS =====================
        private void CargarLibros()
        {
            dgvLibros.Rows.Clear();
            var libros = BibliotecaDB.Instancia.ObtenerLibros();
            foreach (var l in libros)
                dgvLibros.Rows.Add(l.Id, l.Titulo, l.Autor, l.Anio, l.ISBN, l.CantidadTotal, l.CantidadDisponible);
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            var form = new FormLibro();
            if (form.ShowDialog() == DialogResult.OK) CargarLibros();
        }

        private void btnEditarLibro_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione un libro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells[0].Value);
            var libro = BibliotecaDB.Instancia.ObtenerLibroPorId(id);
            var form = new FormLibro(libro);
            if (form.ShowDialog() == DialogResult.OK) CargarLibros();
        }

        private void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione un libro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int id = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells[0].Value);
            string titulo = dgvLibros.SelectedRows[0].Cells[1].Value.ToString();

            if (MessageBox.Show($"¿Eliminar el libro \"{titulo}\"?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    BibliotecaDB.Instancia.EliminarLibro(id);
                    CargarLibros();
                    ActualizarResumen();
                    panelGraficos.Invalidate();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void txtBuscarLibro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarLibro.Text.ToLower();
            dgvLibros.Rows.Clear();
            var libros = BibliotecaDB.Instancia.ObtenerLibros()
                .Where(l => l.Titulo.ToLower().Contains(filtro) || l.Autor.ToLower().Contains(filtro)).ToList();
            foreach (var l in libros)
                dgvLibros.Rows.Add(l.Id, l.Titulo, l.Autor, l.Anio, l.ISBN, l.CantidadTotal, l.CantidadDisponible);
        }

        // ===================== USUARIOS =====================
        private void CargarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            var usuarios = BibliotecaDB.Instancia.ObtenerUsuarios();
            foreach (var u in usuarios)
                dgvUsuarios.Rows.Add(u.Id, u.Nombre, u.Apellido, u.Correo, u.Telefono, u.FechaRegistro.ToShortDateString());
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            var form = new FormUsuario();
            if (form.ShowDialog() == DialogResult.OK) { CargarUsuarios(); ActualizarResumen(); }
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione un usuario para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
            var usuario = BibliotecaDB.Instancia.ObtenerUsuarioPorId(id);
            var form = new FormUsuario(usuario);
            if (form.ShowDialog() == DialogResult.OK) CargarUsuarios();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
            string nombre = $"{dgvUsuarios.SelectedRows[0].Cells[1].Value} {dgvUsuarios.SelectedRows[0].Cells[2].Value}";

            if (MessageBox.Show($"¿Eliminar al usuario \"{nombre}\"?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    BibliotecaDB.Instancia.EliminarUsuario(id);
                    CargarUsuarios();
                    ActualizarResumen();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // ===================== PRÉSTAMOS =====================
        private void CargarPrestamos()
        {
            dgvPrestamos.Rows.Clear();
            var prestamos = BibliotecaDB.Instancia.ObtenerPrestamos();
            foreach (var p in prestamos)
            {
                string estado = p.Estado.ToString();
                if (p.Estado == EstadoPrestamo.Activo && p.FechaDevolucion < DateTime.Now)
                    estado = "Vencido";
                dgvPrestamos.Rows.Add(p.Id, p.NombreUsuario, p.TituloLibro,
                    p.FechaPrestamo.ToShortDateString(), p.FechaDevolucion.ToShortDateString(), estado);
            }
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            var form = new FormPrestamo();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarPrestamos();
                CargarLibros();
                ActualizarResumen();
                panelGraficos.Invalidate();
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione un préstamo para registrar devolución.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells[0].Value);
            string estado = dgvPrestamos.SelectedRows[0].Cells[5].Value.ToString();

            if (estado == "Devuelto")
            { MessageBox.Show("Este préstamo ya fue devuelto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (MessageBox.Show("¿Registrar la devolución de este libro?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    BibliotecaDB.Instancia.RegistrarDevolucion(id);
                    CargarPrestamos();
                    CargarLibros();
                    ActualizarResumen();
                    panelGraficos.Invalidate();
                    MessageBox.Show("Devolución registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnEliminarPrestamo_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count == 0)
            { MessageBox.Show("Seleccione un préstamo para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int id = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show("¿Eliminar este registro de préstamo?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    BibliotecaDB.Instancia.EliminarPrestamo(id);
                    CargarPrestamos();
                    ActualizarResumen();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // ===================== ESTADÍSTICAS =====================
        private void ActualizarResumen()
        {
            var resumen = BibliotecaDB.Instancia.ObtenerResumenEstadistico();
            lblTotalLibros.Text = resumen[0].ToString();
            lblTotalUsuarios.Text = resumen[1].ToString();
            lblTotalPrestamos.Text = resumen[2].ToString();
            lblPrestamosActivos.Text = resumen[3].ToString();
        }

        private void panelGraficos_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            DibujarGraficoLibros(g);
            DibujarGraficoUsuarios(g);
        }

        private void DibujarGraficoLibros(Graphics g)
        {
            var datos = BibliotecaDB.Instancia.ObtenerLibrosMasPrestados(5);
            if (datos.Count == 0) return;

            int offsetX = 20, offsetY = 40, anchoMax = 280, alturaBarra = 22, espaciado = 32;
            int maxVal = datos.Values.Max();

            g.DrawString("📚 Libros más Prestados", new Font("Segoe UI", 10, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(31, 97, 141)), offsetX, 10);

            Color[] colores = { Color.FromArgb(52, 152, 219), Color.FromArgb(41, 128, 185),
                Color.FromArgb(31, 97, 141), Color.FromArgb(21, 67, 99), Color.FromArgb(11, 37, 59) };

            int i = 0;
            foreach (var kvp in datos)
            {
                int y = offsetY + i * espaciado;
                int ancho = maxVal > 0 ? (int)((double)kvp.Value / maxVal * anchoMax) : 0;

                string etiqueta = kvp.Key.Length > 18 ? kvp.Key.Substring(0, 15) + "..." : kvp.Key;
                g.DrawString(etiqueta, new Font("Segoe UI", 8), Brushes.DimGray, offsetX, y + 4);

                int barX = offsetX + 150;
                g.FillRectangle(new SolidBrush(colores[i % colores.Length]), barX, y, Math.Max(ancho, 5), alturaBarra);
                g.DrawString(kvp.Value.ToString(), new Font("Segoe UI", 8, FontStyle.Bold),
                    Brushes.White, barX + 5, y + 5);
                i++;
            }
        }

        private void DibujarGraficoUsuarios(Graphics g)
        {
            var datos = BibliotecaDB.Instancia.ObtenerUsuariosMasActivos(5);
            if (datos.Count == 0) return;

            int offsetX = 20, offsetY = 230, anchoMax = 280, alturaBarra = 22, espaciado = 32;
            int maxVal = datos.Values.Max();

            g.DrawString("👤 Usuarios más Activos", new Font("Segoe UI", 10, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(39, 174, 96)), offsetX, 200);

            Color[] colores = { Color.FromArgb(46, 204, 113), Color.FromArgb(39, 174, 96),
                Color.FromArgb(30, 132, 73), Color.FromArgb(21, 91, 51), Color.FromArgb(11, 50, 28) };

            int i = 0;
            foreach (var kvp in datos)
            {
                int y = offsetY + i * espaciado;
                int ancho = maxVal > 0 ? (int)((double)kvp.Value / maxVal * anchoMax) : 0;

                string etiqueta = kvp.Key.Length > 18 ? kvp.Key.Substring(0, 15) + "..." : kvp.Key;
                g.DrawString(etiqueta, new Font("Segoe UI", 8), Brushes.DimGray, offsetX, y + 4);

                int barX = offsetX + 150;
                g.FillRectangle(new SolidBrush(colores[i % colores.Length]), barX, y, Math.Max(ancho, 5), alturaBarra);
                g.DrawString(kvp.Value.ToString(), new Font("Segoe UI", 8, FontStyle.Bold),
                    Brushes.White, barX + 5, y + 5);
                i++;
            }
        }
    }
}
