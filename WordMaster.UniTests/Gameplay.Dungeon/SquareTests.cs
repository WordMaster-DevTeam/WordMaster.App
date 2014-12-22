using System;
using NUnit.Framework;
using WordMaster.Gameplay;

namespace WordMaster.UniTests
{
	[TestFixture]
	class SquareTests
	{
		[Test]
		public void Gets_all_properties_of_a_Square()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure floor;
			SquareStructure square;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";
			string squareDescription = "a description for a square";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			square = floor.SetSquare( 0, 0, squareName, squareDescription, true );

			// Assert
			Assert.AreSame( square, floor[0, 0] );
			Assert.AreEqual( square.Name, squareName );
			Assert.AreEqual( square.Description, squareDescription );
			Assert.AreEqual( square.Holdable, true );
			Assert.AreEqual( square.Trigger, null );
		}

		[Test]
		public void Resets_and_checks_properties_of_a_Square()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure floor;
			SquareStructure square;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName1 = "a square";
			string squareName2 = "another square";
			string squareDescription1 = "a description for a square";
			string squareDescription2 = "another description for a square";
			string teleportName = "a teleport";
			string teleportDescription = "a description for a teleport";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			square = floor.SetSquare( 0, 0, squareName1, squareDescription1, false );
			square.Name = squareName2;
			square.Description = squareDescription2;
			square.Holdable = true;
			square.SetTeleport( teleportName, teleportDescription, square, true );

			// Assert
			Assert.AreEqual( square.Name, squareName2 );
			Assert.AreEqual( square.Description, squareDescription2 );
			Assert.AreEqual( square.Holdable, true );
			Assert.IsInstanceOf<Teleport>( square.Trigger );
		}

		[Test]
		public void Checks_holdable_property_relation_with_teleport_to_property()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			DungeonStructure dungeon;
			FloorStructure floor;
			SquareStructure squareA, squareB, squareC;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";
			string triggerName = "a teleport";
			string triggerDescription = "a description for a teleport";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			squareA = floor.SetSquare( 0, 0, squareName, "", false );
			squareB = floor.SetSquare( 0, 1, squareName, "", false );
			squareC = floor.SetSquare( 0, 2, squareName, "", true );
			squareA.SetTeleport( triggerName, triggerDescription, squareC, false );

			// Assert
			Assert.AreSame( squareA.Trigger.Holder, squareA );
			Assert.IsInstanceOf<Teleport>( squareA.Trigger);
			Assert.IsTrue( squareA.Holdable );
			Assert.IsFalse( squareB.Holdable );
			Assert.IsTrue( squareC.Holdable );
		}
	}
}
