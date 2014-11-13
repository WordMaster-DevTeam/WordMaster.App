using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMaster.DLL;

namespace WordMaster.UniTests
{
	[TestFixture]
    public class DungeonTests
    {
		[Test]
		public void Get_the_name_of_Dungeons()
		{
			// Arrange
			Dungeon dungeonA, dungeonB;
			string nameA = "", nameB = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) nameA += "a";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) nameB += "b";
			dungeonA = new Dungeon( nameA );
			dungeonB = new Dungeon( nameB );

			// Assert
			Assert.AreEqual( dungeonA.Name, nameA );
			Assert.AreEqual( dungeonB.Name, nameB );
		}

		[Test]
		public void Rename_Dungeon()
		{
			// Arrange
			Dungeon dungeonC;
			string nameC1 = "", nameC2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) nameC1 += "c";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) nameC2 += "c";
			dungeonC = new Dungeon( nameC1 );
			dungeonC.Name = nameC2;

			// Assert
			Assert.AreEqual( dungeonC.Name, nameC2 );
		}

		public void Get_description_of_Dungeon()
		{
			// Arrange
			Dungeon dungeonD, dungeonE;
			string nameD = "", nameE = "";
			string descriptionD = "", descriptionE = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) nameD += "d";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) nameE += "e";
			for( int i = 0; i < NoMagicHelper.MinLongStringLength; i++ ) descriptionD += "d";
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ ) descriptionE += "e";
			dungeonD = new Dungeon( nameD, descriptionD );
			dungeonE = new Dungeon( nameE, descriptionE );

			// Assert
			Assert.AreEqual( dungeonD.Description, descriptionD );
			Assert.AreEqual( dungeonE.Description, descriptionE );
		}

		public void Change_description_of_Dungeon()
		{
			// Arrange
			Dungeon dungeonF;
			string nameF = "";
			string descriptionF1 = "", descriptionF2 = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) nameF += "f";
			for( int i = 0; i < NoMagicHelper.MinLongStringLength; i++ ) descriptionF1 += "d";
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ ) descriptionF2 += "e";
			dungeonF = new Dungeon( nameF, descriptionF1 );
			dungeonF.Description = descriptionF2;

			// Assert
			Assert.AreEqual( dungeonF.Description, descriptionF2 );
		}

		public void Get_number_of_Floor_in_Dungeon()
		{

		}

		[Test]
		public void Add_Floor_in_Dungeon()
		{

		}

		[Test]
		public void Remove_Floor_in_Dungeon()
		{

		}

		[Test]
		public void Get_index_of_a_Floor()
		{

		}

		[Test]
		public void Get_reference_of_a_Floor()
		{

		}
	}
}
