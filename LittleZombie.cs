using SFML.Graphics;

namespace test3;

public class LittleZombie(string backTexturePath) : AbstractZombie(backTexturePath)
{
    public override void SetupAnimations()
    {
        var idleAnimation = new Animation("idle");
        for (int i = 0; i < 12; i++)
        {
            idleAnimation.AddFrame(i * 81, 0, 81, 110, 0.1f);
        }
        AnimationManager.AddAnimation("idle", idleAnimation);
    }

    public override void PlayAnimation(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.Idle:
                AnimationManager.Play("idle", true);
                break;
        }
    }
}