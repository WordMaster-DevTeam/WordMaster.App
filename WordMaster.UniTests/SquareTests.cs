using System;
using NUnit.Framework;
using WordMaster.DLL;

namespace WordMaster.UniTests
{
	[TestFixture]
	class SquareTests
	{
		[Test]
		public void Gets_all_properties_of_a_Square()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName, squareName, squareDescription;
			Dungeon dungeon;
			Floor floor;
			Square square;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = squareName = squareDescription = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
				squareName += "c";
			}
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ )
			{
				squareDescription += "d";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			square = floor.SetSquare( 0, 0, squareName, squareDescription );

			// Assert
			Assert.AreEqual( square.Name, squareName );
			Assert.AreEqual( square.Description, squareDescription );
			Assert.AreEqual( square.Holdable, true );
		}

		[Test]
		public void Resets_and_gets_properties_of_a_Square()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName, squareName1, squareName2, squareDescription1, squareDescription2;
			Dungeon dungeon;
			Floor floor;
			Square square1, square2;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = squareName1 = squareName2 = squareDescription1 = squareDescription2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
				squareName1 += "1";
				squareName2 += "2";
			}
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ )
			{
				squareDescription2 += "1";
				squareDescription2 += "2";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			square1 = floor.SetSquare( 0, 0, squareName1, squareDescription1, true );
			square2 = floor.SetSquare( 0, 1, squareName2, squareDescription2, false );
			square2.Holdable = true;
			square2.TeleportTo = square1;

			// Assert
			Assert.AreEqual( square2.Holdable, true );
			Assert.AreEqual( square2.TeleportTo, square1 );
			Assert.AreEqual( square1.TeleportTo, null );
		}
	}
}
