using interfaceGravity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Models
{
    public class Button : IGraphicElement
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Vector2 _size;


        public Texture2D Texture { get => _texture; set => _texture = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public int Width { get => (int)_size.X; }
        public int Height { get => (int)_size.Y; }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void LoadContent(Texture2D texture)
        {
            
        }

        public void Update(GameTime gametime)
        {
            
        }

        public void Click()
        {

        }

        public Rectangle GetRectangle => throw new NotImplementedException();

    }
}
