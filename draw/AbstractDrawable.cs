using SFML.Graphics;

namespace test3.draw;

public abstract class AbstractDrawable
{
    protected Sprite BackSprite;
    protected Texture BackTexture;
    
    protected AbstractDrawable(Texture backTexture)
    {
        BackTexture = backTexture;
        BackSprite = new Sprite(BackTexture);
    }
    
    protected AbstractDrawable(string backTexturePath)
    {
        BackTexture = new Texture(backTexturePath);
        BackSprite = new Sprite(BackTexture);
    }

    public abstract void Update(float deltaTime);

    public abstract void Draw(IRenderTarget target);
}