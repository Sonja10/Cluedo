using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Cluedo.Models
{
    public class MesDictionaires
    {
        public static Dictionary<string, Color> IndexCouleurNomPerso { get => IndexCouleurNomPerso; private set => IndexCouleurNomPerso = value; }

        public MesDictionaires()
        {
            IndexCouleurNomPerso = new Dictionary<string, Color>
            {
                {"Moutarde", Color.Gold },
                {"Pervenche", Color.Blue },
                {"Violet", Color.Purple },
                {"Olive", Color.Green },
                {"LeBlanc", Color.White },
                {"Rose", Color.Red }
            };
        }
    }
}
