using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson04_Key_Input;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _arial;
    private string _message = "it's september the 25th 2026";
    //60 times a second we inspect the state of the keybord 
    private KeyboardState _KbPreviousState;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _arial = Content.Load<SpriteFont>("SystemArialFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kbCurrentState = Keyboard.GetState();
        _message = "";
        if (kbCurrentState.IsKeyDown(Keys.Up))
        {
            _message += "Up";
        }
        if (kbCurrentState.IsKeyDown(Keys.Down))
        {
            _message += "Down";
        }
        if (kbCurrentState.IsKeyDown(Keys.Left))
        {
            _message += "Left";
        }
        if (kbCurrentState.IsKeyDown(Keys.Right))
        {
            _message += "Right";
        }
        if(_KbPreviousState.IsKeyUp(Keys.Space) && kbCurrentState.IsKeyDown(Keys.Space))
        {
            _message += "\n";
            _message += "space pressed\n";
            _message += "-------------------------\n";
            _message += "-------------------------\n";
            _message += "-------------------------\n";
        }
        else if (kbCurrentState.IsKeyDown(Keys.Space))
        {
            _message += "\n";
            _message += "space held";
        }
        else if (_KbPreviousState.IsKeyDown(Keys.Space))
        {
            _message += "\n";
            _message += "Space released\n";
            _message += "----------------------------------------\n";
            _message += "----------------------------------------\n";
            _message += "----------------------------------------\n";
        }

        _KbPreviousState = kbCurrentState;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.DrawString(_arial, _message, Vector2.Zero, Color.MintCream);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
