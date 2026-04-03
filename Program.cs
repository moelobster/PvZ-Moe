using SFML.Graphics;
using SFML.System;
using SFML.Window;
using test3.draw.screen;

namespace test3;

class Program
{
    private static readonly RenderWindow GameWindow = new RenderWindow(new VideoMode(new Vector2u(1600,900)), "Game Window",Styles.Close, State.Windowed);

    private static AbstractScreen _currentScreen = new StartScreen(GameWindow,"start_screen");
    // private static LittleZombie _littleZombie = new LittleZombie("../../../assets/little_zombie.png");
    
    private static readonly Clock GameClock = new();
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        GameWindow.Closed += (s, e) => GameWindow.Close();
        GameWindow.KeyPressed += (s, e) =>
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                GameWindow.Close();
            }
        };
        GameWindow.KeyPressed += (s, e) =>
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                _currentScreen = new StartScreen(GameWindow, "start_screen");
            }
        };
        GameWindow.KeyPressed += (s, e) =>
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                _currentScreen = new DayScreen(GameWindow, "day_screen");
            }
        };
        
        // _littleZombie.SetPosition(new Vector2f(100, 100));
        // _littleZombie.SetupAnimations();
        
        // 将 LittleZombie 添加到当前 Screen 的可绘制对象列表
        // _currentScreen.AddDrawable(_littleZombie);
        
        while (GameWindow.IsOpen)
        {
            GameWindow.DispatchEvents();
            GameWindow.Clear(Color.Black);
            Update();
            // 统一使用 Screen 的 Draw 方法渲染所有内容
            _currentScreen.Draw(GameWindow);
            GameWindow.Display();
        }
    }
    
    private static void Update()
    {
        // 统一计算增量时间
        var deltaTime = GameClock.Restart().AsSeconds();
        
        // 更新当前 Screen（会自动更新其包含的所有可绘制对象）
        _currentScreen.Update(deltaTime);
        
        // 播放僵尸动画
        // _littleZombie.PlayAnimation(AbstractZombie.AnimationState.Idle); 
    }
}