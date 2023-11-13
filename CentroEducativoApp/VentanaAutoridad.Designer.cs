namespace CentroEducativoApp
{
    partial class VentanaAutoridad
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPagarCuota = new System.Windows.Forms.Button();
            this.btnListadoAlumXDocente = new System.Windows.Forms.Button();
            this.btnInscribirAlumno = new System.Windows.Forms.Button();
            this.btnDeudores = new System.Windows.Forms.Button();
            this.btnListadoAlumXCurso = new System.Windows.Forms.Button();
            this.btnRegistrarAlumno = new System.Windows.Forms.Button();
            this.btnRegistrarCurso = new System.Windows.Forms.Button();
            this.btnRegistarDocente = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnPagarCuota);
            this.panel1.Controls.Add(this.btnListadoAlumXDocente);
            this.panel1.Controls.Add(this.btnInscribirAlumno);
            this.panel1.Controls.Add(this.btnDeudores);
            this.panel1.Controls.Add(this.btnListadoAlumXCurso);
            this.panel1.Controls.Add(this.btnRegistrarAlumno);
            this.panel1.Controls.Add(this.btnRegistrarCurso);
            this.panel1.Controls.Add(this.btnRegistarDocente);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 435);
            this.panel1.TabIndex = 0;
            // 
            // btnPagarCuota
            // 
            this.btnPagarCuota.Location = new System.Drawing.Point(0, 381);
            this.btnPagarCuota.Name = "btnPagarCuota";
            this.btnPagarCuota.Size = new System.Drawing.Size(200, 33);
            this.btnPagarCuota.TabIndex = 4;
            this.btnPagarCuota.Text = "Pagar Cuota";
            this.btnPagarCuota.UseVisualStyleBackColor = true;
            this.btnPagarCuota.Click += new System.EventHandler(this.btnPagarCuota_Click);
            // 
            // btnListadoAlumXDocente
            // 
            this.btnListadoAlumXDocente.Location = new System.Drawing.Point(0, 226);
            this.btnListadoAlumXDocente.Name = "btnListadoAlumXDocente";
            this.btnListadoAlumXDocente.Size = new System.Drawing.Size(200, 33);
            this.btnListadoAlumXDocente.TabIndex = 6;
            this.btnListadoAlumXDocente.Text = "Listado de Alumnos por docente";
            this.btnListadoAlumXDocente.UseVisualStyleBackColor = true;
            this.btnListadoAlumXDocente.Click += new System.EventHandler(this.btnListadoAlumXDocente_Click);
            // 
            // btnInscribirAlumno
            // 
            this.btnInscribirAlumno.Location = new System.Drawing.Point(0, 325);
            this.btnInscribirAlumno.Name = "btnInscribirAlumno";
            this.btnInscribirAlumno.Size = new System.Drawing.Size(200, 34);
            this.btnInscribirAlumno.TabIndex = 5;
            this.btnInscribirAlumno.Text = "Inscribir alumno a cursos";
            this.btnInscribirAlumno.UseVisualStyleBackColor = true;
            this.btnInscribirAlumno.Click += new System.EventHandler(this.btnInscribirAlumno_Click);
            // 
            // btnDeudores
            // 
            this.btnDeudores.Location = new System.Drawing.Point(0, 275);
            this.btnDeudores.Name = "btnDeudores";
            this.btnDeudores.Size = new System.Drawing.Size(200, 30);
            this.btnDeudores.TabIndex = 4;
            this.btnDeudores.Text = "Listado Deudores";
            this.btnDeudores.UseVisualStyleBackColor = true;
            this.btnDeudores.Click += new System.EventHandler(this.btnDeudores_Click);
            // 
            // btnListadoAlumXCurso
            // 
            this.btnListadoAlumXCurso.Location = new System.Drawing.Point(0, 177);
            this.btnListadoAlumXCurso.Name = "btnListadoAlumXCurso";
            this.btnListadoAlumXCurso.Size = new System.Drawing.Size(200, 33);
            this.btnListadoAlumXCurso.TabIndex = 3;
            this.btnListadoAlumXCurso.Text = "Listado de Alumnos";
            this.btnListadoAlumXCurso.UseVisualStyleBackColor = true;
            this.btnListadoAlumXCurso.Click += new System.EventHandler(this.btnListadoAlumXCurso_Click);
            // 
            // btnRegistrarAlumno
            // 
            this.btnRegistrarAlumno.Location = new System.Drawing.Point(0, 124);
            this.btnRegistrarAlumno.Name = "btnRegistrarAlumno";
            this.btnRegistrarAlumno.Size = new System.Drawing.Size(200, 33);
            this.btnRegistrarAlumno.TabIndex = 2;
            this.btnRegistrarAlumno.Text = "Registrar Alumno";
            this.btnRegistrarAlumno.UseVisualStyleBackColor = true;
            this.btnRegistrarAlumno.Click += new System.EventHandler(this.btnRegistrarAlumno_Click);
            // 
            // btnRegistrarCurso
            // 
            this.btnRegistrarCurso.Location = new System.Drawing.Point(0, 71);
            this.btnRegistrarCurso.Name = "btnRegistrarCurso";
            this.btnRegistrarCurso.Size = new System.Drawing.Size(200, 35);
            this.btnRegistrarCurso.TabIndex = 1;
            this.btnRegistrarCurso.Text = "Registrar Materia";
            this.btnRegistrarCurso.UseVisualStyleBackColor = true;
            this.btnRegistrarCurso.Click += new System.EventHandler(this.btnRegistrarCurso_Click);
            // 
            // btnRegistarDocente
            // 
            this.btnRegistarDocente.Location = new System.Drawing.Point(0, 20);
            this.btnRegistarDocente.Name = "btnRegistarDocente";
            this.btnRegistarDocente.Size = new System.Drawing.Size(200, 34);
            this.btnRegistarDocente.TabIndex = 0;
            this.btnRegistarDocente.Text = "Registrar Docente";
            this.btnRegistarDocente.UseVisualStyleBackColor = true;
            this.btnRegistarDocente.Click += new System.EventHandler(this.btnRegistarDocente_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Location = new System.Drawing.Point(12, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 43);
            this.button4.TabIndex = 3;
            this.button4.Text = "Ocultar Menu";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // VentanaAutoridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaAutoridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana Autoridad";
            this.Load += new System.EventHandler(this.VentanaAutoridad_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnRegistrarAlumno;
        private System.Windows.Forms.Button btnRegistrarCurso;
        private System.Windows.Forms.Button btnRegistarDocente;
        private System.Windows.Forms.Button btnListadoAlumXCurso;
        private System.Windows.Forms.Button btnDeudores;
        private System.Windows.Forms.Button btnPagarCuota;
        private System.Windows.Forms.Button btnInscribirAlumno;
        private System.Windows.Forms.Button btnListadoAlumXDocente;
        private System.Windows.Forms.Label label1;
    }
}