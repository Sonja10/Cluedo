using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Cluedo.Models;
using WF_Cluedo.Models.Cases;

namespace WF_Cluedo
{
    public partial class frmGameView : Form
    {
        Game _game;

        MesDictionaires dicos = new MesDictionaires();
        internal Game Game { get { return _game; } set { _game = value; } }

        // Cette liste viendra d'une autre fenetre
        internal List<Joueur> Joueurs;

        public frmGameView()
        {
            InitializeComponent();
            DoubleBuffered = true;

            

            Joueurs = new List<Joueur>()
            {
                //// Valeurs par defaut changer et mettre dans fenetre a part
                new Joueur(NomsJoueurs.Moutarde, MesDictionaires.NomPersonnagesEtIndexDepart["Moutarde"]),
                new Joueur(NomsJoueurs.LeBlanc, MesDictionaires.NomPersonnagesEtIndexDepart["LeBlanc"]),
                new Joueur(NomsJoueurs.Olive, MesDictionaires.NomPersonnagesEtIndexDepart["Olive"]),
                new Joueur(NomsJoueurs.Pervenche, MesDictionaires.NomPersonnagesEtIndexDepart["Pervenche"]),
                new Joueur(NomsJoueurs.Rose, MesDictionaires.NomPersonnagesEtIndexDepart["Rose"]),
                new Joueur(NomsJoueurs.Violet, MesDictionaires.NomPersonnagesEtIndexDepart["Violet"]),
            };

            Game = new Game(Joueurs, this);
        }

        private void tmrInvalidate_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void frmGameView_MouseHover(object sender, EventArgs e)
        {
            if (Game.JoueurActuel.ModeDeplacement == true)
            {
                foreach (AbstractPetiteCase apc in Game.CasesPossibles)
                {
                    this.Cursor = new Cursor(Cursor.Current.Handle);

                    if (Cursor.Position.X >= apc.PositionX && Cursor.Position.X <= apc.PositionX + apc.WIDTH_CASE &&
                        Cursor.Position.Y >= apc.PositionY && Cursor.Position.Y <= apc.PositionY + apc.HEIGHT_CASE)
                    {
                        if (apc is CaseCouloir)
                        {
                            (apc as CaseCouloir).ImageFond = Properties.Resources.fondCouloirs;
                        }
                    }
                }
            }
        }

        // Event de debug
        private void frmGameView_Click(object sender, EventArgs e)
        {
            Point mousePositionClient = new Point(MousePosition.X, MousePosition.Y);
            mousePositionClient = PointToClient(mousePositionClient);
            Game.DeplaceJoueurClick(mousePositionClient);
        }
    }
}
