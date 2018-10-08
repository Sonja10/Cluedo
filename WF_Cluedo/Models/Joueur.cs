using System;
using System.Collections.Generic;
using System.Drawing;
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
        MesDictionaires dicos = new MesDictionaires();

        const int _TAILLE_PION = 28;
        int _positionX_pion;
        int _positionY_pion;
        NomsJoueurs _nomJoueur;
        int _indexCaseActuelle;
        List<AbstractCartes> _cartesEnMain;
        Brush colorJoueur;

        

        public NomsJoueurs NomJoueur { get { return _nomJoueur; } set { _nomJoueur = value; } }
        public int IndexCaseActuelle { get { return _indexCaseActuelle; } set { _indexCaseActuelle = value; } }
        internal List<AbstractCartes> CartesEnMain { get { return _cartesEnMain; } set { _cartesEnMain = value; } }

        public int PositionX_pion { get => _positionX_pion; set => _positionX_pion = value; }
        public int PositionY_pion { get => _positionY_pion; set => _positionY_pion = value; }

        public static int TAILLE_PION => _TAILLE_PION;

        public Joueur(NomsJoueurs nom, int indexCaseDepart)
        {
            NomJoueur = nom;
            IndexCaseActuelle = indexCaseDepart;

            switch (IndexCaseActuelle)
            {
                case -1:
                    colorJoueur = Brushes.White;
                    break;
                case -2:
                    colorJoueur = Brushes.Green;
                    break;
                case -3:
                    colorJoueur = Brushes.Blue;
                    break;
                case -4:
                    colorJoueur = Brushes.Purple;
                    break;
                case -5:
                    colorJoueur = Brushes.Red;
                    break;
                case -6:
                    colorJoueur = Brushes.Gold;
                    break;
                default:
                    colorJoueur = Brushes.Black;
                    break;
            }
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
                        nomSalle = MesDictionaires.IndexNumCaseEtNomSalles[IndexCaseActuelle];
                    }
                }
            }

            return nomSalle;
        }

        //Seulement au départ cette methode
        public void PlaceJoueurSurCaseDepart(Game game)
        {
            foreach (AbstractPetiteCase apc in game.PetitesCases)
            {
                if (apc is CaseDepart)
                {
                    if ((apc as CaseDepart).NumeroPersoCase == IndexCaseActuelle)
                    {
                        PositionX_pion = apc.PositionX + 1;
                        PositionY_pion = apc.PositionY + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Place le pion du joueur sur la case indiquée par ses coordonnées dans la matrice
        /// Attention : Donner les coordonnee tel quelle meme si l'index est 0
        /// Exemple pour la 1ere case du plateau : monJoueur.PlaceSurCaseDemandee(game, matriceAffichageCase[0][0]
        /// </summary>
        /// <Game name="game">Jeu en cours</param>
        /// <int name="indexCaseX">coordonnee X dans la matrice de placement des cases du jeu</param>
        /// <int name="indexCaseY">coordonnee Y dans la matrice de placement des cases du jeu</param>
        public void PlaceSurCaseDemandee(Game game, int indexCaseX, int indexCaseY)
        {
            int decalageX_1ereCase = game.POSITION_X_1ERE_CASE;
            int decalageY_1ereCase = game.POSITION_Y_1ERE_CASE;
            int largeurCase = game.PetitesCases[0].WIDTH_CASE;
            int hauteurCase = game.PetitesCases[0].HEIGHT_CASE;

            PositionX_pion = decalageX_1ereCase + (indexCaseX * largeurCase) + 1;
            PositionY_pion = decalageY_1ereCase + (indexCaseY * hauteurCase) + 1;
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Point p = new Point(PositionX_pion, _positionY_pion);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(colorJoueur, p.X, p.Y, TAILLE_PION, TAILLE_PION);
            e.Graphics.DrawEllipse(Pens.Black, p.X, p.Y, TAILLE_PION, TAILLE_PION);
        }

        
    }
}
