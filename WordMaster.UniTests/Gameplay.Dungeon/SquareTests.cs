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
			Dungeon dungeon;
			Floor floor;
			Square square;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";
			string squareDescription = "a description for a square";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			square = floor.SetSquare( 0, 0, squareName, squareDescription, true, null );

			// Assert
			Assert.AreSame( square, floor.GetSquare( 0, 0 ) );
			Assert.AreEqual( square.Name, squareName );
			Assert.AreEqual( square.Description, squareDescription );
			Assert.AreEqual( square.Holdable, true );
			Assert.AreEqual( square.TargetTeleport, null );
		}

		[Test]
		public void Resets_and_checks_properties_of_a_Square()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			Dungeon dungeon;
			Floor floor;
			Square square;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName1 = "a square";
			string squareName2 = "another square";
			string squareDescription1 = "a description for a square";
			string squareDescription2 = "another description for a square";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			square = floor.SetSquare( 0, 0, squareName1, squareDescription1, false, null );
			square.Name = squareName2;
			square.Description = squareDescription2;
			square.Holdable = true;
			square.TargetTeleport = square;

			// Assert
			Assert.AreEqual( square.Name, squareName2 );
			Assert.AreEqual( square.Description, squareDescription2 );
			Assert.AreEqual( square.Holdable, true );
			Assert.AreEqual( square.TargetTeleport, square );
		}

		[Test]
		public void Checks_holdable_property_relation_with_teleport_to_property()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			Dungeon dungeon;
			Floor floor;
			Square squareA, squareB, squareC;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string squareName = "a square";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			squareA = floor.SetSquare( 0, 0, squareName, "", false, null );
			squareB = floor.SetSquare( 0, 1, squareName, "", false, squareA );
			squareC = floor.SetSquare( 0, 2, squareName, "", true, squareB );
			squareA.TargetTeleport = squareB;
			squareC.Holdable = false;

			// Assert
			Assert.AreSame( squareA.TargetTeleport, squareB );
			Assert.AreSame( squareB.TargetTeleport, squareA );
			Assert.AreSame( squareC.TargetTeleport, null );
			Assert.AreEqual( squareA.Holdable, true );
			Assert.AreEqual( squareB.Holdable, true );
			Assert.AreEqual( squareC.Holdable, false );
		}
	}
}
