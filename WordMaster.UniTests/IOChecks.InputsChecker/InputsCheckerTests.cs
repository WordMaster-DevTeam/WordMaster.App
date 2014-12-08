using System;
using NUnit.Framework;
using WordMaster.IOChecks;

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
			for( int i = 0; i < InputsChecker.MinNameLength; i++ ) minNameLength += "a";
			for( int i = 0; i < InputsChecker.MaxNameLength; i++ ) maxNameLength += "b";
			for( int i = 0; i < InputsChecker.MaxNameLength / 2; i++ ) midNameLength += "c";
			for( int i = 0; i < (InputsChecker.MinNameLength - 1); i++ ) minNameLengthMinusOne += "e";
			for( int i = 0; i < (InputsChecker.MaxNameLength + 1); i++ ) maxNameLengthPlusOne += "f";

			// Assert
			Assert.IsTrue( InputsChecker.CheckNameLength( minNameLength ) );
			Assert.IsTrue( InputsChecker.CheckNameLength( maxNameLength ) );
			Assert.IsTrue( InputsChecker.CheckNameLength( midNameLength ) );
			Assert.IsFalse( InputsChecker.CheckNameLength( minNameLengthMinusOne ) );
			Assert.IsFalse( InputsChecker.CheckNameLength( maxNameLengthPlusOne ) );
		}

		[Test]
		public void Check_Description_length()
		{
			// Arrange
			string minLongStringLength = "", maxLongStringLength = "", midLongStringLength = "", /*minLongStringLengthMinusOne= "",*/ maxLongStringLengthPlusOne = "";

			// Act
			for( int i = 0; i < InputsChecker.MinDescriptionLength; i++ ) minLongStringLength += "a";
			for( int i = 0; i < InputsChecker.MaxDescriptionLength; i++ ) maxLongStringLength += "b";
			for( int i = 0; i < InputsChecker.MaxDescriptionLength / 2; i++ ) midLongStringLength += "c";
			/*for( int i = 0; i < (NoMagicHelper.MinDescritptionLength - 1); i++ ) minLongStringLengthMinusOne += "e";*/
			for( int i = 0; i < (InputsChecker.MaxDescriptionLength + 1); i++ ) maxLongStringLengthPlusOne += "f";

			// Assert
			Assert.IsTrue( InputsChecker.CheckDescriptionLength( minLongStringLength ) );
			Assert.IsTrue( InputsChecker.CheckDescriptionLength( maxLongStringLength ) );
			Assert.IsTrue( InputsChecker.CheckDescriptionLength( midLongStringLength ) );
			/*Assert.IsFalse( NoMagicHelper.CheckLongStringLength( minLongStringLengthMinusOne ) );*/
			Assert.IsFalse( InputsChecker.CheckDescriptionLength( maxLongStringLengthPlusOne ) );
		}
		[Test]
		public void Check_Floor_size()
		{
			// Arrange
			int minFloorSize, midFloorSize, maxFloorSize, minSizeMinusOne, maxSizePlusOne;

			// Act
			minFloorSize = InputsChecker.MinFloorSize;
			maxFloorSize = InputsChecker.MaxFloorSize;
			midFloorSize = InputsChecker.MaxFloorSize / 2;
			minSizeMinusOne = InputsChecker.MinFloorSize - 1;
			maxSizePlusOne = InputsChecker.MaxFloorSize + 1;

			// Assert
			Assert.IsTrue( InputsChecker.CheckFloorSize( minFloorSize ) );
			Assert.IsTrue( InputsChecker.CheckFloorSize( maxFloorSize ) );
			Assert.IsTrue( InputsChecker.CheckFloorSize( midFloorSize ) );
			Assert.IsFalse( InputsChecker.CheckFloorSize( minSizeMinusOne ) );
			Assert.IsFalse( InputsChecker.CheckFloorSize( maxSizePlusOne ) );
		}
    }
}
