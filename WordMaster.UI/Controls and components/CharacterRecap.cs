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
		HistoricRecord _historicRecord;
        internal GlobalContext _globalContext;
        GameContext _gameContext;

        public event EventHandler CharacterListEdited;

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
            LifeLbl.Text = LifeLbl.Text + character.CurrentHealth;
            LevelLbl.Text = LevelLbl.Text + character.Level;
            if(character.Dungeon!=null)
            {
                DungeonLbl.Text = DungeonLbl.Text + character.Dungeon.Structure.Name;
                if(character.GameContext.Historic.Cancelled ==true)
                {
                    DungeonLbl.Text = DungeonLbl.Text + " (unfinished)";
                }
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
                _gameContext = _character.GameContext;
                InGame inGame = new InGame( _gameContext );
                inGame.Show( );
            }

                  
        }

        private void BtnEdit_Click( object sender, EventArgs e )
        {
            using( CharacterCreator _editForm= new CharacterCreator() )
            {
                _editForm.TextBoxName = _character.Name;
                _editForm.TextBoxDescription = _character.Description;

                DialogResult res=_editForm.ShowDialog();

                if(res==DialogResult.OK)
                {
                    _globalContext.RenameCharacter( _character, _editForm.TextBoxName );
                    _character.Description = _editForm.TextBoxDescription;
                    if(CharacterListEdited !=null)
                    {
                        CharacterListEdited( this, e );
                    }
                }
            }
        }

        private void BtnDelete_Click( object sender, EventArgs e )
        {
            _globalContext.ForceRemoveCharacter( _character );
            if ( CharacterListEdited != null )
            {
                CharacterListEdited( this, e );
            }
        } 
    }
}
