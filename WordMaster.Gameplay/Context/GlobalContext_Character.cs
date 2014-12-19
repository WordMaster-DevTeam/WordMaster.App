using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public partial class GlobalContext
	{
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

		/// <summary>
		/// Adds an instance of <see cref="Character"/> class in this instance of <see cref="GlobalContext"/> class.
		/// NOTE: this if for debug.
		/// WARNING: Character's name must be unique.
		/// </summary>
		/// <param name="name">Character's name, must be unique in this GlobalContext.</param>
		/// <returns>A "level 5" Character.</returns>
		internal Character AddDefaultCharacter( string name )
		{
			Character character = new Character( this, name, "A standard guy without particuliar ambition. Height 1,79 meter with helmet and weight 91 kilograms with armor.", 100, 0, 1, 10 );
			_characters.Add( character );
			return character;
		}

		#region Adds Character
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
		#endregion

		#region Removes Character
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
		#endregion

		#region Renames Character
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
		#endregion

		#region Gets and checks Character
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
	}
}
