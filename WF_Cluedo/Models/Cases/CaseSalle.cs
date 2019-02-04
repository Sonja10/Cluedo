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

        public CaseSalle(int posX, int posY, int matricePosX, int matricePosY, int numeroSalleCase)
        {
            PositionX = posX;
            PositionY = posY;
            MatricePosX = matricePosX;
            MatricePosY = matricePosY;
            TypeDeLaCase = TYPES_CASES.Salle;

            NumeroSalleCase = numeroSalleCase;

            //Cuisine = 2, SalleDeBal = 3, Veranda = 4, billard = 5, biblio = 6, bureau = 7, hall = 8, salon = 9, SalleManger = 10, 
            switch (NumeroSalleCase)
            {
                case 2:
                    NomSalle = "Cuisine";
                    break;
                case 3:
                    NomSalle = "Salle de bal";
                    break;
                case 4:
                    NomSalle = "Véranda";
                    break;
                case 5:
                    NomSalle = "Billard";
                    break;
                case 6:
                    NomSalle = "Biblio";
                    break;
                case 7:
                    NomSalle = "Bureau";
                    break;
                case 8:
                    NomSalle = "Hall";
                    break;
                case 9:
                    NomSalle = "Salon";
                    break;
                case 10:
                    NomSalle = "Salle à manger";
                    break;
                case 11:
                    break;
                default:
                    break;
            }
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            Brush b;
            PointF p = new PointF(PositionX, PositionY);
            
            switch (NomSalle)
            {
                case "Cuisine":
                    b = Brushes.LightGray;
                    break;
                case "Salle de bal":
                    b = Brushes.LightPink;
                    break;
                case "Véranda":
                    b = Brushes.LightSalmon;
                    break;
                case "Billard":
                    b = Brushes.LightBlue;
                    break;
                case "Biblio":
                    b = Brushes.LightYellow;
                    break;
                case "Bureau":
                    b = Brushes.LightBlue;
                    break;
                case "Hall":
                    b = Brushes.LightPink;
                    break;
                case "Salon":
                    b = Brushes.LightSeaGreen;
                    break;
                case "Salle à manger":
                    b = Brushes.LightYellow;
                    break;
                default:
                    //Voir comment faire pour le faire correspondre a la bonne salle aussi
                    b = Brushes.BurlyWood;
                    break;
            }

            e.Graphics.FillRectangle(b, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
