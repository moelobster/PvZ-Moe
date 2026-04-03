using SFML.Graphics;
using SFML.System;
using test3.util;

namespace test3.draw.screen;

public sealed class StartScreen : AbstractScreen
{
    private Texture TitleTexture;

    public StartScreen(RenderWindow window, string name)
        : base(name, "../../../assets/title_background_screen.jpg")
    {
        TitleTexture = new Texture("../../../assets/title_text.png");
        // 缩放背景以适应窗口
        var (x, y) = (window.Size.X, window.Size.Y);
        
        var (bgx, bgy) = (BackTexture.Size.X, BackTexture.Size.Y);
        var bgscale = Math.Max((float)x / bgx, (float)y / bgy);
        BackSprite = SpriteBuilder.Center(
            BackSprite,
            new Vector2f((float)x / 2, (float)y / 2),
            new Vector2f(bgx, bgy),
            new Vector2f(bgscale, bgscale)
        );
        
        var titleSprite = new Sprite(TitleTexture);
        var (ttx, tty) = (TitleTexture.Size.X, TitleTexture.Size.Y);
        var titleScale = x * 0.75f / ttx;
        titleSprite = SpriteBuilder.Center(
            titleSprite,
            new Vector2f((float)x / 2, (float)y / 7),
            new Vector2f(ttx, tty),
            new Vector2f(titleScale, titleScale)
        );
        AddSprite("title", titleSprite);
    }
}