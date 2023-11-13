namespace CentroEducativoApp
{
    partial class ListaDeudasHijos
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
            this.btnBuscarCuotas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBuscarCuotasImpagas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarCuotas
            // 
            this.btnBuscarCuotas.Location = new System.Drawing.Point(635, 375);
            this.btnBuscarCuotas.Name = "btnBuscarCuotas";
            this.btnBuscarCuotas.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCuotas.TabIndex = 11;
            this.btnBuscarCuotas.Text = "Buscar";
            this.btnBuscarCuotas.UseVisualStyleBackColor = true;
            this.btnBuscarCuotas.Click += new System.EventHandler(this.btnBuscarCuotas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(389, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Legajo:";
            // 
            // tbBuscarCuotasImpagas
            // 
            this.tbBuscarCuotasImpagas.Location = new System.Drawing.Point(466, 379);
            this.tbBuscarCuotasImpagas.Name = "tbBuscarCuotasImpagas";
            this.tbBuscarCuotasImpagas.Size = new System.Drawing.Size(100, 20);
            this.tbBuscarCuotasImpagas.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Buscar que cuotas debe el alumno:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(93, 85);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(617, 266);
            this.dataGridView2.TabIndex = 7;
            // 
            // ListaDeudasHijos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscarCuotas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBuscarCuotasImpagas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListaDeudasHijos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista deudas";
            this.Load += new System.EventHandler(this.ListaDeudasHijos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarCuotas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBuscarCuotasImpagas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}