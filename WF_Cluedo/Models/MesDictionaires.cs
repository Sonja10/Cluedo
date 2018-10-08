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
        static Dictionary<string, Color> _indexCouleurEtNomPerso;
        static Dictionary<string, int> _nomPersonnagesEtIndexDepart;
        static Dictionary<string, int> _nomSallesEtIndexNumCase;
        static Dictionary<int, string> _indexNumCaseEtNomSalles;
        public static Dictionary<string, Color> IndexCouleurEtNomPerso { get => _indexCouleurEtNomPerso; set => _indexCouleurEtNomPerso = value; }
        public static Dictionary<string, int> NomPersonnagesEtIndexDepart { get => _nomPersonnagesEtIndexDepart; set => _nomPersonnagesEtIndexDepart = value; }
        public static Dictionary<string, int> NomSallesEtIndexNumCase { get => _nomSallesEtIndexNumCase; set => _nomSallesEtIndexNumCase = value; }
        public static Dictionary<int, string> IndexNumCaseEtNomSalles { get => _indexNumCaseEtNomSalles; set => _indexNumCaseEtNomSalles = value; }

        public MesDictionaires()
        {
            IndexCouleurEtNomPerso = new Dictionary<string, Color>
            {
                {"Moutarde", Color.Gold },
                {"Pervenche", Color.Blue },
                {"Violet", Color.Purple },
                {"Olive", Color.Green },
                {"LeBlanc", Color.White },
                {"Rose", Color.Red }
            };

            NomPersonnagesEtIndexDepart = new Dictionary<string, int>() {
                { "LeBlanc", -1 },
                { "Olive", -2 },
                { "Pervenche", -3 },
                { "Violet", -4 },
                { "Rose", -5 },
                { "Moutarde", -6 }
            };

            NomSallesEtIndexNumCase = new Dictionary<string, int>() {
                { "Cuisine", 2 },
                { "Salle de bal", 3 },
                { "Véranda", 4 },
                { "Billard", 5 },
                { "Biblio", 6 },
                { "Bureau", 7 },
                { "Hall", 8 },
                { "Salon", 9 },
                { "Salle à manger", 10 }
            };

            IndexNumCaseEtNomSalles = new Dictionary<int, string>() {
                { 2, "Cuisine" },
                { 3, "Salle de bal" },
                { 4, "Véranda" },
                { 5, "Billard" },
                { 6, "Biblio" },
                { 7, "Bureau" },
                { 8, "Hall" },
                { 9, "Salon" },
                { 10, "Salle à manger" }
            };
        }
    }
}
