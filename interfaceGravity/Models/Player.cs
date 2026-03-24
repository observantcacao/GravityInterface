using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Models
{
    public class Player : Sprite
    {
        private float _speed = 800f;
        private float _jumpForce = 400f;
        private bool _grounded = true;
        private float _friction = 0.8f;

        private Keys _leftKey = Keys.A;
        private Keys _rightKey = Keys.D;
        private Keys _jumpKey = Keys.Space;

        private KeyboardState _previousKState = Keyboard.GetState();

        public Player(float masse, Vector2 position, Vector2 taille) : base(masse, position, taille)
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
            var kstate = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            // déplacement horizontal
            if (kstate.IsKeyDown(_leftKey))
            {
                direction.X = -1;
            }
            if (kstate.IsKeyDown(_rightKey))
            {
                direction.X = 1;
            }

            // applique la force horizontale
            ApplyForce(new Vector2(direction.X * _speed, 0));

            // saut
            if (kstate.IsKeyDown(_jumpKey) && _grounded)
            {
                _vitesse.Y = -_jumpForce; // appliquer une force de saut en modifiant directement la vitesse verticale
                _grounded = false; // le joueur n'est plus au sol après avoir sauté
            }

            // gestion gravité
            if (!_grounded)
            {
                ApplyForce(new Vector2(0, 981f * Masse)); // 9.81f , 981f
            }

            // Appel à la physique de Sprite 
            base.Update(gameTime);


            // gestion des collisions avec les éléments du jeu

            HandleCollisions();

            /*if (Position.Y >= 200)
            {
                _position.Y = 200;
                _vitesse.Y = 0;
                _grounded = true;
            }*/
            /*_grounded = false;
            Rectangle playerRect = GetRectangle;
            foreach (Sprite platform in Globals.Plateforms)
            {
                if (playerRect.Intersects(platform.GetRectangle))
                {
                    if (Position.X + Width >= platform.GetRectangle.Left)
                    {
                        _vitesse.X = 0;
                    }
                    else if (Position.X >= platform.GetRectangle.Right + Width)
                    {
                        _vitesse.X = 0;
                        //_position.X = platform.Position.X + Width;
                    }

                    if (playerRect.Bottom >= platform.GetRectangle.Top)
                    {
                        _position.Y = platform.GetRectangle.Top - Height;
                        _vitesse.Y = 0;
                        _grounded = true;
                    }
                    else if (Position.Y >= platform.GetRectangle.Bottom - Height)
                    {
                        _vitesse.Y = 0;
                    }
                }
            }*/



            // gestion de la friction
            int inputDirection = Math.Sign(direction.X);
            int velocityDirection = Math.Sign(_vitesse.X);

            if (_grounded)
            {
                if (direction.X == 0)
                {
                    _vitesse.X *= _friction;
                }
                else if (inputDirection != velocityDirection && direction.X != 0)
                {
                    // quand le joueur change de direction, la friction devient plus forte
                    _vitesse.X *= _friction - 0.1f;
                }

                // si trop petit, on stoppe le mouvement horizontal
                if (Math.Abs(_vitesse.X) < 0.1f)
                {
                    _vitesse.X = 0;
                }
            }

            _previousKState = kstate;
        }

        public void HandleCollisions()
        {
            _grounded = false;
            Rectangle playerRect = GetRectangle;

            foreach (Sprite plateform in Globals.Plateforms)
            {
                Rectangle platformRect = plateform.GetRectangle;

                if (playerRect.Intersects(platformRect))
                {
                    // collision par le bas
                    if (_vitesse.Y > 0 && playerRect.Bottom - _vitesse.Y <= platformRect.Top)
                    {
                        _position.Y = platformRect.Top - Height;
                        _vitesse.Y = 0;
                        _grounded = true;
                    }
                    // collision par le haut
                    else if (_vitesse.Y < 0 && playerRect.Top - _vitesse.Y >= platformRect.Bottom)
                    {
                        _position.Y = platformRect.Bottom;
                        _vitesse.Y = 0;
                    }
                    // collision par la gauche
                    else if (_vitesse.X > 0 && playerRect.Right - _vitesse.X <= platformRect.Left)
                    {
                        _position.X = platformRect.Left - Width;
                        _vitesse.X = 0;
                    }
                    // collision par la droite
                    else if (_vitesse.X < 0 && playerRect.Left - _vitesse.X >= platformRect.Right)
                    {
                        _position.X = platformRect.Right;
                        _vitesse.X = 0;
                    }
                }
            }

            //foreach (Sprite plateform in Globals.Plateforms)
            //{

            //}

            if (_position.Y >= 500)
            {
                _position = new Vector2(100, 100);
            }
        }

    }
}
