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
			GlobalContext context;
			string dungeonName;
			Dungeon dungeon;

			// Act
			context = new GlobalContext();
			dungeonName = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
				dungeonName += "a";
			dungeon = context.AddDungeon( dungeonName );

			// Assert
			Assert.AreEqual( dungeon.Name, dungeonName );
		}

		[Test]
		public void Gets_the_description_of_Dungeon()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, dungeonDescription;
			Dungeon dungeon;

			// Act
			context = new GlobalContext();
			dungeonName = dungeonDescription = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
				dungeonName += "a";
			for( int i = 0; i < NoMagicHelper.MinDescriptionLength; i++ )
				dungeonDescription += "b";
			dungeon = context.AddDungeon( dungeonName, dungeonDescription );

			// Assert
			Assert.AreEqual( dungeon.Description, dungeonDescription );
		}

		[Test]
		public void Adds_and_recovers_a_Floor_using_his_level_or_his_name_in_Dungeon()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName1, floorName2;
			Dungeon dungeon;
			Floor floor1, floor2, floorCheck1, floorCheck2;

			// Act
			context = new GlobalContext();
			dungeonName = floorName1 = floorName2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName1 += "b";
				floorName2 += "c";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor1 = dungeon.AddFloor( floorName1, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );
			floor2 = dungeon.AddFloor( floorName2, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );

			// Assert
			Assert.AreEqual( floor1.Name, floorName1 );
			Assert.AreEqual( floor2.Name, floorName2 );
			if( dungeon.TryGetFloor( 0, out floorCheck1 ) ) Assert.AreSame( floor1, floorCheck1 );
			else throw new Exception( "Cannot recover Floor." );
			if( dungeon.TryGetFloor( floorName2, out floorCheck2 ) ) Assert.AreSame( floor2, floorCheck2 );
			else throw new Exception( "Cannot recover Floor." );
		}

		[Test]
		public void Adds_a_Floor_while_another_with_the_same_name_already_exist_throws_ArgumentException()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName;
			Dungeon dungeon;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
			}
			dungeon = context.AddDungeon( dungeonName );
			dungeon.AddFloor( floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeon.AddFloor( floorName, NoMagicHelper.MaxFloorSize, NoMagicHelper.MaxFloorSize ) );
		}

		[Test]
		public void Adds_a_Floor_with_a_negative_index_throws_ArgumentException()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName;
			Dungeon dungeon;

			// Act
			context = new GlobalContext();
			dungeonName = floorName = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName += "b";
			}
			dungeon = context.AddDungeon( dungeonName );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeon.AddFloor( -1, floorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize ) );
		}

		[Test]
		public void Adds_a_Floor_with_a_detached_index_throws_ArgumentException()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName1, floorName2;
			Dungeon dungeon;

			// Act
			context = new GlobalContext();
			dungeonName = floorName1 = floorName2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName1 += "b";
				floorName2 += "b";
			}
			dungeon = context.AddDungeon( dungeonName );
			dungeon.AddFloor( floorName1, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );

			// Assert
			Assert.Throws<ArgumentException>( () => dungeon.AddFloor( 42, floorName2, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize ) );
		}

		[Test]
		public void Adds_Floor_with_a_specified_index_and_gets_the_number_of_Floors_in_Dungeon()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, floorName1, floorName2;
			Dungeon dungeon;

			// Act
			context = new GlobalContext();
			dungeonName = floorName1 = floorName2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				floorName1 += "b";
				floorName2 += "c";
			}
			dungeon = context.AddDungeon( dungeonName );
			dungeon.AddFloor( 0, floorName1, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			dungeon.AddFloor( 1, floorName2, NoMagicHelper.MaxFloorSize, NoMagicHelper.MaxFloorSize );

			// Assert
			Assert.AreEqual( dungeon.NumberOfFloors, 2 );
		}

		[Test]
		public void Inserts_Floor_at_specified_index_and_recovers_a_Floor_using_his_name_or_his_index_in_Dungeon()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, insertedFloorName, floorName1, floorName2;
			Dungeon dungeon;
			Floor insertedFloor, floor1, floor2, floorCheck1, floorCheck2, floorCheck3;

			// Act
			context = new GlobalContext();
			dungeonName = insertedFloorName = floorName1 = floorName2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				insertedFloorName += "b";
				floorName1 += "c";
				floorName2 += "d";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor1 = dungeon.AddFloor( floorName1, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			floor2 = dungeon.AddFloor( floorName2, NoMagicHelper.MaxFloorSize, NoMagicHelper.MaxFloorSize );
			insertedFloor = dungeon.AddFloor( 1, insertedFloorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );

			// Assert
			if( dungeon.TryGetFloor( 0, out floorCheck1 ) ) Assert.AreSame( insertedFloor, floorCheck1 );
			else throw new Exception( "Can not recover Floor." );
			if( dungeon.TryGetFloor( 1, out floorCheck2 ) ) Assert.AreSame( floor1, floorCheck2 );
			else throw new Exception( "Can not recover Floor." );
			if( dungeon.TryGetFloor( 2, out floorCheck3 ) ) Assert.AreSame( floor2, floorCheck3 );
			else throw new Exception( "Can not recover Floor." );
		}

		[Test]
		public void Removes_upper_Floor_and_checks_existence_using_Floor_name_in_Dungeon()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, removedFloorName, floorName1, floorName2;
			Dungeon dungeon;
			Floor removedFloor, floor1, floor2;

			// Act
			context = new GlobalContext();
			dungeonName = removedFloorName = floorName1 = floorName2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				removedFloorName += "b";
				floorName1 += "c";
				floorName2 += "d";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor1 = dungeon.AddFloor( 0, floorName1, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			floor2 = dungeon.AddFloor( 1, floorName2, NoMagicHelper.MinFloorSize, NoMagicHelper.MaxFloorSize );
			removedFloor = dungeon.AddFloor( 2, removedFloorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			dungeon.RemoveFloor( removedFloor );

			// Assert
			Assert.IsTrue( dungeon.ExistFloor( floorName1 ) );
			Assert.IsTrue( dungeon.ExistFloor( floorName2 ) );
			Assert.IsFalse( dungeon.ExistFloor( removedFloorName ) );	
		}

		[Test]
		public void Removes_one_Floor_in_the_middle_update_the_levels_correctly()
		{
			// Arrange
			GlobalContext context;
			string dungeonName, removedFloorName, floorName1, floorName2;
			Dungeon dungeon;
			Floor removedFloor, floor1, floor2;

			// Act
			context = new GlobalContext();
			dungeonName = removedFloorName = floorName1 = floorName2 = "";
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ )
			{
				dungeonName += "a";
				removedFloorName += "b";
				floorName1 += "c";
				floorName2 += "d";
			}
			dungeon = context.AddDungeon( dungeonName );
			floor1 = dungeon.AddFloor( 0, floorName1, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			removedFloor = dungeon.AddFloor( 1, removedFloorName, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			floor2 = dungeon.AddFloor( 2, floorName2, NoMagicHelper.MinFloorSize, NoMagicHelper.MinFloorSize );
			dungeon.RemoveFloor( removedFloor );

			// Assert
			Assert.IsTrue( dungeon.ExistFloor( floorName1 ) );
			Assert.IsTrue( dungeon.ExistFloor( floorName2 ) );
			Assert.IsFalse( dungeon.ExistFloor( removedFloorName ) );	
		}
	}
}
