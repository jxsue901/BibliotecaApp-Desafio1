namespace BibliotecaApp.Forms
{
    partial class FormUsuario
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(400, 50);

            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text = "Usuario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            int lx = 20, ly = 70, lg = 35;
            this.label1.Text = "Nombre *"; this.label1.Location = new System.Drawing.Point(lx, ly); this.label1.AutoSize = true;
            this.label2.Text = "Apellido *"; this.label2.Location = new System.Drawing.Point(lx, ly + lg); this.label2.AutoSize = true;
            this.label3.Text = "Correo *"; this.label3.Location = new System.Drawing.Point(lx, ly + lg * 2); this.label3.AutoSize = true;
            this.label4.Text = "Teléfono"; this.label4.Location = new System.Drawing.Point(lx, ly + lg * 3); this.label4.AutoSize = true;

            int tx = 120, tw = 240;
            this.txtNombre.Location = new System.Drawing.Point(tx, ly - 3); this.txtNombre.Size = new System.Drawing.Size(tw, 23);
            this.txtApellido.Location = new System.Drawing.Point(tx, ly + lg - 3); this.txtApellido.Size = new System.Drawing.Size(tw, 23);
            this.txtCorreo.Location = new System.Drawing.Point(tx, ly + lg * 2 - 3); this.txtCorreo.Size = new System.Drawing.Size(tw, 23);
            this.txtTelefono.Location = new System.Drawing.Point(tx, ly + lg * 3 - 3); this.txtTelefono.Size = new System.Drawing.Size(tw, 23);

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(100, ly + lg * 4 + 10);
            this.btnGuardar.Size = new System.Drawing.Size(90, 32);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(210, ly + lg * 4 + 10);
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.ClientSize = new System.Drawing.Size(400, ly + lg * 4 + 60);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label1); this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2); this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label3); this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label4); this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnGuardar); this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo, label1, label2, label3, label4;
        private System.Windows.Forms.TextBox txtNombre, txtApellido, txtCorreo, txtTelefono;
        private System.Windows.Forms.Button btnGuardar, btnCancelar;
        private System.Windows.Forms.Panel panelHeader;
    }
}
