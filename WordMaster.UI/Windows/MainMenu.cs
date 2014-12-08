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

namespace WordMaster.UI
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
		}

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            // Test Characters list, will be discart when tests are finish
            AppManager.CurrentContext.AddCharacter( "Arnaud", "" );
            AppManager.CurrentContext.AddCharacter( "Etienne", "" );
            AppManager.CurrentContext.AddCharacter( "Nicolas", "" );
            AppManager.CurrentContext.AddCharacter( "Benoit", "" );
            AppManager.CurrentContext.AddCharacter( "Sophie", "" );
            AppManager.CurrentContext.AddCharacter( "Margaux", "" );
            AppManager.CurrentContext.AddCharacter( "Olivier", "" );
            AppManager.CurrentContext.AddCharacter( "Antoine", "" );
            AppManager.CurrentContext.AddCharacter( "Simon", "" );
            AppManager.CurrentContext.AddCharacter( "Damien", "" );
            AppManager.CurrentContext.AddCharacter( "Bob", "" );
            AppManager.CurrentContext.AddCharacter( "John", "" );
            AppManager.CurrentContext.AddCharacter( "Henry", "" );
            AppManager.CurrentContext.AddCharacter( "Jules", "" );
            AppManager.CurrentContext.AddCharacter( "Louis", "" );
            AppManager.CurrentContext.AddCharacter( "Charles", "" );
            AppManager.CurrentContext.AddCharacter( "Marcel", "" );
            AppManager.CurrentContext.AddCharacter( "Boris", "" );
            AppManager.CurrentContext.AddCharacter( "John-John", "" );
            AppManager.CurrentContext.AddCharacter( "Legolas75", "" );
            AppManager.CurrentContext.AddCharacter( "AragornxXxSWAG-YOLO", "" );

			CharacterTableLayout.ColumnCount = AppManager.CurrentContext.Characters.Count() / 3;
			CharacterTableLayout.RowCount = 3;
            
            // Saved Characters loading (need serialization)
            // ---- TODO ----

            // Filling table layout with all the Characters            
            foreach(Character character in AppManager.CurrentContext.Characters)
            {
                CharacterRecap newCell = new CharacterRecap();
                newCell.SetCharacter( character );                
                CharacterTableLayout.Controls.Add( newCell );               
            }

            foreach(RowStyle style in this.CharacterTableLayout.RowStyles)
            {
                style.SizeType = SizeType.Percent;
            }
            
        }

        private void CreateCharacterBtn_Click( object sender, EventArgs e )
        {
            CharacterCreator createCharacterForm = new CharacterCreator( );
            createCharacterForm.Show( );
        }

        private void QuitBtn_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        private void panel1_Paint( object sender, PaintEventArgs e )
        {

        }

        private void ScoresBtn_Click( object sender, EventArgs e )
        {

        }

        private void OptionBtn_Click( object sender, EventArgs e )
        {

        }

        private void TutorialBTn_Click( object sender, EventArgs e )
        {

        }       
	}
}
