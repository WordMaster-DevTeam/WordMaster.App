using System;

namespace WordMaster.Gameplay
{
	[Serializable]
	internal class Monster
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="gameContext"></param>
		/// <param name="floor"></param>
		internal Monster( GameContext gameContext, FloorStructure floor )
		{
			if( gameContext.GlobalContext.NumberOfMonsters == 0 ) throw new InvalidOperationException( "No Monster set." );
			if( !floor.CheckAllSquares() ) throw new InvalidOperationException( "All Squares must be set." );

			for( int i = 0; i < floor.NumberOfLines; i++ )
			{
				for( int j = 0; j < floor.NumberOfColumns; j++ )
				{
					SquareStructure square = floor[i, j];
					int value = gameContext.GlobalContext.Random.Next( 100 );

					if( square.Holdable )
					{
						// ...
					}
				}
			}
		}


	}
}
