using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Particle_Effects
{
    public class Particle
    {






        private Texture2D _texture; // The texture that will be drawn to represent the
        private Vector2 _position; // The current position of the particle
        private Rectangle _rect; // A Rectangle to scale our textures into
        private Vector2 _velocity; // The speed of the particle at the current instance
        private float _angle; // The current angle of rotation of the particle
        private float _angularVelocity; // The speed that the angle is changing
        private Color _color; // The color of the particle
        private int _size; // The size of the particle assuming length = width
        private int _TTL; // The 'time to live' of the particle
    }
}
