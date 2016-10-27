namespace BatalhaNaval.Client
{
    partial class frmGame
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
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.navalBattlePanelPlayer2 = new BatalhaNaval.Client.NavalBattlePanel();
            this.navalBattlePanelPlayer1 = new BatalhaNaval.Client.NavalBattlePanel();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.gpbOrientacao = new System.Windows.Forms.GroupBox();
            this.rdbHorizontal = new System.Windows.Forms.RadioButton();
            this.rdbVertical = new System.Windows.Forms.RadioButton();
            this.gpbOrientacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.Location = new System.Drawing.Point(7, 47);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(0, 30);
            this.lblPlayer1.TabIndex = 2;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.Location = new System.Drawing.Point(673, 47);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(0, 30);
            this.lblPlayer2.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(121, 16);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // navalBattlePanelPlayer2
            // 
            this.navalBattlePanelPlayer2.Location = new System.Drawing.Point(532, 140);
            this.navalBattlePanelPlayer2.Name = "navalBattlePanelPlayer2";
            this.navalBattlePanelPlayer2.ReadOnly = false;
            this.navalBattlePanelPlayer2.Size = new System.Drawing.Size(519, 386);
            this.navalBattlePanelPlayer2.TabIndex = 1;
            // 
            // navalBattlePanelPlayer1
            // 
            this.navalBattlePanelPlayer1.Location = new System.Drawing.Point(12, 140);
            this.navalBattlePanelPlayer1.Name = "navalBattlePanelPlayer1";
            this.navalBattlePanelPlayer1.ReadOnly = false;
            this.navalBattlePanelPlayer1.Size = new System.Drawing.Size(514, 389);
            this.navalBattlePanelPlayer1.TabIndex = 0;
            this.navalBattlePanelPlayer1.OnSelectedCell += new System.EventHandler<BatalhaNaval.Client.CellSelectedEventArgs>(this.navalBattlePanelPlayer1_OnSelectedCell);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(12, 16);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(103, 20);
            this.txtPlayerName.TabIndex = 4;
            // 
            // gpbOrientacao
            // 
            this.gpbOrientacao.Controls.Add(this.rdbHorizontal);
            this.gpbOrientacao.Controls.Add(this.rdbVertical);
            this.gpbOrientacao.Location = new System.Drawing.Point(12, 104);
            this.gpbOrientacao.Name = "gpbOrientacao";
            this.gpbOrientacao.Size = new System.Drawing.Size(218, 30);
            this.gpbOrientacao.TabIndex = 6;
            this.gpbOrientacao.TabStop = false;
            this.gpbOrientacao.Text = "Orientação";
            this.gpbOrientacao.Visible = false;
            // 
            // rdbHorizontal
            // 
            this.rdbHorizontal.AutoSize = true;
            this.rdbHorizontal.Location = new System.Drawing.Point(68, 9);
            this.rdbHorizontal.Name = "rdbHorizontal";
            this.rdbHorizontal.Size = new System.Drawing.Size(72, 17);
            this.rdbHorizontal.TabIndex = 4;
            this.rdbHorizontal.TabStop = true;
            this.rdbHorizontal.Text = "Horizontal";
            this.rdbHorizontal.UseVisualStyleBackColor = true;
            // 
            // rdbVertical
            // 
            this.rdbVertical.AutoSize = true;
            this.rdbVertical.Location = new System.Drawing.Point(150, 9);
            this.rdbVertical.Name = "rdbVertical";
            this.rdbVertical.Size = new System.Drawing.Size(60, 17);
            this.rdbVertical.TabIndex = 3;
            this.rdbVertical.TabStop = true;
            this.rdbVertical.Text = "Vertical";
            this.rdbVertical.UseVisualStyleBackColor = true;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 541);
            this.Controls.Add(this.gpbOrientacao);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.navalBattlePanelPlayer2);
            this.Controls.Add(this.navalBattlePanelPlayer1);
            this.Name = "frmGame";
            this.Text = "Carubbi\'s Batalha Naval";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.gpbOrientacao.ResumeLayout(false);
            this.gpbOrientacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NavalBattlePanel navalBattlePanelPlayer1;
        private NavalBattlePanel navalBattlePanelPlayer2;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.GroupBox gpbOrientacao;
        private System.Windows.Forms.RadioButton rdbHorizontal;
        private System.Windows.Forms.RadioButton rdbVertical;
    }
}

