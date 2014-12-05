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
    public partial class DungeonRecap : UserControl
    {
        Dungeon uCDungeon;
        public DungeonRecap()
        {
            InitializeComponent( );
            this.Dock = DockStyle.Fill;
        }

        internal void SetDungeon( Dungeon aDungeon)
        {
            uCDungeon = aDungeon;
            NameLbl.Text = NameLbl.Text + aDungeon.Name;
            FloorsCountLbl.Text = FloorsCountLbl.Text + aDungeon.Floors.Count( );
            DescriptionLbl.Text = DescriptionLbl.Text + aDungeon.Description;
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
