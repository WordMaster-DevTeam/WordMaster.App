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
    public partial class CharacterRecap : UserControl
    {
        public CharacterRecap()
        {
            InitializeComponent( );
        }
        internal void SetCharacter(Character aCharacter)
        {
            NameLbl.Text = NameLbl.Text + aCharacter.Name;
            LifeLbl.Text = LifeLbl.Text + aCharacter.Health;
            LevelLbl.Text = LevelLbl.Text + aCharacter.Level;
            DungeonLbl.Text = DungeonLbl.Text + aCharacter.Dungeon;
        }
        private void LaunchBtn_Click_1( object sender, EventArgs e )
        {
            Ingame ingameform = new Ingame( );
            ingameform.Show( );
        }

        
    }
}
