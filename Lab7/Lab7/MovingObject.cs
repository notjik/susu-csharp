using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab7;

public class MovingObject(Vector2 position, Texture2D texture, Vector2 velocity, GraphicsDevice graphicsDevice)
    : GameObject(position, texture)
{
    private Vector2 Velocity { get; set; } = velocity;
    private const float SpeedMultiplier = 1.2f; // Коэффициент увеличения скорости

    public override void Update(GameTime gameTime)
    {
        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Проверяем границы окна
        if (Position.X < 0 || Position.X + Texture.Width > graphicsDevice.Viewport.Width)
        {
            Velocity = Reflect(Velocity, Vector2.UnitX);  // Отражение по оси X
            Position = Position with { X = MathHelper.Clamp(Position.X, 0, graphicsDevice.Viewport.Width - Texture.Width) };
        }

        if (!(Position.Y < 0) && !(Position.Y + Texture.Height > graphicsDevice.Viewport.Height)) return;
        Velocity = Reflect(Velocity, Vector2.UnitY);  // Отражение по оси Y
        Position = Position with { Y = MathHelper.Clamp(Position.Y, 0, graphicsDevice.Viewport.Height - Texture.Height) };
    }

    // Метод для обработки отражения скорости
    private static Vector2 Reflect(Vector2 velocity, Vector2 normal)
    {
        var dot = Vector2.Dot(velocity, normal);
        return velocity - 2 * dot * normal;  // Отражение по нормали
    }

    protected override void OnCollisionResponse(GameObject other)
    {
        // Вычисляем нормаль к поверхности столкновения
        var collisionNormal = Vector2.Normalize(Position - other.Position);

        // Проверка, идет ли столкновение по движению объекта (по направлению скорости)
        var dotProduct = Vector2.Dot(Velocity, collisionNormal);

        if (dotProduct > 0) // Столкновение идет в том же направлении, в котором движется объект
        {
            // Увеличиваем скорость в зависимости от угла столкновения
            Velocity += collisionNormal * SpeedMultiplier; // Увеличиваем скорость вдоль нормали
        }
        else
        {
            // Отражение от объекта
            Velocity = Reflect(Velocity, collisionNormal);
        }
    }
}
