using System;
using NUnit.Framework;
using WordMaster.Gameplay;

namespace WordMaster.UniTests
{
	[TestFixture]
    public class DungeonTests
    {
		[Test]
		public void Gets_all_properties_of_a_Dungeon()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			string dungeonName = "a dungeon";
			string dungeonDescription = "a description of a dungeon";

			// Act
			dungeon = context.AddDungeon( dungeonName, dungeonDescription );

			// Assert
			Assert.AreEqual( dungeon.Name, dungeonName );
			Assert.AreEqual( dungeon.Description, dungeonDescription );
		}

		[Test]
		public void Add_two_Floors_with_the_same_name_throws_ArgumentException()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			string dungeonName = "a dungeon";
			string floorName = "a floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			dungeon.AddFloor( floorName, "", 3, 3 );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeon.AddFloor( floorName, "", 3, 3 ) );
		}

		[Test]
		public void Can_not_adds_a_Floor_with_a_negative_index()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure square;
			string dungeonName = "a dungeon";
			string floorName = "a floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, "");

			// Assert
			Assert.IsFalse( dungeon.TryAddFloor( -1, floorName, "", 3, 3, out square ) );
		}

		[Test]
		public void Can_not_adds_a_Floor_with_a_detached_index()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure square;
			string dungeonName = "a dungeon";
			string floorAName = "a floor";
			string floorBName = "another floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, ""  );
			dungeon.AddFloor( floorAName, "", 3, 3 );

			// Assert
			Assert.IsFalse( dungeon.TryAddFloor( 42, floorBName, "", 3, 3, out square ) );
		}

		[Test]
		public void Adds_Floor_with_a_specified_index_and_gets_the_number_of_Floors_in_Dungeon()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure floorA, floorB, floorC;
			string dungeonName = "a dungeon";
			string floorAName = "a floor";
			string floorBName = "another floor";
			string floorCName = "yet another floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floorA = dungeon.AddFloor( 0, floorAName, "", 3, 3 );
			floorB = dungeon.AddFloor( 1, floorBName, "", 3, 3 );
			floorC = dungeon.AddFloor( 1, floorCName, "", 3, 3 );

			// Assert
			Assert.AreSame( floorC, dungeon.GetFloor( 1 ) );
			Assert.AreEqual( dungeon.NumberOfFloors, 3 );
			Assert.AreEqual( floorB.Level, 2 );
		}

		[Test]
		public void Removes_upper_Floor_and_checks_existence_using_Floor_name_in_Dungeon()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure floorA, floorB, floorC;
			string dungeonName = "a dungeon";
			string floorAName = "a floor";
			string floorBName = "another floor";
			string floorCName = "yet another floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floorA = dungeon.AddFloor( floorAName, "", 3, 3 );
			floorB = dungeon.AddFloor( floorBName, "", 3, 3 );
			floorC = dungeon.AddFloor( floorCName, "", 3, 3 ); 
			dungeon.TryRemoveFloor( floorC );

			// Assert
			Assert.IsTrue( dungeon.ExistFloor( floorAName ) );
			Assert.IsTrue( dungeon.ExistFloor( floorBName ) );
			Assert.IsFalse( dungeon.ExistFloor( floorCName ) );	
		}

		[Test]
		public void Removes_one_Floor_in_the_middle_update_the_levels_correctly()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure floorA, floorB, floorC;
			string dungeonName = "a dungeon";
			string floorAName = "a floor";
			string floorBName = "another floor";
			string floorCName = "yet another floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floorA = dungeon.AddFloor( floorAName, "", 3, 3 );
			floorB = dungeon.AddFloor( floorBName, "", 3, 3 );
			floorC = dungeon.AddFloor( floorCName, "", 3, 3 );
			dungeon.TryRemoveFloor( floorB );

			// Assert
			Assert.AreEqual(floorA.Level, 0 );
			Assert.AreEqual( floorC.Level, 1 );
		}
	}
}
