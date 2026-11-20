using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Particle_Effects
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        MouseState mouseState;
        ParticleEngine particleEngine;
        List<Texture2D> particles;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            particles = new List<Texture2D>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            particles.Add(Content.Load<Texture2D>("circle"));
            particles.Add(Content.Load<Texture2D>("diamond"));
            particles.Add(Content.Load<Texture2D>("star"));


            // Create the particle engine AFTER loading textures
            particleEngine = new ParticleEngine(particles, Vector2.Zero, true);

            particleEngine.Speed = 2f;
            particleEngine.Color = Color.Blue;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            // Enable particles while holding left mouse button
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                particleEngine.Enabled = true;
            }
            else
            {
                particleEngine.Enabled = false;
            }

            // Set emitter location to mouse position
            particleEngine.EmitterLocation = mouseState.Position.ToVector2();

            // Update particle engine
            particleEngine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            particleEngine.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
