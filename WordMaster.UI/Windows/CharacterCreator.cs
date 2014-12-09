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
using WordMaster.IOChecks;

namespace WordMaster.UI
{
    public partial class CharacterCreator : Form
    {
        public CharacterCreator()
        {
            InitializeComponent( );
        }

        public string CharacterName
        {
            get { return _nameTextBox.Text; }
        }

        public string Description
        {
            get { return _descriptionRichTextBox.Text; }
        }

        private void CreateCharacter_Load( object sender, EventArgs e )
        {
            PathLbl.Text = "";
        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {

        }


        private void CreateBtn_Click( object sender, EventArgs e )
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close( );
            //Character character;
            //if(AppManager.CurrentContext.TryGetCharacter(NameLbl.Text, out character))
            //{
            //    MessageBox.Show( "A Character already exist with this name." );
            //}
            //else
            //{
            //    if(InputsChecker.CheckNameLength(NameLbl.Text))
            //    {
            //        AppManager.CurrentContext.AddCharacter( NameLbl.Text, DescriptionLbl.Text );
            //        if(AppManager.CurrentContext.TryGetCharacter(NameLbl.Text,out character))
            //        {
            //            MessageBox.Show( "Character added" );
            //        }
            //        else
            //        {
            //            MessageBox.Show( "An error occured, the CHracter cannot be added." );
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show( "The Character's name must contains between 3 and 30 letters." );
            //    }
                
            //}
        }

        private void BackBtn_Click( object sender, EventArgs e )
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close( );
            
        }

        private void BrowseBtn_Click( object sender, EventArgs e )
        {

        }
    }
}
