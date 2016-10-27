namespace BatalhaNaval.Client
{
    partial class PutShipDialog
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
            this.navalBattlePanel1 = new BatalhaNaval.Client.NavalBattlePanel();
            this.SuspendLayout();
            // 
            // navalBattlePanel1
            // 
            this.navalBattlePanel1.Location = new System.Drawing.Point(12, 12);
            this.navalBattlePanel1.Name = "navalBattlePanel1";
            this.navalBattlePanel1.ReadOnly = false;
            this.navalBattlePanel1.Size = new System.Drawing.Size(512, 383);
            this.navalBattlePanel1.TabIndex = 2;
            // 
            // PutShipDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.navalBattlePanel1);
            this.Name = "PutShipDialog";
            this.Text = "Selecione uma coordenada para atacar";
            this.Load += new System.EventHandler(this.PutShipDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private NavalBattlePanel navalBattlePanel1;
    }
}