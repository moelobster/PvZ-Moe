using SFML.Graphics;
using SFML.System;

namespace test3.util;

public class SpriteBuilder
{
    /// <summary>
    /// 这是Center方法，可以设置缩放比例
    /// </summary>
    /// <param name="sprite"> 要设置的Sprite</param>
    /// <param name="position"> 要设置的贴图定位点位置</param>
    /// <param name="size"> 要设置的贴图大小</param>
    /// <returns></returns>
    public static Sprite Center(Sprite sprite, Vector2f position,Vector2f size)
    {
        sprite.Position = new Vector2f(position.X - size.X / 2, position.Y - size.Y / 2);
        sprite.Scale = new Vector2f(1, 1);
        return sprite;
    }
    
    /// <summary>
    /// 这是Center方法的重载，可以设置缩放比例
    /// </summary>
    /// <param name="sprite"> 要设置的Sprite</param>
    /// <param name="position"> 要设置的贴图定位点位置</param>
    /// <param name="size"> 要设置的贴图大小</param>
    /// <param name="scale"> 要设置的贴图缩放比例</param>
    /// <returns></returns>
    public static Sprite Center(Sprite? sprite, Vector2f position,Vector2f size,Vector2f scale)
    {
        sprite.Scale = scale;
        sprite.Position = new Vector2f(position.X - size.X / 2 * scale.X, position.Y - size.Y / 2 * scale.Y);
        
        return sprite;
    }
}