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
    public class CharacterTests
    {
        #region Character builder tests
        
        [Test]
		public void Create_Character_with_name_null_empty_string_or_whitespace()
		{
            List<Item> invent= new List<Item>();
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( ()=>new Character(" ", "zer",10,0,1, book, invent,10,testdungeon,testfloor,testsquare) );
            Assert.Throws<ArgumentException>( () => new Character(null, "zer", 10, 0, 1, book, invent, 10, testdungeon,testfloor,testsquare) );
            Assert.Throws<ArgumentException>( () => new Character(string.Empty, "zer", 10, 0, 1, book, invent, 10, testdungeon,testfloor,testsquare) );
        }

        [Test]
        public void Create_character_with_null_description()
        {
            List<Item> invent = new List<Item>();
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( () => new Character( "zer", null, 10, 0, 1, book, invent, 10, testdungeon, testfloor, testsquare ) );
        }

        [Test]
        public void Create_character_with_no_hp()
        {
            List<Item> invent = new List<Item>();
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor("testfloor",18,25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( () => new Character( "zer", "", 0, 0, 1, book, invent, 10, testdungeon, testfloor, testsquare ) );
        }

        [Test]
        public void Helper_builder_create_character_correctly()
        {
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );
           
            Character testChar = new Character("tartempion", "truc", testdungeon,testfloor,testsquare);

            Assert.That(testChar.Name, Is.EqualTo("tartempion"));
            Assert.That(testChar.Descritption, Is.EqualTo("truc"));
            Assert.That(testChar.Health, Is.EqualTo(100));
            Assert.That(testChar.Experience, Is.EqualTo(0));
            Assert.That(testChar.Level, Is.EqualTo(1));
            Assert.That(testChar.Armor, Is.EqualTo(10));
        }

        [Test]
        public void Massive_builder_create_character_as_intented()
        {
            List<Item> invent = new List<Item>();
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Character testCharacter = new Character("tartempion", "truc", 8100, 3700, 18, book, invent, 58, testdungeon,testfloor,testsquare);

            Assert.That(testCharacter.Name, Is.EqualTo("tartempion"));
            Assert.That(testCharacter.Descritption, Is.EqualTo("truc"));
            Assert.That(testCharacter.Health, Is.EqualTo(8100));
            Assert.That(testCharacter.Experience, Is.EqualTo(3700));
            Assert.That(testCharacter.Level, Is.EqualTo(18));
            Assert.That(testCharacter.Armor, Is.EqualTo(58));           
        }

        [Test]
        public void Negative_experience_throw_exception()
        {
            List<Item> invent = new List<Item>( );
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( () => new Character( "tartempion", "truc", 8100, -3700, 18, book, invent, 58, testdungeon, testfloor, testsquare ) );
        }

        [Test]
        public void Negative_health_throw_experience()
        {
            List<Item> invent = new List<Item>( );
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( () => new Character( "tartempion", "truc", -8100, 3700, 18, book, invent, 58, testdungeon, testfloor, testsquare ) );
        }

        [Test]
        public void Negative_level_throw_exception()
        {
            List<Item> invent = new List<Item>( );
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( () => new Character( "tartempion", "truc", 8100, 3700, -18, book, invent, 58, testdungeon, testfloor, testsquare ) );
        }

        [Test]
        public void Negative_armor_throw_exception()
        {
            List<Item> invent = new List<Item>( );
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 25 );
            Square testsquare = new Square( "testtype", true );

            Assert.Throws<ArgumentException>( () => new Character( "tartempion", "truc", 8100, 3700, 18, book, invent, -58, testdungeon, testfloor, testsquare ) );
        }
        
        [Test]
        public void Character_cant_move_to_not_holdable_square()
        {
            List<Item> invent = new List<Item>( );
            List<string> book = new List<string>( );
            Dungeon testdungeon = new Dungeon( "test dungeon" );
            Floor testfloor = new Floor( "testfloor", 18, 24 );
            Square testsquare = new Square( "testtype", true );
            Character testcharacter = new Character( "plop", "zer", 10, 0, 1, book, invent, 10, testdungeon, testfloor, testsquare );

            testfloor.SetSquare( 14, 22, "unholdable", false );

            Assert.Throws<InvalidOperationException>( () => testcharacter.MoveTo( 14, 22 ) );            
        }
        #endregion
    }
}
