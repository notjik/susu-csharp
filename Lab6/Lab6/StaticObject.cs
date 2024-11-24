using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab6;

public class StaticObject(Vector2 position, Texture2D texture) : GameObject(position, texture)
{
    public override void Update(GameTime gameTime)
    {
        // Никаких действий для неподвижного объекта
    }
}
