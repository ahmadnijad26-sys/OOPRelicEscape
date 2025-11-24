using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ProjectOOPGame_Fresh
{
    public class TutorialLevel : IGameLevel
    {
        public Player Player { get; private set; }
        public bool IsCompleted { get; private set; }

        private List<TrainingDummy> dummies;
        private List<ItemDrop> items;

        public void Initialize()
        {
            Player = new Player(new Vector2(100, 100));
            dummies = new List<TrainingDummy>();
            items = new List<ItemDrop>();

            // Add tutorial content
            dummies.Add(new TrainingDummy(new Vector2(300, 200), DummyType.Scarecrow));
            items.Add(new ItemDrop(new Vector2(400, 300), "Watering Can"));
            
            IsCompleted = false;
        }

        public void Update(float deltaTime, KeyboardState current, KeyboardState previous)
        {
            Player.Update(deltaTime, current, previous);

            // Tutorial logic - complete when dummy defeated and item collected
            if (dummies.Count == 0 && Player.HasItem("Watering Can"))
            {
                IsCompleted = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            // Draw level content
            foreach (var dummy in dummies) dummy.Draw(spriteBatch);
            foreach (var item in items) item.Draw(spriteBatch);
            Player.Draw(spriteBatch);
        }
    }
}
