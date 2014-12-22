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
using WordMaster.IOChecks;

namespace WordMaster.UI
{
	public partial class MainMenu : Form
	{
        internal GlobalContext _globalContext;        
        Character _character;
        Dungeon _dungeon;
        Game _game;
        HistoricRecord _historic;
        GameContext _gameContext;

		public MainMenu()
		{
			InitializeComponent();
		}

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            _globalContext = new GlobalContext( );
            _character = _globalContext.AddDefaultCharacter( "Tartempion" );
            _dungeon = _globalContext.AddDefaultDungeon( "the default dungeon" );
            _gameContext = new GameContext( _globalContext, _character, _dungeon, out _game, out _historic );

            // Test Characters list, will be discart when tests are finish


            CharacterTableLayout.RowCount = _globalContext.Characters.Count( );
			
            
            // Saved Characters loading (need serialization)
            // ---- TODO ----

            // Filling table layout with all the Characters            
            foreach(Character character in _globalContext.Characters)
            {
                CharacterRecap newCell = new CharacterRecap();
                newCell.SetCharacter( character );
                newCell.SetContext( _globalContext );
                CharacterTableLayout.Controls.Add( newCell );               
            }
        }

        private void CreateCharacterBtn_Click( object sender, EventArgs e )
        {
            using( CharacterCreator createCharacterForm = new CharacterCreator( ) )
            {
                bool isValid;
                Character character;
                do
                {
                    isValid = false;
                    DialogResult r = createCharacterForm.ShowDialog( );
                    if ( r == DialogResult.Cancel ) return;

                    string name = createCharacterForm.CharacterName;
                    string desc = createCharacterForm.Description;
                    if ( InputsChecker.CheckNameLength( name ) )
                    {
                        isValid = true;
                        // Do add the new Characher here!
                        Character newCharacter = _globalContext.AddCharacter( name, desc );
                        if ( _globalContext.TryGetCharacter( name, out character ) )
                        {
                            MessageBox.Show( "Character added" );
                        }
                        else
                        {
                            MessageBox.Show( "An error occured, the Character cannot be added." );
                        }
                        CharacterRecap newCell = new CharacterRecap( );
                        newCell.SetCharacter( newCharacter );
                        CharacterTableLayout.Controls.Add( newCell );
                    }
                }
                while ( !isValid );
            }
        }

        private void QuitBtn_Click( object sender, EventArgs e )
        {
            Application.Exit();
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
