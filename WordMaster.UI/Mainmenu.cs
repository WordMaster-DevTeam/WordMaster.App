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
	public partial class Mainmenu : Form
	{
		public Mainmenu()
		{
			InitializeComponent();
		}

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            // Test Characters list,will be discart when tests are finish
            AppManager.CurrentContext.AddCharacter( "default character", "" );
            AppManager.CurrentContext.AddCharacter( "character1", "" );
            AppManager.CurrentContext.AddCharacter( "character2", "" );
            AppManager.CurrentContext.AddCharacter( "character3", "" );
            AppManager.CurrentContext.AddCharacter( "character4", "" );
            AppManager.CurrentContext.AddCharacter( "character5", "" );
            AppManager.CurrentContext.AddCharacter( "character6", "" );
            AppManager.CurrentContext.AddCharacter( "character7", "" );
            AppManager.CurrentContext.AddCharacter( "character8", "" );
            AppManager.CurrentContext.AddCharacter( "character9", "" );
            AppManager.CurrentContext.AddCharacter( "character10", "" );
            AppManager.CurrentContext.AddCharacter( "character11", "" );
            AppManager.CurrentContext.AddCharacter( "character12", "" );
            AppManager.CurrentContext.AddCharacter( "character13", "" );
            AppManager.CurrentContext.AddCharacter( "character14", "" );
            AppManager.CurrentContext.AddCharacter( "character15", "" );
            AppManager.CurrentContext.AddCharacter( "character16", "" );
            AppManager.CurrentContext.AddCharacter( "character17", "" );
            AppManager.CurrentContext.AddCharacter( "character18", "" );
            AppManager.CurrentContext.AddCharacter( "character19", "" );
            AppManager.CurrentContext.AddCharacter( "character20", "" );

            int nbLines = 3;
            CharacterTableLayout.ColumnCount = AppManager.CurrentContext.Characters.Count( ) / nbLines;
            CharacterTableLayout.RowCount = nbLines;
            

            
            // Saved Characters loading (need serialization)

            //TODO


            //Filling table layout with all the Characters
            
            foreach(Character aChara in AppManager.CurrentContext.Characters)
            {
                CharacterRecap newCell = new CharacterRecap();
                newCell.SetCharacter( aChara );                
                CharacterTableLayout.Controls.Add( newCell );               
            }

            foreach(RowStyle style in this.CharacterTableLayout.RowStyles)
            {
                style.SizeType = SizeType.Percent;
            }
            
        }

        private void CreateCharacterBtn_Click( object sender, EventArgs e )
        {
            CreateCharacter createCharacterForm = new CreateCharacter( );
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
