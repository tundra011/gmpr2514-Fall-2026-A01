using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Lukas_Wieland_Assignment02;

public class Blocker
{
    
    private const int _Width = 10, _Height = 54;
    private Texture2D _texture;
    private Vector2 _position ;


    internal Rectangle BoundingBox
    {
        
        get{ return new Rectangle((int)_position.X, (int)_position.Y, _Width, _Height);}

    }

    internal void Initalize(Vector2 position)
    {
        
        _position = position;

    }

    internal void LoadContent(ContentManager content)
    {
        
        _texture = content.Load<Texture2D>("Paddle");

    }

    internal void Draw(SpriteBatch _spriteBatch)
    {

        _spriteBatch.Draw(_texture, BoundingBox, Color.White);

    }

}