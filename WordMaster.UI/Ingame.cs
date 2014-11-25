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
            context.AddCharacter( "Default Character", "Some description here" );
            context.AddDungeon( "Default Dungeon" );

            string error="";
            
            if(context.TryGetCharacter("Default Character", out character))
            {                
                NameLabel.Text = NameLabel.Text + " \t " + character.Name;
                LifeLabel.Text = LifeLabel.Text + " \t " + character.Health;
                LeveLabel.Text = LeveLabel.Text + " \t " + character.Level;
                DescriptionLabel.Text = DescriptionLabel.Text + "\n \n" + character.Description;
            }
            else
            {
                error = error + "The Character cannot be retrieved.";
            }
            
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
    }
}
