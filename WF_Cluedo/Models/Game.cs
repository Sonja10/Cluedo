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
        const int _POSITION_XY_1ERE_CASE = 10;

        List<Joueur> _joueurs; // recoit depuis l'autre forme
        List<AbstractCartes> _combinaisonVictorieuse; // Tirer au hasard dans _toutes les cartes possibles
        List<AbstractCartes> _toutesLesCartesPossibles; // Mettre en dur
        List<AbstractPetiteCase> _petitesCases; // Liste de toute les petites cases Sous forme de matrice?
        List<Salle> _salles; 
        Joueur _joueurActuel;

        // CaseCouloir = 1, Salle = 2, EntréeSalle = 3, Depart = -1, rien = 0
        int[][] matriceAffichageCase = new int[][]
        {
            new int[] { 2, 2, 2, 2, 2, 2, 0, 0, 0, -1, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 2, 2, 2, 2, 2, 2, 0, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 0, 2, 2, 2, 2, 2, 2 }, 
            new int[] { 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 1, 1, 1, 3, 2, 2, 2, 0 },
            new int[] { 0, 2, 2, 2, 3, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, -1 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 3, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 2, 2, 0 },
            new int[] { 2, 2, 2, 2, 2, 2, 3, 2, 1, 1, 0, 0, 0, 0, 0, 1, 1, 2, 2, 2, 2, 2, 2, 2 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 3, 2, 2, 2, 2, 2, 2 },
            new int[] { -1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2 }, 
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 2, 2, 1, 1, 1, 2, 2, 2, 2, 2, 0 },
            new int[] { 2, 2, 2, 2, 2, 2, 3, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, -1 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 3, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 2, 1, 1, 2, 2, 2, 2, 2, 2, 1, 1, 3, 2, 2, 2, 2, 2, 2 },
            new int[] { 2, 2, 2, 2, 2, 2, 0, -1, 0, 0, 2, 2, 2, 2, 0, 0, 1, 0, 2, 2, 2, 2, 2, 2 }
        };

        public List<AbstractCartes> ToutesLesCartesPossibles { get { return _toutesLesCartesPossibles; } private set { _toutesLesCartesPossibles = value; } }
        public List<AbstractPetiteCase> PetitesCases { get { return _petitesCases; } private set { _petitesCases = value; } }


        public Game(List<Joueur> joueurs, Form view)
        {
            // Plateau de jeu

            int posX = _POSITION_XY_1ERE_CASE;
            int posY = _POSITION_XY_1ERE_CASE;
            int largeurCase = (new CaseCouloir(1, 1)).WIDTH_CASE;
            int hauteurCase = (new CaseCouloir(1, 1)).HEIGHT_CASE;

            PetitesCases = new List<AbstractPetiteCase>();

            for (int i = 0; i < matriceAffichageCase.Length; i++)
            {
                for (int j = 0; j < matriceAffichageCase[i].Length; j++)
                {
                    if (matriceAffichageCase[i][j] == 1)
                    {
                        CaseCouloir caseCouloir = new CaseCouloir(posX, posY);
                        PetitesCases.Add(caseCouloir);
                    }

                    posX += largeurCase;
                }

                posY += hauteurCase;
                posX = _POSITION_XY_1ERE_CASE;
            }



            foreach (AbstractPetiteCase apc in PetitesCases)
            {
                view.Paint += apc.Paint;
            }



            //Set main joueur
        }

    }
}
