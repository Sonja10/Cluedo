using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_Cluedo.Models.Cartes;

namespace WF_Cluedo.Models
{
    class Joueur
    {

        NomsJoueurs _nomJoueur;
        int _indexCaseActuelle;
        List<AbstractCartes> _cartesEnMain;
        // faire un dictionnaire qui fait correspondre les noms des joueurs aux index des case de depart

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
    }
}
