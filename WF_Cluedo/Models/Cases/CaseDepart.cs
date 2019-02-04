using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cluedo.Models.Cases
{
    class CaseDepart : AbstractPetiteCase
    {
        int _numeroPersoCase;
        
        public int NumeroPersoCase { get => _numeroPersoCase; set => _numeroPersoCase = value; }

        public CaseDepart(int posX, int posY, int matricePosX, int matricePosY, int numeroPersoCase)
        {
            PositionX = posX;
            PositionY = posY;
            MatricePosX = matricePosX;
            MatricePosY = matricePosY;
            TypeDeLaCase = TYPES_CASES.Depart;
            NumeroPersoCase = numeroPersoCase; //Nombre que jai mis dans la matrice des cases du jeu pour differencier les personnages/couleurs
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            Brush b;
            PointF p = new PointF(PositionX, PositionY);

            //DepartBlanc = -1, DepartVert = -2, DepartBleu = -3, DepartViolet = -4, DepartRose = -5, DepartJaune = -6
            switch (NumeroPersoCase)
            {
                case -1:
                    b = Brushes.White;
                    break;
                case -2:
                    b = Brushes.Green;
                    break;
                case -3:
                    b = Brushes.Blue;
                    break;
                case -4:
                    b = Brushes.Purple;
                    break;
                case -5:
                    b = Brushes.Red;
                    break;
                case -6:
                    b = Brushes.Gold;
                    break;
                default:
                    b = Brushes.Black;
                    break;
            }

            e.Graphics.FillRectangle(b, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
            e.Graphics.DrawRectangle(Pens.Gray, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
