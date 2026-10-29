using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson05_Pong;

public class Paddle
{
    
    private const int _Width = 10, _Height = 54;
    private const float _Speed = 240;
    private Texture2D _texture;
    private Vector2 _position , _velocity;
    private Rectangle _playAreaBoundingBox;

    internal Rectangle BoundingBox
    {
        
        get{ return new Rectangle((int)_position.X, (int)_position.Y, _Width, _Height);}

    }

    internal void Initalize(Vector2 position,Rectangle playAreaBoundingBox)
    {

        _playAreaBoundingBox = playAreaBoundingBox;
        
        _position = position;

    }

    internal void LoadContent(ContentManager content)
    {
        
        _texture = content.Load<Texture2D>("Paddle");

    }

    internal void Update(GameTime gametime, Keys buttonUp, Keys buttonDown)
    {
        
        float dt = (float) gametime.ElapsedGameTime.TotalSeconds;

        KeyboardState kbstate = Keyboard.GetState();

        if(_position.Y <= _playAreaBoundingBox.Top || (_position.Y + _Height >= _playAreaBoundingBox.Bottom))
        {
            _velocity *= -1;
        }
        else if(kbstate.IsKeyDown(buttonUp)){
            _velocity = new Vector2(0, -_Speed);
        }
        else if (kbstate.IsKeyDown(buttonDown))
        {
            _velocity = new Vector2(0, _Speed);
        }
        else
        {
            _velocity = new Vector2(0, 0);
        }
        _position += _velocity * dt;

        // if(_position.Y <= _playAreaBoundingBox.Top)
        // {
        //     _position.Y = _playAreaBoundingBox.Top;
        // }
        // else if(_position.Y + _Height >= _playAreaBoundingBox.Bottom)
        // {
        //     _position.Y = _playAreaBoundingBox.Bottom - _Height;
        // }

        
    }

    internal void Draw(SpriteBatch _spriteBatch)
    {

        _spriteBatch.Draw(_texture, BoundingBox, Color.Teal);

    }

}