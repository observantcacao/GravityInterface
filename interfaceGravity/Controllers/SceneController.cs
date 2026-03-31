using interfaceGravity.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Controllers
{
    public class SceneController
    {
        private List<IScene> _listScene;
        private SceneDisponible SceneActuelle;
        enum SceneDisponible
        {
            Menu,
            Setting,
            Game,
            Error
        }

        /*public SceneController(List<IScene> ListScene)
        {

        }*/

        public void Update(GameTime gameTime)
        {
            try
            {
                _listScene[(int)SceneActuelle].Update(gameTime);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                SceneActuelle = SceneDisponible.Error;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _listScene[(int)SceneActuelle].Draw(spriteBatch);
        }
    }
}
