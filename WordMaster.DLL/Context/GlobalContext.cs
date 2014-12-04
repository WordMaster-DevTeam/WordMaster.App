using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public class GlobalContext
	{
		readonly List<Character> _characters;
		readonly List<Dungeon> _dungeons;

		/// <summary>
		/// Initiliazes a new instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public GlobalContext()
		{
			_characters = new List<Character>();
			_dungeons = new List<Dungeon>();
		}

		/// <summary>
		/// Gets all the instances of <see cref="Character"/> initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Character> Characters
		{
			get { return _characters; }
		}

		/// <summary>
		/// Gets all the instances of <see cref="Dungeon"/> initialized in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public IEnumerable<Dungeon> Dungeons
		{
			get { return _dungeons; }
		}

		#region Character's management methods
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
			Character check, character;

			if( TryGetCharacter( name, out check ) ) throw new ArgumentException("A Character with this name already exist.", "name");
			if( hp <= 0 ) throw new ArgumentException( "Health Point must be greater than 0." );
			if( xp < 0 ) throw new ArgumentException( "Experience point must be positive." );
			if( level <= 0 ) throw new ArgumentException( "Level must be greater than 0." );
			if( armor <= 0 ) throw new ArgumentException( "Armor must be greater than 0." );

			character = new Character( name, description, hp, xp, level, armor );
			_characters.Add( character );
			return character;
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
		/// NOTE: this if for debug.
		/// WARNING: Character's name must be unique.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <returns>A "level 5" Character.</returns>
		public Character AddDefaultCharacter( string name )
		{
			Character check, character;

			if(TryGetCharacter(name, out check) ) throw new ArgumentException( "A Floor with this name already exist.", "name" );

			character = new Character( name, "Default Character.", 200, 1000, 5, 150 );
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
			Character check;
			if( TryGetCharacter( name, out check ) || hp <= 0 || xp < 0 || level <= 0 || armor <= 0 )
			{
				character = null;
				return false;
			}
			else
			{
				character = new Character( name, description, hp, xp, level, armor );
				return true;
			}
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
			return TryAddCharacter( name, description, 100, 0, 1, 10, out character );
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Character must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="character">Character's refernece.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		public void RenameCharacter( Character character, string newName )
		{
			Character check;

			if( TryGetCharacter( newName, out check ) ) throw new ArgumentException( "A Character with this name already exist.", "name" );

			character.Name = newName;
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Character must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="oldName">Character's current name.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		public void RenameCharacter( string oldName, string newName )
		{
			Character character;

			if( TryGetCharacter( oldName, out character ) ) throw new ArgumentException( "No Character with this name already exist.", "name" );

			RenameCharacter( character, newName );
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="character">Character's refernece.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		/// <returns>If the Character have been renamed.</returns>
		public bool TryRenaneCharacter( Character character, string newName)
		{
			Character check;

			if( TryGetCharacter( newName, out check ) )
			{
				return false;
			}
			else 
			{
				character.Name = newName;
				return true;
			}
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Character"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="oldName">Character's current name.</param>
		/// <param name="newName">Charcter's new name, must be unique.</param>
		/// <returns>If the Character have been renamed.</returns>
		public bool TryRenaneCharacter( string oldName, string newName )
		{
			Character character;

			if( TryGetCharacter( oldName, out character ) ) return TryRenaneCharacter( character, newName );
			else return false;
		}

		/// <summary>
		/// Removes an instance of <see cref="Character"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: Character must not been used in any instance of <see cref="Game"/> class.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <returns>If the Character has been removed.</returns>
		public bool TryRemoveCharacter( Character character )
		{
			if( character.Game != null )
			{
				return false;
			}
			else
			{
				_characters.Remove( character );
				return true;
			}	
		}

		/// <summary>
		/// Removes an instance of <see cref="Character"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: Character's current <see cref="Game"/> will be cancelled before removal.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void ForceRemoveCharacter( Character character )
		{
			if (character.Game != null ) EndGame( character);
			_characters.Remove( character );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Character"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Character's name.</param>
		/// <param name="dungeon">Character's reference to recover.</param>
		/// <returns>If the Character have been found.</returns>
		public bool TryGetCharacter( string name, out Character character )
		{
			foreach( Character aCharacter in _characters )
			{
				if( aCharacter.Name == name )
				{
					character = aCharacter;
					return true;
				}
			}
			character = null;
			return false;
		}
		#endregion

		#region Dungeon's management methods
		/// <summary>
		/// Adds an instance of <see cref="Dungeon"/> class in this instance of <see cref="GlobalContext"/> class.
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Dungeon's description.</param>
		/// <returns>New Dungeon's reference.</returns>
		public Dungeon AddDungeon( string name, string description )
		{
			Dungeon check, dungeon;

			if( TryGetDungeon( name, out check ) ) throw new ArgumentException("A Floor with this name already exist.", "name");
			
			dungeon = new Dungeon( this, name, description );
			_dungeons.Add( dungeon );
			return dungeon;
		}

		/// <summary>
		/// Adds an instance of <see cref="Dungeon"/> class in this instance of <see cref="GlobalContext"/> class.
		/// NOTE: this if for debug.
		/// WARNING: Dungeon's name must be unique.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <returns>A Dungeon of 3 <see cref="Floor"/> of 3*3 <see cref="Square"/>s each.</returns>
		public Dungeon AddDefaultDungeon(string name)
		{
			Dungeon check, dungeon;
			Floor floorA, floorB, floorC;
			Square goAtoB, goBtoC, goCtoB;

			if( TryGetDungeon( name, out check ) ) throw new ArgumentException( "A Floor with this name already exist.", "name" );

			dungeon = this.AddDungeon( name, "Default Dungeon." );

			// Level 0
			floorA = dungeon.AddFloor( "The Entrance Area", "You enter the dungeon and stand near the entrance...", 3, 3  );
			dungeon.Entrance = floorA.SetSquare( 1, 0, "Entrance", "A wooden door that crack will you push it.", true, null );
			floorA.SetSquare( 1, 1, "Wooden Floor", "The planks have begin to decay long ago.", true, null );
			goAtoB = floorA.SetSquare( 1, 2, "Wooden Stair", "You are not sure this stair will stand long enough to carry you.", true, null );
			floorA.SetAllUninitializedSquares( "Wooden wall", "The planks have endure the passing of time...", false );
			
			// Level 1
			floorB = dungeon.AddFloor( "The 1st Floor", "While you climbing the stair, you feel the end is near.", 3, 3 );
			goAtoB.TeleportTo = floorB.SetSquare( 1, 2, "Destroyed Wooden Stair", "You can not go back.", true, null );
			floorB.SetSquare(2, 1, "Wooden Floor", "The planks have begin to decay long ago.", true, null );
			goBtoC = floorB.SetSquare(1, 1, "Hole", "Their is an hole here, in the floor's roof...", true, null );
			floorB.SetAllUninitializedSquares( "Wooden wall", "The planks have endure the passing of time...", false );

			// Level 2
			floorC = dungeon.AddFloor( "The Roof", "You can feel the cold air of the sea.", 3, 3 );
			goCtoB = floorC.SetSquare( 1, 1, "Hole", "Their is an hole here, in the floor's roof...", true, goBtoC );
			goBtoC.TeleportTo = goCtoB;
			goCtoB.TeleportTo = goBtoC;
			floorC.SetSquare( 0, 1, "Wooden Floor", "The planks have begin to decay long ago.", true, null );
			dungeon.Exit = floorC.SetSquare(0, 2, "Iron ladder", "You can safely escape using this.", true, null );
			floorC.SetAllUninitializedSquares( "Wooden wall", "The planks have endure the passing of time...", false );

			return dungeon;
		}

		/// <summary>
		/// Adds an instance of <see cref="Dungeon"/> class in this instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name, must be unique in this GlobalContext.</param>
		/// <param name="description">Dungeon's description.</param>
		/// <param name="dungeon">Dungeon's reference to recover.</param>
		/// <returns>If the Dungeon have been created and added.</returns>
		public bool TryAddDungeon( string name, string description, out Dungeon dungeon )
		{
			Dungeon check;

			if( TryGetDungeon( name, out check ) )
			{
				dungeon = null;
				return false;
			}
			else
			{
				dungeon = new Dungeon( this, name, description );
				_dungeons.Add( dungeon );
				return true;
			}
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Dungeon"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Dungeon must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="dungeon">Dungeon's refernece.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		public void RenameDungeon( Dungeon dungeon, string newName )
		{
			Dungeon check;

			if( TryGetDungeon( newName, out check ) ) throw new ArgumentException( "A Dungeon with this name already exist.", "name" );

			dungeon.Name = newName;
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Dungeon"/> int his instance of <see cref="GlobalContext"/>.
		/// WARNING: The Dungeon must already exist and the nex name must not already must be used.
		/// </summary>
		/// <param name="oldName">Dungeon's current name.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		public void RenameDungeon( string oldName, string newName )
		{
			Dungeon dungeon;

			if( !TryGetDungeon( oldName, out dungeon ) ) throw new ArgumentException( "No Dungeon with this name already exist.", "name" );

			RenameDungeon( dungeon, newName );
		}

		/// <summary>
		/// Sets the name of this instance of <see cref="Dungeon"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="dungeon">Dungeon's refernece.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		/// <returns>If the Dungeon have been renamed.</returns>
		public bool TryRenaneDungeon( Dungeon dungeon, string newName )
		{
			Dungeon check;

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
		/// Sets the name of this instance of <see cref="Dungeon"/> int his instance of <see cref="GlobalContext"/>.
		/// </summary>
		/// <param name="oldName">Dungeon's current name.</param>
		/// <param name="newName">Dungeon's new name, must be unique.</param>
		/// <returns>If the Dungeon have been renamed.</returns>
		public bool TryRenaneDungeon( string oldName, string newName )
		{
			Dungeon dungeon;

			if( TryGetDungeon( oldName, out dungeon ) ) return TryRenaneDungeon( dungeon, newName );
			else return false;
		}

		/// <summary>
		/// Removes an instance <see cref="Dungeon"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: Dungeon should not been used in any instance of <see cref="Game"/> class.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <returns>If the Dungeon has been removed.</returns>
		public bool TryRemoveDungeon( Dungeon dungeon )
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
		/// Removes an instance <see cref="Dungeon"/> class from this instance of <see cref="GlobalContext"/>.
		/// NOTE: All <see cref="Character"/>'s current <see cref="Game"/> using this Dungeon will be cancelled before removal.
		/// </summary>
		/// <param name="dungeon">Dungeon's reference.</param>
		public void ForceRemoveDungeon( Dungeon dungeon )
		{
			foreach( Character character in _characters )
				if( character.Dungeon.Equals( dungeon ) )
					EndGame( character );
			_dungeons.Remove( dungeon );
		}

		/// <summary>
		/// Gets the reference of the instance of <see cref="Dungeon"/> class in the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		/// <param name="name">Dungeon's name.</param>
		/// <param name="dungeon">Dungeon's reference to recover.</param>
		/// <returns>If the Dungeon have been found.</returns>
		public bool TryGetDungeon( string name, out Dungeon dungeon )
		{
			foreach( Dungeon aDungeon in _dungeons )
			{
				if( aDungeon.Name == name )
				{
					dungeon = aDungeon;
					return true;
				}
			}
			dungeon = null;
			return false;
		}
		#endregion

		#region Game's management methods
		/// <summary>
		/// Creates news instances of <see cref="Game"/> class and <see cref="HistoricRecord"/> classes.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		/// <param name="dungeon">Dungeon's reference.</param>
		/// <returns>New Game's reference.</returns>
		public Game StartNewGame( Character character, Dungeon dungeon)
		{
			if( dungeon.Entrance == null || dungeon.Exit == null ) throw new ArgumentException( "Dungeon's entrance and exit or not set", "dungeon" );

			HistoricRecord record;
			Game game = new Game( character, dungeon, out record );
			character.EnterDungeon( dungeon , game, record );

			return game;
		}

		/// <summary>
		/// Finishs a <see cref="Game"/>.
		/// The player have used the exit <see cref="Square"/>.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void FinishGame( Character character )
		{
			character.Game.Historic.Finished = true;
			character.LeaveDungeon();
		}

		/// <summary>
		/// Ends a <see cref="Game"/> .
		/// The player who have use the exit function.
		/// </summary>
		/// <param name="character">Character's reference.</param>
		public void EndGame( Character character )
		{
			character.Game.Historic.Cancelled = true;
			character.LeaveDungeon();
		}
		#endregion
	}
}
