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
			Dungeon dungeonRef;
			Floor floorRef;
			string name = "", floorName = "", floorDesc = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName += "b";
			}
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ )
			{
				floorDesc += "c";
			}
			dungeonRef = new Dungeon( name );
			floorRef = dungeonRef.AddFloor( floorName, floorDesc, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );

			//Assert
			Assert.AreEqual( floorRef.Name, floorName );
			Assert.AreEqual( floorRef.Description, floorDesc );
			Assert.AreEqual( floorRef.Length, NoMagicHelper.MinFloorSize );
			Assert.AreEqual( floorRef.Width, NoMagicHelper.MaxFloorSize );
		}

		[Test]
		public void Initializes_all_Squares_and_checks_initialisation()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor floorRef;
			string name = "", floorName = "", squaresName = "", squaresDesc = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName += "b";
				squaresName += "c";
			}
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ )
			{
				squaresDesc += "d";
			}
			dungeonRef = new Dungeon( name );
			floorRef = dungeonRef.AddFloor( floorName, NoMagicHelper.MinFloorSize );
			floorRef.SetAllSquares(squaresName, squaresDesc, true);

			// Assert
			Assert.IsTrue( floorRef.CheckAllSquare() );
		}

		[Test]
		public void Gets_a_Square_reference()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor floorRef;
			Square squareRef, squareRefCheck;
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
			dungeonRef = new Dungeon( name );
			floorRef = dungeonRef.AddFloor( floorName, NoMagicHelper.MinFloorSize );
			squareRef = floorRef.SetSquare( squareName, squareDesc, false, 1, 1 );
			
			// Assert
			if( floorRef.TryGetSquare( 1, 1, out squareRefCheck ) ) Assert.AreSame( squareRef, squareRefCheck );
			else throw new Exception( "Cannot recover Square's reference" );
		}

		[Test]
		public void Initializes_all_uninitializes_Squares_and_checks_initialisation()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor floorRef;
			Square squareRef, anotherSquareRef;
			string name = "", floorName = "", squaresName = "", squaresDesc = "", aSquareName = "", aSquareDesc = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName += "b";
				squaresName += "c";
				aSquareName += "1";
			}
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ )
			{
				squaresDesc += "d";
				aSquareDesc += "2";
			}
			dungeonRef = new Dungeon( name );
			floorRef = dungeonRef.AddFloor( floorName, NoMagicHelper.MinFloorSize );
			squareRef = floorRef.SetSquare( aSquareName, aSquareDesc, true, 1, 1 );
			floorRef.SetAllUninitializedSquares( squaresName, squaresDesc, false );

			// Assert
			Assert.IsTrue( floorRef.CheckAllSquare() );
			Assert.AreEqual( squareRef.Name, aSquareName );
			if( floorRef.TryGetSquare( 0, 0, out anotherSquareRef ) ) Assert.AreNotEqual( squareRef.Name, anotherSquareRef.Name );
			else throw new Exception( "Cannot recover Square's reference" );
		}
	}
}
