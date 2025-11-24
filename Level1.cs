using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ProjectOOPGame_Fresh
{
    public class Level1 : IGameLevel
    {
        public Player Player { get; private set; }
        public bool IsCompleted { get; private set; }

        private List<Enemy> enemies;
        private List<InteractiveObject> objects;
        private TileType[,] map;
        private int mapWidth = 16, mapHeight = 16, tileSize = 64;

        public void Initialize()
        {
            Player = new Player(new Vector2(128, 128));
            enemies = new List<Enemy>();
            objects = new List<InteractiveObject>();

            // Faris' Level 1 content
            InitializeMap();
            InitializeEnemies();
            InitializeObjects();

            IsCompleted = false;
        }

        private void InitializeMap()
        {
            map = new TileType[mapWidth, mapHeight];
            // Faris' map generation code here
        }

        private void InitializeEnemies()
        {
            // Faris' enemy placement code here
            enemies.Add(new Enemy(new Vector2(256, 256), EnemyType.Snake));
        }

        private void InitializeObjects()
        {
            // Faris' object placement code here
        }

        public void Update(float deltaTime, KeyboardState current, KeyboardState previous)
        {
            Player.Update(deltaTime, current, previous);

            // Faris' Level 1 update logic here
            foreach (var enemy in enemies) enemy.Update(deltaTime, Player);

            // Complete when relic obtained
            if (Player.HasItem("Spiritvine Blade"))
            {
                IsCompleted = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            // Faris' drawing code here
            DrawMap(spriteBatch);
            foreach (var enemy in enemies) enemy.Draw(spriteBatch);
            foreach (var obj in objects) obj.Draw(spriteBatch);
            Player.Draw(spriteBatch);
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            // Faris' map drawing code
        }
    }
}
