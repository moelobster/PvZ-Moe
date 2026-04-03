using SFML.Graphics;

namespace test3.draw.screen;

public abstract class AbstractScreen(string name, string backTexturePath) 
    : AbstractDrawable(backTexturePath)
{
    public string Name = name;
    protected Dictionary<string, Sprite>? Sprites;

    public virtual void AddSprite(string name, Sprite sprite)
    {
        Sprites ??= new Dictionary<string, Sprite>();
        Sprites[name] = sprite;
    }
    
    public virtual Sprite? GetSprite(string key)
    {
        return Sprites?.GetValueOrDefault(key);
    }
    
    public override void Update(float deltaTime)
    {
        // Sprites 不需要 Update，子类可重写
    }
    
    public override void Draw(IRenderTarget target)
    {
        // 先绘制背景
        target.Draw(BackSprite);
        // 再绘制子 Sprites
        if (Sprites == null) return;
        foreach (var sprite in Sprites.Values)
        {
            target.Draw(sprite);
        }
    }
}