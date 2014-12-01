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
        [Test]
        public void Gets_all_properties_of_Character()
        {
			// Arrange
			GlobalContext context =  new GlobalContext();
			Character character;
			string characterName = "a character";
			string characterDescription = "a description of a character";
			int hp = 150, xp = 500, lvl = 3, armor = 25;

			// Act
			character = context.AddCharacter(characterName, characterDescription, hp, xp, lvl, armor);

			// Assert
			Assert.AreEqual(character.Name, characterName);
			Assert.AreEqual(character.Description, characterDescription);
			Assert.AreEqual(character.Health, hp);
			Assert.AreEqual(character.Experience, xp);
			Assert.AreEqual(character.Level, lvl);
			Assert.AreEqual(character.Armor, armor);
        }

        [Test]
        public void Create_character_with_incorrect_stats_throws_ArgumentException()
        {
			// Arrange
			GlobalContext context = new GlobalContext();
			string characterName = "a character";
			string characterDescription = "a description for a character";

			// Act
			/*
			 * Nothing, see Assert
			 */

			// Assert
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, 0, 0, 1, 10 ) );
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, -1, 0, 1, 10 ) );
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, 100, -1, 1, 10 ) );
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, 100, 0, 0, 10 ) );
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, 100, 0, -1, 10 ) );
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, 100, 0, 1, 0 ) );
			Assert.Throws<ArgumentException>( () => context.AddCharacter( characterName, characterDescription, 100, 0, 1, -1 ) );
        }       
        
        [Test]
        public void When_a_Game_start_Character_are_put_in_dungeon_and_can_not_move_to_not_holdable_square()
        {
			// Arrange
			GlobalContext context = new GlobalContext();
			Character character;
			Dungeon dungeon;
			Floor floor;
			Square final;
			string characterName = "a character";
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squaresName = "a square";

			// Act
			character = context.AddCharacter( characterName, "");
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			floor.SetAllSquares( squaresName, "", false );
			dungeon.Entrance = floor.SetSquare( 0, 0, squaresName, "", true, null );
			dungeon.Exit = floor.SetSquare( 1, 1, squaresName, "", true, null );
			floor.SetSquare( 0, 1, squaresName, "", true, null );
			context.StartNewGame( character, dungeon );

			// Assert
			Assert.AreSame( character.Square, dungeon.Entrance );
			Assert.IsFalse( character.TryMoveTo( 1, 0, out final ) );
			Assert.AreEqual( character.Square, final );
			Assert.IsTrue( character.TryMoveTo( 0, 1, out final ) );
			Assert.AreEqual( character.Square, final );
			Assert.IsTrue( character.TryMoveTo( 1, 1, out final ) );
			Assert.AreEqual( character.Square, final );
		}
    }
}
