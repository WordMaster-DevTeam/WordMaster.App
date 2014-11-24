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
		public void Create_Character_with_name_null_or_empty_string_or_filled_with_whitespace_only_throws_argument()
		{
			// Arrange
			GlobalContext context;
			Character character;

			// Act
			context = new GlobalContext();

			// Assert
            Assert.Throws<ArgumentException>( () => context.TryAddCharacter( "", out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( string.Empty, out character ) );
        }

        [Test]
        public void Create_character_with_incorrect_stats()
        {
			// Arrange
			GlobalContext context;
			string characterName, characterDescription;
			Character character;

			// Act
			context = new GlobalContext();
			characterName = characterDescription = "";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) characterName += "a";
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ ) characterDescription += "b";

			// Assert
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, 0, 0, 1, 10, out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, -1, 0, 1, 10, out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, 100, -1, 1, 10, out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, 100, 0, 0, 10, out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, 100, 0, -1, 10, out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, 100, 0, 1, 0, out character ) );
			Assert.Throws<ArgumentException>( () => context.TryAddCharacter( characterName, characterDescription, 100, 0, 1, -1, out character ) );
        }

        [Test]
        public void All_parameters_used_in_building_method_create_character_properly()
        {
			// Arrange
			GlobalContext context;
			string characterName, characterDescription;
			Character character;

			// Act
			context = new GlobalContext();
			characterName = characterDescription = "";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) characterName += "a";
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ ) characterDescription += "b";
			context.TryAddCharacter( characterName, characterDescription, 999, 9000, 42, 300, out character );

			// Assert
			Assert.That( character.Name, Is.EqualTo( characterName ) );
			Assert.That( character.Description, Is.EqualTo( characterDescription ) );
			Assert.That( character.Health, Is.EqualTo( 999 ) );
			Assert.That( character.Experience, Is.EqualTo( 9000 ) );
			Assert.That( character.Level, Is.EqualTo( 42 ) );
			Assert.That( character.Armor, Is.EqualTo( 300 ) );           
        }
        
        [Test]
        public void When_a_Game_start_Character_are_put_in_dungeon_and_can_not_move_to_not_holdable_square()
        {
			// Arrange
			GlobalContext context;
			string characterName, dungeonName, floorName, squaresName;
			Character character;
			Dungeon dungeon;
			Floor floor;
			Square squareEntrance, squareExit, trash;

			// Act
			context = new GlobalContext();
			characterName = dungeonName = floorName = squaresName = "";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ )
			{
				characterName += "a";
				dungeonName += "b";
				floorName += "c";
				squaresName += "d";
			}
			context.TryAddCharacter( characterName, out character );
			context.TryAddDungeon( dungeonName, out dungeon );
			dungeon.TryAddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize, out floor );
			floor.TrySetAllSquares( squaresName, "", false );
			floor.TrySetSquare( 0, 0, squaresName, "", true, null, out squareEntrance );
			dungeon.Entrance = squareEntrance;
			floor.TrySetSquare( 1, 1, squaresName, "", true, null, out squareExit );
			dungeon.Exit = squareExit;
			floor.TrySetSquare( 0, 1, squaresName, "", true, null, out trash );
			context.StartNewGame( character, dungeon );

			// Assert
			Assert.AreSame( character.Square, squareEntrance );
			Assert.IsFalse( character.TryMoveTo( 1, 0 ) );
		}
    }
}
