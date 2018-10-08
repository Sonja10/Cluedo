using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Cluedo.Models.Cases;

namespace WF_Cluedo.Models
{
    class Salle
    {
        string _nomSalle;
        List<CaseSalle> _casesDeLaSalle;
        bool _occupe;

        public bool Occupe { get => _occupe; set => _occupe = false; }
        public List<CaseSalle> CasesDeLaSalle { get => _casesDeLaSalle; set => _casesDeLaSalle = value; }
        public string NomSalle { get => _nomSalle; set => _nomSalle = value; }

        public Salle(string nom)
        {
            NomSalle = nom;
            CasesDeLaSalle = new List<CaseSalle>();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            const int DECALAGE_LABEL_X = 10;
            const int DECALAGE_LABEL_Y = 10;

            int positionX_1ereCaseSalle = CasesDeLaSalle[0].PositionX;
            int positionY_1ereCaseSalle = CasesDeLaSalle[0].PositionY;

            Point p = new Point(positionX_1ereCaseSalle + DECALAGE_LABEL_X, positionY_1ereCaseSalle + DECALAGE_LABEL_Y);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.DrawString(NomSalle, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, p);
        }
    }
}
