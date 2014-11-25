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
        GlobalContext context = new GlobalContext( );      
        Character character;
        Dungeon dungeon;

        public Ingame()
        {
            InitializeComponent( );

        }

        private void label3_Click( object sender, EventArgs e )
        {

        }

        private void Ingame_Load( object sender, EventArgs e )
        {
            character = context.AddDefaultCharacter("Olivier");
            dungeon = context.AddDefaultDungeon( "The Cage" );
            context.StartNewGame(character, dungeon);

            // Dungeon panel
            DungeonLabel.Text += "  " + dungeon.Name;
            FloorLabel.Text += "  " + character.Floor.Name;
            SquareLabel.Text += "  " + character.Square.Name;

            // Character panel
            NameLabel.Text +=  "  " + character.Name;
            LifeLabel.Text += "  " + character.Health;
            LeveLabel.Text += "  " + character.Level;
            ArmorLabel.Text += "  " + character.Armor;
            DescriptionLabel.Text = DescriptionLabel.Text + "\n \n" + character.Description;
            
        }

        #region Empty methods
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
        #endregion

        private void QuitTheGame_Click( object sender, EventArgs e )
        {
            Application.Exit( );
        }

        private void GoToLeftButton_Click( object sender, EventArgs e )
        {
           
        }

        private void DescriptionLabel_Click( object sender, EventArgs e )
        {

        }

        private void FloorLabel_Click( object sender, EventArgs e )
        {

        }
    }
}
