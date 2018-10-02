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
    class Game
    {
        List<Joueur> _joueurs; // recoit depuis l'autre forme
        List<AbstractCartes> _combinaisonVictorieuse; // Tirer au hasard dans _toutes les cartes possibles
        List<AbstractCartes> _toutesLesCartesPossibles; // Mettre en dur
        List<AbstractPetiteCase> _petitesCases; // Liste de toute les petites cases Sous forme de matrice?
        List<Salle> _salles; 
        Joueur _joueurActuel;

        int[] matriceAffichageCase = new int[] { 1, 2, 3, 4 };

        public List<AbstractCartes> ToutesLesCartesPossibles { get { return _toutesLesCartesPossibles; } private set { _toutesLesCartesPossibles = value; } }
        public List<AbstractPetiteCase> PetitesCases { get { return _petitesCases; } private set { _petitesCases = value; } }


        public Game(List<Joueur> joueurs, Form view)
        {
            //Set main joueur

            PetitesCases = new List<AbstractPetiteCase>();

            CaseCouloir caseCouloir = new CaseCouloir(2, 2);
            PetitesCases.Add(caseCouloir);



            foreach (AbstractPetiteCase apc in PetitesCases)
            {
                view.Paint += apc.Paint;
            }
        }

    }
}
