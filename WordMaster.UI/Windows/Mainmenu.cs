using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.Library;

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
            GlobalContext context = new GlobalContext( );

            context.AddCharacter( "default character", "" );

            //DataGridView initialisation

            CharacterDataGridView.DataSource = context.Characters;
            CharacterDataGridView.Columns.Remove( "Experience" );
            CharacterDataGridView.Columns.Remove( "Armor" );
            CharacterDataGridView.Columns.Remove( "Historics" );
            CharacterDataGridView.Columns.Remove( "Game" );
            CharacterDataGridView.Columns.Remove( "Square" );
            
        }

        private void CreateCharacterBtn_Click( object sender, EventArgs e )
        {
            CharacterEditor createCharacterForm = new CharacterEditor( );
            createCharacterForm.Show( );
        }

        private void LaunchBtn_Click( object sender, EventArgs e )
        {
            InGame ingameform = new InGame( );
            ingameform.Show( );
        }

        private void QuitBtn_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }       
	}
}
