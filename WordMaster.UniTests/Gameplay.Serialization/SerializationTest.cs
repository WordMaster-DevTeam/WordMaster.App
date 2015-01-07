using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WordMaster.Gameplay;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace WordMaster.UniTests
{
    [TestFixture]
    class SerializationTest
    {
        [Test]
        public void Serialization_work_as_expected()
        {
            //Arrange
            GlobalContext _context = new GlobalContext( );
            Character _character = _context.AddDefaultCharacter( "Robert" );
            Dungeon _dungeon = _context.AddDefaultDungeon( "Old Swamp" );
            Game _game;
            HistoricRecord _historic;

            GameContext _gamecontext = _context.StartNewGame( _character, _dungeon, out _game, out _historic );
                      
            //Act
            //Serialize
            IFormatter formatter = new BinaryFormatter( );
            Stream stream = new FileStream( "SomeFileName.bin", FileMode.Create, FileAccess.Write, FileShare.None );
            formatter.Serialize( stream, _gamecontext );
            stream.Close();

            //Deserialize
            IFormatter openingformatter = new BinaryFormatter( );
            Stream openingstream = new FileStream( "SomeFileName.bin", FileMode.Open, FileAccess.Read, FileShare.Read );
            GameContext deserializedgamecontext = (GameContext)openingformatter.Deserialize( openingstream );
            openingstream.Close( );

            //Assert
            Assert.That( deserializedgamecontext, Is.InstanceOf<GameContext>( ) );
            Assert.That( deserializedgamecontext.Game.Character, Is.Not.SameAs( _gamecontext.Game.Character ) );
            Assert.That( deserializedgamecontext.Game.Character.Armor, Is.EqualTo( _gamecontext.Game.Character.Armor ) );
        }
    }
}
