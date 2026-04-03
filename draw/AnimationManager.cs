using SFML.Graphics;

namespace test3.draw;

public class AnimationManager
{
    private readonly Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();
    private Animation? _currentAnimation;
    private string? _defaultAnimation;
    private readonly Sprite _sprite;

    /// <summary>
    /// 这个是动画管理器，为一个对象管理其所有类型的动画
    /// </summary>
    /// <param name="sprite">精灵图</param>
    public AnimationManager(Sprite sprite)
    {
        _sprite = sprite;
    }

    /// <summary>
    /// 添加一个动画
    /// </summary>
    /// <param name="name">动画名称</param>
    /// <param name="animation">动画</param>
    public void AddAnimation(string name, Animation animation)
    {
        animation.Name = name;
        _animations[name] = animation;

        if (_currentAnimation != null) return;
        _currentAnimation = animation;
        _defaultAnimation = name;
    }
    
    public void Play(string? name, bool loop = true)
    {
        if(name == null) return;
        if (!_animations.TryGetValue(name, out var animation)) return;
        // 如果已经在播放这个动画，不需要重置
        if (_currentAnimation == animation && animation.IsPlaying && !animation.IsFinished)
            return;
                
        _currentAnimation = animation;
        _currentAnimation.Play(loop);
        UpdateSpriteTextureRect();
    }
    
    /// <summary>
    /// 更新动画
    /// </summary>
    /// <param name="deltaTime">时间差</param>
    public void Update(float deltaTime)
    {
        if (_currentAnimation != null)
        {
            _currentAnimation.Update(deltaTime);
            UpdateSpriteTextureRect();
            
            // 如果当前动画播放完成，切回默认动画
            if (_currentAnimation.IsFinished && _currentAnimation.Name != _defaultAnimation)
            {
                Play(_defaultAnimation, true);
            }
        }
    }
    
    private void UpdateSpriteTextureRect()
    {
        if (_currentAnimation != null)
        {
            _sprite.TextureRect = _currentAnimation.GetCurrentFrame();
        }
    }
    
    public void Stop()
    {
        _currentAnimation?.Stop();
    }
    
    // public string GetCurrentAnimationName()
    // {
    //     return _currentAnimation?.Name ?? string.Empty;
    // }
}