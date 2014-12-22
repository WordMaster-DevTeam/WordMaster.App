using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public partial class GlobalContext
	{
		/// <summary>
		/// Gets (read only) all the instances of <see cref="DungeonStructure"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<DungeonStructure> Dungeons
		{
			get { return _dungeons; }
		}

		/// <summary>
		/// Gets the number of instance of <see cref="DungeonStructure"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public int NumberOfDungeons
		{
			get { return _dungeons.Count; }
		}

		/// <summary>
		/// Gets an instance of <see cref="DungeonStructure"/> class that are totally empty (one floor, one square, unholdable, no entrance, no exit).
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unisuqe in tjis GlobalContext.</param>
		/// <param name="size">Floor's size of the Floor automatically created within this Dungeon, all Square are </param>
		/// <returns>New Dungeon's reference.</returns>
		public DungeonStructure EmptyDungeon( string name, int size )
		{
			DungeonStructure check;

			if( TryGetDungeon( name, out check ) ) throw new ArgumentException( "A Dungeon with this name already exist.", "name" );
			if( size <= 0 ) throw new ArgumentException( "Floor's size can not be inferior or equal to zero.", "zero" );
			
			DungeonStructure emptyDungeon = new DungeonStructure( this, name, "" );
			emptyDungeon.AddFloor( 0, "", "", size, size );
			emptyDungeon.Entrance = emptyDungeon[0].SetSquare( 0, 0, "", "", true );
			emptyDungeon.Exit = emptyDungeon[0].SetSquare( size - 1, size - 1, "", "", true );
			emptyDungeon[0].SetAllSquares( "", "", false );

			return emptyDungeon;
		}

		/// <summary>
		/// Adds an instance of <see cref="DungeonStructure"/> class in this instance of <see cref="GlobalContext"/> class.
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <returns>The default Dungeon.</returns>
		private DungeonStructure AddDefaultDungeon( string name )
		{
			DungeonStructure check, dungeon;
			FloorStructure floorA, floorB, floorC, floorD, floorE, floorF;

			if( TryGetDungeon( name, out check ) ) throw new ArgumentException( "A Dungeon with this name already exist.", "name" );

			dungeon = this.AddDungeon( name, "The default dungeon." );

			// Level 0
			floorA = dungeon.AddFloor( "The entrance area", "You enter the dungeon and stand near the entrance...", 10, 10 );
			floorA.SetSquare( 1, 1, "Entrance", "A wooden door that crack will you push it.", true );
			floorA.SetSquare( 1, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 1, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 1, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 1, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 1, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 1, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 1, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 2, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 2, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 3, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 3, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 3, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 3, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 4, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 4, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 4, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 4, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 4, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 4, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 5, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 5, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 6, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 6, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 6, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 6, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 6, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 6, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 7, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetSquare( 8, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorA.SetAllUninitializedSquares( "Stone wall", "The stone have endure the passing of time...", false );

			// Level 1
			floorB = dungeon.AddFloor( "The 1st floor", "While you climbing the stair, you feel the air become rarer.", 10, 10 );
			floorB.SetSquare( 1, 1, "Wooden ladder", "Their is an hole here, in the floor's roof...", true );
			floorB.SetSquare( 1, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 1, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 1, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 1, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 1, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 1, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 1, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 2, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 2, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 3, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 4, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 5, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 6, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 6, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 7, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 7, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 7, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 7, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 7, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 8, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetSquare( 8, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorB.SetAllUninitializedSquares( "Stone wall", "The stone have endure the passing of time...", false );

			// Level 2
			floorC = dungeon.AddFloor( "The 2nd floor", "While the ground is still cold, the air is warm.", 10, 10 );
			floorC.SetSquare( 1, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 1, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 1, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 1, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 1, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 1, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 2, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 2, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 2, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 3, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 3, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 3, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 4, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 4, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 4, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 4, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 4, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 5, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 5, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 5, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 6, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 6, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 6, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 6, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 6, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 6, 8, "Iron ladder", "You can safely escape this floor from here.", true );
			floorC.SetSquare( 7, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 7, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 7, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 8, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 8, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 8, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetSquare( 8, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorC.SetAllUninitializedSquares( "Stone wall", "The stone have endure the passing of time...", false );

			// Level 3
			floorD = dungeon.AddFloor( "The 3rd Floor", "Yours feets are now accustomed to the cold.", 10, 10 );
			floorD.SetSquare( 2, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 2, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 2, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 2, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 2, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 3, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 3, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 3, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 4, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 4, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 4, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 4, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 4, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 5, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 5, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 5, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 5, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 5, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 6, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 6, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 7, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 7, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 7, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 8, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 8, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetSquare( 8, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorD.SetAllUninitializedSquares( "Stone wall", "The stone have endure the passing of time...", false );

			// Level 4
			floorE = dungeon.AddFloor( "The 4th floor", "", 10, 10 );
			floorE.SetSquare( 1, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 1, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 1, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 1, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 1, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 1, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 2, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 2, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 2, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 2, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 3, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 4, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 4, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 4, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 4, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 5, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 5, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 6, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 6, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 6, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 6, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 6, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 6, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 7, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 7, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 7, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 7, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetSquare( 8, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorE.SetAllUninitializedSquares( "Stone wall", "The stone have endure the passing of time...", false );

			// Level 5
			floorF = dungeon.AddFloor( "Final area", "The exit is near...", 10, 10 );
			floorF.SetSquare( 1, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 1, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 1, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 1, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 1, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 2, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 2, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 2, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 2, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 2, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 3, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 3, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 3, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 3, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 3, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 3, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 4, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 4, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 4, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 4, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 5, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 5, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 5, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 5, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 5, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 6, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 6, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 6, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 6, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 6, 7, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 6, 8, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 7, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 1, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 2, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 3, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 4, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 5, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 6, "Stone floor", "The stone are cold below yours feets.", true );
			floorF.SetSquare( 8, 8, "Exit", "To leave the dungeon.", true );
			floorF.SetAllUninitializedSquares( "Wooden wall", "The planks have endure the passing of time...", false );

			// Special Squares
			dungeon.Entrance = floorA[1, 1];
			dungeon.Exit = floorF[8, 8];
			floorA[8, 8].SetTeleport( "Old stair", "You are not sure this stair will stand long enough to carry you.", floorB[8, 8], true );
			floorB[1, 1].SetTeleport( "Hole", "Their is an hole here, in the floor's ground...", floorC[1, 1], true );
			floorC[6, 8].SetTeleport( "Iron ladder", "You can safely escape this floor from here.", floorD[6, 8], true );
			floorD[8, 8].SetTeleport( "Wooden ladder", "A sturdy ladder.", floorE[8, 8], true );
			floorE[8, 6].SetTeleport( "Rope", "A rope that lead somewhere else.", floorF[8, 6], true );
			floorA[2, 6].SetTeleport( "Magical teleporter", "An unknow device that could lead you somewhere else", floorF[3, 7], false );
			floorF[2, 8].SetSwitch( "Bulky mechanism", "Their an inscription above the mechanism: \"Activate that you may escape\"", true, false, false, floorF.CreateSquare( 7, 8, "Stone floor", "The stone are cold below yours feets.", true ) );
			floorF[4, 8].SetTrap( "Strange device", "You should not try to touch it, but why not?", false, false, false, false, 20 );

			return dungeon;
		}

		#region Adds Dungeon
		/// <summary>
		/// Adds an instance of <see cref="DungeonStructure"/> class in this instance of <see cref="GlobalContext"/> class.
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Dungeon's description.</param>
		/// <returns>New Dungeon's reference.</returns>
		public DungeonStructure AddDungeon( string name, string description )
		{
			if( CheckDungeon( name ) ) throw new ArgumentException( "A Dungeon with this name already exist.", "name" );

			DungeonStructure dungeon = new DungeonStructure( this, name, description );
			_dungeons.Add( dungeon );
			return dungeon;
		}

		/// <summary>
		/// Adds an instance of <see cref="DungeonStructure"/> class in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Dungeon's description.</param>
		/// <param name="dungeon">Dungeon's reference to recover.</param>
		/// <returns>If the Dungeon have been created and added.</returns>
		public bool TryAddDungeon( string name, string description, out DungeonStructure dungeon )
		{
			try
			{
				dungeon = AddDungeon( name, description );
				return true;
			}
			catch
			{
				dungeon = null;
				return false;
			}
		}
		#endregion

		#region Removes Dungeon
		/// <summary>
		/// Removes an instance <see cref="DungeonStructure"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: Dungeon should not been used in any instance of <see cref="Game"/> class.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <returns>If the Dungeon has been removed.</returns>
		public bool TryRemoveDungeon( DungeonStructure dungeon )
		{
			if( dungeon.Editable )
			{
				_dungeons.Remove( dungeon );
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Removes an instance <see cref="DungeonStructure"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: All <see cref="CharacterBreed"/>'s current <see cref="Game"/> using this Dungeon will be cancelled before removal.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference.</param>
		public void ForceRemoveDungeon( DungeonStructure dungeon )
		{
			foreach( CharacterBreed character in _characters )
				if( character.Dungeon.Equals( dungeon ) )
					CancelGame( character );
			_dungeons.Remove( dungeon );
		}
		#endregion

		#region Renames Dungeon
		/// <summary>
		/// Sets the name of this instance of <see cref="DungeonStructure"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Dungeon must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="dungeon">Dungeon's refernece.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		public void RenameDungeon( DungeonStructure dungeon, string newName )
		{
			DungeonStructure check;

			if( TryGetDungeon( newName, out check ) ) throw new ArgumentException( "A Dungeon with this name already exist.", "name" );

			dungeon.Name = newName;
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="DungeonStructure"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Dungeon must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="oldName">Dungeon's current name.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		public void RenameDungeon( string oldName, string newName )
		{
			DungeonStructure dungeon;

			if( !TryGetDungeon( oldName, out dungeon ) ) throw new ArgumentException( "No Dungeon with this name already exist.", "name" );

			RenameDungeon( dungeon, newName );
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="DungeonStructure"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="dungeon">Dungeon's refernece.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		/// <returns>If the Dungeon have been renamed.</returns>
		public bool TryRenaneDungeon( DungeonStructure dungeon, string newName )
		{
			DungeonStructure check;

			if( TryGetDungeon( newName, out check ) )
			{
				return false;
			}
			else
			{
				dungeon.Name = newName;
				return true;
			}
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="DungeonStructure"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="oldName">Dungeon's current name.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		/// <returns>If the Dungeon have been renamed.</returns>
		public bool TryRenaneDungeon( string oldName, string newName )
		{
			DungeonStructure dungeon;

			if( TryGetDungeon( oldName, out dungeon ) ) return TryRenaneDungeon( dungeon, newName );
			else return false;
		}
		#endregion

		#region Gets and checks Dungeon
		/// <summary>
		/// Gets the reference of the instance of <see cref="DungeonStructure"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name.</param>
		/// <param name="dungeon">Dungeon's reference to recover.</param>
		/// <returns>If the Dungeon have been found.</returns>
		public DungeonStructure GetDungeon( string name )
		{
			foreach( DungeonStructure dungeon in _dungeons )
				if( dungeon.Name == name )
					return dungeon;

			return null;
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="DungeonStructure"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name.</param>
		/// <param name="dungeon">Dungeon's reference to recover.</param>
		/// <returns>If the Dungeon have been found.</returns>
		public bool TryGetDungeon( string name, out DungeonStructure dungeon )
		{
			if( (dungeon = GetDungeon( name )) == null )
				return false;
			else
				return true;
		}

		/// <summary>
		/// Checks if an instance of <see cref="DungeonStructure"/> class with the specified name exists in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name.</param>
		/// <returns>If the Dungeon have been found.</returns>
		public bool CheckDungeon( string name )
		{
			if( GetDungeon( name ) == null ) // No Dungeon with this name exist
				return false;
			else // A Dungeon with this name exist
				return true;
		}
		#endregion
	}
}
