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
        
        var bgscale = Math.Max((float)x / BackTexture.Size.X, (float)y / BackTexture.Size.Y);
        BackSprite = SpriteBuilder.Center(
            BackSprite,
            new Vector2f((float)x / 2, (float)y / 2),
            new Vector2f(bgscale, bgscale)
        );
        
        var titleSprite = new Sprite(TitleTexture);
        var titleScale = x * 0.75f / TitleTexture.Size.X;
        titleSprite = SpriteBuilder.Center(
            titleSprite,
            new Vector2f((float)x / 2, (float)y / 7),
            new Vector2f(titleScale, titleScale)
        );
        AddSprite("title", titleSprite);
    }
}