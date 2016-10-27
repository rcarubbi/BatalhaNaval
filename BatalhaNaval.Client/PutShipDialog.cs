using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatalhaNaval.Client
{
    public partial class PutShipDialog : Form
    {
        public PutShipDialog()
        {
            InitializeComponent();
        }

        public event EventHandler<CellSelectedEventArgs> OnSelectedCell;

      

        private void PutShipDialog_Load(object sender, EventArgs e)
        {
            navalBattlePanel1.OnSelectedCell += new EventHandler<CellSelectedEventArgs>(navalBattlePanel1_OnSelectedCell);
            navalBattlePanel1.ReadOnly = false;
        }

        void navalBattlePanel1_OnSelectedCell(object sender, CellSelectedEventArgs e)
        {
            /*if (((TextBox)navalBattlePanel1.GetChildAtPoint(e.Coordinates)).Text == "X")
                throw new ApplicationException("Você já atacou esta posição");*/

            if (OnSelectedCell != null)
            {
            
                OnSelectedCell(sender, new CellSelectedEventArgs() { 
                    Coordinates = e.Coordinates  });
            }
            this.Hide();
        }

      
    }
}
