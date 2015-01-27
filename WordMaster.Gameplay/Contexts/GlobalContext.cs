using System;
using System.Collections.Generic;
using WordMaster.Gameplay;

namespace WordMaster.Gameplay
{
	/// <summary>
	/// Global object that contains must of the others Objects used in this application. Serializable.
	/// </summary>
	[Serializable]
	public class GlobalContext
	{
		public readonly Random Random = new Random();
		readonly List<Character> _characters;
		readonly List<DungeonStructure> _dungeons;
		readonly List<Ennemy> _monsters;

		/// <summary>
		/// Initiliazes a new instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="defaultValues">If the default values are added automatically, true by default.</param>
		public GlobalContext()
		{
			_characters = new List<Character>();
			_dungeons = new List<DungeonStructure>();
			_monsters = new List<Ennemy>();

			AddDefaultDungeon();
			AddLevelOneCharacter( "Olivier", "A standard guy without particuliar ambition. Height 1,79 meter with helmet and weight 91 kilograms (with armor)." );
			AddDefaultMonsters();
		}

		#region 1. Characters' related properties
		/// <summary>
		/// Gets (read only) all the instances of <see cref="Character"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Character> Characters
		{
			get { return _characters; }
		}

		/// <summary>
		/// Gets the number of instance of <see cref="Character"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public int NumberOfCharacters
		{
			get { return _characters.Count; }
		}
		#endregion

		#region 2. Dungeons' related properties
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
		#endregion

		#region 3. Monsters' related properties
		/// <summary>
		/// Gets (read only) all the instances of <see cref="Ennemy"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Ennemy> Monsters
		{
			get { return _monsters; }
		}

		/// <summary>
		/// Gets the number of instance of <see cref="Ennemy"/> class initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public int NumberOfMonsters
		{
			get { return _monsters.Count; }
		}
		#endregion

		#region A] Games management methods
		/// <summary>
		/// Creates news instances of <see cref="Game"/> class and <see cref="HistoricRecord"/> classes.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <param name="historicRecord">HistoricRecord's reference to recover</param>
		/// <returns>New GameContext's reference.</returns>
		public GameContext StartNewGame( Character character, DungeonStructure dungeon, out HistoricRecord historicRecord )
		{
			if( dungeon.Finishable ) throw new ArgumentException( "Dungeon's entrance and exit or not set", "dungeon" );

			GameContext gameContext = new GameContext( this, character, dungeon, out historicRecord );
			character.EnterDungeon( gameContext );
			return gameContext;
		}

		/// <summary>
		/// Finishs a <see cref="Game"/>.
		/// The player have used the exit <see cref="SquareStructure"/>.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void FinishGame( Character character )
		{
			character.GameContext.Historic.Finished = true;
			character.LeaveDungeon();
		}

		/// <summary>
		/// Ends a <see cref="Game"/> .
		/// The player who have use the exit function.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void CancelGame( Character character )
		{
			character.GameContext.Historic.Cancelled = true;
			character.LeaveDungeon();
		}
		#endregion

		#region B] Characters management methods
		// Adds Characters
		/// <summary>
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// NOTE: this if for debug.
		/// WARNING: Character's name must be unique.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <returns>A level 1 default Character.</returns>
		public Character AddLevelOneCharacter( string name, string description = "" )
		{
			Character character = new Character( this, name, "A standard guy without particuliar ambition. Height 1,79 meter with helmet and weight 91 kilograms with armor.", 100, 0, 1, 10 );
			_characters.Add( character );
			return character;
		}

		/// <summary>
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// WARNING: Character's name must be unique.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Character's description.</param>
		/// <param name="hp">Character's health.</param>
		/// <param name="xp">Character's experience.</param>
		/// <param name="level">Character's level.</param>
		/// <param name="armor">Character's armor.</param>
		/// <returns>New Character's reference.</returns>
		public Character AddCharacter( string name, string description, int hp, int xp, int level, int armor )
		{
			if( CheckCharacter( name ) ) throw new ArgumentException( "A Character with this name already exist.", "name" );
			if( hp <= 0 ) throw new ArgumentException( "Health Point must be greater than 0." );
			if( xp < 0 ) throw new ArgumentException( "Experience point must be positive." );
			if( level <= 0 ) throw new ArgumentException( "Level must be greater than 0." );
			if( armor <= 0 ) throw new ArgumentException( "Armor must be greater than 0." );

			Character character = new Character( this, name, description, hp, xp, level, armor );
			_characters.Add( character );
			return character;
		}

		/// <summary>
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Character's description.</param>
		/// <param name="hp">Character's health.</param>
		/// <param name="xp">Character's experience.</param>
		/// <param name="level">Character's level.</param>
		/// <param name="armor">Character's armor.</param>
		/// <param name="character">Character's reference to recover.</param>
		/// <returns>If the Character have been created and added.</returns>
		public bool TryAddCharacter( string name, string description, int hp, int xp, int level, int armor, out Character character )
		{
			try
			{
				character = AddCharacter( name, description, hp, xp, level, armor );
				return true;
			}
			catch
			{
				character = null;
				return false;
			}
		}

		/// <summary>
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// NOTE: Character's stats will be set to 100 hp, 0 xp, lvl 1 and 10 armor.
		/// WARNING: Character's name must be unique.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Character's description.</param>
		/// <returns>New Character's reference.</returns>
		public Character AddCharacter( string name, string description )
		{
			return AddCharacter( name, description, 100, 0, 1, 10 );
		}

		/// <summary>
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// NOTE: Character's stats will be set to 100 hp, 0 xp, lvl 1 and 10 armor.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Character's description.</param>
		/// <param name="character">Character's reference to recover.</param>
		/// <returns>If the Character have been created and added.</returns>
		public bool TryAddCharacter( string name, string description, out Character character )
		{
			try
			{
				character = AddCharacter( name, description );
				return true;
			}
			catch
			{
				character = null;
				return false;
			}
		}

		// Removes Characters
		/// <summary>
		/// Removes an instance of <see cref="Character"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: Character must not been used in any instance of <see cref="Game"/> class.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <returns>If the Character has been removed.</returns>
		public bool TryRemoveCharacter( Character character )
		{
			if( character.GameContext != null ) // No Game have ongoing with this Character
			{
				_characters.Remove( character );
				return true;
			}
			else // Can not remove this because a Game is ongoing with this Character
			{
				return false;
			}
		}

		/// <summary>
		/// Removes an instance of <see cref="Character"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: Character's current <see cref="Game"/> will be cancelled before removal.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void ForceRemoveCharacter( Character character )
		{
			if( character.GameContext != null )
				CancelGame( character );
			_characters.Remove( character );
		}

		// Renames Characters
		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Character must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="character">Character's refernece.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		public void RenameCharacter( Character character, string newName )
		{
			if( CheckCharacter( newName ) ) throw new ArgumentException( "A Character with this name already exist.", "newName" );

			character.Name = newName;
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		/// <returns>If the Character have been renamed.</returns>
		public bool TryRenaneCharacter( Character character, string newName )
		{
			try
			{
				RenameCharacter( character, newName );
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Character must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="currentName">Character's current name.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		public void RenameCharacter( string currentName, string newName )
		{
			Character character;

			if( !TryGetCharacter( currentName, out character ) ) throw new ArgumentException( "No Character with this name already exist.", "name" );

			RenameCharacter( character, newName );
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="currentName">Character's current name.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		/// <returns>If the Character have been renamed.</returns>
		public bool TryRenaneCharacter( string currentName, string newName )
		{
			try
			{
				RenameCharacter( currentName, newName );
				return true;
			}
			catch
			{
				return false;
			}
		}

		// Gets Characters
		/// <summary>
		/// Gets the reference of the instance of <see cref="Character"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name.</param>
		/// <returns>Character's reference, if found.</returns>
		public Character GetCharacter( string name )
		{
			foreach( Character character in _characters )
				if( character.Name == name )
					return character;

			return null; // No Character with this name found
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Character"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name.</param>
		/// <param name="dungeon">Character's reference to recover.</param>
		/// <returns>If the Character have been found.</returns>
		public bool TryGetCharacter( string name, out Character character )
		{
			if( (character = GetCharacter( name )) == null ) // No Character with this name exist
				return false;
			else // A Character with this name exist
				return true;
		}

		// Checks Characters
		/// <summary>
		/// Checks if an instance of <see cref="Character"/> class with the specified name exists in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name.</param>
		/// <returns>If the Character have been found.</returns>
		public bool CheckCharacter( string name )
		{
			if( GetCharacter( name ) == null ) // No Character with this name exist
				return false;
			else // A Character with this name exist
				return true;
		}
		#endregion

		#region C] Dungeons management methods
		// Adds Dungeons
		/// <summary>
		/// Gets an instance of <see cref="DungeonStructure"/> class that are totally empty (one floor).
		/// WARNING: size must be superior or equal to 2.
		/// </summary>
		/// <param name="size">Floor's size of the Floor automatically created within this Dungeon, all Square are </param>
		/// <returns>New Dungeon's reference.</returns>
		public DungeonStructure AddEmptyDungeon( int size )
		{
			if( size <= 2 ) throw new ArgumentException( "Floor's size can not be inferior or equal to zero.", "zero" );

			DungeonStructure emptyDungeon = new DungeonStructure( this, new Guid().ToString(), "" );
			emptyDungeon.AddFloor( 0, "", "", size, size );
			emptyDungeon.Entrance = emptyDungeon[0].SetSquare( 0, 0, "", "", true );
			emptyDungeon.Exit = emptyDungeon[0].SetSquare( size - 1, size - 1, "", "", true );
			emptyDungeon[0].SetAllSquares( "", "", true );

			return emptyDungeon;
		}

		/// <summary>
		/// Adds an instance of <see cref="DungeonStructure"/> class in this instance of <see cref="GlobalContext"/> class.
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <returns>The default Dungeon.</returns>
		private DungeonStructure AddDefaultDungeon( )
		{
			DungeonStructure dungeon = this.AddDungeon( "Tutorial", "The first Dungeon to crawl." );
			FloorStructure floorA, floorB, floorC, floorD, floorE, floorF;

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
			floorF[2, 8].SetSwitch( "Bulky mechanism", "Their an inscription above the mechanism: \"Activate that you may escape\"", true, false, floorF.CreateSquare( 7, 8, "Stone floor", "The stone are cold below yours feets.", true ) );
			floorF[4, 8].SetTrap( "Strange device", "You should not try to touch it, but why not?", false, false, false, 20 );

			// Monsters appearance
			foreach( FloorStructure floorStructure in dungeon.AllFloorStructures )
				floorStructure.SetMonsterAppearance( (int)Math.Min( floorStructure.Level * 3, 100 ), 1, 100 );

			return dungeon;
		}

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

		// Removes Dungeons
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
		/// NOTE: All <see cref="Character"/>'s current <see cref="Game"/> using this Dungeon will be cancelled before removal.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference.</param>
		public void ForceRemoveDungeon( DungeonStructure dungeon )
		{
			foreach( Character character in _characters )
				if( character.Dungeon.Equals( dungeon ) )
					CancelGame( character );
			_dungeons.Remove( dungeon );
		}

		// Renames Dungeons
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
		/// </summary>
		/// <param name="dungeon">Dungeon's refernece.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		/// <returns>If the Dungeon have been renamed.</returns>
		public bool TryRenaneDungeon( DungeonStructure dungeon, string newName )
		{
			try
			{
				RenameDungeon( dungeon, newName );
				return true;
			}
			catch
			{
				return false;
			}
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
		/// <param name="oldName">Dungeon's current name.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		/// <returns>If the Dungeon have been renamed.</returns>
		public bool TryRenaneDungeon( string oldName, string newName )
		{
			try
			{
				RenameDungeon( oldName, newName );
				return true;
			}
			catch
			{
				return false;
			}
		}

		// Gets Dungeons
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

		// Checks Dungeons
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

		#region D] Monsters management methods
		/// <summary>
		/// Adds 3 defaults <see cref="Ennemies"/> type.
		/// </summary>
		private void AddDefaultMonsters()
		{
			AddLevyMonster( "Levy Trainer", "Easy", "You ... angry", new Dictionary<int, string> { { 1, "are" } }, 1 );
			AddVeteranMonster( "Veteran Trainer", "Medium", "You ... be here. There is ... .", new Dictionary<int, string> { { 1, "shouldn't" }, { 2, "dangers" } }, 1, 2 );
			AddEliteMonster( "Elite Trainer", "Hard", "You ... go, you ... see, you ... act", new Dictionary<int, string> { { 1, "will" } }, 1, 1, 1 );
		}
		

		// Adds Monsters
		/// <summary>
		/// Adds a <see cref="Levy"/> to the pool of <see cref="Ennemy"/>s.
		/// </summary>
		/// <param name="name"><see cref="Levy"/>'s name.</param>
		/// <param name="description"><see cref="Levy"/>'s description.</param>
		/// <param name="sentance">Sentance displayed for the combat system.</param>
		/// <param name="possibleAnswers">Answers to choose from.</param>
		/// <param name="correctAnswers">Correct answer.</param>
		/// <returns>The new <see cref="Levy"/>'s reference.</returns>
		public Levy AddLevyMonster(string name, string description, string sentance, Dictionary<int, string> possibleAnswers, int correctAnswers)
		{
			Levy levy = new Levy(this, name, description, 10, 10, 1, 5, sentance, possibleAnswers, correctAnswers);
			_monsters.Add(levy);
			return levy;
		}

		/// <summary>
		/// Adds a <see cref="Veteran"/> to the pool of <see cref="Ennemy"/>s.
		/// </summary>
		/// <param name="name"><see cref="Veteran"/>'s name.</param>
		/// <param name="description"><see cref="Veteran"/>'s description.</param>
		/// <param name="sentance">Sentance displayed for the combat system.</param>
		/// <param name="possibleAnswers">Answers to choose from.</param>
		/// <param name="firstCorrectAnswer">First correct answer.</param>
		/// <param name="secondCorrectAnswer">Second correct answer.</param>
		/// <returns>The new <see cref="Veteran"/>'s reference.</returns>
		public Veteran AddVeteranMonster(string name, string description, string sentance, Dictionary<int, string> possibleAnswers, int firstCorrectAnswer, int secondCorrectAnswer)
		{
			Veteran veteran = new Veteran(this, name, description, 20, 20, 5, 10, sentance, possibleAnswers, firstCorrectAnswer, secondCorrectAnswer);
			_monsters.Add(veteran);
			return veteran;
		}

		/// <summary>
		/// Adds a <see cref="Elite"/> to the pool of <see cref="Ennemy"/>.
		/// </summary>
		/// <param name="name"><see cref="Elite"/>'s name.</param>
		/// <param name="description"><see cref="Elite"/>'s description.</param>
		/// <param name="sentance">Sentance displayed for the combat system.</param>
		/// <param name="possibleAnswers">Answers to choose from.</param>
		/// <param name="firstCorrectAnswer">First correct anwser.</param>
		/// <param name="secondCorrectAnswers">Second correct answer.</param>
		/// <param name="thirdCorrectAnswer">Third correct answer.</param>
		/// <returns>The new <see cref="Elite"/>'s reference.</returns>
		public Elite AddEliteMonster(string name, string description, string sentance, Dictionary<int, string> possibleAnswers, int firstCorrectAnswer, int secondCorrectAnswers, int thirdCorrectAnswer)
		{
			Elite elite = new Elite(this, name,  description, 30, 30, 10, 20, sentance, possibleAnswers, firstCorrectAnswer, secondCorrectAnswers, thirdCorrectAnswer);
			_monsters.Add(elite);
			return elite;
		}

		// Gets Monsters
		/// <summary>
		/// Gets a <see cref="Monster"/> by his name.
		/// </summary>
		/// <param name="name"><see cref="Monster"/>'s current name.</param>
		/// <returns>The <see cref="Monster"/>'s reference.</returns>
		public Ennemy GetMonster( string name )
		{
			foreach( Ennemy monster in _monsters )
				if( monster.Name == name )
					return monster;

			return null;
		}

		/// <summary>
		/// Gets a <see cref="Monster"/> by his name.
		/// </summary>
		/// <param name="name"><see cref="Monster"/>'s current name.</param>
		/// <param name="monster"><see cref="Monster"/>'s reference.</param>
		/// <returns>If a <see cref="Monster"/> have been found.</returns>
		public bool TryGetMonster( string name, out Ennemy monster )
		{
			try
			{
				monster = GetMonster( name );
				return true;
			}
			catch
			{
				monster = null;
				return false;
			}
		}

		// Check Monsters
		/// <summary>
		/// Checks if an instance of <see cref="Ennemy"/> exist in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name"><see cref="Ennemy"/>'s name.</param>
		/// <returns>If the <see cref="Ennemy"/> have been found.</returns>
		public bool CheckMonster( string name )
		{
			foreach( Ennemy monster in _monsters )
				if( monster.Name == name )
					return true;
			return false;
		}
		#endregion
	}
}
