using Microsoft.Xna.Framework.Graphics;

namespace ProjectOOPGame_Fresh
{
    public class LevelManager
    {
        public IGameLevel CurrentLevel { get; private set; }

        public void LoadLevel(IGameLevel level)
        {
            CurrentLevel = level;
            level.Initialize();
        }

        public void Update(float deltaTime, InputManager input)
        {
            CurrentLevel?.Update(deltaTime, input.CurrentState, input.PreviousState);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            CurrentLevel?.Draw(spriteBatch, camera);
        }
    }
}
