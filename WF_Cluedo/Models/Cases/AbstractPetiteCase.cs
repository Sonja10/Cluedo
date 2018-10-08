using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cluedo
{
    class AbstractPetiteCase
    {
        const int _WIDTH_CASE = 30;
        const int _HEIGHT_CASE = 30;

        int _positionX;
        int _positionY;
        bool _occupee;

        public int WIDTH_CASE { get { return _WIDTH_CASE; } }
        public int HEIGHT_CASE { get { return _HEIGHT_CASE; } } 

        public int PositionX { get { return _positionX; } set { _positionX = value; } }
        public int PositionY { get { return _positionY; } set { _positionY = value; } }
        public bool Occupee { get => _occupee; set => _occupee = false; }

        public virtual void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }
    }
}
