using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.Gameplay;

namespace WordMaster.UI
{
    public partial class CharacterRecap : UserControl
    {
        Character _character;
		Game _game;
		HistoricRecord _historicRecord;

        public CharacterRecap()
        {
            InitializeComponent( );
            this.Dock = DockStyle.Fill;
        }

        internal void SetCharacter(Character character)
        {
            _character = character;
            NameLbl.Text = NameLbl.Text + character.Name;
            LifeLbl.Text = LifeLbl.Text + character.Health;
            LevelLbl.Text = LevelLbl.Text + character.Level;
            DungeonLbl.Text = DungeonLbl.Text + character.Dungeon;
        }

        private void LaunchBtn_Click( object sender, EventArgs e )
        {
            if(_character.Dungeon==null)
            {
                using( DungeonSelection dungeonSelectForm = new DungeonSelection( ) )
                {
                    
                    DialogResult res = dungeonSelectForm.ShowDialog( );
                    if(res == DialogResult.OK)
                    {
                        dungeonSelectForm.Close( );
                    }
                    
                }
                
            }
            else
            {
            }                     
        } 
    }
}
