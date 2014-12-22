using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.Gameplay;

namespace WordMaster.UI
{
    public partial class DungeonSelection : Form, IDungeonSelector
    {
        List<Dungeon> _dungeons;
        GlobalContext _context;

        public DungeonSelection()
        {
            InitializeComponent( );
        }

        public void SetDungeonList( List<Dungeon> dungeonList )
        {
            _dungeons = dungeonList;
            DungeonListTableLayout.RowCount = _dungeons.Count( );

            foreach ( Dungeon aDungeon in _dungeons )
            {
                DungeonRecap newRecap = new DungeonRecap( );
                newRecap.SetDungeon( aDungeon );
                DungeonListTableLayout.Controls.Add( newRecap );
            }
        }

        internal void SetContext( GlobalContext context )
        {
            _context = context;
        }
        
        protected override void OnLoad( EventArgs e )
        {
            AppManager.CurrentContext.AddDefaultDungeon( "Rusty Cage" );
            AppManager.CurrentContext.AddDefaultDungeon( "Black Tower" );
            AppManager.CurrentContext.AddDefaultDungeon( "Mudddy Jail" );
            AppManager.CurrentContext.AddDefaultDungeon( "Flooded Cache" );
            AppManager.CurrentContext.AddDefaultDungeon( "Unknow Place" );

            DungeonListTableLayout.RowCount = AppManager.CurrentContext.Dungeons.Count( );

            foreach(Dungeon aDungeon in AppManager.CurrentContext.Dungeons)
            {
                DungeonRecap newRecap = new DungeonRecap( );
                newRecap.SetDungeon( aDungeon );
                newRecap.IsSelected+= new EventHandler ( DungeonRecap_SelectBtnClicked);
                DungeonListTableLayout.Controls.Add( newRecap );
            }
        }

        private void DungeonRecap_SelectBtnClicked(object sender,EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //newRecap.RecapDungeon = recapCharacter.Dungeon;
        }

        private void BackBtn_Click( object sender, EventArgs e )
        {
            this.Close( );
        }
    }
}
