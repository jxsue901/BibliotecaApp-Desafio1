namespace BibliotecaApp.Forms
{
    partial class FormPrestamo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.cmbLibro = new System.Windows.Forms.ComboBox();
            this.dtpFechaPrestamo = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(420, 50);

            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text = "Registrar Préstamo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            int lx = 20, ly = 70, lg = 40;
            this.label1.Text = "Usuario *"; this.label1.Location = new System.Drawing.Point(lx, ly); this.label1.AutoSize = true;
            this.label2.Text = "Libro *"; this.label2.Location = new System.Drawing.Point(lx, ly + lg); this.label2.AutoSize = true;
            this.label3.Text = "Fecha Préstamo"; this.label3.Location = new System.Drawing.Point(lx, ly + lg * 2); this.label3.AutoSize = true;
            this.label4.Text = "Fecha Devolución"; this.label4.Location = new System.Drawing.Point(lx, ly + lg * 3); this.label4.AutoSize = true;

            int tx = 150, tw = 240;
            this.cmbUsuario.Location = new System.Drawing.Point(tx, ly - 3); this.cmbUsuario.Size = new System.Drawing.Size(tw, 23);
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbLibro.Location = new System.Drawing.Point(tx, ly + lg - 3); this.cmbLibro.Size = new System.Drawing.Size(tw, 23);
            this.cmbLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.dtpFechaPrestamo.Location = new System.Drawing.Point(tx, ly + lg * 2 - 3); this.dtpFechaPrestamo.Size = new System.Drawing.Size(tw, 23);
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(tx, ly + lg * 3 - 3); this.dtpFechaDevolucion.Size = new System.Drawing.Size(tw, 23);

            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.Location = new System.Drawing.Point(100, ly + lg * 4 + 10);
            this.btnGuardar.Size = new System.Drawing.Size(100, 32);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(220, ly + lg * 4 + 10);
            this.btnCancelar.Size = new System.Drawing.Size(100, 32);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.ClientSize = new System.Drawing.Size(420, ly + lg * 4 + 65);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label1); this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label2); this.Controls.Add(this.cmbLibro);
            this.Controls.Add(this.label3); this.Controls.Add(this.dtpFechaPrestamo);
            this.Controls.Add(this.label4); this.Controls.Add(this.dtpFechaDevolucion);
            this.Controls.Add(this.btnGuardar); this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Text = "Registrar Préstamo";

            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, label1, label2, label3, label4;
        private System.Windows.Forms.ComboBox cmbUsuario, cmbLibro;
        private System.Windows.Forms.DateTimePicker dtpFechaPrestamo, dtpFechaDevolucion;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
        private System.Windows.Forms.Panel panelHeader;
    }
}
