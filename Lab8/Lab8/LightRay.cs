using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab8;

public class LightRay
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; }
    public float Length { get; set; }
    public float Focus { get; set; }
    public Color Color { get; set; }

    public Texture2D Texture;

    public LightRay(Texture2D texture, Vector2 position, float rotation, float length, float focus, Color color)
    {
        Texture = texture;
        Position = position;
        Rotation = rotation;
        Length = length;
        Focus = focus;
        Color = color;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, null, Color,
            Rotation, new Vector2(Texture.Width / 2, 0),
            new Vector2(Focus, Length / (float)Texture.Height), // Масштабирование
            SpriteEffects.None, 0f);
    }
}