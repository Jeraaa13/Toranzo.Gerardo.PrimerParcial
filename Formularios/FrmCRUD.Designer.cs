namespace Formularios
{
    partial class FrmCRUD
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            lstbRead = new ListBox();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 217);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(89, 42);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(276, 217);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 42);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(524, 217);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 36);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // lstbRead
            // 
            lstbRead.FormattingEnabled = true;
            lstbRead.ItemHeight = 15;
            lstbRead.Location = new Point(12, 12);
            lstbRead.Name = "lstbRead";
            lstbRead.Size = new Size(595, 199);
            lstbRead.TabIndex = 3;
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 265);
            Controls.Add(lstbRead);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Name = "FrmCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRUD";
            FormClosing += FrmCRUD_FormClosing;
            FormClosed += FrmCRUD_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        protected Button btnAgregar;
        protected Button btnModificar;
        protected Button btnEliminar;
        protected ListBox lstbRead;
    }
}