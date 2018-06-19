namespace SportMaxApp
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(378, 228);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(66, 25);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(72, 40);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(99, 55);
            this.btnProducto.TabIndex = 3;
            this.btnProducto.Text = "Productos";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Visible = false;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(280, 40);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(105, 55);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Visible = false;
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.Location = new System.Drawing.Point(72, 142);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(99, 55);
            this.btnEmpleado.TabIndex = 5;
            this.btnEmpleado.Text = "Empleados";
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(280, 229);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(80, 23);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 283);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnEmpleado);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnProducto);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}