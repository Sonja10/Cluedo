using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Cluedo.Models.Cartes;
using WF_Cluedo.Models.Cases;

namespace WF_Cluedo.Models
{
    class Joueur
    {

        NomsJoueurs _nomJoueur;
        int _indexCaseActuelle;
        List<AbstractCartes> _cartesEnMain;
        // faire un dictionnaire qui fait correspondre les noms des joueurs aux index des case de depart

        public Dictionary<int, string> indexNumSallesEtNoms = new Dictionary<int, string>() {
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

        public NomsJoueurs NomJoueur { get { return _nomJoueur; } set { _nomJoueur = value; } }
        public int IndexCaseActuelle { get { return _indexCaseActuelle; } set { _indexCaseActuelle = value; } }
        internal List<AbstractCartes> CartesEnMain { get { return _cartesEnMain; } set { _cartesEnMain = value; } }

        public Joueur(NomsJoueurs nom)
        {
            NomJoueur = nom;
            // IndexCaseActuelle = case de depart en fonction du nom;
        }

        public void SetMainJoueur(List<AbstractCartes> touteLesCartesPossibles)
        {
            // tirer une main au hasard dans ces cartes
            // CartesEnMain = main tirée
        }


        /// <summary>
        /// Rend le nom de la salle si le joueur est dans une salle sinon rend un chaine vide
        /// </summary>
        /// <Game name="game">Jeu en cours</param>
        /// <returns>nom de la salle</returns>
        public string GetNomSalleSiDedans(Game game)
        {
            string nomSalle = string.Empty;

            foreach (Salle salle in game.Salles)
            {
                foreach (CaseSalle caseSalle in salle.CasesDeLaSalle)
                {
                    if (caseSalle.NumeroSalleCase == IndexCaseActuelle)
                    {
                        nomSalle = indexNumSallesEtNoms[IndexCaseActuelle];
                    }
                }
            }

            return nomSalle;
        }

        public void Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
