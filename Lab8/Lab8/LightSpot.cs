using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab8;

public class LightSpot
{
    public Vector2 Position { get; set; }
    public float Brightness { get; set; }
    public Color Color { get; set; }

    public Texture2D Texture;

    public LightSpot(Texture2D texture, Vector2 position, float brightness, Color color)
    {
        Texture = texture;
        Position = position;
        Brightness = brightness;
        Color = color;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        float scale = Brightness / (Texture.Width / 2);
        spriteBatch.Draw(Texture, Position, null, Color, 0f, new Vector2(Texture.Width / 2, Texture.Height / 2), scale, SpriteEffects.None, 0f);
    }
}
