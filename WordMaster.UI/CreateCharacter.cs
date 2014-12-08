using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordMaster.DLL;

namespace WordMaster.UI
{
    public partial class CreateCharacter : Form
    {
        public CreateCharacter()
        {
            InitializeComponent( );
        }

        private void CreateCharacter_Load( object sender, EventArgs e )
        {
            PathLbl.Text = "";
        }

        private void DescriptionLbl_Click( object sender, EventArgs e )
        {

        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {

        }

        private void BrowseLbl_Click( object sender, EventArgs e )
        {
            OpenFileDialog openFile = new OpenFileDialog( );

            openFile.Title = "Choose your avatar's image";
            openFile.Filter = "BMP Files|*.bmp|JPG Files|*.jpg|PNG Files|*.png";
            openFile.InitialDirectory = @"Bibliothèques\Images";
            openFile.CheckFileExists = true;

            if(openFile.ShowDialog()==DialogResult.OK)
            {
                PathLbl.Text = openFile.FileName.ToString( );
                AvatarPictureBox.Image = new Bitmap( openFile.FileName );
            }
        }

        private void CreateBtn_Click( object sender, EventArgs e )
        {
            Character character;
            if(AppManager.CurrentContext.TryGetCharacter(NameLbl.Text, out character))
            {
                MessageBox.Show( "A Character already exist with this name." );
            }
            else
            {
                if(NoMagicHelper.CheckNameLength(NameLbl.Text))
                {
                    AppManager.CurrentContext.AddCharacter( NameLbl.Text, DescriptionLbl.Text );
                    if(AppManager.CurrentContext.TryGetCharacter(NameLbl.Text,out character))
                    {
                        MessageBox.Show( "Character added" );
                    }
                    else
                    {
                        MessageBox.Show( "An error occured, the CHracter cannot be added." );
                    }
                }
                else
                {
                    MessageBox.Show( "The Character's name must contains between 3 and 30 letters." );
                }
                
            }
        }

        private void BackBtn_Click( object sender, EventArgs e )
        {
            this.Close( );
        }
    }
}
