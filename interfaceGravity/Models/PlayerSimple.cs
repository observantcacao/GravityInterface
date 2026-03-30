/*
 * auteur : Loukian platonov
 * date   : 26.03.2026
 * description : classe joueur
 * aide   : https://www.youtube.com/watch?v=HujUFaqh-D8
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Models
{
    public class PlayerSimple : Sprite
    {
        private Vector2 MAX_VELOCITY_BY_PLAYER = new Vector2(400f, 1200f);

        private float _speed = 20f;
        private float _jumpForce = 400f;
        private float _gravity = 800f;
        private Vector2 _velocity = Vector2.Zero;
        private bool _grounded = true;

        private Keys _leftKey = Keys.A;
        private Keys _rightKey = Keys.D;
        private Keys _jumpKey = Keys.Space;

        public PlayerSimple(Vector2 position, Vector2 size) : base(position, size)
        {

        }

        public void CustomiseKeys(Keys left, Keys right, Keys jump)
        {
            _leftKey = left;
            _rightKey = right;
            _jumpKey = jump;
        }

        public void Update(GameTime gameTime)
        {
            UpdateVelocity(gameTime);
            UpdatePosition(gameTime);
            Friction();
        }

        private void UpdateVelocity(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // déplacement
            if (kState.IsKeyDown(_leftKey) && _velocity.X > -MAX_VELOCITY_BY_PLAYER.X)
            {
                _velocity.X -= _speed;
            }
            if (kState.IsKeyDown(_rightKey) && _velocity.X < MAX_VELOCITY_BY_PLAYER.X)
            {
                _velocity.X += _speed;
            }

            // appliquer la gravité
            if (!_grounded)
            {
                _velocity.Y += _gravity * deltaTime;
            }

            // saut
            if (kState.IsKeyDown(_jumpKey) && _grounded)
            {
                _velocity.Y = -_jumpForce;
                _grounded = false;
            }
        }

        private void UpdatePosition(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _grounded = false;
            Vector2 futurPos = _position + _velocity * deltaTime;
            Rectangle futurRect = new Rectangle((int)futurPos.X, (int)futurPos.Y, (int)_size.X, (int)_size.Y);

            foreach (Sprite platform in Globals.Plateforms)
            {
                if (futurPos.X != _position.X)
                {
                    futurRect = new Rectangle((int)futurPos.X, (int)_position.Y, (int)_size.X, (int)_size.Y);
                    if (futurRect.Intersects(platform.GetRectangle))
                    {
                        if (futurPos.X > Position.X)
                        {
                            futurPos.X = platform.GetRectangle.Left - Width;

                        }
                        else
                        {
                            futurPos.X = platform.GetRectangle.Right;
                        }
                        _velocity.X = 0;
                    }
                }

                if (futurPos.Y != Position.Y)
                {
                    futurRect = new Rectangle((int)_position.X, (int)futurPos.Y, (int)_size.X, (int)_size.Y);
                    if (futurRect.Intersects(platform.GetRectangle))
                    {
                        if (futurPos.Y > Position.Y)
                        {
                            futurPos.Y = platform.GetRectangle.Top - Height;
                            _grounded = true;
                        }
                        else
                        {
                            futurPos.Y = platform.GetRectangle.Bottom;
                        }
                        _velocity.Y = 0;
                    }
                }

            }

            _position = futurPos;

            if (_position.Y > 500)
            {
                _position = new Vector2(50, 50);
                _velocity = Vector2.Zero;
            }
        }

        private void Friction()
        {
            if (_grounded)
            {
                _velocity.X *= 0.7f; // 0.8f
                if (Math.Abs(_velocity.X) < 0.1f)
                {
                    _velocity.X = 0;
                }
            }
        }
    }
}
