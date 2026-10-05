using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lukas_Wieland_Assignment01;

public class Assignment01 : Game
{
    private const int _WindowWidth = 240, _WindowHeight = 220, _PlayAreaEdgeLineWidth = 1;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _rock, _backGroundTexture;
    private SpriteFont _arial;
    private string _output = "lol";
    private SimpleAnimation _bird, _explosion;
    private KeyboardState _KbPreviousState;
    private Vector2 _birdPosition, _RockVelocity, _RockPosition;
    private Rectangle PlayAreaBoundingBox
    {
        get
        {
            return new Rectangle(0,_PlayAreaEdgeLineWidth, _WindowWidth, _WindowHeight - (_PlayAreaEdgeLineWidth *2));
        }
    } 

    public Assignment01()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 240;
        _graphics.PreferredBackBufferHeight = 220;
        _graphics.ApplyChanges();

        _RockPosition = new Vector2(150,195);
        _RockVelocity = new Vector2(20,-20);


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        _arial = Content.Load<SpriteFont>("SystemArialFont");
        _backGroundTexture = Content.Load<Texture2D>("forest-road-preview");
        _rock = Content.Load<Texture2D>("rocks-3");
        Texture2D birdFrame = Content.Load<Texture2D>("flying-creature-cycle");
        Texture2D explosionFrame = Content.Load<Texture2D>("spritesheet");

        _bird = new SimpleAnimation(birdFrame, 32, 32, 7, 7);
        _explosion = new SimpleAnimation(explosionFrame, 64, 64, 8, 8);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _bird.Update(gameTime);
        _explosion.Update(gameTime);
        float dt = (float) gameTime.ElapsedGameTime.TotalSeconds;

        _RockPosition += _RockVelocity * dt;

        if(_RockPosition.X <= PlayAreaBoundingBox.Left || (_RockPosition.X + 12) >= PlayAreaBoundingBox.Right)
        {
            _RockVelocity.X *= -1;
        }

        if(_RockPosition.Y <= PlayAreaBoundingBox.Top || (_RockPosition.Y + 12 >= PlayAreaBoundingBox.Bottom))
        {
            _RockVelocity.Y *= -1;
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(_backGroundTexture, Vector2.Zero, Color.White);
        _spriteBatch.DrawString(_arial, _output, new Vector2(20, 20), Color.White);
        _bird.Draw(_spriteBatch,new Vector2(120,120), SpriteEffects.None);
        _explosion.Draw(_spriteBatch, new Vector2(50,50), SpriteEffects.None);
        Rectangle ballRectangle = new Rectangle( (int)_RockPosition.X, (int)_RockPosition.Y, 12, 12);

        _spriteBatch.Draw(_rock, ballRectangle, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
