using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cluedo.Models.Cases
{
    class CaseBordure : AbstractPetiteCase
    {

        public CaseBordure(int posX, int posY)
        {
            PositionX = posX;
            PositionY = posY;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            PointF p = new PointF(PositionX, PositionY);
            e.Graphics.FillRectangle(Brushes.Black, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
