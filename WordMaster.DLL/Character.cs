using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster.DLL
{
    public class Character
    {
        #region Attributes
        readonly string _name;
        readonly string _description;
        uint _hp;
        uint _xp;
        uint _level;
        List<Equipment> _inventory;
        uint _armor;
        int _posX;
        int _posY;
        #endregion

        #region Getters and setters
        public string Name
        {
            get { return _name; }
        }

        public string Descritption
        {
            get { return _description; }
        }

        public uint Health
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public uint Experience
        {
            get { return _xp; }
            set { _xp = value; }
        }

        public uint Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public uint Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        #endregion

        /// <summary>
        /// Initialize a new instance of <see cref="Character"/>, base massive builder.
        /// </summary>
        /// <param name="name">Can't be empty or null.</param>
        /// <param name="descript">CAN be empty but not null.</param>
        /// <param name="hp">Must be greater than 0.</param>
        /// <param name="xp">Must be equal or greater than 0.</param>
        /// <param name="lvl">Must be greater than 0.</param>
        /// <param name="invent">Can't be null.</param>
        /// <param name="armor">Must be greater than 0.</param>
        /// <param name="posX">Can't be null.</param>
        /// <param name="posY">Can't be null.</param>
        public Character(string name, string descript, uint hp, uint xp, uint lvl, List<Equipment> invent, uint armor, int posX, int posY)
        {
            #region Exception management
            if (name == "" || name == null) throw new ArgumentException("Name can't be empty or null.");
            if (descript == null) throw new ArgumentException("Description can't be null");
            if (hp <= 0) throw new ArgumentException("Health Point must be greater than 0.");
            if (xp < 0) throw new ArgumentException("Expérience point can't be negative.");
            if (lvl <= 0) throw new ArgumentException("Level must be greater than 0.");
            if (invent == null) throw new ArgumentException("Inventory can't be null.");
            if (armor <= 0) throw new ArgumentException("Armor must be greater than 0.");
            if (posX == null) throw new ArgumentException("Postion X can't be null.");
            if (posY == null) throw new ArgumentException("Position Y can't be null");
            #endregion

            #region Assignation
            _name = name;
            _description = descript;
            _hp = hp;
            _xp = xp;
            _inventory = invent;
            _armor = armor;
            _posX = posX;
            _posY = posY;
            #endregion
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Character"/> class.
        /// </summary>
        /// <param name="name">Can't be empty or null.</param>
        /// <param name="descript">CAN be empty but not null.</param>
        /// <param name="invent">Can't be null.</param>
        /// <param name="posX">Can't be null.</param>
        /// <param name="posY">Can't be null.</param>
        public Character(string name, string descript, List<Equipment> invent, int posX, int posY): this(name, descript, 100, 0, 1, invent,10, posX, posY)
        {
        }

        /// <summary>
        /// Move <see cref="Character"/> to a different square.
        /// </summary>
        /// <param name="posX">Can't be null.</param>
        /// <param name="posY">Can't be null.</param>
        public void Move(int posX, int posY)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Make the Character attack.
        /// </summary>
        public void Attack()
        {
            throw new NotImplementedException();
        }

    }
}
