using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lab6;

public abstract class GameObject
{
    public Vector2 Position { get; set; }
    public Texture2D Texture { get; private set; }

    protected GameObject(Vector2 position, Texture2D texture)
    {
        Position = position;
        Texture = texture ?? throw new ArgumentNullException(nameof(texture));
    }

    public abstract void Update(GameTime gameTime);

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }
}
