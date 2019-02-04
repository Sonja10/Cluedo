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
        bool _caseDeplacementPossible;
        public Image ImageFond { get { return _imageFond; } set { _imageFond = value; } }
        public bool CaseDeplacementPossible { get => _caseDeplacementPossible; set => _caseDeplacementPossible = value; }

        public CaseCouloir(int posX, int posY, int matricePosX, int matricePosY)
        {
            PositionX = posX;
            PositionY = posY;
            MatricePosX = matricePosX;
            MatricePosY = matricePosY;
            CaseDeplacementPossible = false;
            TypeDeLaCase = TYPES_CASES.Couloir;
            ImageFond = Properties.Resources.fondCouloirs;
        }

        public override void Paint(object sender, PaintEventArgs e)
        {
            PointF p = new PointF(PositionX, PositionY);

            if (CaseDeplacementPossible)
                ImageFond = Properties.Resources.fondCouloirsPossible;
            else
                ImageFond = Properties.Resources.fondCouloirs;

            e.Graphics.DrawImage(ImageFond, p);
            e.Graphics.DrawRectangle(Pens.Gray, p.X, p.Y, WIDTH_CASE, HEIGHT_CASE);
        }
    }
}
