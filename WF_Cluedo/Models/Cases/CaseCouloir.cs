using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cluedo.Models.Cases
{
    class CaseCouloir : AbstractPetiteCase
    {
        Image _imageFond;

        private Image ImageFond { get { return _imageFond; } set { _imageFond = value; } }

        public CaseCouloir(int posX, int posY)
        {
            PositionX = posX;
            PositionY = posY;
            ImageFond = Properties.Resources.fondCouloirs;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            PointF p = new PointF(PositionX, PositionY);
            e.Graphics.DrawImage(ImageFond, p);
        }
    }
}
