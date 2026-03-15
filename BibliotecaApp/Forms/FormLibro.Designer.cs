namespace BibliotecaApp.Forms
{
    partial class FormLibro
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(31, 97, 141);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(400, 50);

            // lblTitulo
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text = "Libro";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Labels
            int lx = 20, ly = 70, lh = 25, lg = 35;
            this.label1.Text = "Título *"; this.label1.Location = new System.Drawing.Point(lx, ly); this.label1.AutoSize = true;
            this.label2.Text = "Autor *"; this.label2.Location = new System.Drawing.Point(lx, ly + lg); this.label2.AutoSize = true;
            this.label3.Text = "Año"; this.label3.Location = new System.Drawing.Point(lx, ly + lg * 2); this.label3.AutoSize = true;
            this.label4.Text = "ISBN"; this.label4.Location = new System.Drawing.Point(lx, ly + lg * 3); this.label4.AutoSize = true;
            this.label5.Text = "Cantidad"; this.label5.Location = new System.Drawing.Point(lx, ly + lg * 4); this.label5.AutoSize = true;

            // TextBoxes
            int tx = 120, tw = 240;
            this.txtTitulo.Location = new System.Drawing.Point(tx, ly - 3); this.txtTitulo.Size = new System.Drawing.Size(tw, 23);
            this.txtAutor.Location = new System.Drawing.Point(tx, ly + lg - 3); this.txtAutor.Size = new System.Drawing.Size(tw, 23);
            this.txtISBN.Location = new System.Drawing.Point(tx, ly + lg * 3 - 3); this.txtISBN.Size = new System.Drawing.Size(tw, 23);

            // NumericUpDowns
            this.numAnio.Location = new System.Drawing.Point(tx, ly + lg * 2 - 3); this.numAnio.Size = new System.Drawing.Size(tw, 23);
            this.numAnio.Minimum = 1000; this.numAnio.Maximum = 2100; this.numAnio.Value = 2020;

            this.numCantidad.Location = new System.Drawing.Point(tx, ly + lg * 4 - 3); this.numCantidad.Size = new System.Drawing.Size(tw, 23);
            this.numCantidad.Minimum = 1; this.numCantidad.Maximum = 999; this.numCantidad.Value = 1;

            // Buttons
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(100, ly + lg * 5 + 10);
            this.btnGuardar.Size = new System.Drawing.Size(90, 32);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(31, 97, 141);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(210, ly + lg * 5 + 10);
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(400, ly + lg * 5 + 60);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label1); this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label2); this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.label3); this.Controls.Add(this.numAnio);
            this.Controls.Add(this.label4); this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label5); this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnGuardar); this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, label1, label2, label3, label4, label5;
        private System.Windows.Forms.TextBox txtTitulo, txtAutor, txtISBN;
        private System.Windows.Forms.NumericUpDown numAnio, numCantidad;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
        private System.Windows.Forms.Panel panelHeader;
    }
}
