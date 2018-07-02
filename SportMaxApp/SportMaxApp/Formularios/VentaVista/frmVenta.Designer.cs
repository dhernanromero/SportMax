namespace SportMaxApp.Formularios.VentaVista
{
    partial class frmVenta
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
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtDniCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gridDetalleVenta = new System.Windows.Forms.DataGridView();
            this.CodProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Talle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(27, 376);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(83, 20);
            this.lblVendedor.TabIndex = 0;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(295, 375);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(149, 20);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Documento Cliente:";
            // 
            // txtDniCliente
            // 
            this.txtDniCliente.Location = new System.Drawing.Point(452, 372);
            this.txtDniCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDniCliente.Name = "txtDniCliente";
            this.txtDniCliente.Size = new System.Drawing.Size(202, 26);
            this.txtDniCliente.TabIndex = 3;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(680, 379);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(111, 58);
            this.btnBuscarCliente.TabIndex = 4;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(166, 42);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(148, 26);
            this.txtCodigoProducto.TabIndex = 10;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(28, 46);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(126, 20);
            this.lblProducto.TabIndex = 11;
            this.lblProducto.Text = "Codigo Poducto:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(364, 38);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(112, 35);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gridDetalleVenta
            // 
            this.gridDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalleVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodProducto,
            this.Descripcion,
            this.Talle,
            this.Precio,
            this.Cantidad});
            this.gridDetalleVenta.Location = new System.Drawing.Point(18, 83);
            this.gridDetalleVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridDetalleVenta.Name = "gridDetalleVenta";
            this.gridDetalleVenta.Size = new System.Drawing.Size(832, 263);
            this.gridDetalleVenta.TabIndex = 13;
            this.gridDetalleVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalleVenta_CellContentClick);
            // 
            // CodProducto
            // 
            this.CodProducto.HeaderText = "CodigoProducto";
            this.CodProducto.Name = "CodProducto";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Talle
            // 
            this.Talle.HeaderText = "Talle";
            this.Talle.Name = "Talle";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(825, 379);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(94, 58);
            this.btnConfirmar.TabIndex = 14;
            this.btnConfirmar.Text = "Confirmar Compra";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(961, 379);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(88, 58);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(120, 372);
            this.txtVendedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(154, 26);
            this.txtVendedor.TabIndex = 16;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(894, 100);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(74, 29);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "Total:";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTotal.Location = new System.Drawing.Point(884, 183);
            this.lblMontoTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(165, 36);
            this.lblMontoTotal.TabIndex = 18;
            this.lblMontoTotal.Text = "MontoTotal";
            this.lblMontoTotal.Visible = false;
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(295, 417);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(95, 20);
            this.lblTarjeta.TabIndex = 19;
            this.lblTarjeta.Text = "Nro. Tarjeta:";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Location = new System.Drawing.Point(452, 414);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(202, 26);
            this.txtTarjeta.TabIndex = 20;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(138, 414);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(136, 28);
            this.cboFormaPago.TabIndex = 21;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(14, 420);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(118, 20);
            this.lblFormaPago.TabIndex = 22;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 486);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.gridDetalleVenta);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtDniCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblVendedor);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtDniCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView gridDetalleVenta;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Talle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
    }
}