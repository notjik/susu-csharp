using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab8;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D lightTexture;
    private Texture2D rayTexture;
    private Texture2D backgroundTexture;

    private LightManager lightManager;
    private LightSpot mouseLightSpot;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // Загрузка текстур
        backgroundTexture = Content.Load<Texture2D>("background");
        lightTexture = Content.Load<Texture2D>("lightSpot");
        rayTexture = Content.Load<Texture2D>("lightRay");


        // Создание менеджера освещения
        lightManager = new LightManager();

        // Создание светового пятна для мыши
        mouseLightSpot = new LightSpot(lightTexture, Vector2.Zero, 100, LightManager.RandomColor());
        lightManager.AddLightSpot(mouseLightSpot);

        // Добавление лучей по углам экрана
        AddLightRayInCorners(GraphicsDevice.Viewport);
    }

    private void AddLightRayInCorners(Viewport viewport)
    {
        // Центр экрана
        Vector2 center = new Vector2(viewport.Width / 2f, viewport.Height / 2f);

        // Углы окна
        Vector2[] corners = new Vector2[]
        {
            new Vector2(0, 0), // Верхний левый угол
            new Vector2(viewport.Width, 0), // Верхний правый угол
            new Vector2(0, viewport.Height), // Нижний левый угол
            new Vector2(viewport.Width, viewport.Height) // Нижний правый угол
        };

        // Добавляем лучи в углы, направляя их к центру
        foreach (var corner in corners)
        {
            // Вычисляем угол поворота для направления луча к центру
            float rotation = (float)Math.Atan2(center.Y - corner.Y, center.X - corner.X);

            // Создаём луч с рандомным цветом
            LightRay lightRay = new LightRay(
                texture: rayTexture,
                position: corner,
                rotation: rotation,
                length: 300f, // Длина луча
                focus: 1.0f, // Фокус (ширина луча)
                color: LightManager.RandomColor() // Рандомный цвет
            );

            // Добавляем луч в список
            lightManager.AddLightRay(lightRay);
        }
    }


    private float GetRotationTowards(Vector2 from, Vector2 to)
    {
        // Рассчитывает угол поворота (в радианах) от точки `from` к точке `to`
        return (float)Math.Atan2(to.Y - from.Y, to.X - from.X);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        // Получение состояния мыши
        MouseState mouseState = Mouse.GetState();

        // Обновление позиции светового пятна для мыши
        mouseLightSpot.Position = new Vector2(mouseState.X, mouseState.Y);

        // Увеличение яркости при зажатии левой кнопки мыши
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            mouseLightSpot.Brightness += 1f; // Увеличение яркости
        }
        else
        {
            // Медленное восстановление до минимального значения
            mouseLightSpot.Brightness = MathHelper.Clamp(mouseLightSpot.Brightness - 1f, 100f, float.PositiveInfinity);
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // Отрисовка фона
        spriteBatch.Begin();
        spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
        spriteBatch.End();

        // Отрисовка освещения
        lightManager.Draw(spriteBatch);

        base.Draw(gameTime);
    }
}