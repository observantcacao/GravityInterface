using interfaceGravity.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace interfaceGravity
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private Sprite _platform1;
        private Sprite _platform2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _player = new Player(1f, new Vector2(100, 100), new Vector2(50, 50));
            _platform1 = new Sprite(new Vector2(0, 300), new Vector2(400, 600));
            _platform2 = new Sprite(new Vector2(0, 350), new Vector2(1000, 600));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player.LoadContent(GraphicsDevice, Color.White);
            _platform1.LoadContent(GraphicsDevice, Color.MintCream);
            _platform2.LoadContent(GraphicsDevice, Color.MintCream);
            // TODO: use this.Content to load your game content here
            Globals.Plateforms.Add(_platform1);
            Globals.Plateforms.Add(_platform2);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _player.Update(gameTime);
            Globals.Plateforms.ForEach(p => p.Update(gameTime));
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _player.Draw(_spriteBatch);
            Globals.Plateforms.ForEach(p => p.Draw(_spriteBatch));
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
