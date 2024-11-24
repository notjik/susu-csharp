using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Lab6;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<GameObject> _gameObjects;

    private Texture2D _staticTexture;
    private Texture2D _movingTexture;
    private Texture2D _playerTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    
    protected override void Initialize()
    {
        var displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;

        _graphics.PreferredBackBufferWidth = displayMode.Width;
        _graphics.PreferredBackBufferHeight = displayMode.Height;
        
        _graphics.IsFullScreen = true;
        
        _graphics.ApplyChanges();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Загружаем текстуры
        _playerTexture = Content.Load<Texture2D>("playerObject");
        _staticTexture = Content.Load<Texture2D>("staticObject");
        _movingTexture = Content.Load<Texture2D>("movingObject");

        // Создаем игровые объекты
        _gameObjects =
        [
            new StaticObject(new Vector2(100, 100), _staticTexture),
            new StaticObject(new Vector2(300, 200), _staticTexture),

            new MovingObject(new Vector2(400, 100), _movingTexture, new Vector2(100, 50), GraphicsDevice),
            new MovingObject(new Vector2(200, 300), _movingTexture, new Vector2(-50, 75), GraphicsDevice),

            new PlayerObject(new Vector2(500, 500), _playerTexture, 200, GraphicsDevice)
        ];
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }
        foreach (var obj in _gameObjects)
        {
            obj.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        foreach (var obj in _gameObjects)
        {
            obj.Draw(_spriteBatch);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}