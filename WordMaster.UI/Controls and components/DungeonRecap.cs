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
        DungeonStructure _dungeonStructure;
              
        internal DungeonStructure DungeonStructure
        {
            get { return _dungeonStructure; }
        }

        public DungeonRecap()
        {
            InitializeComponent( );
            this.Dock = DockStyle.Fill;
        }

        public event EventHandler IsSelected;

        internal void SetDungeon( DungeonStructure dungeonStructure )
        {
            _dungeonStructure = dungeonStructure;
            NameLbl.Text = NameLbl.Text + dungeonStructure.Name;
			FloorsCountLbl.Text = FloorsCountLbl.Text + dungeonStructure.NumberOfFloors;
            DescriptionLbl.Text = DescriptionLbl.Text + dungeonStructure.Description;
        }

        private void SelectBtn_Click( object sender, EventArgs e )
        {            
            if ( IsSelected != null ) IsSelected( this, e );
        }

        private void label2_Click( object sender, EventArgs e ){}
    }
}
