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

        internal Game Game { get { return _game; } set { _game = value; } }

        // Faudra deplacer dans lautre fenetre avec les joueurs
        public Dictionary<string, int> indexDepartPersonnages;

        // Cette liste viendra d'une autre fenetre
        internal List<Joueur> Joueurs;

        public frmGameView()
        {
            InitializeComponent();
            DoubleBuffered = true;

            // Faudra deplacer dans lautre fenetre avec les joueurs
            indexDepartPersonnages = new Dictionary<string, int>() {
                { "LeBlanc", -1 },
                { "Olive", -2 },
                { "Pervenche", -3 },
                { "Violet", -4 },
                { "Rose", -5 },
                { "Moutarde", -6 }
            };

            Joueurs = new List<Joueur>()
            {
                //// Valeurs par defaut changer et mettre dans fenetre a part
                new Joueur(NomsJoueurs.Moutarde, indexDepartPersonnages["Moutarde"]),
                new Joueur(NomsJoueurs.LeBlanc, indexDepartPersonnages["LeBlanc"]),
                new Joueur(NomsJoueurs.Olive, indexDepartPersonnages["Olive"]),
                new Joueur(NomsJoueurs.Pervenche, indexDepartPersonnages["Pervenche"]),
                new Joueur(NomsJoueurs.Rose, indexDepartPersonnages["Rose"]),
                new Joueur(NomsJoueurs.Violet, indexDepartPersonnages["Violet"]),
            };

            Game = new Game(Joueurs, this);
        }

        private void tmrInvalidate_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
