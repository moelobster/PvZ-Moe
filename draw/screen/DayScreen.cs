using SFML.Graphics;
using SFML.System;
using test3.util;

namespace test3.draw.screen;

public class DayScreen: AbstractScreen
{
    public DayScreen(RenderWindow window, string name) : 
        base(name, "../../../assets/day.jpg")
    {
        var y = window.Size.Y;

        var bgscale = (float)y / BackTexture.Size.Y;
        BackSprite = SpriteBuilder.LeftTop(
            BackSprite,
            new Vector2f(0,0),
            new Vector2f(bgscale, bgscale)
        );
    }
    
}