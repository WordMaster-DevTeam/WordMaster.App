using System;
using NUnit.Framework;
using WordMaster.Library;

namespace WordMaster.UniTests
{
	[TestFixture]
    public class InputsCheckerTests
    {
		[Test]
		public void Checks_name_length()
		{
			// Arrange
			string minNameLength = "", maxNameLength = "", midNameLength = "", minNameLengthMinusOne = "", maxNameLengthPlusOne = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinNameLength; i++ ) minNameLength += "a";
			for( int i = 0; i < NoMagicHelper.MaxNameLength; i++ ) maxNameLength += "b";
			for( int i = 0; i < NoMagicHelper.MaxNameLength / 2; i++ ) midNameLength += "c";
			for( int i = 0; i < (NoMagicHelper.MinNameLength - 1); i++ ) minNameLengthMinusOne += "e";
			for( int i = 0; i < (NoMagicHelper.MaxNameLength + 1); i++ ) maxNameLengthPlusOne += "f";

			// Assert
			Assert.IsTrue( NoMagicHelper.CheckNameLength( minNameLength ) );
			Assert.IsTrue( NoMagicHelper.CheckNameLength( maxNameLength ) );
			Assert.IsTrue( NoMagicHelper.CheckNameLength( midNameLength ) );
			Assert.IsFalse( NoMagicHelper.CheckNameLength( minNameLengthMinusOne ) );
			Assert.IsFalse( NoMagicHelper.CheckNameLength( maxNameLengthPlusOne ) );
		}

		[Test]
		public void Check_Description_length()
		{
			// Arrange
			string minLongStringLength = "", maxLongStringLength = "", midLongStringLength = "", /*minLongStringLengthMinusOne= "",*/ maxLongStringLengthPlusOne = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinDescriptionLength; i++ ) minLongStringLength += "a";
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength; i++ ) maxLongStringLength += "b";
			for( int i = 0; i < NoMagicHelper.MaxDescriptionLength / 2; i++ ) midLongStringLength += "c";
			/*for( int i = 0; i < (NoMagicHelper.MinDescritptionLength - 1); i++ ) minLongStringLengthMinusOne += "e";*/
			for( int i = 0; i < (NoMagicHelper.MaxDescriptionLength + 1); i++ ) maxLongStringLengthPlusOne += "f";

			// Assert
			Assert.IsTrue( NoMagicHelper.CheckDescriptionLength( minLongStringLength ) );
			Assert.IsTrue( NoMagicHelper.CheckDescriptionLength( maxLongStringLength ) );
			Assert.IsTrue( NoMagicHelper.CheckDescriptionLength( midLongStringLength ) );
			/*Assert.IsFalse( NoMagicHelper.CheckLongStringLength( minLongStringLengthMinusOne ) );*/
			Assert.IsFalse( NoMagicHelper.CheckDescriptionLength( maxLongStringLengthPlusOne ) );
		}
		[Test]
		public void Check_Floor_size()
		{
			// Arrange
			int minFloorSize, midFloorSize, maxFloorSize, minSizeMinusOne, maxSizePlusOne;

			// Act
			minFloorSize = NoMagicHelper.MinFloorSize;
			maxFloorSize = NoMagicHelper.MaxFloorSize;
			midFloorSize = NoMagicHelper.MaxFloorSize / 2;
			minSizeMinusOne = NoMagicHelper.MinFloorSize - 1;
			maxSizePlusOne = NoMagicHelper.MaxFloorSize + 1;

			// Assert
			Assert.IsTrue( NoMagicHelper.CheckFloorSize( minFloorSize ) );
			Assert.IsTrue( NoMagicHelper.CheckFloorSize( maxFloorSize ) );
			Assert.IsTrue( NoMagicHelper.CheckFloorSize( midFloorSize ) );
			Assert.IsFalse( NoMagicHelper.CheckFloorSize( minSizeMinusOne ) );
			Assert.IsFalse( NoMagicHelper.CheckFloorSize( maxSizePlusOne ) );
		}
    }
}
