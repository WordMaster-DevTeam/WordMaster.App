using System;
using NUnit.Framework;
using WordMaster.DLL;

namespace WordMaster.UniTests
{
	[TestFixture]
	class FloorTests
	{
		[Test]
		public void Gets_all_properties_of_a_Floor()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName, floorDescription;
			Dungeon dungeon;
			Floor floor;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = floorDescription = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
			}
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ )
			{
				floorDescription += "c";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor = dungeon.AddFloor( floorName, floorDescription, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );

			//Assert
			Assert.AreEqual( floor.Name, floorName );
			Assert.AreEqual( floor.Description, floorDescription );
			Assert.AreEqual( floor.NumberOfLines, NoMagicHelper.MinFloorSize );
			Assert.AreEqual( floor.NumberOfColumns, NoMagicHelper.MaxFloorSize );
		}

		[Test]
		public void Initializes_all_Squares_and_checks_initialisation()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName, squaresName, squaresDescription;
			Dungeon dungeon;
			Floor floor;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = squaresName = squaresDescription = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
				squaresName += "c";
			}
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ )
			{
				squaresDescription += "d";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			floor.SetAllSquares(squaresName, squaresDescription, true);

			// Assert
			Assert.IsTrue( floor.CheckAllSquare() );
		}

		[Test]
		public void Gets_a_Square_reference()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName, squareName;
			Dungeon dungeon;
			Floor floor;
			Square square, squareCheck;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = squareName = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
				squareName += "c";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			square = floor.SetSquare( 1, 1 , squareName );
			
			// Assert
			if( floor.TryGetSquare( 1, 1, out squareCheck ) ) Assert.AreSame( square, squareCheck );
			else throw new Exception( "Can not recover Square." );
		}

		[Test]
		public void Initializes_all_uninitializes_Squares_and_checks_initialisation()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName, squaresName, anotherSquareName;
			Dungeon dungeon;
			Floor floor;
			Square square, anotherSquare;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = squaresName = anotherSquareName = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
				squaresName += "1";
				anotherSquareName += "2";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			square = floor.SetSquare( 1, 1, anotherSquareName );
			floor.SetAllUninitializedSquares( squaresName );

			// Assert
			Assert.IsTrue( floor.CheckAllSquare() );
			Assert.AreEqual( square.Name, anotherSquareName );
			if( floor.TryGetSquare( 0, 0, out anotherSquare ) ) Assert.AreNotEqual( square.Name, anotherSquare.Name );
			else throw new Exception( "Cannot recover Square's reference" );
		}
	}
}
