using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Interfaces
{
    interface IGravity
    {
        float Masse { get; }
        Vector2 Position { get; }
        Vector2 Vitesse { get; }
        Vector2 Acceleration { get; }

        /// <summary>
        /// Appliquer une force au modèle en modifiant son accélération en fonction de sa masse.
        /// </summary>
        /// <param name="force">La force à appliquer</param>
        void ApplyForce(Vector2 force); // Acceleration += force / Masse;
        /// <summary>
        /// Mettre à jour l'état du modèle en fonction du temps écoulé
        /// </summary>
        /// <param name="deltaTime">Le temps écoulé depuis la dernière mise à jour</param>
        void Update(GameTime gametime); // Vitesse += Acceleration * (float)gametime.ElapsedGameTime.TotalSeconds; Position += Vitesse * (float)gametime.ElapsedGameTime.TotalSeconds; Acceleration = Vector2.Zero;

    }
}