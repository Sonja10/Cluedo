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
        MesDictionaires dicos = new MesDictionaires();

        const int _POSITION_X_1ERE_CASE = 50;
        const int _POSITION_Y_1ERE_CASE = 20;

        List<Joueur> _joueurs; // recoit depuis l'autre forme
        List<Salle> _salles; // A creer et remplir des casesSalle
        List<AbstractCartes> _combinaisonVictorieuse; // Tirer au hasard dans _toutes les cartes possibles
        List<AbstractCartes> _toutesLesCartesPossibles; // Mettre en dur
        List<AbstractPetiteCase> _petitesCases; // Liste de toute les petites cases Sous forme de matrice?
        Joueur _joueurActuel;

        

        

        //CaseCouloir = 1, 
        //Cuisine = 2, SalleDeBal = 3, Veranda = 4, billard = 5, biblio = 6, bureau = 7, hall = 8, salon = 9, SalleManger = 10, 
        //EntréesSalles = 11, 
        //DepartBlanc = -1, DepartVert = -2, DepartBleu = -3, DepartViolet = -4, DepartRose = -5, DepartJaune = -6 
        //rien = 0
        public int[][] matriceAffichageCase = new int[][]
        {
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, -1, 0, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 2, 2, 2, 2, 2, 2, 0, 1, 1, 1, 3, 3, 3, 3, 1, 1, 1, 0, 4, 4, 4, 4, 4, 4, 0 }, 
            new int[] { 0, 2, 2, 2, 2, 2, 2, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 4, 4, 4, 4, 4, 4, 0 },
            new int[] { 0, 2, 2, 2, 2, 2, 2, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 4, 4, 4, 4, 4, 4, 0 },
            new int[] { 0, 2, 2, 2, 2, 2, 2, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 4, 4, 4, 4, 4, 4, 0 },
            new int[] { 0, 2, 2, 2, 2, 2, 2, 1, 1, 11, 3, 3, 3, 3, 3, 3, 11, 1, 1, 1, 11, 4, 4, 4, 0, 0 },
            new int[] { 0, 0, 2, 2, 2, 11, 2, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 1, 1, 1, 1, 1, -3, 0 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 3, 11, 3, 3, 3, 3, 11, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 11, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 11, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 5, 11, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 6, 6, 11, 6, 6, 0, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 11, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 6, 6, 6, 6, 6, 6, 6, 0 },
            new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 11, 6, 6, 6, 6, 6, 6, 0 },
            new int[] { 0, -6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 6, 6, 6, 6, 6, 6, 0 }, 
            new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 8, 8, 11, 11, 8, 8, 1, 1, 1, 6, 6, 6, 6, 6, 0, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 11, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 1, 1, 1, 1, 1, 1, -4, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 11, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 11, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 7, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 11, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 0, -5, 0, 0, 8, 8, 8, 8, 0, 0, 1, 0, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public List<AbstractCartes> ToutesLesCartesPossibles { get { return _toutesLesCartesPossibles; } private set { _toutesLesCartesPossibles = value; } }
        public List<AbstractPetiteCase> PetitesCases { get { return _petitesCases; } private set { _petitesCases = value; } }
        internal List<Salle> Salles { get => _salles; set => _salles = value; }
        internal List<Joueur> Joueurs { get => _joueurs; set => _joueurs = value; }

        public int POSITION_X_1ERE_CASE => _POSITION_X_1ERE_CASE;
        public int POSITION_Y_1ERE_CASE => _POSITION_Y_1ERE_CASE;

        public Game(List<Joueur> joueurs, Form view)
        {
            // Plateau de jeu

            int posX = POSITION_X_1ERE_CASE;
            int posY = POSITION_Y_1ERE_CASE;
            int largeurCase = (new CaseCouloir(1, 1)).WIDTH_CASE;
            int hauteurCase = (new CaseCouloir(1, 1)).HEIGHT_CASE;

            PetitesCases = new List<AbstractPetiteCase>();
            Salles = new List<Salle>()
            {
                new Salle("Cuisine"),
                new Salle("Salle de bal"),
                new Salle("Véranda"),
                new Salle("Billard"),
                new Salle("Biblio"),
                new Salle("Bureau"),
                new Salle("Hall"),
                new Salle("Salon"),
                new Salle("Salle à manger")
            };

            for (int i = 0; i < matriceAffichageCase.Length; i++)
            {
                for (int j = 0; j < matriceAffichageCase[i].Length; j++)
                {
                    if (matriceAffichageCase[i][j] == 1)
                    {
                        CaseCouloir caseCouloir = new CaseCouloir(posX, posY);
                        PetitesCases.Add(caseCouloir);
                    }
                    else if (matriceAffichageCase[i][j] < 0)
                    {
                        PetitesCases.Add(new CaseDepart(posX, posY, matriceAffichageCase[i][j]));
                    }
                    else if (matriceAffichageCase[i][j] > 1)
                    {
                        PetitesCases.Add(new CaseSalle(posX, posY, matriceAffichageCase[i][j]));
                    }
                    else
                    {
                        //Finalement c'est mieux sans : a voir plus tard si tu veux te faire chier a différencier les 4 possibilités
                        //CaseBordure bordure = new CaseBordure(posX, posY);
                        //view.Paint += bordure.Paint;
                    }

                    posX += largeurCase;
                }

                posY += hauteurCase;
                posX = POSITION_X_1ERE_CASE;
            }

            foreach (AbstractPetiteCase apc in PetitesCases)
            {
                if (apc is CaseCouloir == false)
                {
                    view.Paint += apc.Paint;
                }


                // Pour repartir les casesSalle dans les bonnes Salles
                if (apc is CaseSalle)
                {
                    if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Cuisine"])
                    {
                        Salles[0].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Salle de bal"])
                    {
                        Salles[1].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Véranda"])
                    {
                        Salles[2].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Billard"])
                    {
                        Salles[3].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Biblio"])
                    {
                        Salles[4].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Bureau"])
                    {
                        Salles[5].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Hall"])
                    {
                        Salles[6].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Salon"])
                    {
                        Salles[7].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                    else if ((apc as CaseSalle).NumeroSalleCase == MesDictionaires.NomSallesEtIndexNumCase["Salle à manger"])
                    {
                        Salles[8].CasesDeLaSalle.Add(apc as CaseSalle);
                    }
                }
            }

            // 2eme foreach pr que les bordures apparaisses correctementt
            foreach (AbstractPetiteCase apc in PetitesCases)
            {
                if (apc is CaseCouloir)
                {
                    view.Paint += apc.Paint;
                }
            }

            // Pour les labels sur les salles
            foreach (Salle salle in Salles)
            {
                view.Paint += salle.Paint;
            }



            // Joueurs
            Joueurs = joueurs;
            foreach (Joueur j in Joueurs)
            {
                view.Paint += j.Paint;
                j.PlaceJoueurSurCaseDepart(this);
            }

            Joueurs[0].PlaceSurCaseDemandee(this, 7, 3);

            //Set main joueur
        }

    }
}
