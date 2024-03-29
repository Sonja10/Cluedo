﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Cluedo.Models.Cartes;
using WF_Cluedo.Models.Cases;
using static WF_Cluedo.AbstractPetiteCase;

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
        List<AbstractPetiteCase> _casesPossibles;
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
            new int[] { 0, 2, 2, 2, 2, 2, 2, 1, 1, 13, 3, 3, 3, 3, 3, 3, 13, 1, 1, 1, 14, 4, 4, 4, 0, 0 },
            new int[] { 0, 0, 2, 2, 2, 12, 2, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 1, 1, 1, 1, 1, -3, 0 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 3, 13, 3, 3, 3, 3, 13, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 15, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 5, 5, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 100, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 5, 5, 15, 5, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 6, 6, 16, 6, 6, 0, 0 },
            new int[] { 0, 10, 10, 10, 10, 10, 10, 100, 10, 1, 1, 0, 0, 0, 0, 0, 1, 1, 6, 6, 6, 6, 6, 6, 6, 0 },
            new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 16, 6, 6, 6, 6, 6, 6, 0 },
            new int[] { 0, -6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 6, 6, 6, 6, 6, 6, 0 }, 
            new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 8, 8, 18, 18, 8, 8, 1, 1, 1, 6, 6, 6, 6, 6, 0, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 19, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 1, 1, 1, 1, 1, 1, -4, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 18, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 17, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 7, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 9, 1, 1, 8, 8, 8, 8, 8, 8, 1, 1, 17, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 9, 9, 9, 9, 9, 9, 0, -5, 0, 0, 8, 8, 8, 8, 0, 0, 1, 0, 7, 7, 7, 7, 7, 7, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public List<AbstractCartes> ToutesLesCartesPossibles { get { return _toutesLesCartesPossibles; } private set { _toutesLesCartesPossibles = value; } }
        public List<AbstractPetiteCase> PetitesCases { get { return _petitesCases; } private set { _petitesCases = value; } }
        internal List<Salle> Salles { get => _salles; set => _salles = value; }
        internal List<Joueur> Joueurs { get => _joueurs; set => _joueurs = value; }
        internal Joueur JoueurActuel { get => _joueurActuel; set => _joueurActuel = value; }

        public int POSITION_X_1ERE_CASE => _POSITION_X_1ERE_CASE;
        public int POSITION_Y_1ERE_CASE => _POSITION_Y_1ERE_CASE;

        internal List<AbstractPetiteCase> CasesPossibles { get => _casesPossibles; set => _casesPossibles = value; }

        public Game(List<Joueur> joueurs, Form view)
        {
            // Plateau de jeu

            int posX = POSITION_X_1ERE_CASE;
            int posY = POSITION_Y_1ERE_CASE;
            int largeurCase = (new CaseCouloir(1, 1, 1, 1)).WIDTH_CASE;
            int hauteurCase = (new CaseCouloir(1, 1, 1, 1)).HEIGHT_CASE;

            CasesPossibles = new List<AbstractPetiteCase>();
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
                        CaseCouloir caseCouloir = new CaseCouloir(posX, posY, j, i);
                        PetitesCases.Add(caseCouloir);
                    }
                    else if (matriceAffichageCase[i][j] < 0)
                    {
                        PetitesCases.Add(new CaseDepart(posX, posY, j, i, matriceAffichageCase[i][j]));
                    }
                    else if (matriceAffichageCase[i][j] > 1)
                    {
                        PetitesCases.Add(new CaseSalle(posX, posY, j, i, matriceAffichageCase[i][j]));
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

                if (apc is CaseSalle)
                {
                    // Si la case de gauche est un couloir
                    if (matriceAffichageCase[apc.MatricePosY][apc.MatricePosX - 1] == 1 || matriceAffichageCase[apc.MatricePosY][apc.MatricePosX - 1] == 0)
                    {
                        (apc as CaseSalle).DirectionBordure = "G";
                    }
                    // Si la case de droite est un couloir
                    if (matriceAffichageCase[apc.MatricePosY][apc.MatricePosX + 1] == 1 || matriceAffichageCase[apc.MatricePosY][apc.MatricePosX + 1] == 0)
                    {
                        (apc as CaseSalle).DirectionBordure += "D";
                    }
                    // Si la case de haut est un couloir
                    if (matriceAffichageCase[apc.MatricePosY - 1][apc.MatricePosX] == 1 || matriceAffichageCase[apc.MatricePosY - 1][apc.MatricePosX] == 0)
                    {
                        (apc as CaseSalle).DirectionBordure += "H";
                    }
                    // Si la case de bas est un couloir
                    if (matriceAffichageCase[apc.MatricePosY + 1][apc.MatricePosX] == 1 || matriceAffichageCase[apc.MatricePosY + 1][apc.MatricePosX] == 0)
                    {
                        (apc as CaseSalle).DirectionBordure += "B";
                    }
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
            InitialisationJoueurs(joueurs, view);
        }

        public void InitialisationJoueurs(List<Joueur> joueurs, Form view)
        {
            Random rnd = new Random();
            Joueurs = joueurs;

            foreach (Joueur j in Joueurs)
            {
                view.Paint += j.Paint;
                j.PlaceJoueurSurCaseDepart(this);
            }

            //Set mains joueurs

            JoueurActuel = Joueurs[rnd.Next(Joueurs.Count)];
            SetJoueurActuel();
        }

        public void SetJoueurActuel()
        {
            JoueurActuel.ModeDeplacement = true;
            AffichageCaseDeplacementPossible(2);
        }

        public void AffichageCaseDeplacementPossible(int nombreLanceDe)
        {
            //Suppression des cases possibles precedentes 
            foreach (AbstractPetiteCase apc in CasesPossibles)
            {
                if (apc is CaseCouloir)
                {
                    (apc as CaseCouloir).CaseDeplacementPossible = false;
                }
            }
            CasesPossibles.Clear();
            foreach (AbstractPetiteCase apc in PetitesCases)
            {
                if (apc is CaseSalle && (apc as CaseSalle).SalleDeplacementPossible)
                {
                    (apc as CaseSalle).SalleDeplacementPossible = false;
                }
            }

            // Definition des cases possibles
            for (int i = 1; i < nombreLanceDe; i++)
            {
                foreach (AbstractPetiteCase apc in PetitesCases)
                {
                    if (apc.MatricePosX >= JoueurActuel.CaseActuelle.MatricePosX - nombreLanceDe && apc.MatricePosX <= JoueurActuel.CaseActuelle.MatricePosX + nombreLanceDe &&
                        apc.MatricePosY >= JoueurActuel.CaseActuelle.MatricePosY - nombreLanceDe && apc.MatricePosY <= JoueurActuel.CaseActuelle.MatricePosY + nombreLanceDe )
                    {
                        if (apc.MatricePosX == JoueurActuel.CaseActuelle.MatricePosX + i && apc.MatricePosY >= JoueurActuel.CaseActuelle.MatricePosY - nombreLanceDe + i && apc.MatricePosY <= JoueurActuel.CaseActuelle.MatricePosY + nombreLanceDe - i ||
                            apc.MatricePosX == JoueurActuel.CaseActuelle.MatricePosX - i && apc.MatricePosY >= JoueurActuel.CaseActuelle.MatricePosY - nombreLanceDe + i && apc.MatricePosY <= JoueurActuel.CaseActuelle.MatricePosY + nombreLanceDe - i ||
                            apc.MatricePosX <= JoueurActuel.CaseActuelle.MatricePosX + nombreLanceDe && apc.MatricePosX >= JoueurActuel.CaseActuelle.MatricePosX - nombreLanceDe && apc.MatricePosY == JoueurActuel.CaseActuelle.MatricePosY ||
                            apc.MatricePosY <= JoueurActuel.CaseActuelle.MatricePosY + nombreLanceDe && apc.MatricePosY >= JoueurActuel.CaseActuelle.MatricePosY - nombreLanceDe && apc.MatricePosX == JoueurActuel.CaseActuelle.MatricePosX)
                        {
                            CasesPossibles.Add(apc);
                        }
                    }
                }
            }

            // Affichage
            foreach (AbstractPetiteCase apc in CasesPossibles)
            {
                if (apc is CaseCouloir)
                {
                    (apc as CaseCouloir).CaseDeplacementPossible = true;
                }
                // Si c'est une porte de caseSalle
                else if (apc is CaseSalle && matriceAffichageCase[apc.MatricePosY][apc.MatricePosX] > 10)
                {
                    // On cherche dans toutes les cases
                    foreach (AbstractPetiteCase apc2 in PetitesCases)
                    {
                        // On recupere les cases salle
                        if (apc2 is CaseSalle)
                        {
                            // Si le nom de la salle correspond au nom de la porte
                            if ((apc2 as CaseSalle).NomSalle == (apc as CaseSalle).NomSalle)
                            {
                                (apc as CaseSalle).SalleDeplacementPossible = true;
                                (apc2 as CaseSalle).SalleDeplacementPossible = true;
                            }
                        }
                    }
                }
            }
        }

        public Point RecupererCaseClickee(int posXClick, int posYClick)
        {
            Point coordMatrice = new Point();

            foreach (AbstractPetiteCase apc in PetitesCases)
            {
                if (posXClick > apc.PositionX && posXClick < apc.PositionX + apc.WIDTH_CASE &&
                    posYClick > apc.PositionY && posYClick < apc.PositionY + apc.HEIGHT_CASE)
                {
                    coordMatrice.X = apc.MatricePosX;
                    coordMatrice.Y = apc.MatricePosY;
                }
            }

            return coordMatrice;
        }

        // Method de debug
        public void DeplaceJoueurClick(Point mousePositionClick)
        {
            Point coordMatriceCase = RecupererCaseClickee(mousePositionClick.X,mousePositionClick.Y);
            JoueurActuel.PlaceSurCaseDemandee(this, coordMatriceCase.X, coordMatriceCase.Y);
            SetJoueurActuel();
            
        }
    }
}
