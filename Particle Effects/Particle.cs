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

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, float angle, float angularVelocity, Color color, int size, int TTL)
        {
            _texture = texture;
            _position = position;
            _rect = new Rectangle(0, 0, size, size);
            _rect.Location = _position.ToPoint();
            _velocity = velocity;
            _angle = angle;
            _angularVelocity = angularVelocity;
            _color = color;
            _size = size;
            _TTL = TTL;
        }


        public void Update()
        {
            _position += _velocity;
            _angle += _angularVelocity;
            _rect.Location = _position.ToPoint();
            _TTL--;
        }


        public bool Dead
        {
            get { return _TTL <= 0; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            spriteBatch.Draw(_texture, _rect, null, _color, _angle, origin,

            SpriteEffects.None, 0f);

        }
    }
}
