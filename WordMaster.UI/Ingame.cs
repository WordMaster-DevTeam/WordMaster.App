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
        public Ingame()
        {
            InitializeComponent( );
        }

        private void Ingame_Load( object sender, EventArgs e )
        {
            Character character = AppManager.CurrentContext.AddDefaultCharacter( "Olivier" );
            Dungeon dungeon = AppManager.CurrentContext.AddDefaultDungeon( "The Cage" );
            AppManager.CurrentGame = AppManager.CurrentContext.StartNewGame( character, dungeon );

            // Dungeon panel
            DungeonLabel.Text += "  " + AppManager.CurrentGame.Dungeon.Name;
            FloorLabel.Text += "  " + AppManager.CurrentGame.Character.Floor.Name;
            SquareLabel.Text += "  " + AppManager.CurrentGame.Character.Square.Name;

            // Character panel
            NameLabel.Text += "  " + AppManager.CurrentGame.Character.Name;
            LifeLabel.Text += "  " + AppManager.CurrentGame.Character.Health;
            LeveLabel.Text += "  " + AppManager.CurrentGame.Character.Level;
            ArmorLabel.Text += "  " + AppManager.CurrentGame.Character.Armor;
            DescriptionLabel.Text = DescriptionLabel.Text + "  " + AppManager.CurrentGame.Character.Description;
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

        private void floorView1_Load( object sender, EventArgs e )
        {

        }
        
    }
}
