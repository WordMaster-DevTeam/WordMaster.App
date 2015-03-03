using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using WordMaster.Gameplay;
using WordMaster.IOChecks;

namespace WordMaster.UI
{
	public partial class MainMenu : Form
	{
        internal GlobalContext _globalContext;
        GameContext _gameContext;

		public MainMenu()
		{
			InitializeComponent();
		}

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            // Saved Characters loading            
            string path = Path.GetFullPath( "GlobalContext.bin" );

            if ( File.Exists( path ) )
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream( "GlobalContext.bin", FileMode.Open, FileAccess.Read, FileShare.Read );

				try
				{
					_globalContext = (GlobalContext)formatter.Deserialize( stream );
				}
				catch
				{
					StartNewGlobalContext();
				}
				finally
				{
					stream.Close( );
				}
            }
            else
            {
				StartNewGlobalContext();
            }
            
            CharacterTableLayout.RowCount = _globalContext.Characters.Count( );                       

            // Filling table layout with all the Characters            
            foreach(Character character in _globalContext.Characters)
            {
                CharacterRecap newCell = new CharacterRecap( _globalContext);
                newCell.SetCharacter( character );
                newCell.SetContext( _globalContext );
                CharacterTableLayout.Controls.Add( newCell );
                newCell.CharacterListEdited += new EventHandler( newCell_CharacterListEdited );
            }
        }

		void StartNewGlobalContext()
		{
			_globalContext = new GlobalContext();
			HistoricRecord toTrashHistoric;
			_gameContext = _globalContext.StartNewGame( _globalContext.GetCharacter( "Olivier" ), _globalContext.GetDungeon( "Tutorial" ), out toTrashHistoric );
		}

        void newCell_CharacterListEdited(object sender, EventArgs e)
        {
            CharacterTableLayout.Controls.Clear( );
            foreach ( Character character in _globalContext.Characters )
            {
                CharacterRecap newCell = new CharacterRecap( _globalContext );
                newCell.SetCharacter( character );
                newCell.SetContext( _globalContext );
                CharacterTableLayout.Controls.Add( newCell );
                newCell.CharacterListEdited += new EventHandler( newCell_CharacterListEdited );
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

                    string name = createCharacterForm.TextBoxName;
                    string desc = createCharacterForm.TextBoxDescription;
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
                        CharacterRecap newCell = new CharacterRecap( _globalContext );
                        newCell.SetCharacter( newCharacter );
                        CharacterTableLayout.Controls.Add( newCell );
                    }
                }
                while ( !isValid );
            }
        }

        private void QuitBtn_Click( object sender, EventArgs e )
        {
            IFormatter formatter = new BinaryFormatter( );
            Stream stream = new FileStream( "GlobalContext.bin", FileMode.Create, FileAccess.Write, FileShare.None );
            formatter.Serialize( stream, _globalContext );
            stream.Close();
            Application.Exit();
        }       
	}
}
