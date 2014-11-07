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
    public class NoMagicHelperTests
    {
		[Test]
		public void Name_with_correct_length_returns_true()
		{
			string minLengthName = "";
			string maxlengthName = "";
			int i = 0;

			for( i = 0; i < NoMagicHelper.MinLengthName; i++ ) minLengthName += "a";
			for( i = 0; i < NoMagicHelper.MaxLengthName; i++ ) maxlengthName += "b";

			Console.WriteLine( "Min value tested: " + minLengthName.Length );
			Console.WriteLine( "Max value tested: " + maxlengthName.Length );
			Assert.IsTrue( NoMagicHelper.CheckLengthName( minLengthName ) );
			Assert.IsTrue( NoMagicHelper.CheckLengthName( maxlengthName ) );
		}

		[Test]
		public void Name_with_Incorrect_length_returns_false()
		{
			string minLengthMinusOneName = "";
			string maxlengthPlusOneName = "";
			int i = 0;

			for( i = 0; i < (NoMagicHelper.MinLengthName - 1); i++ ) minLengthMinusOneName += "c";
			for( i = 0; i < (NoMagicHelper.MaxLengthName + 1); i++ ) maxlengthPlusOneName += "d";

			Console.WriteLine( "Min value tested: " + minLengthMinusOneName.Length );
			Console.WriteLine( "Max value tested: " + maxlengthPlusOneName.Length );
			Assert.IsFalse( NoMagicHelper.CheckLengthName( minLengthMinusOneName ) );
			Assert.IsFalse( NoMagicHelper.CheckLengthName( maxlengthPlusOneName ) );
		}
    }
}
