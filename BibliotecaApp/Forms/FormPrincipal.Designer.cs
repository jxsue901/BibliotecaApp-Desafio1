namespace BibliotecaApp.Forms
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLibros = new System.Windows.Forms.TabPage();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.tabPrestamos = new System.Windows.Forms.TabPage();
            this.tabEstadisticas = new System.Windows.Forms.TabPage();

            // Libros tab controls
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.btnAgregarLibro = new System.Windows.Forms.Button();
            this.btnEditarLibro = new System.Windows.Forms.Button();
            this.btnEliminarLibro = new System.Windows.Forms.Button();
            this.txtBuscarLibro = new System.Windows.Forms.TextBox();
            this.lblBuscarLibro = new System.Windows.Forms.Label();

            // Usuarios tab controls
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();

            // Prestamos tab controls
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.btnNuevoPrestamo = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnEliminarPrestamo = new System.Windows.Forms.Button();

            // Estadisticas
            this.panelResumen = new System.Windows.Forms.Panel();
            this.panelGraficos = new System.Windows.Forms.Panel();
            this.lblTotalLibros = new System.Windows.Forms.Label();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.lblTotalPrestamos = new System.Windows.Forms.Label();
            this.lblPrestamosActivos = new System.Windows.Forms.Label();
            this.lblCard1 = new System.Windows.Forms.Label();
            this.lblCard2 = new System.Windows.Forms.Label();
            this.lblCard3 = new System.Windows.Forms.Label();
            this.lblCard4 = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.SuspendLayout();

            // ===== panelTop =====
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(31, 97, 141);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Controls.Add(this.lblAppTitle);
            this.panelTop.Controls.Add(this.lblSubtitulo);

            this.lblAppTitle.Text = "GESTIÓN DE BIBLIOTECA";
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(15, 8);
            this.lblAppTitle.AutoSize = true;

            this.lblSubtitulo.Text = "Sistema de administración de libros, usuarios y préstamos";
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(174, 214, 241);
            this.lblSubtitulo.Location = new System.Drawing.Point(17, 42);
            this.lblSubtitulo.AutoSize = true;

            // ===== tabControl =====
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.TabPages.Add(this.tabLibros);
            this.tabControl.TabPages.Add(this.tabUsuarios);
            this.tabControl.TabPages.Add(this.tabPrestamos);
            this.tabControl.TabPages.Add(this.tabEstadisticas);

            this.tabLibros.Text = "  📚 Libros  ";
            this.tabLibros.Padding = new System.Windows.Forms.Padding(5);
            this.tabUsuarios.Text = "  👤 Usuarios  ";
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(5);
            this.tabPrestamos.Text = "  📋 Préstamos  ";
            this.tabPrestamos.Padding = new System.Windows.Forms.Padding(5);
            this.tabEstadisticas.Text = "  📊 Estadísticas  ";
            this.tabEstadisticas.Padding = new System.Windows.Forms.Padding(5);

            // ===== TAB LIBROS =====
            ConfigurarDataGridView(this.dgvLibros, new System.Drawing.Point(5, 40),
                new System.Drawing.Size(970, 460));
            this.dgvLibros.Columns.Add("Id", "ID");
            this.dgvLibros.Columns.Add("Titulo", "Título");
            this.dgvLibros.Columns.Add("Autor", "Autor");
            this.dgvLibros.Columns.Add("Anio", "Año");
            this.dgvLibros.Columns.Add("ISBN", "ISBN");
            this.dgvLibros.Columns.Add("Total", "Total");
            this.dgvLibros.Columns.Add("Disponibles", "Disponibles");
            this.dgvLibros.Columns[0].Width = 40;
            this.dgvLibros.Columns[1].Width = 220;
            this.dgvLibros.Columns[2].Width = 160;
            this.dgvLibros.Columns[3].Width = 50;
            this.dgvLibros.Columns[4].Width = 140;
            this.dgvLibros.Columns[5].Width = 60;
            this.dgvLibros.Columns[6].Width = 90;

            this.lblBuscarLibro.Text = "🔍 Buscar:";
            this.lblBuscarLibro.Location = new System.Drawing.Point(5, 10);
            this.lblBuscarLibro.AutoSize = true;
            this.lblBuscarLibro.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.txtBuscarLibro.Location = new System.Drawing.Point(75, 7);
            this.txtBuscarLibro.Size = new System.Drawing.Size(250, 23);
            this.txtBuscarLibro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscarLibro.TextChanged += new System.EventHandler(this.txtBuscarLibro_TextChanged);

            ConfigurarBoton(this.btnAgregarLibro, "+ Añadir", new System.Drawing.Point(700, 7),
                System.Drawing.Color.FromArgb(31, 97, 141));
            this.btnAgregarLibro.Click += new System.EventHandler(this.btnAgregarLibro_Click);

            ConfigurarBoton(this.btnEditarLibro, "✏ Editar", new System.Drawing.Point(800, 7),
                System.Drawing.Color.FromArgb(39, 174, 96));
            this.btnEditarLibro.Click += new System.EventHandler(this.btnEditarLibro_Click);

            ConfigurarBoton(this.btnEliminarLibro, "🗑 Eliminar", new System.Drawing.Point(893, 7),
                System.Drawing.Color.FromArgb(192, 57, 43));
            this.btnEliminarLibro.Click += new System.EventHandler(this.btnEliminarLibro_Click);

            this.tabLibros.Controls.Add(this.lblBuscarLibro);
            this.tabLibros.Controls.Add(this.txtBuscarLibro);
            this.tabLibros.Controls.Add(this.btnAgregarLibro);
            this.tabLibros.Controls.Add(this.btnEditarLibro);
            this.tabLibros.Controls.Add(this.btnEliminarLibro);
            this.tabLibros.Controls.Add(this.dgvLibros);

            // ===== TAB USUARIOS =====
            ConfigurarDataGridView(this.dgvUsuarios, new System.Drawing.Point(5, 40),
                new System.Drawing.Size(970, 460));
            this.dgvUsuarios.Columns.Add("Id", "ID");
            this.dgvUsuarios.Columns.Add("Nombre", "Nombre");
            this.dgvUsuarios.Columns.Add("Apellido", "Apellido");
            this.dgvUsuarios.Columns.Add("Correo", "Correo Electrónico");
            this.dgvUsuarios.Columns.Add("Telefono", "Teléfono");
            this.dgvUsuarios.Columns.Add("Registro", "Fecha Registro");
            this.dgvUsuarios.Columns[0].Width = 40;
            this.dgvUsuarios.Columns[1].Width = 150;
            this.dgvUsuarios.Columns[2].Width = 150;
            this.dgvUsuarios.Columns[3].Width = 240;
            this.dgvUsuarios.Columns[4].Width = 120;
            this.dgvUsuarios.Columns[5].Width = 110;

            var lblUsuarios = new System.Windows.Forms.Label();
            lblUsuarios.Text = "Gestión de Usuarios";
            lblUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblUsuarios.Location = new System.Drawing.Point(5, 10);
            lblUsuarios.AutoSize = true;

            ConfigurarBoton(this.btnAgregarUsuario, "+ Añadir", new System.Drawing.Point(700, 7),
                System.Drawing.Color.FromArgb(31, 97, 141));
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);

            ConfigurarBoton(this.btnEditarUsuario, "✏ Editar", new System.Drawing.Point(800, 7),
                System.Drawing.Color.FromArgb(39, 174, 96));
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);

            ConfigurarBoton(this.btnEliminarUsuario, "🗑 Eliminar", new System.Drawing.Point(893, 7),
                System.Drawing.Color.FromArgb(192, 57, 43));
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);

            this.tabUsuarios.Controls.Add(lblUsuarios);
            this.tabUsuarios.Controls.Add(this.btnAgregarUsuario);
            this.tabUsuarios.Controls.Add(this.btnEditarUsuario);
            this.tabUsuarios.Controls.Add(this.btnEliminarUsuario);
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);

            // ===== TAB PRESTAMOS =====
            ConfigurarDataGridView(this.dgvPrestamos, new System.Drawing.Point(5, 40),
                new System.Drawing.Size(970, 460));
            this.dgvPrestamos.Columns.Add("Id", "ID");
            this.dgvPrestamos.Columns.Add("Usuario", "Usuario");
            this.dgvPrestamos.Columns.Add("Libro", "Libro");
            this.dgvPrestamos.Columns.Add("FechaPrestamo", "Fecha Préstamo");
            this.dgvPrestamos.Columns.Add("FechaDevolucion", "Fecha Devolución");
            this.dgvPrestamos.Columns.Add("Estado", "Estado");
            this.dgvPrestamos.Columns[0].Width = 40;
            this.dgvPrestamos.Columns[1].Width = 200;
            this.dgvPrestamos.Columns[2].Width = 220;
            this.dgvPrestamos.Columns[3].Width = 120;
            this.dgvPrestamos.Columns[4].Width = 130;
            this.dgvPrestamos.Columns[5].Width = 90;

            var lblPrestamos = new System.Windows.Forms.Label();
            lblPrestamos.Text = "Gestión de Préstamos";
            lblPrestamos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblPrestamos.Location = new System.Drawing.Point(5, 10);
            lblPrestamos.AutoSize = true;

            ConfigurarBoton(this.btnNuevoPrestamo, "+ Nuevo", new System.Drawing.Point(650, 7),
                System.Drawing.Color.FromArgb(142, 68, 173));
            this.btnNuevoPrestamo.Click += new System.EventHandler(this.btnNuevoPrestamo_Click);

            ConfigurarBoton(this.btnDevolver, "↩ Devolver", new System.Drawing.Point(755, 7),
                System.Drawing.Color.FromArgb(39, 174, 96));
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);

            ConfigurarBoton(this.btnEliminarPrestamo, "🗑 Eliminar", new System.Drawing.Point(893, 7),
                System.Drawing.Color.FromArgb(192, 57, 43));
            this.btnEliminarPrestamo.Click += new System.EventHandler(this.btnEliminarPrestamo_Click);

            this.tabPrestamos.Controls.Add(lblPrestamos);
            this.tabPrestamos.Controls.Add(this.btnNuevoPrestamo);
            this.tabPrestamos.Controls.Add(this.btnDevolver);
            this.tabPrestamos.Controls.Add(this.btnEliminarPrestamo);
            this.tabPrestamos.Controls.Add(this.dgvPrestamos);

            // ===== TAB ESTADÍSTICAS =====
            // Cards de resumen
            AgregarCard(this.tabEstadisticas, "Total Libros", this.lblCard1, this.lblTotalLibros,
                new System.Drawing.Point(10, 10), System.Drawing.Color.FromArgb(31, 97, 141));
            AgregarCard(this.tabEstadisticas, "Total Usuarios", this.lblCard2, this.lblTotalUsuarios,
                new System.Drawing.Point(190, 10), System.Drawing.Color.FromArgb(39, 174, 96));
            AgregarCard(this.tabEstadisticas, "Total Préstamos", this.lblCard3, this.lblTotalPrestamos,
                new System.Drawing.Point(370, 10), System.Drawing.Color.FromArgb(142, 68, 173));
            AgregarCard(this.tabEstadisticas, "Préstamos Activos", this.lblCard4, this.lblPrestamosActivos,
                new System.Drawing.Point(550, 10), System.Drawing.Color.FromArgb(211, 84, 0));

            // Panel gráficos
            this.panelGraficos.Location = new System.Drawing.Point(10, 120);
            this.panelGraficos.Size = new System.Drawing.Size(460, 380);
            this.panelGraficos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGraficos.BackColor = System.Drawing.Color.White;
            this.panelGraficos.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraficos_Paint);
            this.tabEstadisticas.Controls.Add(this.panelGraficos);

            // ===== MAIN FORM =====
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTop);
            this.Text = "Sistema de Gestión de Biblioteca";
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(1000, 640);

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarDataGridView(System.Windows.Forms.DataGridView dgv,
            System.Drawing.Point location, System.Drawing.Size size)
        {
            dgv.Location = location;
            dgv.Size = size;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 97, 141);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersHeight = 32;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 245, 251);
        }

        private void ConfigurarBoton(System.Windows.Forms.Button btn, string texto,
            System.Drawing.Point location, System.Drawing.Color color)
        {
            btn.Text = texto;
            btn.Location = location;
            btn.Size = new System.Drawing.Size(90, 28);
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void AgregarCard(System.Windows.Forms.Control parent, string titulo,
            System.Windows.Forms.Label lblTitulo, System.Windows.Forms.Label lblValor,
            System.Drawing.Point location, System.Drawing.Color color)
        {
            var card = new System.Windows.Forms.Panel();
            card.Location = location;
            card.Size = new System.Drawing.Size(170, 90);
            card.BackColor = color;

            lblTitulo.Text = titulo;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(200, 230, 255);
            lblTitulo.Location = new System.Drawing.Point(10, 10);
            lblTitulo.AutoSize = true;

            lblValor.Text = "0";
            lblValor.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblValor.ForeColor = System.Drawing.Color.White;
            lblValor.Location = new System.Drawing.Point(10, 30);
            lblValor.AutoSize = true;

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblValor);
            parent.Controls.Add(card);
        }

        // Controls
        private System.Windows.Forms.Panel panelTop, panelResumen, panelGraficos;
        private System.Windows.Forms.Label lblAppTitle, lblSubtitulo;
        private System.Windows.Forms.Label lblTotalLibros, lblTotalUsuarios, lblTotalPrestamos, lblPrestamosActivos;
        private System.Windows.Forms.Label lblCard1, lblCard2, lblCard3, lblCard4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLibros, tabUsuarios, tabPrestamos, tabEstadisticas;
        private System.Windows.Forms.DataGridView dgvLibros, dgvUsuarios, dgvPrestamos;
        private System.Windows.Forms.Button btnAgregarLibro, btnEditarLibro, btnEliminarLibro;
        private System.Windows.Forms.Button btnAgregarUsuario, btnEditarUsuario, btnEliminarUsuario;
        private System.Windows.Forms.Button btnNuevoPrestamo, btnDevolver, btnEliminarPrestamo;
        private System.Windows.Forms.TextBox txtBuscarLibro;
        private System.Windows.Forms.Label lblBuscarLibro;
    }
}
