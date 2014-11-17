using System;
using NUnit.Framework;
using WordMaster.DLL;

namespace WordMaster.UniTests
{
	[TestFixture]
    public class NoMagicHelperTests
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

		[Test]
		public void Check_short_string_length()
		{
			string minShortStringLength = "", maxShortStringLength = "", midShortStringLength = "", /*minShortStringLengthMinusOne= "",*/ maxShortStringLengthPlusOne = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinShortStringLength; i++ ) minShortStringLength += "a";
			for( int i = 0; i < NoMagicHelper.MaxShortStringLength; i++ ) maxShortStringLength += "b";
			for( int i = 0; i < NoMagicHelper.MaxShortStringLength / 2; i++ ) midShortStringLength += "c";
			/*for( int i = 0; i < (NoMagicHelper.MinShortStringLength - 1); i++ ) minShortStringLengthMinusOne += "e";*/
			for( int i = 0; i < (NoMagicHelper.MaxShortStringLength + 1); i++ ) maxShortStringLengthPlusOne += "f";

			// Assert
			Assert.IsTrue( NoMagicHelper.CheckShortStringLength( minShortStringLength ) );
			Assert.IsTrue( NoMagicHelper.CheckShortStringLength( maxShortStringLength ) );
			Assert.IsTrue( NoMagicHelper.CheckShortStringLength( midShortStringLength ) );
			/*Assert.IsFalse( NoMagicHelper.CheckShortStringLength( minShortStringLengthMinusOne ) );*/
			Assert.IsFalse( NoMagicHelper.CheckShortStringLength( maxShortStringLengthPlusOne ) );
		}

		[Test]
		public void Check_Long_string_length()
		{
			// Arrange
			string minLongStringLength = "", maxLongStringLength = "", midLongStringLength = "", /*minLongStringLengthMinusOne= "",*/ maxLongStringLengthPlusOne = "";

			// Act
			for( int i = 0; i < NoMagicHelper.MinLongStringLength; i++ ) minLongStringLength += "a";
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength; i++ ) maxLongStringLength += "b";
			for( int i = 0; i < NoMagicHelper.MaxLongStringLength / 2; i++ ) midLongStringLength += "c";
			/*for( int i = 0; i < (NoMagicHelper.MinLongStringLength - 1); i++ ) minLongStringLengthMinusOne += "e";*/
			for( int i = 0; i < (NoMagicHelper.MaxLongStringLength + 1); i++ ) maxLongStringLengthPlusOne += "f";

			// Assert
			Assert.IsTrue( NoMagicHelper.CheckLongStringLength( minLongStringLength ) );
			Assert.IsTrue( NoMagicHelper.CheckLongStringLength( maxLongStringLength ) );
			Assert.IsTrue( NoMagicHelper.CheckLongStringLength( midLongStringLength ) );
			/*Assert.IsFalse( NoMagicHelper.CheckLongStringLength( minLongStringLengthMinusOne ) );*/
			Assert.IsFalse( NoMagicHelper.CheckLongStringLength( maxLongStringLengthPlusOne ) );
		}
    }
}
