using ExplosionAndSMoke.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExplosionAndSMoke
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Camera camera;

        Explosion explosionManager;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        float timeElapsed;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 640;
            Content.RootDirectory = "Content";
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            Texture2D smokee = Content.Load<Texture2D>("particlesmokee");
            Texture2D spark = Content.Load<Texture2D>("spark");
            Texture2D bangExplosion = Content.Load<Texture2D>("explosion");
            explosionManager = new Explosion(spriteBatch, spark, camera, smokee, bangExplosion);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                explosionManager.Reset((float)gameTime.ElapsedGameTime.TotalSeconds);
                timeElapsed = 0;
            }
            else if (timeElapsed > 4)
            {
                explosionManager.Reset((float)gameTime.ElapsedGameTime.TotalSeconds);
                timeElapsed = 0;
            }
            // TODO: Add your update logic here
            explosionManager.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
            
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            explosionManager.Draw((float)gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
