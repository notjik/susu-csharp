using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Lab8;

public class LightManager
{
    private List<LightSpot> lightSpots = new List<LightSpot>();
    private List<LightRay> lightRays = new List<LightRay>();

    public void AddLightSpot(LightSpot lightSpot)
    {
        lightSpots.Add(lightSpot);
    }

    public void AddLightRay(LightRay lightRay)
    {
        lightRays.Add(lightRay);
    }

    public static Color RandomColor()
    {
        Random random = new Random();
        byte red = (byte)random.Next(0, 256);
        byte green = (byte)random.Next(0, 256);
        byte blue = (byte)random.Next(0, 256);
        return new Color(red, green, blue);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);

        // Отрисовка пятен света
        foreach (var spot in lightSpots)
        {
            spot.Draw(spriteBatch);
        }

        // Отрисовка лучей
        foreach (var ray in lightRays)
        {
            ray.Draw(spriteBatch);
        }

        spriteBatch.End();
    }
}