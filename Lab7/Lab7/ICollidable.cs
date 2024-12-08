using System;
using Microsoft.Xna.Framework;

namespace Lab7;

public interface ICollidable
{
    Rectangle BoundingBox { get; }
    event EventHandler<GameObject> OnCollision;
    
    void CheckCollision(GameObject other);
}