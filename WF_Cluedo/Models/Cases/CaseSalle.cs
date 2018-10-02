using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cluedo.Models.Cases
{
    class CaseSalle : AbstractPetiteCase
    {
        Image _imageFond;
        int _numeroSalleCase;

        private Image ImageFond { get { return _imageFond; } set { _imageFond = value; } }
        public int NumeroSalleCase { get => _numeroSalleCase; set => _numeroSalleCase = value; }

        public CaseSalle(int posX, int posY, int numeroSalleCase)
        {
            PositionX = posX;
            PositionY = posY;

            NumeroSalleCase = numeroSalleCase; 
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            Brush b;
            PointF p = new PointF(PositionX, PositionY);

            //Cuisine = 2, SalleDeBal = 3, Veranda = 4, billard = 5, biblio = 6, bureau = 7, hall = 8, salon = 9, SalleManger = 10, 
            switch (NumeroSalleCase)
            {
                case 2:
                    b = Brushes.LightGray;
                    break;
                case 3:
                    b = Brushes.LightPink;
                    break;
                case 4:
                    b = Brushes.LightSalmon;
                    break;
                case 5:
                    b = Brushes.LightBlue;
                    break;
                case 6:
                    b = Brushes.LightYellow;
                    break;
                case 7:
                    b = Brushes.LightBlue;
                    break;
                case 8:
                    b = Brushes.LightPink;
                    break;
                case 9:
                    b = Brushes.LightSeaGreen;
                    break;
                case 10:
                    b = Brushes.LightYellow;
                    break;
                case 11:
                    b = Brushes.RosyBrown;
                    break;
                default:
                    b = Brushes.Black;
                    break;
            }

            //e.Graphics.DrawImage(ImageFond, p);
            e.Graphics.FillRectangle(b, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
            //e.Graphics.DrawRectangle(Pens.Gray, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
