using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.DLL;

namespace WordMaster.UI
{
    public partial class Ingame : Form
    {
        GlobalContext _context = new GlobalContext( );      
        Character _character;
        Dungeon _dungeon;
        Game _game;

        public Ingame()
        {
            InitializeComponent( );
        }

        private void Ingame_Load( object sender, EventArgs e )
        {
            _character = _context.AddDefaultCharacter("Olivier");
            _dungeon = _context.AddDefaultDungeon( "The Cage" );
            _game = _context.StartNewGame(_character, _dungeon);

            // Dungeon panel
            DungeonLabel.Text += "  " + _dungeon.Name;
            FloorLabel.Text += "  " + _character.Floor.Name;
            SquareLabel.Text += "  " + _character.Square.Name;

            // Character panel
            NameLabel.Text +=  "  " + _character.Name;
            LifeLabel.Text += "  " + _character.Health;
            LeveLabel.Text += "  " + _character.Level;
            ArmorLabel.Text += "  " + _character.Armor;
            DescriptionLabel.Text = DescriptionLabel.Text + "\n \n" + _character.Description;   
        }
       
        private void QuitTheGame_Click( object sender, EventArgs e )
        {
            Application.Exit( );
        }

        private void GoToLeftButton_Click( object sender, EventArgs e )
        {
           
        }
        #region Empty methods
        private void label3_Click( object sender, EventArgs e )
        {

        }

       private void Profilpicturebox_Click( object sender, EventArgs e )
        {
            
        }

        private void WDversionlbl_Click( object sender, EventArgs e )
        {

        }

		private void Lifelbl_Click( object sender, EventArgs e )
		{

		}

		private void panel1_Paint( object sender, PaintEventArgs e )
		{

		}

		private void Namelbl_Click( object sender, EventArgs e )
		{

		}
        private void DescriptionLabel_Click( object sender, EventArgs e )
        {

        }

        private void FloorLabel_Click( object sender, EventArgs e )
        {

        }
        #endregion
        
    }
}
