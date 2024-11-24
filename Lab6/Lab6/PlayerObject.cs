using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab6;


public class PlayerObject(Vector2 position, Texture2D texture, float speed, GraphicsDevice graphicsDevice) : GameObject(position, texture)
{
    private float Speed { get; set; } = speed;

    public override void Update(GameTime gameTime)
    {
        KeyboardState state = Keyboard.GetState();

        Vector2 newPosition = Position;

        if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
            newPosition.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            newPosition.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            newPosition.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            newPosition.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Проверяем столкновения с границами окна
        newPosition.X = MathHelper.Clamp(newPosition.X, 0, graphicsDevice.Viewport.Width - Texture.Width);
        newPosition.Y = MathHelper.Clamp(newPosition.Y, 0, graphicsDevice.Viewport.Height - Texture.Height);

        Position = newPosition;
    }

}
