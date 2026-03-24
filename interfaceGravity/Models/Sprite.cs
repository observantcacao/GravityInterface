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

    public class Sprite : IGravity, IGraphicElement
    {
        protected float _masse;
        protected Vector2 _vitesse;
        protected Vector2 _acceleration;
        protected Vector2 _position;

        protected Texture2D _texture;
        protected Vector2 _taille;
        public float Masse { get => _masse; }
        public Vector2 Position { get => _position; }
        public Vector2 Vitesse { get => _vitesse; }
        public Vector2 Acceleration { get => _acceleration; }
        public Texture2D Texture { get => _texture; set => _texture = value; }
        public int Width { get => (int)_taille.X; set => _taille.X = (int)value; }
        public int Height { get => (int)_taille.Y; set => _taille.Y = (int)value; }

        public Sprite(float masse, Vector2 position, Vector2 taille, int width, int height)
        {
            _masse = masse;
            _position = position;
            _taille = taille;
            Width = width;
            Height = height;
        }


        public void ApplyForce(Vector2 force)
        {
            if (_masse <= 0f)
            {
                return;
            }
            _acceleration += force / _masse;
        }

        public void LoadContent(Texture2D texture)
        {
            _texture = texture;
        }

        /// <summary>
        /// charge une texture blanche par défaut pour le sprite
        /// </summary>
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _vitesse += _acceleration * deltaTime; // gestion de la vitesse par rapport à l'accélération
            _position += _vitesse * deltaTime; // gestion de la position par rapport à la vitesse
            _acceleration = Vector2.Zero; // réinitialisation de l'accélération après chaque mise à jour

            // ajouter logique...
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, GetRectangle, null, Color.White);
        }

        public Rectangle GetRectangle => new Rectangle((int)_position.X, (int)_position.Y, (int)Width, (int)Height);

    }
}