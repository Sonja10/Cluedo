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
        const int _WIDTH_CASE = 60;
        const int _HEIGHT_CASE = 60;

        int _positionX;
        int _positionY;

        public int WIDTH_CASE { get { return _WIDTH_CASE; } }
        public int HEIGHT_CASE { get { return _HEIGHT_CASE; } } 

        public int PositionX { get { return _positionX; } set { _positionX = value; } }
        public int PositionY { get { return _positionY; } set { _positionY = value; } }

        public virtual void Paint(object sender, PaintEventArgs e)
        {
            PointF p = new PointF(PositionX, PositionY);
        }
    }
}
