using System;
using NUnit.Framework;
using WordMaster.DLL;

namespace WordMaster.UniTests
{
	[TestFixture]
    public class DungeonTests
    {
		[Test]
		public void Gets_the_name_of_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			string name = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) name += "a";
			dungeonRef = new Dungeon( name );

			// Assert
			Assert.AreEqual( dungeonRef.Name, name );
		}

		[Test]
		public void Changes_the_name_of_Dungeon()
		{
			// Arrange
			Dungeon dungeon;
			string name1 = "", name2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) name1 += "a";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) name2 += "b";
			dungeon = new Dungeon( name1 );
			dungeon.Name = name2;

			// Assert
			Assert.AreEqual( dungeon.Name, name2 );
		}

		[Test]
		public void Gets_the_description_of_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			string name = "", desc = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) name += "a";
			for( int i = 0; i < NoMagicHelper.MinLongStringLength; i++ ) desc += "b";
			dungeonRef = new Dungeon( name, desc );

			// Assert
			Assert.AreEqual( dungeonRef.Description, desc );
		}

		[Test]
		public void Changes_the_description_of_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			string name = "", desc1 = "", desc2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) name += "a";
			for( int i = 0; i < NoMagicHelper.MinLongStringLength; i++ ) desc1 += "b";
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ ) desc2 += "c";
			dungeonRef = new Dungeon( name, desc1 );
			dungeonRef.Description = desc2;

			// Assert
			Assert.AreEqual( dungeonRef.Description, desc2 );
		}

		[Test]
		public void Adds_and_recovers_a_Floor_using_his_index_or_his_name_in_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor floorRef1, floorRef2, floorRefCheck1, floorRefCheck2;
			string name = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName1 += "b";
				floorName2 += "c";
			}
			dungeonRef = new Dungeon( name );
			floorRef1 = dungeonRef.AddFloor(floorName1, NoMagicHelper.MinFloorSize );
			floorRef2 = dungeonRef.AddFloor(floorName2, NoMagicHelper.MaxFloorSize );

			// Assert
			Assert.AreEqual( floorRef1.Name, floorName1 );
			Assert.AreEqual( floorRef2.Name, floorName2 );
			if( dungeonRef.TryGetFloor( 0, out floorRefCheck1 ) ) Assert.AreSame( floorRef1, floorRefCheck1 );
			else throw new Exception( "Cannot recover Floor." );
			if( dungeonRef.TryGetFloor( floorName2, out floorRefCheck2 ) ) Assert.AreSame( floorRef2, floorRefCheck2 );
			else throw new Exception( "Cannot recover Floor." );
		}

		[Test]
		public void Adds_a_Floor_while_another_with_the_same_name_already_exist_throws_ArgumentException()
		{
			// Arrange
			Dungeon dungeonRef;
			string name = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName1 += "b";
				floorName2 += "b";
			}
			dungeonRef = new Dungeon( name );
			dungeonRef.AddFloor( floorName1, NoMagicHelper.MinFloorSize );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeonRef.AddFloor( floorName2, NoMagicHelper.MaxFloorSize ) );
		}

		[Test]
		public void Adds_a_Floor_with_a_negative_index_throws_ArgumentException()
		{
			Dungeon dungeonRef;
			string name = "", floorName = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName += "b";
			}
			dungeonRef = new Dungeon( name );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeonRef.AddFloor( -1, floorName, NoMagicHelper.MinFloorSize ) );
		}

		[Test]
		public void Adds_a_Floor_with_a_detached_index_throws_ArgumentException()
		{
			Dungeon dungeonRef;
			string name = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName1 += "b";
				floorName2 += "b";
			}
			dungeonRef = new Dungeon( name );
			dungeonRef.AddFloor( floorName1, NoMagicHelper.MinFloorSize );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeonRef.AddFloor( 2, floorName2, NoMagicHelper.MinFloorSize ) );
		}

		[Test]
		public void Adds_Floor_with_a_specified_index_and_gets_the_number_of_Floors_in_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			string name = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				floorName1 += "b";
				floorName2 += "c";
			}
			dungeonRef = new Dungeon( name );
			dungeonRef.AddFloor( 0, floorName1, NoMagicHelper.MinFloorSize );
			dungeonRef.AddFloor( 1, floorName2, NoMagicHelper.MaxFloorSize );

			// Assert
			Assert.AreEqual( dungeonRef.NumberOfFloors, 2 );
		}

		[Test]
		public void Inserts_Floor_at_specified_index_and_recovers_a_Floor_using_his_name_or_his_index_in_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor insertedFloorRef, floorRef1, floorRef2, floorRefCheck1, floorRefCheck2, floorRefCheck3;
			string name = "", insertedFloorName = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				insertedFloorName += "b";
				floorName1 += "c";
				floorName2 += "d";
			}
			dungeonRef = new Dungeon( name );
			floorRef1 = dungeonRef.AddFloor( floorName1, NoMagicHelper.MinFloorSize );
			floorRef2 = dungeonRef.AddFloor( floorName2, NoMagicHelper.MaxFloorSize );
			insertedFloorRef = dungeonRef.AddFloor( 0, insertedFloorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );

			// Assert
			if( dungeonRef.TryGetFloor( 0, out floorRefCheck1 ) ) Assert.AreSame( insertedFloorRef, floorRefCheck1 );
			else throw new Exception( "Cannot recover Floor." );
			if( dungeonRef.TryGetFloor( 1, out floorRefCheck2 ) ) Assert.AreSame( floorRef1, floorRefCheck2 );
			else throw new Exception( "Cannot recover Floor." );
			if( dungeonRef.TryGetFloor( 2, out floorRefCheck3 ) ) Assert.AreSame( floorRef2, floorRefCheck3 );
			else throw new Exception( "Cannot recover Floor." );
		}

		[Test]
		public void Removes_upper_Floor_and_checks_existence_using_Floor_name_in_Dungeon()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor removedFloorRef, floorRef1, floorRef2;
			string name = "", removedFloorName = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				removedFloorName += "b";
				floorName1 += "c";
				floorName2 += "d";
			}
			dungeonRef = new Dungeon( name );
			floorRef1 = dungeonRef.AddFloor( 0, floorName1, NoMagicHelper.MinFloorSize );
			floorRef2 = dungeonRef.AddFloor( 1, floorName2, NoMagicHelper.MinFloorSize );
			removedFloorRef = dungeonRef.AddFloor( 2, removedFloorName, NoMagicHelper.MinFloorSize );
			dungeonRef.RemoveFloor( removedFloorRef );

			// Assert
			Assert.IsTrue( dungeonRef.ExistFloor( floorName1 ) );
			Assert.IsTrue( dungeonRef.ExistFloor( floorName2 ) );
			Assert.IsFalse( dungeonRef.ExistFloor( removedFloorName ) );	
		}

		[Test]
		public void Removes_one_Floor_in_the_middle_update_the_indexes_correctly()
		{
			// Arrange
			Dungeon dungeonRef;
			Floor removedFloorRef, floorRef1, floorRef2;
			string name = "", removedFloorName = "", floorName1 = "", floorName2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				name += "a";
				removedFloorName += "b";
				floorName1 += "c";
				floorName2 += "d";
			}
			dungeonRef = new Dungeon( name );
			floorRef1 = dungeonRef.AddFloor( 0, floorName1, NoMagicHelper.MinFloorSize );
			removedFloorRef = dungeonRef.AddFloor( 1, removedFloorName, NoMagicHelper.MinFloorSize );
			floorRef2 = dungeonRef.AddFloor( 2, floorName2, NoMagicHelper.MinFloorSize );
			dungeonRef.RemoveFloor( removedFloorRef );

			// Assert
			Assert.IsTrue( dungeonRef.ExistFloor( floorName1 ) );
			Assert.IsTrue( dungeonRef.ExistFloor( floorName2 ) );
			Assert.IsFalse( dungeonRef.ExistFloor( removedFloorName ) );	
		}
	}
}
