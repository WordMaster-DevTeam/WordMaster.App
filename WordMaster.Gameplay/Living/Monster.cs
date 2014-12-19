using System;
using System.Collections.Generic;

namespace WordMaster.Gameplay
{
	public class Monster
	{
		readonly GlobalContext _globalContext;
		string _name, _description;
		int _maxHealth, _health, _experience, _level, _armor;
		readonly List<Item> _inventory;

		/// <summary>
		/// Initializes a new instance of <see cref="Monster"/> class.
		/// </summary>
		/// <param name="name">Monster's name.</param>
		/// <param name="description">Monster's description.</param>
		/// <param name="health">Monster's health.</param>
		/// <param name="experience">Monsters's experience, gained by a <see cref="Character"/> when slayed.</param>
		/// <param name="level">Monster's level, used when a <see cref="Floor"/> is filled.</param>
		/// <param name="armor">Monster's armor.</param>
		/// <param name="inventory">Monster's inventory.</param>
		internal Monster( GlobalContext globalContext, string name, string description, int health, int experience, int level, int armor )
		{
			_globalContext = globalContext;
			_name = name;
			_description = description;
			_maxHealth = health;
			_health = health;
			_experience = experience;
			_level = level;
			_armor = armor;
			_inventory = new List<Item>();
		}

		/// <summary>
		/// Gets the current instance of <see cref="GlobalContext"/> class.
		/// </summary>
		public GlobalContext GlobalContext
		{
			get { return _globalContext; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Monster"/>'s name.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Monster"/>'s description.
		/// </summary>
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the <see cref="Monster"/>'s maximum health points.
		/// </summary>
		public int MaxHealth
		{
			get { return _maxHealth; }
			internal set { _maxHealth = value; }
		}

		/// <summary>
		/// Gets or sets (this DLL only) the <see cref="Monster"/>'s health points.
		/// </summary>
		public int Health
		{
			get { return _health; }
			internal set { _health = value; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Monster"/>'s experience points, gained by a <see cref="Character"/> when slayed.
		/// </summary>
		public int Experience
		{
			get { return _experience; }
			set { _experience = value; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Monster"/>'s level.
		/// </summary>
		public int level
		{
			get { return _level; }
			set { _level = value; }
		}

		/// <summary>
		/// Gets or sets the <see cref="Monster"/>'s armor value.
		/// </summary>
		public int Armor
		{
			get { return _armor; }
			set { _armor = value; }
		}

		/// <summary>
		/// Gets if this <see cref="Monster"/> is alive.
		/// </summary>
		public bool Alive
		{
			get { return _health > 0; }
		}

		/// <summary>
		/// Get if this <see cref="Monster"/> is dead.
		/// </summary>
		public bool Dead
		{
			get { return _health <= 0; }
		}

		/// <summary>
		/// Gets the list (read only) of <see cref="Item"/>s this <see cref="Monster"/> holds.
		/// </summary>
		public IEnumerable<Item> Inventory
		{
			get { return _inventory; }
		}
	}
}
