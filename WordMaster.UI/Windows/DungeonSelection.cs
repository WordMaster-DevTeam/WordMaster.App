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
    public partial class DungeonSelection : Form
    {
        GlobalContext _globalContext;
        Character _character;

        public DungeonSelection( Character character, GlobalContext globalContext )
        {
            _globalContext = globalContext;
            _character = character;
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            DungeonListTableLayout.RowCount = _globalContext.Dungeons.Count();

            foreach ( DungeonStructure dungeon in _globalContext.Dungeons )
            {
                DungeonRecap newRecap = new DungeonRecap( );
                newRecap.SetDungeon( dungeon );
                newRecap.IsSelected += new EventHandler( DungeonRecap_SelectBtnClicked );
                DungeonListTableLayout.Controls.Add( newRecap );
            }
        }

        private void DungeonRecap_SelectBtnClicked(object sender,EventArgs e)
        {
            HistoricRecord historicRecord;

            this.DialogResult = DialogResult.OK;
            GameContext gameContext = _globalContext.StartNewGame( _character,( (DungeonRecap)sender ).DungeonStructure, out historicRecord);
            InGame ingameForm = new InGame( gameContext );
            ingameForm.Show( );
        }

        private void BackBtn_Click( object sender, EventArgs e )
        {
            this.Close( );
        }
    }
}
