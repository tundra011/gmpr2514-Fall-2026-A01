using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lukas_Wieland_Assignment02;

public class Pong : Game
{
    private const int _WindowWidth = 750, _WindowHeight = 450, _PlayAreaEdgeLineWidth = 12;
    private Ball _ball;
    private Paddle _paddle01, _paddle02;
    private Blocker _blocker;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _backgroundTexture;
    private Vector2  _paddlePosition, _paddlePosition2, _blockerPosition;
    private Rectangle PlayAreaBoundingBox
    {
        get
        {
            return new Rectangle(0,_PlayAreaEdgeLineWidth, _WindowWidth, _WindowHeight - (_PlayAreaEdgeLineWidth *2));
        }
    } 

    public Pong()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        _graphics.ApplyChanges();

        _paddlePosition = new Vector2(690,198);
        _paddlePosition2 = new Vector2(60,198);
        _blockerPosition = new Vector2(386,198);

        _ball = new Ball();
        _ball.Initalize(PlayAreaBoundingBox);

        _paddle01 = new Paddle();
        _paddle01.Initalize(_paddlePosition, PlayAreaBoundingBox);

        _paddle02 = new Paddle();
        _paddle02.Initalize(_paddlePosition2, PlayAreaBoundingBox);

        _blocker = new Blocker();
        _blocker.Initalize(_blockerPosition);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _backgroundTexture = Content.Load<Texture2D>("Court");
        _ball.LoadContent(Content);
        _paddle01.LoadContent(Content);
        _paddle02.LoadContent(Content);
        _blocker.LoadContent(Content);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        float dt = (float) gameTime.ElapsedGameTime.TotalSeconds;

        _ball.Update(gameTime);
        _paddle01.Update(gameTime, Keys.Up, Keys.Down);
        _paddle02.Update(gameTime, Keys.W, Keys.S);

        if (_ball.ProccessCollision(_paddle01.BoundingBox ) || _ball.ProccessCollision(_paddle02.BoundingBox)|| _ball.ProccessCollision(_blocker.BoundingBox))
        {

        }
    

        // Rectangle paddleBoundingBox = new Rectangle((int)_paddlePosition.X,(int)_paddlePosition.Y,_PaddleWidth,_PaddleHeight);
        // Rectangle ballBoundingBox = new Rectangle((int)_ballPostition.X,(int)_ballPostition.Y,_BallWidthAndHeight,_BallWidthAndHeight);
        // Rectangle paddle2Boundingbox = new Rectangle((int)_paddlePosition2.X,(int)_paddlePosition2.Y,_PaddleWidth,_PaddleHeight);

        // bool colliding = ballBoundingBox.Intersects(paddleBoundingBox);
        // bool colliding2 = ballBoundingBox.Intersects(paddle2Boundingbox);
        // if (colliding)
        // {

        //     _ballVelocity.X *= -1;
        //     _paddleHits += 1;

        //     if(_paddleHits == _SpeedUpRequiredHits)
        //     {
        //         _ballVelocity.X += -20;
        //         _ballVelocity.Y += -20;
        //         _paddleHits = 0;
        //     }

        // }
        // if (colliding2)
        // {

        //     _ballVelocity.X *= -1;
        //     _paddleHits += 1;

        //     if(_paddleHits == _SpeedUpRequiredHits)
        //     {
        //         _ballVelocity.X += 20;
        //         _ballVelocity.Y += 20;
        //         _paddleHits = 0;
        //     }
    
        // }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(_backgroundTexture,new Rectangle(0,0  , _WindowWidth, _WindowHeight), Color.White);

        _ball.Draw(_spriteBatch);
        _paddle01.Draw(_spriteBatch);
        _paddle02.Draw(_spriteBatch);
        _blocker.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
