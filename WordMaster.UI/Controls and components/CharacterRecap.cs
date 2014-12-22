﻿using System;
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
        internal GlobalContext _globalContext;
        GameContext _gameContext;

        public CharacterRecap( GlobalContext globalContext )
        {
            _globalContext = globalContext;
            InitializeComponent( );
            this.Dock = DockStyle.Fill;
        }

        internal void SetCharacter(Character character)
        {
            _character = character;
            NameLbl.Text = NameLbl.Text + character.Name;
            LifeLbl.Text = LifeLbl.Text + character.Health;
            LevelLbl.Text = LevelLbl.Text + character.Level;
            if(character.Dungeon!=null)
            {
                DungeonLbl.Text = DungeonLbl.Text + character.Dungeon.Name;
            }
            
        }

        internal void SetContext(GlobalContext globalContext)
        {
            _globalContext = globalContext;
        }

        private void LaunchBtn_Click( object sender, EventArgs e )
        {
            if(_character.Dungeon == null)
            {

                using( DungeonSelection dungeonSelectForm = new DungeonSelection( _character, _globalContext) )
                {

                    DialogResult res = dungeonSelectForm.ShowDialog( );
                    if(res == DialogResult.OK)
                    {
                        ParentForm.Refresh();
                        dungeonSelectForm.Close( );
                    }

                }
                
            }
            else
            {
                InGame inGame = new InGame( _gameContext );
                inGame.Show( );
            }

                  
        } 
    }
}
