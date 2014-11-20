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
        public void StartNewGame_behave_as_expected()
        {

        }
        
    }
}
