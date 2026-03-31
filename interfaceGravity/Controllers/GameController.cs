using interfaceGravity.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Controllers
{
    public class GameController
    {
        private PlayerSimple _player;
        private Sprite _platform1;
        private Sprite _platform2;
        private Sprite _platform3;
        private Balance _balance;

        public void Initialize()
        {
            _player = new PlayerSimple(new Vector2(50,50),new Vector2(50,50));
            _platform1 = new Sprite(new Vector2(0,200),new Vector2(200,200));
            _platform2 = new Sprite(new Vector2(300, 200), new Vector2(200, 200));

            Globals.Plateforms.Add(_platform1);
            Globals.Plateforms.Add(_platform2);
        }

        public void LoadContent()
        {
            _platform1.LoadContent(Color.White);
            _platform2.LoadContent(Color.White);
            _player.LoadContent(Color.Brown); // DarkGoldenrod
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _platform1.Draw(spriteBatch);
            _platform2.Draw(spriteBatch);

            _player.Draw(spriteBatch);
        }
    }
}
