using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Interfaces
{
    interface IGraphicElement
    {
        Texture2D Texture { get; }
        Vector2 Position { get; }
        int Height { get; }
        int Width { get; }


        /// <summary>
        /// Charger les ressources nécessaires pour le modèle
        /// </summary>
        void LoadContent(Texture2D texture);
        /// <summary>
        /// Mettre à jour l'état du modèle en fonction du temps écoulé
        /// </summary>
        /// <param name="deltaTime">Le temps écoulé depuis la dernière mise à jour</param>
        void Update(GameTime gametime);
        /// <summary>
        /// Dessiner le modèle à l'écran
        /// </summary>
        /// <param name="spriteBatch">Le SpriteBatch utilisé pour dessiner le modèle</param>
        void Draw(SpriteBatch spriteBatch);
        /// <summary>
        /// Permet d'obtenir un rectangle représentant la zone occupée par le modèle
        /// </summary>
        /// <returns>Un rectangle représentant la zone occupée par le modèle</returns>
        Rectangle GetRectangle { get; }
    }
}
