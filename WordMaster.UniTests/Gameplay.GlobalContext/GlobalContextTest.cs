using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMaster.Library;

namespace WordMaster.UniTests
{
    [TestFixture]
    class GlobalContextTest
    {
		[Test]
		public void Adds_a_Character_and_recovers_it()
		{
			//Arrange
			GlobalContext context = new GlobalContext();
			Character character;
			string characterName = "a character";

			//Act
			character = context.AddCharacter( characterName, "" );

			//Assert
			Assert.That( context.Characters, Contains.Item( character ) );
		}

		[Test]
		public void Rename_a_Dungeon_using_name_or_reference()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			Dungeon dungeonA, dungeonB;
			string dungeonAName1 = "a dungeon";
			string dungeonAName2 = "another name for a dungeon";
			string dungeonBName1 = "a dungeon too";
			string dungeonBName2 = "yet antoher name for a dungeon";

			// Act
			dungeonA = context.AddDungeon( dungeonAName1, "" );
			dungeonB = context.AddDungeon( dungeonBName1, "" );
			context.RenameDungeon( dungeonAName1, dungeonAName2 );
			context.RenameDungeon( dungeonB, dungeonBName2 );

			// Assert
			Assert.AreEqual( dungeonA.Name, dungeonAName2 );
			Assert.AreEqual( dungeonB.Name, dungeonBName2 );
		}

		[Test]
		public void Add_two_Dungeons_with_the_same_name_throws_ArgumentException()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			string dungeonName = "a dungeon";

			// Act
			context.AddDungeon( dungeonName, "" );

			// Assert
			Assert.Throws<ArgumentException>( () => context.AddDungeon( dungeonName, "" ) );
		}

        [Test]
        public void Start_New_Game_set_Game_and_all_things_as_expected()
        {
            //Arrange
            GlobalContext context = new GlobalContext();
			Game game;
            Character character;
            Dungeon dungeon;
            Floor floor;
			string characterName = "a character";
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";
            
            //Act
			character = context.AddCharacter( characterName, "" );
			dungeon = context.AddDungeon( dungeonName, "" );
            floor = dungeon.AddFloor( floorName, "", 3, 3 );
			dungeon.Entrance = floor.SetSquare( 0, 0, "The entrance", "", true, null );
			dungeon.Exit = floor.SetSquare( 2, 2, "The exit", "", true, null );
			floor.SetAllUninitializedSquares( squareName, "", true );
            game = context.StartNewGame( character, dungeon );

            //Assert
            Assert.AreSame( game.Character, character );
			Assert.AreSame( game.Dungeon, dungeon );
			Assert.AreSame( game.Historic, character.Historics.Last() );    
        }

        [Test]
        public void GlobalContext_finish_a_game_as_expected()
        {
            //Arrange
            GlobalContext context = new GlobalContext();
			Game game;
            Character character;
            Dungeon dungeon;
            Floor floor;
			string characterName = "a character";
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";

            //Act
			character = context.AddCharacter( characterName, "" );
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
            dungeon.Entrance = floor.SetSquare( 0, 0, "The entrance", "", true, null );
            dungeon.Exit = floor.SetSquare( 2, 2, "The exit", "", true, null );
			floor.SetAllUninitializedSquares( squareName, "", true );
            game = context.StartNewGame( character, dungeon );
            context.FinishGame(character);

            //Assert            
            Assert.That( character.Dungeon, Is.Null );
            Assert.That( character.Floor, Is.Null );
            Assert.That( character.Square, Is.Null );
            Assert.That( character.Game, Is.Null );
            Assert.That( character.Historics.Last( ).Finished, Is.True );
        }

        [Test]
        public void GlobalContext_End_a_game_as_expected()
        {
            //Arrange
            GlobalContext context = new GlobalContext();
			Game game;
            Character character;
            Dungeon dungeon;
            Floor floor;
			string characterName = "a character";
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";

			//Act
			character = context.AddCharacter( characterName, "" );
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			dungeon.Entrance = floor.SetSquare( 0, 0, "The entrance", "", true, null );
			dungeon.Exit = floor.SetSquare( 2, 2, "The exit", "", true, null );
			floor.SetAllUninitializedSquares( squareName, "", true );
			game = context.StartNewGame( character, dungeon );
            context.EndGame( character );

            //Assert
            Assert.That( character.Historics.Last( ).Cancelled, Is.True );
        }
    }
}
