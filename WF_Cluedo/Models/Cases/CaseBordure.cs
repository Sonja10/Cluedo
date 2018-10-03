using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cluedo.Models.Cases
{
    // Finalement mieux sans, on garde kan meme au cas ou
    class CaseBordure
    {
        const int _WIDTH_CASE = 30;
        const int _HEIGHT_CASE = 10;

        int _positionX;
        int _positionY;

        public int WIDTH_CASE { get { return _WIDTH_CASE; } }
        public int HEIGHT_CASE { get { return _HEIGHT_CASE; } }

        public int PositionX { get { return _positionX; } set { _positionX = value; } }
        public int PositionY { get { return _positionY; } set { _positionY = value; } }

        public CaseBordure(int posX, int posY)
        {
            PositionX = posX;
            PositionY = posY;
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            PointF p = new PointF(PositionX, PositionY);
            e.Graphics.FillRectangle(Brushes.Black/*Brushes.DarkSlateGray*/, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
