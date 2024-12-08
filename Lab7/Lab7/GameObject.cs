using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab7;

public abstract class GameObject(Vector2 position, Texture2D texture) : ICollidable
{
    public Vector2 Position { get; set; } = position;
    protected Texture2D Texture { get; set; } = texture ?? throw new ArgumentNullException(nameof(texture));

    public Rectangle BoundingBox => new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

    public event EventHandler<GameObject> OnCollision;

    public void CheckCollision(GameObject other)
    {
        // Проверяем пересечение bounding box'ов
        if (BoundingBox.Intersects(other.BoundingBox))
        {
            // Если BoundingBox пересекаются, выполняем проверку пикселей
            if (PixelCollision(other))
            {
                // Уведомляем оба объекта о столкновении
                OnCollision?.Invoke(this, other);
                OnCollisionResponse(other);

                other.OnCollision?.Invoke(other, this);
                other.OnCollisionResponse(this);
            }
        }
    }

    // Метод для проверки столкновения пикселей
    private bool PixelCollision(GameObject other)
    {
        // Получаем пиксели для обоих объектов
        Color[] colorData1 = new Color[Texture.Width * Texture.Height];
        Texture.GetData(colorData1);

        Color[] colorData2 = new Color[other.Texture.Width * other.Texture.Height];
        other.Texture.GetData(colorData2);

        // Получаем области пересечения BoundingBox объектов
        Rectangle intersection = Rectangle.Intersect(this.BoundingBox, other.BoundingBox);

        // Преобразуем координаты в текстуре в пиксели с учетом позиции
        for (int y = intersection.Top; y < intersection.Bottom; y++)
        {
            for (int x = intersection.Left; x < intersection.Right; x++)
            {
                // Преобразуем (x, y) в индекс массива пикселей
                int index1 = (x - (int)Position.X) + (y - (int)Position.Y) * Texture.Width;
                int index2 = (x - (int)other.Position.X) + (y - (int)other.Position.Y) * other.Texture.Width;

                // Получаем цвета пикселей в этих точках
                Color color1 = colorData1[index1];
                Color color2 = colorData2[index2];

                // Проверяем, что пиксели не прозрачные
                if (color1.A > 0 && color2.A > 0)
                {
                    return true; // Если хотя бы один пиксель перекрывается, значит столкновение
                }
            }
        }

        return false; // Если перекрытия нет
    }

    protected abstract void OnCollisionResponse(GameObject other);

    public abstract void Update(GameTime gameTime);

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }
}
