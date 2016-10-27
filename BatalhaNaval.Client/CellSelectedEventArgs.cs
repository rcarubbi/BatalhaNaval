using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BatalhaNaval.Client
{
    public class CellSelectedEventArgs : EventArgs
    {
        public Point Coordinates
        {
            get;
            set;
        }

      


    }
}
