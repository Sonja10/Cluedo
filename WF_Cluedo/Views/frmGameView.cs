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

        // Cette liste viendra d'une autre fenetre
        internal List<Joueur> Joueurs = new List<Joueur>()
        {
            // Valeurs par defaut changer et mettre dans fenetre a part
            new Joueur(NomsJoueurs.Moutarde),
            new Joueur(NomsJoueurs.LeBlanc),
            new Joueur(NomsJoueurs.Olive)
        };

        public frmGameView()
        {
            InitializeComponent();
            DoubleBuffered = true;

            Game = new Game(Joueurs, this);
        }

        private void tmrInvalidate_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
