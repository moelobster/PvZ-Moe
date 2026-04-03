using SFML.Graphics;
using SFML.System;

namespace test3.draw;

public abstract class AbstractZombie: AbstractDrawable
{
    protected AnimationManager AnimationManager;
    protected Vector2f Position;

    public enum AnimationState
    {
        Idle
    }

    /// <summary>
    /// 这是个僵尸的抽象类
    /// </summary>
    /// <param name="backTexturePath"> 纹理路径 </param>
    protected AbstractZombie(string backTexturePath) : base(backTexturePath)
    {
        // 加载纹理
        BackTexture = new Texture(backTexturePath);
        BackSprite = new Sprite(BackTexture);
        // 创建动画管理器
        AnimationManager = new AnimationManager(BackSprite);
    }

    public abstract void SetupAnimations();
    
    public override void Update(float deltaTime)
    {
        // 更新动画
        AnimationManager.Update(deltaTime);
    }
    
    public override void Draw(IRenderTarget target)
    {
        target.Draw(BackSprite);
    }
    
    public void SetPosition(Vector2f newPosition)
    {
        Position = newPosition;
        BackSprite.Position = Position;
    }

    public abstract void PlayAnimation(AnimationState state);
    
}