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

        public InGame(GameContext gameContext)
        {
            _gameContext = gameContext;

			InitializeComponent();
        }

        private void InGame_Load( object sender, EventArgs e )
        {
			// DungeonPanel
            DungeonTextBox1.Text = _gameContext.Game.Character.Dungeon.Name;
            DungeonTextBox2.Text = _gameContext.Game.Character.Dungeon.Description;
            FloorTextBox1.Text = _gameContext.Game.Character.Floor.Name;
            FloorTextBox2.Text = _gameContext.Game.Character.Floor.Description;
            SquareTextBox1.Text = _gameContext.Game.Character.Square.Name;
            SquareTextBox2.Text = _gameContext.Game.Character.Square.Description;

			// CharacterPanel
            NameTextBox.Text = _gameContext.Game.Character.Name;
            LifeTextBox.Text = _gameContext.Game.Character.Health.ToString( );
            LevelTextBox.Text = _gameContext.Game.Character.Level.ToString( );
            ArmorTextBox.Text = _gameContext.Game.Character.Armor.ToString( );
            DescriptionTextBox.Text = _gameContext.Game.Character.Description;

			// FloorViewer
			FloorViewer.Initialize( _gameContext );
        }

        private void QuitTheGame_Click( object sender, EventArgs e )
        {
            _gameContext.Game.Historic.Cancelled = true;
            Application.Exit( );
        }
	
		private void NameTextBox_TextChanged( object sender, EventArgs e )
		{

		}

		#region Up, Right, Down and Left actions' methods
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

			// JPO Random
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

		private void MoveAndUpdate( Square initial, int line, int column )
		{
			Square target, final;

			if( initial.Floor.TryGetSquare( line, column, out target ) )
			{
				if( _gameContext.Game.Character.TryMoveTo( target, out final ) ) // Checks holdable state and teleport to another square if neeeded
				{
					if( final != null ) // The Game continue
					{
						if( !initial.Floor.Equals( final.Floor ) ) // Updates needed if the Floor have change
						{
							// Update FloorViewer's Floor and Floor's text boxes
							FloorViewer.ViewPort.FloorRender = new FloorRender(_gameContext.Game.Character, final.Floor);
							FloorTextBox1.Text = final.Floor.Name;
							FloorTextBox2.Text = final.Floor.Description;
						}
						if( !initial.Equals( final ) ) // Updates needed if the Square have changed
						{
							// Update Square's text boxes
							SquareTextBox1.Text = final.Name;
							SquareTextBox2.Text = final.Description;
						}
					}
					else // The Game have been ended
					{
						if( target.Equals( _gameContext.Game.Dungeon.Entrance ) || target.Equals( _gameContext.Game.Dungeon.Exit ) ) // Fail to finish the game
						{
							// Update FloorViewer's Floor and all text boxes (Dungeon, Floor, Square)
							FloorViewer.ViewPort.FloorRender = new FloorRender( null, _globalContext.EmptyDungeon[0] );
							DungeonTextBox1.Text = _globalContext.EmptyDungeon.Name;
							DungeonTextBox2.Text = _globalContext.EmptyDungeon.Description;
							FloorTextBox1.Text = _globalContext.EmptyDungeon[0].Name;
							FloorTextBox2.Text = _globalContext.EmptyDungeon[0].Description;
							SquareTextBox1.Text = _globalContext.EmptyDungeon[0][0, 0].Name;
							SquareTextBox2.Text = _globalContext.EmptyDungeon[0][0, 0].Description;
						}
					}
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
		#endregion
	}
}
