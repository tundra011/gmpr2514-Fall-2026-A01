using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lukas_Wieland_Assignment02;

public class Ball
{
    
    private const int _widthAndHeight = 21, _CollisionTimerInterval = 400;
    private Texture2D _texture;
    private Vector2 _postition , _velocity;
    private Rectangle _playAreaBoundingBox;
    private int _collisionTimerMill;

    internal Rectangle Boundingbox
    {
        get{ return new Rectangle((int)_postition.X, (int)_postition.Y, _widthAndHeight, _widthAndHeight );}
    }

    internal void Initalize(Rectangle playAreaBoundingBox)
    {
        
        _playAreaBoundingBox = playAreaBoundingBox;
        _postition = new Vector2(150,195);
        _velocity = new Vector2(-60,-60);

    }

    internal void LoadContent(ContentManager content)
    {
        
        _texture = content.Load<Texture2D>("Ball");

    }
    
    internal void Update(GameTime gametime)
    {
        
        _collisionTimerMill += gametime.ElapsedGameTime.Milliseconds;

        float dt = (float) gametime.ElapsedGameTime.TotalSeconds;

        _postition += _velocity * dt;

        //bounce off sides and the top and bottom
        if(_postition.X <= _playAreaBoundingBox.Left || (_postition.X + _widthAndHeight) >= _playAreaBoundingBox.Right)
        {
            _velocity.X *= -1;
        }

        if(_postition.Y <=_playAreaBoundingBox.Top || (_postition.Y + _widthAndHeight >= _playAreaBoundingBox.Bottom))
        {
            _velocity.Y *= -1;
        }

    }

    internal void Draw(SpriteBatch _spriteBatch)
    {
        
        Rectangle ballRectangle = new Rectangle( (int)_postition.X, (int)_postition.Y, _widthAndHeight, _widthAndHeight);

        _spriteBatch.Draw(_texture, ballRectangle, Color.White);

    }

    internal bool ProccessCollision(Rectangle otherBox)
    {
        
        bool didCollide = false;

        if (_collisionTimerMill >= _CollisionTimerInterval && Boundingbox.Intersects(otherBox))
        {
            didCollide = true;
            _collisionTimerMill = 0;
            Rectangle intersection = Rectangle.Intersect(Boundingbox, otherBox);
            if(intersection.Width > intersection.Height)
            {
                _velocity.Y *= -1;
            }
            else
            {
                _velocity.X *= -1;
            }
        }

        return didCollide;

    }

}