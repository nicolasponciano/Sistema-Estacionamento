namespace Estacionamento
{
    partial class Listar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Listar));
            this.estacionamentoDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnListaCadastro = new System.Windows.Forms.Button();
            this.btnfechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.estacionamentoDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListaCadastro
            // 
            this.btnListaCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaCadastro.Location = new System.Drawing.Point(311, 285);
            this.btnListaCadastro.Name = "btnListaCadastro";
            this.btnListaCadastro.Size = new System.Drawing.Size(232, 33);
            this.btnListaCadastro.TabIndex = 0;
            this.btnListaCadastro.Text = "Lista";
            this.btnListaCadastro.UseVisualStyleBackColor = true;
            this.btnListaCadastro.Click += new System.EventHandler(this.btnListaCadastro_Click);
            // 
            // btnfechar
            // 
            this.btnfechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfechar.Location = new System.Drawing.Point(23, 12);
            this.btnfechar.Name = "btnfechar";
            this.btnfechar.Size = new System.Drawing.Size(71, 33);
            this.btnfechar.TabIndex = 1;
            this.btnfechar.Text = "Fechar";
            this.btnfechar.UseVisualStyleBackColor = true;
            this.btnfechar.Click += new System.EventHandler(this.btnfechar_Click);
            // 
            // Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 330);
            this.Controls.Add(this.btnfechar);
            this.Controls.Add(this.btnListaCadastro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Listar";
            this.Text = "Listar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Listar_FormClosing);
            this.Load += new System.EventHandler(this.Listar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.estacionamentoDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource estacionamentoDataSet1BindingSource;
        private System.Windows.Forms.Button btnListaCadastro;
        private System.Windows.Forms.Button btnfechar;
    }
}