namespace CentroEducativoApp
{
    partial class Docente
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
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerNotas = new System.Windows.Forms.Button();
            this.btnCargarNota = new System.Windows.Forms.Button();
            this.btnHorarioTrabajo = new System.Windows.Forms.Button();
            this.btnListaEstudiantes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(510, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Docente";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Location = new System.Drawing.Point(12, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 43);
            this.button4.TabIndex = 7;
            this.button4.Text = "Ocultar Menu";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnVerNotas);
            this.panel1.Controls.Add(this.btnCargarNota);
            this.panel1.Controls.Add(this.btnHorarioTrabajo);
            this.panel1.Controls.Add(this.btnListaEstudiantes);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 424);
            this.panel1.TabIndex = 6;
            // 
            // btnVerNotas
            // 
            this.btnVerNotas.Location = new System.Drawing.Point(0, 248);
            this.btnVerNotas.Name = "btnVerNotas";
            this.btnVerNotas.Size = new System.Drawing.Size(200, 33);
            this.btnVerNotas.TabIndex = 7;
            this.btnVerNotas.Text = "Ver nota de estudiante";
            this.btnVerNotas.UseVisualStyleBackColor = true;
            // 
            // btnCargarNota
            // 
            this.btnCargarNota.Location = new System.Drawing.Point(0, 186);
            this.btnCargarNota.Name = "btnCargarNota";
            this.btnCargarNota.Size = new System.Drawing.Size(200, 33);
            this.btnCargarNota.TabIndex = 6;
            this.btnCargarNota.Text = "Poner nota a estudiante";
            this.btnCargarNota.UseVisualStyleBackColor = true;
            this.btnCargarNota.Click += new System.EventHandler(this.btnCargarNota_Click);
            // 
            // btnHorarioTrabajo
            // 
            this.btnHorarioTrabajo.Location = new System.Drawing.Point(0, 117);
            this.btnHorarioTrabajo.Name = "btnHorarioTrabajo";
            this.btnHorarioTrabajo.Size = new System.Drawing.Size(200, 33);
            this.btnHorarioTrabajo.TabIndex = 5;
            this.btnHorarioTrabajo.Text = "Horario Laboral";
            this.btnHorarioTrabajo.UseVisualStyleBackColor = true;
            this.btnHorarioTrabajo.Click += new System.EventHandler(this.btnHorarioTrabajo_Click);
            // 
            // btnListaEstudiantes
            // 
            this.btnListaEstudiantes.Location = new System.Drawing.Point(0, 54);
            this.btnListaEstudiantes.Name = "btnListaEstudiantes";
            this.btnListaEstudiantes.Size = new System.Drawing.Size(200, 30);
            this.btnListaEstudiantes.TabIndex = 4;
            this.btnListaEstudiantes.Text = "Lista de estudiantes";
            this.btnListaEstudiantes.UseVisualStyleBackColor = true;
            this.btnListaEstudiantes.Click += new System.EventHandler(this.btnListaEstudiantes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(406, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bienvenido";
            // 
            // Docente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 518);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Docente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Docente";
            this.Load += new System.EventHandler(this.Docente_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnListaEstudiantes;
        private System.Windows.Forms.Button btnHorarioTrabajo;
        private System.Windows.Forms.Button btnCargarNota;
        private System.Windows.Forms.Button btnVerNotas;
        private System.Windows.Forms.Label label2;
    }
}