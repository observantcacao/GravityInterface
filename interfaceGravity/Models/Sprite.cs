using interfaceGravity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Models
{

    public class Sprite : IGraphicElement
    {
        protected Vector2 _position;
        protected Vector2 _size;
        protected Texture2D _texture;
        public Vector2 Position { get => _position; }
        public Texture2D Texture { get => _texture; set => _texture = value; }
        public int Width { get => (int)_size.X; set => _size.X = (int)value; }
        public int Height { get => (int)_size.Y; set => _size.Y = (int)value; }

        public Sprite(Vector2 position, Vector2 size)
        {
            _position = position;
            _size = size;
        }

        public void LoadContent(Texture2D texture)
        {
            _texture = texture;
        }

        /// <summary>
        /// charage une couleur unie dans la texture du sprite
        /// </summary>
        /// <param name="graphicsDevice"></param>
        /// <param name="color">couleur voulue dans le sprite</param>
        public void LoadContent(GraphicsDevice graphicsDevice, Color color)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { color });
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
            // code...
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, GetRectangle, null, Color.White);
        }

        public Rectangle GetRectangle => new Rectangle((int)_position.X, (int)_position.Y, (int)Width, (int)Height);

    }
}