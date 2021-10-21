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
        bool _salleDeplacementPossible;
        string _directionBordure;

        private Image ImageFond { get { return _imageFond; } set { _imageFond = value; } }

        public string DirectionBordure { get => _directionBordure; set => _directionBordure = value; }
        public int NumeroSalleCase { get => _numeroSalleCase; set => _numeroSalleCase = value; }
        public string NomSalle { get => _nomSalle; set => _nomSalle = value; }
        public bool SalleDeplacementPossible { get => _salleDeplacementPossible; set => _salleDeplacementPossible = value; }
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
                case 12:
                    NomSalle = "Cuisine"; 
                    break;
                case 3:
                case 13:
                    NomSalle = "Salle de bal";
                    break;
                case 4:
                case 14:
                    NomSalle = "Véranda";
                    break;
                case 5:
                case 15:
                    NomSalle = "Billard";
                    break;
                case 6:
                case 16:
                    NomSalle = "Biblio";
                    break;
                case 7:
                case 17:
                    NomSalle = "Bureau";
                    break;
                case 8:
                case 18:
                    NomSalle = "Hall";
                    break;
                case 9:
                case 19:
                    NomSalle = "Salon";
                    break;
                case 10:
                case 100:
                    NomSalle = "Salle à manger";
                    break;
                default:
                    break;
            }
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            Brush b = Brushes.Black;
            Brush bd = Brushes.Red;
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
                    break;
            }

            if (NumeroSalleCase > 10)
            {
                b = Brushes.BurlyWood;
            }

            e.Graphics.FillRectangle(b, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);

            if (SalleDeplacementPossible)
            {
                switch (DirectionBordure)
                {
                    case "G":
                        e.Graphics.FillRectangle(bd, p.X, p.Y, 3, HEIGHT_CASE);                      
                        break;
                    case "D":
                        e.Graphics.FillRectangle(bd, p.X + WIDTH_CASE - 3, p.Y, 3, HEIGHT_CASE);
                        break;
                    case "H":
                        e.Graphics.FillRectangle(bd, p.X, p.Y, WIDTH_CASE, 3);
                        break;
                    case "B":
                        e.Graphics.FillRectangle(bd, p.X, p.Y + HEIGHT_CASE -3, WIDTH_CASE, 3);
                        break;
                    case "GH":
                        e.Graphics.FillRectangle(bd, p.X, p.Y, 3, HEIGHT_CASE);
                        e.Graphics.FillRectangle(bd, p.X, p.Y, WIDTH_CASE, 3);
                        break;
                    case "DH":
                        e.Graphics.FillRectangle(bd, p.X + WIDTH_CASE - 3, p.Y, 3, HEIGHT_CASE);
                        e.Graphics.FillRectangle(bd, p.X, p.Y, WIDTH_CASE, 3);
                        break;
                    case "GB":
                        e.Graphics.FillRectangle(bd, p.X, p.Y, 3, HEIGHT_CASE);
                        e.Graphics.FillRectangle(bd, p.X, p.Y + HEIGHT_CASE - 3, WIDTH_CASE, 3);
                        break;
                    case "DB":
                        e.Graphics.FillRectangle(bd, p.X + WIDTH_CASE - 3, p.Y, 3, HEIGHT_CASE);
                        e.Graphics.FillRectangle(bd, p.X, p.Y + HEIGHT_CASE - 3, WIDTH_CASE, 3);
                        break;
                    default:
                        break;
                }
            }

            
        }
    }
}
