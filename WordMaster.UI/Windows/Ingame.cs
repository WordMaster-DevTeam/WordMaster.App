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
		GameContext _gameContext;
		Game _game;
		HistoricRecord _historicRecord;

        public InGame()
        {
			_globalContext = new GlobalContext();

			_gameContext = _globalContext.StartNewGame( _gameContext.GetCharacter( "Oliver" ), _globalContext.GetDungeon( "The Academy" ), out _game, out _historicRecord );
			InitializeComponent();
        }

        private void InGame_Load( object sender, EventArgs e )
        {
			UpdateDungeonPanel();
			UpdateCharacterPanel();
			FloorViewer.Initialize( _gameContext );
        }



		#region Interface's updates
		private void UpdateCharacterPanel()
		{
			NameTextBox.Text = _gameContext.Game.Character.Name;
			LifeTextBox.Text = _gameContext.Game.Character.Health.ToString() + " / " + _gameContext.Game.Character.MaxHealth.ToString();
			LevelTextBox.Text = _gameContext.Game.Character.Level.ToString();
			ArmorTextBox.Text = _gameContext.Game.Character.Armor.ToString();
			ExperienceTextBox.Text = _gameContext.Game.Character.Experience.ToString();
			DescriptionTextBox.Text = _gameContext.Game.Character.Description;
		}

		private void UpdateDungeonPanel()
		{
			if(_gameContext.Game.Character.GameContext != null ) // Game ongoing
			{
				DungeonTextBox1.Text = _gameContext.Game.Character.Dungeon.Name;
				DungeonTextBox2.Text = _gameContext.Game.Character.Dungeon.Description;
				FloorTextBox1.Text = _gameContext.Game.Character.Floor.Name;
				FloorTextBox2.Text = _gameContext.Game.Character.Floor.Description;
				SquareTextBox1.Text = _gameContext.Game.Character.Square.Name;
				SquareTextBox2.Text = _gameContext.Game.Character.Square.Description;

				if( _game.Character.Square.Trigger == null ) // No Trigger
				{
					MiscTextBox2.Text = "...";
					MiscTextBox1.Text = "...";
				}
				else // Trigger found
				{
					MiscTextBox1.Text = _gameContext.Game.Character.Square.Trigger.Name;
					MiscTextBox2.Text = _gameContext.Game.Character.Square.Trigger.Description;
				}
			}
			else // Game ended
			{
				DungeonTextBox1.Text = "";
				DungeonTextBox2.Text = "";
				FloorTextBox1.Text = "";
				FloorTextBox2.Text = "";
				SquareTextBox1.Text = "";
				SquareTextBox2.Text = "";
				MiscTextBox1.Text = "";
				MiscTextBox2.Text = "";
			}
		}
		#endregion

		#region Interface's controls
		private void MoveAndUpdate( Square initial, int line, int column )
		{
			Square target = initial.Floor[line, column];

			if( _gameContext.Game.Character.TryMoveTo( target ) ) // Checks holdable state and activates trigger if neeeded
			{
				if( _gameContext.Game.Character.GameContext == null ) // Game ended
				{
					// Updated FloorViewer's Floor
					FloorViewer.ViewPort.FloorRender = new FloorRender( null, _globalContext.EmptyDungeon(new Guid().ToString(), (10))[0] );
					UpdateDungeonPanel();
					UpdateCharacterPanel();
				}
				else // Game ongoing
				{
					FloorViewer.ViewPort.FloorRender = new FloorRender( _gameContext.Game.Character, _gameContext.Game.Character.Floor );
					UpdateDungeonPanel();
					UpdateCharacterPanel();
				}
			}
		}

		private void GoToUp()
		{
			if( _gameContext.Game.Character.Square != null )
				MoveAndUpdate
				(
					_gameContext.Game.Character.Square,
					_gameContext.Game.Character.Square.Line - 1,
					_gameContext.Game.Character.Square.Column
				);
		}

		private void GoToRight()
		{
			if( _gameContext.Game.Character.Square != null )
				MoveAndUpdate
				(
					_gameContext.Game.Character.Square,
					_gameContext.Game.Character.Square.Line,
					_gameContext.Game.Character.Square.Column + 1
				);
		}

		private void GoToDown()
		{
			if( _gameContext.Game.Character.Square != null )
				MoveAndUpdate
				(
					_gameContext.Game.Character.Square,
					_gameContext.Game.Character.Square.Line + 1,
					_gameContext.Game.Character.Square.Column
				);
		}

		private void GoToLeft()
		{
			if( _gameContext.Game.Character.Square != null )
				MoveAndUpdate
				(
					_gameContext.Game.Character.Square,
					_gameContext.Game.Character.Square.Line,
					_gameContext.Game.Character.Square.Column - 1
				);
		}

		private void GoToUpButton_Click( object sender, EventArgs e )
		{
			GoToUp();
		}

		private void GoToRightButton_Click( object sender, EventArgs e )
		{
			GoToRight();
		}

		private void GoToDownButton_Click( object sender, EventArgs e )
		{
			GoToDown();
		}

		private void GoToLeftButton_Click( object sender, EventArgs e )
		{
			GoToLeft();
		}

		protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
		{
			// Capture Z & up arrow key
			if( keyData == Keys.Z || keyData == Keys.Up )
			{
				GoToUp();
				return true;
			}

			// Capture D & right arrow key
			if( keyData == Keys.D || keyData == Keys.Right )
			{
				GoToRight();
				return true;
			}
			// Capture S & down arrow key
			if( keyData == Keys.S || keyData == Keys.Down )
			{
				GoToDown();
				return true;
			}
			// Capture Q & left arrow key
			if( keyData == Keys.Q || keyData == Keys.Left )
			{
				GoToLeft();
				return true;
			}

			// Capture R key (random movement)
			if( keyData == Keys.R )
			{
				int key = _globalContext.Random.Next( 4 );

				switch( key )
				{
					case 0:
						GoToUp();
						break;
					case 1:
						GoToRight();
						break;
					case 2:
						GoToDown();
						break;
					case 3:
						GoToLeft();
						break;
				}
			}

			return base.ProcessCmdKey( ref msg, keyData );
		}

		private void QuitTheGame_Click( object sender, EventArgs e )
		{
			Application.Exit();
		}
		#endregion
	}
}
