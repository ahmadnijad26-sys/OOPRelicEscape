public interface IGameLevel
{
    Player Player { get; }
    bool IsCompleted { get; }
    void Initialize();
    void Update(float deltaTime, KeyboardState current, KeyboardState previous);
    void Draw(SpriteBatch spriteBatch, Camera camera);
}
