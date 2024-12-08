using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab7;

public class MovingObject : GameObject
{
    public Vector2 Velocity { get; set; }
    private GraphicsDevice _graphicsDevice;
    private float _speedMultiplier = 1.2f; // Коэффициент увеличения скорости

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
            Velocity = Reflect(Velocity, Vector2.UnitX);  // Отражение по оси X
            Position = Position with { X = MathHelper.Clamp(Position.X, 0, _graphicsDevice.Viewport.Width - Texture.Width) };
        }

        if (Position.Y < 0 || Position.Y + Texture.Height > _graphicsDevice.Viewport.Height)
        {
            Velocity = Reflect(Velocity, Vector2.UnitY);  // Отражение по оси Y
            Position = Position with { Y = MathHelper.Clamp(Position.Y, 0, _graphicsDevice.Viewport.Height - Texture.Height) };
        }
    }

    // Метод для обработки отражения скорости
    private Vector2 Reflect(Vector2 velocity, Vector2 normal)
    {
        float dot = Vector2.Dot(velocity, normal);
        return velocity - 2 * dot * normal;  // Отражение по нормали
    }

    protected override void OnCollisionResponse(GameObject other)
    {
        // Вычисляем нормаль к поверхности столкновения
        Vector2 collisionNormal = Vector2.Normalize(Position - other.Position);

        // Проверка, идет ли столкновение по движению объекта (по направлению скорости)
        float dotProduct = Vector2.Dot(Velocity, collisionNormal);

        if (dotProduct > 0) // Столкновение идет в том же направлении, в котором движется объект
        {
            // Увеличиваем скорость в зависимости от угла столкновения
            Velocity += collisionNormal * _speedMultiplier; // Увеличиваем скорость вдоль нормали
        }
        else
        {
            // Отражение от объекта
            Velocity = Reflect(Velocity, collisionNormal);
        }
    }
}
