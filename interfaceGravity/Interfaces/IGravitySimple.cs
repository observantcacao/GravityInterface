using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceGravity.Interfaces
{
    interface IGravitySimple
    {
        float Gravity { get; }
        Vector2 _velocity { get; }
    }
}
