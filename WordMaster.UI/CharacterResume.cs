using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.DLL;

namespace WordMaster.UI
{
    public partial class CharacterResume : UserControl
    {
        public string name { get; set; }

        public int level { get; set; }

        public int health { get; set; }

        public string dungeon { get; set; }

        public CharacterResume()
        {
            InitializeComponent( );
        }

        protected override void OnLoad( EventArgs e )
        {
            NameLbl.Text += name;
            LevelLbl.Text += level;
            HealthLbl.Text += health;
            DungeonLbl.Text += dungeon;

        }
    }
}
