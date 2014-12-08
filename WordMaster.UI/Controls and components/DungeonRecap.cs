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
    public partial class DungeonRecap : UserControl
    {
        Dungeon _dungeon;

        public DungeonRecap()
        {
            InitializeComponent( );
            this.Dock = DockStyle.Fill;
        }

        internal void SetDungeon( Dungeon dungeon)
        {
            _dungeon = dungeon;
            NameLbl.Text = NameLbl.Text + dungeon.Name;
            FloorsCountLbl.Text = FloorsCountLbl.Text + dungeon.Floors.Count( );
            DescriptionLbl.Text = DescriptionLbl.Text + dungeon.Description;
        }

        private void SelectBtn_Click( object sender, EventArgs e )
        {

        }
       
        private void DungeonRecap_Load( object sender, EventArgs e )
        {

        }

        private void label2_Click( object sender, EventArgs e )
        {

        }
    }
}
