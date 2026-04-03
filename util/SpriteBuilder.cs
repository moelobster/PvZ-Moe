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
    public static Sprite Center(Sprite sprite, Vector2f position)
    {
        return Center(sprite, position, new  Vector2f(1, 1));
    }
    
    /// <summary>
    /// 这是Center方法的重载，可以设置缩放比例
    /// </summary>
    /// <param name="sprite"> 要设置的Sprite</param>
    /// <param name="position"> 要设置的贴图定位点位置</param>
    /// <param name="scale"> 要设置的贴图缩放比例</param>
    /// <returns></returns>
    public static Sprite Center(Sprite sprite, Vector2f position,Vector2f scale)
    {
        var size = new Vector2f(sprite.TextureRect.Width, sprite.TextureRect.Height);
        sprite.Position = new Vector2f(position.X - size.X / 2 * scale.X, position.Y - size.Y / 2 * scale.Y);
        sprite.Scale = scale;
        return sprite;
    }

    /// <summary>
    /// 这是LeftTop方法，可以设置缩放比例
    /// </summary>
    /// <param name="sprite"> 要设置的Sprite</param>
    /// <param name="position"> 要设置的贴图定位点位置</param>
    /// <returns></returns>
    public static Sprite LeftTop(Sprite sprite, Vector2f position)
    {
        return LeftTop(sprite, position, new  Vector2f(1, 1));
    }

    /// <summary>
    /// 这是LeftTop方法的重载，可以设置缩放比例
    /// </summary>
    /// <param name="sprite"> 要设置的Sprite</param>
    /// <param name="position"> 要设置的贴图定位点位置</param>
    /// <param name="scale"> 要设置的贴图缩放比例</param>
    /// <returns></returns>
    public static Sprite LeftTop(Sprite sprite, Vector2f position, Vector2f scale)
    {
        sprite.Position = position;
        sprite.Scale = scale;
        return sprite;
    }
}