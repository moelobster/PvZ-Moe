using SFML.Graphics;
using SFML.System;

namespace test3;


public class AnimationFrame
{
    public IntRect TextureRect { get; set; }
    public float Duration { get; set; } // 这一帧显示的时间（秒）
    
    /// <summary>
    /// 这个类表示一个动画帧，包含一个矩形区域和一个显示时间
    /// </summary>
    /// <param name="rect">矩形区域</param>
    /// <param name="duration">显示时间</param>
    public AnimationFrame(IntRect rect, float duration)
    {
        TextureRect = rect;
        Duration = duration;
    }
}

public class Animation
{
    public float FrameRate { get; set; } = 24f;//frame per seconds
    
    private readonly List<AnimationFrame> _frames = new List<AnimationFrame>();
    private float _currentTime = 0f;//当前时间
    private int _currentFrameIndex = 0;//当前帧索引
    private bool _isPlaying = false;//是否正在播放
    private bool _loop = true;//是否循环

    /// <summary>
    /// 创建一个动画，并指定名称
    /// </summary>
    /// <param name="name"> 动画名称 </param>
    public Animation(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    
    public bool IsPlaying => _isPlaying;
    
    public bool IsFinished => !_loop && _currentFrameIndex >= _frames.Count - 1;
    
    public void AddFrame(IntRect rect, float duration = -1f)
    {
        float frameDuration = duration > 0 ? duration : 1f / FrameRate;
        _frames.Add(new AnimationFrame(rect, frameDuration));
    }
    
    public void AddFrame(int x, int y, int width, int height, float duration = -1f)
    {
        AddFrame(new IntRect(new Vector2i(x,y),new Vector2i(width,height)), duration);
    }
    
    //经过deltaTime时间，尝试更新动画
    public void Update(float deltaTime)
    {
        // 如果没有播放或者没有帧，则返回
        if (!_isPlaying || _frames.Count == 0) return;
        // 更新当前时间
        _currentTime += deltaTime;
        
        // 检查是否需要切换到下一帧
        while (_currentTime >= _frames[_currentFrameIndex].Duration)
        {
            // 减去当前帧的时间，并切换到下一帧
            _currentTime -= _frames[_currentFrameIndex].Duration;
            _currentFrameIndex++;
            
            //播放到最后一帧，如果循环则返回第一帧，否则停止播放
            if (_currentFrameIndex >= _frames.Count)
            {
                if (_loop)
                {
                    _currentFrameIndex = 0;
                }
                else
                {
                    _currentFrameIndex = _frames.Count - 1;
                    Stop();
                    break;
                }
            }
        }
    }
    
    public IntRect GetCurrentFrame()
    {
        if (_frames.Count == 0)
        {
            return new IntRect(new Vector2i(0,0),new Vector2i(32,32)); // 默认大小
        }
        return _frames[_currentFrameIndex].TextureRect;
    }
    
    public void Play(bool loopAnimation = true)
    {
        _isPlaying = true;
        _loop = loopAnimation;
        _currentFrameIndex = 0;
        _currentTime = 0f;
    }

    public void Stop()
    {
        _isPlaying = false;
    }
    
    public void Pause()
    {
        _isPlaying = false;
    }
    
    public void Resume()
    {
        _isPlaying = true;
    }
    
    public void Reset()
    {
        _currentFrameIndex = 0;
        _currentTime = 0f;
    }
    
}