using interfaceGravity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        protected Vector2 _taille;
        protected Texture2D _texture;
        public Vector2 Position { get => _position; }
        public Texture2D Texture { get => _texture; set => _texture = value; }
        public int Width { get => (int)_taille.X; set => _taille.X = (int)value; }
        public int Height { get => (int)_taille.Y; set => _taille.Y = (int)value; }

        public Sprite(Vector2 position, Vector2 taille)
        {
            _position = position;
            _taille = taille;
        }

        public void LoadContent(Texture2D texture)
        {
            _texture = texture;
        }

        /// <summary>
        /// charge une texture blanche par défaut pour le sprite
        /// </summary>
        public void LoadContent(GraphicsDevice graphicsDevice, Color color)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { color });
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
            // ajouter logique...
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, GetRectangle, null, Color.White);
        }

        public Rectangle GetRectangle => new Rectangle((int)_position.X, (int)_position.Y, (int)Width, (int)Height);

    }
}