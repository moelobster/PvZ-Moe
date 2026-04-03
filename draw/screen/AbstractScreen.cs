using SFML.Graphics;

namespace test3.draw.screen;

public abstract class AbstractScreen(string name, string backTexturePath) 
    : AbstractDrawable(backTexturePath)
{
    public string Name = name;
    protected Dictionary<string, Sprite>? Drawables;

    public virtual void AddSprite(string name, Sprite drawable)
    {
        Drawables ??= new Dictionary<string, Sprite>();
        Drawables[name] = drawable;
    }
    
    public virtual Sprite? GetDrawable(string key)
    {
        return Drawables?.GetValueOrDefault(key);
    }
    
    public override void Update(float deltaTime)
    {
        // Sprites 不需要 Update，子类可重写
    }
    
    public override void Draw(IRenderTarget target)
    {
        // 先绘制背景
        target.Draw(BackSprite);
        // 再绘制子 Drawables
        if (Drawables == null) return;
        foreach (var drawable in Drawables.Values)
        {
            target.Draw(drawable);
        }
    }
}