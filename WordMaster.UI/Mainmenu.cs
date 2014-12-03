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

            CharacterTableLayout.ColumnCount = 4;
            CharacterTableLayout.RowCount = 3;

            AppManager.CurrentContext.AddCharacter( "default character", "" );
            AppManager.CurrentContext.AddCharacter( "character1", "" );
            AppManager.CurrentContext.AddCharacter( "character2", "" );
            AppManager.CurrentContext.AddCharacter( "character3", "" );
            AppManager.CurrentContext.AddCharacter( "character4", "" );
            AppManager.CurrentContext.AddCharacter( "character5", "" );
          
            // Saved Characters loading

            //TODO


            //Filling table layout with all the Characters
            
            foreach(Character aChara in AppManager.CurrentContext.Characters)
            {
                CharacterRecap newCell = new CharacterRecap();
                newCell.SetCharacter( aChara );                
                CharacterTableLayout.Controls.Add( newCell );               
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
	}
}
