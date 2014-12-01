using System;
using NUnit.Framework;
using WordMaster.Library;

namespace WordMaster.UniTests
{
	[TestFixture]
	class FloorTests
	{
		[Test]
		public void Gets_all_properties_of_a_Floor()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			Dungeon dungeon;
			Floor floor;
			string dungeonName = "a dungeon";
			string floorName = "a floor";
			string floorDescription = "a description for a floor";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, floorDescription, 3, 3 );

			//Assert
			Assert.AreEqual( floor.Name, floorName );
			Assert.AreEqual( floor.Description, floorDescription );
			Assert.AreEqual( floor.NumberOfLines, 3 );
			Assert.AreEqual( floor.NumberOfColumns, 3);
		}

		[Test]
		public void Initializes_all_Squares_and_checks_initialisation()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			Dungeon dungeon;
			Floor floor;
			string dungeonName = "a dungeon";
			string floorName= "a floor";
			string squaresName = "a square";
			string squaresDescription = "a description for a square";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			floor.TrySetAllSquares(squaresName, squaresDescription, true);

			// Assert
			Assert.AreNotSame( floor.GetSquare( 0, 0 ), null );
			Assert.IsTrue( floor.CheckAllSquares() );
		}

		[Test]
		public void Initializes_all_uninitializes_Squares_and_checks_initialisation()
		{
			// Arrange
			GlobalContext context = new GlobalContext();
			Dungeon dungeon;
			Floor floor;
			Square square;
			string dungeonName = "a dungeon";
			string floorName = " a floor";
			string squaresName = "a square";
			string aSquareName = "another square";

			// Act
			dungeon = context.AddDungeon( dungeonName, "" );
			floor = dungeon.AddFloor( floorName, "", 3, 3 );
			square = floor.SetSquare( 1, 1, aSquareName );
			floor.SetAllUninitializedSquares( squaresName );

			// Assert
			Assert.IsTrue( floor.CheckAllSquares() );
			Assert.AreEqual( square.Name, aSquareName );
			Assert.AreNotEqual( square.Name, floor.GetSquare( 0, 0 ).Name );
		}
	}
}
