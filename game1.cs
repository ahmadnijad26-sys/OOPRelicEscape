using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectOOPGame_Fresh
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private LevelManager levelManager;
        private InputManager inputManager;
        private Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            levelManager = new LevelManager();
            inputManager = new InputManager();
            camera = new Camera(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            // Start with tutorial level
            levelManager.LoadLevel(new TutorialLevel());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            inputManager.Update();

            levelManager.Update(deltaTime, inputManager);
            camera.Update(levelManager.CurrentLevel?.Player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin(transformMatrix: camera.Transform);
            levelManager.Draw(spriteBatch, camera);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
