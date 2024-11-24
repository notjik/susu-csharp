using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab6;

public class MovingObject : GameObject
{
    public Vector2 Velocity { get; set; }
    private GraphicsDevice _graphicsDevice;

    public MovingObject(Vector2 position, Texture2D texture, Vector2 velocity, GraphicsDevice graphicsDevice)
        : base(position, texture)
    {
        Velocity = velocity;
        _graphicsDevice = graphicsDevice;
    }

    public override void Update(GameTime gameTime)
    {
        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Проверяем границы окна
        if (Position.X < 0 || Position.X + Texture.Width > _graphicsDevice.Viewport.Width)
        {
            Velocity = Velocity with { X = Velocity.X * -1 }; // Меняем направление по оси X
            Position = Position with
            {
                X = MathHelper.Clamp(Position.X, 0, _graphicsDevice.Viewport.Width - Texture.Width)
            };
        }

        if (Position.Y < 0 || Position.Y + Texture.Height > _graphicsDevice.Viewport.Height)
        {
            Velocity = Velocity with { Y = Velocity.Y * -1 }; // Меняем направление по оси Y
            Position = Position with
            {
                Y = MathHelper.Clamp(Position.Y, 0, _graphicsDevice.Viewport.Height - Texture.Height)
            };
        }
    }
}

