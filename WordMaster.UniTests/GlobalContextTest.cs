using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMaster.DLL;

namespace WordMaster.UniTests
{
    [TestFixture]
    class GlobalContextTest
    {
        [Test]
        public void AddCharacter_add_a_character_as_expected()
        {
            //Arrange
            GlobalContext testContext;
            Character expected = null; 

            //Act
            testContext = new GlobalContext( );
            testContext.AddCharacter( "test" );
            foreach(Character aCharacter in testContext.Characters)
            {
                if( aCharacter.Name=="test")
                {
                    expected = aCharacter;
                }
            }
            if ( expected == null ) throw new Exception( "expected is still null" );

            //Assert
            Assert.That( testContext.Characters, Contains.Item( expected ) );
        }

        [Test]
        public void TryGetCharacter_return_true_and_the_instance_for_an_existing_character()
        {
            //Assert
            GlobalContext testContext = new GlobalContext( );
            Character testCharacter = null;
            Character expectedResult = null;

            //Act
            testContext.AddCharacter( "test" );
            if(testContext.TryGetCharacter("test", out testCharacter))
            {
                expectedResult = testCharacter;
            }
            
            //Assert
            Assert.That( testContext.TryGetCharacter( "test", out testCharacter ), Is.True );
            Assert.That( expectedResult is Character );
            
        }

        [Test]
        public void AddDungeon_add_dungeon_as_expected()
        {
            //Arrange
            GlobalContext testContext;
            Dungeon expected = null;

            //Act
            testContext = new GlobalContext( );
            testContext.AddDungeon( "test" );
            foreach ( Dungeon aDungeon in testContext.Dungeons )
            {
                if ( aDungeon.Name == "test" )
                {
                    expected = aDungeon;
                }
            }
            if ( expected == null ) throw new Exception( "expected is still null" );

            //Assert
            Assert.That( testContext.Dungeons, Contains.Item( expected ) );
        }

        [Test]
        public void TryGetDungeon_return_true_and_the_instance_for_an_existing_dungeon()
        {
            //Assert
            GlobalContext testContext = new GlobalContext( );
            Dungeon testDungeon = null;
            Dungeon expectedResult = null;

            //Act
            testContext.AddDungeon( "test" );
            if ( testContext.TryGetDungeon("test", out testDungeon ) )
            {
                expectedResult = testDungeon;
            }

            //Assert
            Assert.That( testContext.TryGetDungeon( "test", out testDungeon ), Is.True );
            Assert.That( expectedResult is Dungeon );
        }

        [Test]
        public void StartNewGame_set_a_a_game_as_expected()
        {
            //Arrange
            GlobalContext testContext = new GlobalContext( );
            Character testCharacter;
            Dungeon testDungeon;
            Floor testFloor;
            Square testEntrance, testExit;
            Game testGame;
            
            //Act
            testDungeon=testContext.AddDungeon( "test" );
            testCharacter=testContext.AddCharacter( "testchar" );
            testFloor = testDungeon.AddFloor( 0, "testFloor", "", 3, 3 );
            testEntrance = testFloor.SetSquare( 0, 0, "testentrance", "", true, null );
            testExit = testFloor.SetSquare( 2, 2, "testExit", "", true, null );
            testFloor.SetAllUninitializedSquares( "eee", "", true );
            testDungeon.Entrance = testEntrance;
            testDungeon.Exit = testExit;               
            testGame=testContext.StartNewGame( testCharacter, testDungeon );

            //Assert
            Assert.That( testGame.Character is Character );
            Assert.That( testGame.Character, Is.EqualTo( testCharacter ) );
            Assert.That( testGame.Dungeon is Dungeon );
            Assert.That( testGame.Dungeon, Is.EqualTo( testDungeon ) );
            Assert.That( testGame.Historic is HistoricRecord );          
            
        }

        [Test]
        public void GlobalContext_finish_a_game_as_expected()
        {
            //Arrange
            GlobalContext testContext = new GlobalContext( );
            Character testCharacter;
            Dungeon testDungeon;
            Floor testFloor;
            Square testEntrance, testExit;
            Game testGame;

            //Act
            testDungeon = testContext.AddDungeon( "test" );
            testCharacter = testContext.AddCharacter( "testchar" );
            testFloor = testDungeon.AddFloor( 0, "testFloor", "", 3, 3 );
            testEntrance = testFloor.SetSquare( 0, 0, "testentrance", "", true, null );
            testExit = testFloor.SetSquare( 2, 2, "testExit", "", true, null );
            testFloor.SetAllUninitializedSquares( "eee", "", true );
            testDungeon.Entrance = testEntrance;
            testDungeon.Exit = testExit;
            testGame = testContext.StartNewGame( testCharacter, testDungeon );
            testContext.FinishGame(testCharacter);

            //Assert            
            Assert.That( testCharacter.Dungeon, Is.Null );
            Assert.That( testCharacter.Floor, Is.Null );
            Assert.That( testCharacter.Square, Is.Null );
            Assert.That( testCharacter.Game, Is.Null );
            Assert.That( testCharacter.Historics.Last( ).Finished, Is.True );
        }

        [Test]
        public void GlobalContext_End_a_game_as_expected()
        {
            //Arrange
            GlobalContext testContext = new GlobalContext( );
            Character testCharacter;
            Dungeon testDungeon;
            Floor testFloor;
            Square testEntrance, testExit;
            Game testGame;

            //Act
            testDungeon = testContext.AddDungeon( "test" );
            testCharacter = testContext.AddCharacter( "testchar" );
            testFloor = testDungeon.AddFloor( 0, "testFloor", "", 3, 3 );
            testEntrance = testFloor.SetSquare( 0, 0, "testentrance", "", true, null );
            testExit = testFloor.SetSquare( 2, 2, "testExit", "", true, null );
            testFloor.SetAllUninitializedSquares( "eee", "", true );
            testDungeon.Entrance = testEntrance;
            testDungeon.Exit = testExit;
            testGame = testContext.StartNewGame( testCharacter, testDungeon );
            testContext.EndGame( testCharacter );

            //Assert
            Assert.That( testCharacter.Historics.Last( ).Cancelled, Is.True );
        }
           
        
    }
}
