using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Lesson01;

public class SimpleGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _pixle;

    // private int _xPosition, _yPosition, _width, _height;
    private Vector2 _position, _dimensions;

    private Color _rectangleColor;
    private bool _isVisible;

    public SimpleGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _position = new Vector2(100,150);
        _dimensions = new Vector2(300,200);
        // _xPosition = 100;
        // _yPosition = 150;
        // _width = 300;
        // _height = 200;

        _rectangleColor = Color.DarkCyan;
        _isVisible = true;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // create a 1x1 pixle object
        _pixle = new Texture2D(GraphicsDevice, 1,1);
        _pixle.SetData(new [] {Color.White});

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Color.CornflowerBlue);

        if (_isVisible) {

            _spriteBatch.Begin();
            // Rectangle rect = new Rectangle(_xPosition, _yPosition, _width, _height);
            // the x any y values stored in Vector2 are floats while in a rect they are a int
             Rectangle rect = new Rectangle( (int)_position.X , (int)_position.Y , (int)_dimensions.X , (int)_dimensions.Y);
           _spriteBatch.Draw(_pixle,rect, _rectangleColor);
            _spriteBatch.End();

        }
        // TODO: Add your drawing code here
        base.Draw(gameTime);

    }

}
