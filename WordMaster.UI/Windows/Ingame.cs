using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.Gameplay;
using WordMaster.Rendering;

namespace WordMaster.UI
{
    public partial class InGame : Form
    {
        GlobalContext _globalContext;      
        Character _character;
        Dungeon _dungeon;
        Game _game;
		GameContext _gameContext;

        public InGame()
        {
			_globalContext = new GlobalContext();
			_character = _globalContext.AddDefaultCharacter( "Oliver" );
			_dungeon = _globalContext.AddDefaultDungeon( "The Cab" );
			_game = _globalContext.StartNewGame( _character, _dungeon );
			_gameContext = new GameContext( _globalContext, _game );

			InitializeComponent();

			// Dungeon panel
			DungeonLabel.Text += " : " + _dungeon.Name;
			FloorLabel.Text += " : " + _character.Floor.Name;
			SquareLabel.Text += " : " + _character.Square.Name;

			// Character panel
			NameLabel.Text += " : " + _character.Name;
			LifeLabel.Text += " : " + _character.Health;
			LeveLabel.Text += " : " + _character.Level;
			ArmorLabel.Text += " : " + _character.Armor;
			DescriptionLabel.Text = DescriptionLabel.Text + "\n" + _character.Description;

			FloorViewer.Initialize( _gameContext );		
        }

        private void InGame_Load( object sender, EventArgs e )
        {

        }
       
        private void QuitTheGame_Click( object sender, EventArgs e )
        {
            Application.Exit( );
        }

        private void GoToLeftButton_Click( object sender, EventArgs e )
        {
           
        }
       
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

		private void GoToRightButton_Click( object sender, EventArgs e )
		{

		}

		private void GoToDownButton_Click( object sender, EventArgs e )
		{

		}

		private void GoToUpButton_Click( object sender, EventArgs e )
		{

		}

		private void floorView1_Click( object sender, EventArgs e )
		{

		}
    }
}
