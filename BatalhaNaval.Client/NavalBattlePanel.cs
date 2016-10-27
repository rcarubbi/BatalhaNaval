using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BatalhaNaval.Client
{
    

    public partial class NavalBattlePanel : UserControl
    {
        public NavalBattlePanel()
        {
            InitializeComponent();
            PrepareMatrix();
        }
        private bool _readonly;
        public bool ReadOnly
        {
            get
            {
                return _readonly;
            }

            set
            {
                _readonly = value;
                foreach (Control c in this.tableLayoutPanel5.Controls)
                {
                    c.Enabled = !_readonly;
                }
            }
        }




        private void PrepareMatrix()
        {
            TextBox cell = null;
            for (int x=0; x<15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    cell = new TextBox();
                    cell.Click += new EventHandler(cell_Click);
                    this.tableLayoutPanel5.Controls.Add(cell, x, y);
                }
            }
        }

        public event EventHandler<CellSelectedEventArgs> OnSelectedCell;

        void cell_Click(object sender, EventArgs e)
        {
            if (!ReadOnly)
            {
                TextBox selectedCell = ((TextBox)sender);
                selectedCell.Text = "X";
                TableLayoutPanelCellPosition position = this.tableLayoutPanel5.GetPositionFromControl(selectedCell);
                
                if (OnSelectedCell != null)
                {
                    OnSelectedCell(this, new CellSelectedEventArgs() { Coordinates = new Point(position.Row, position.Column) });
                }
            }
        }

        public void PutShip(int shipId, Point initialPosition, Orientation orientation, int shipSize)
        {
            TextBox position;
            for (int i = 0; i < shipSize; i++)
            {
                if (orientation == Orientation.Horizontal)
                {
                    position = (TextBox)this.tableLayoutPanel5.GetControlFromPosition(initialPosition.Y++, initialPosition.X);
                }
                else
                {
                    position = (TextBox)this.tableLayoutPanel5.GetControlFromPosition(initialPosition.Y, initialPosition.X++);
                }
                position.Text = shipId.ToString();
            }

        
        }
    }
}
