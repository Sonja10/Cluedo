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
        string _nomSalle;

        private Image ImageFond { get { return _imageFond; } set { _imageFond = value; } }
        public int NumeroSalleCase { get => _numeroSalleCase; set => _numeroSalleCase = value; }
        public string NomSalle { get => _nomSalle; set => _nomSalle = value; }

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
                    NomSalle = "Cuisine";
                    b = Brushes.LightGray;
                    break;
                case 3:
                    NomSalle = "Salle de bal";
                    b = Brushes.LightPink;
                    break;
                case 4:
                    NomSalle = "Véranda";
                    b = Brushes.LightSalmon;
                    break;
                case 5:
                    NomSalle = "Billard";
                    b = Brushes.LightBlue;
                    break;
                case 6:
                    NomSalle = "Biblio";
                    b = Brushes.LightYellow;
                    break;
                case 7:
                    NomSalle = "Bureau";
                    b = Brushes.LightBlue;
                    break;
                case 8:
                    NomSalle = "Hall";
                    b = Brushes.LightPink;
                    break;
                case 9:
                    NomSalle = "Salon";
                    b = Brushes.LightSeaGreen;
                    break;
                case 10:
                    NomSalle = "Salle à manger";
                    b = Brushes.LightYellow;
                    break;
                case 11:
                    //Voir comment faire pour le faire correspondre a la bonne salle aussi
                    b = Brushes.BurlyWood;
                    break;
                default:
                    b = Brushes.Black;
                    break;
            }

            e.Graphics.FillRectangle(b, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
