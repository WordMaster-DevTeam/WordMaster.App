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
			Dungeon dungeon;
			Floor floorRef;
			Square squareRef;
			string name = "", floorName = "", squareName = "", squareDesc = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName += "b";
				squareName += "c";
			}
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ )
			{
				squareDesc += "d";
			}
			dungeon = new Dungeon( name );
			floorRef = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			squareRef = floorRef.SetSquare( squareName, squareDesc, true, 0, 0 );

			// Assert
			Assert.AreEqual( squareRef.Name, squareName );
			Assert.AreEqual( squareRef.Description, squareDesc );
			Assert.AreEqual( squareRef.Holdable, true );
		}

		[Test]
		public void Resets_and_gets_all_properties_of_a_Square()
		{
			// Arrange
			Dungeon dungeon;
			Floor floorRef;
			Square squareRef;
			string name = "", floorName = "", squareName1 = "", squareName2 = "", squareDesc1 = "", squareDesc2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName += "b";
				squareName1 += "1";
				squareName2 += "2";
			}
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ )
			{
				squareDesc1 += "1";
				squareDesc2 += "2";
			}
			dungeon = new Dungeon( name );
			floorRef = dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			squareRef = floorRef.SetSquare( squareName1, squareDesc1, true, 0, 0 );
			squareRef.Name = squareName2;
			squareRef.Description = squareDesc2;
			squareRef.Holdable = false;

			// Assert
			Assert.AreEqual( squareRef.Name, squareName2 );
			Assert.AreEqual( squareRef.Description, squareDesc2 );
			Assert.AreEqual( squareRef.Holdable, false );
		}
	}
}
