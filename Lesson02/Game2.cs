using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson02;

public class Game2 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _pixle;

    private Vector2 _position, _dimensions;

    private int _count;
    private float _spacing;

    public Game2()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        _position = new Vector2(50, 200);
        _dimensions = new Vector2(60, 40);

        _count = 6;
        _spacing = 10;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _pixle = new Texture2D(GraphicsDevice, 1, 1);
        _pixle.SetData(new[] { Color.White });

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

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        for(int i = 0; i < _count; i++)
        {
            float x = _position.X + i * (_dimensions.X + _spacing);
            Rectangle r = new Rectangle((int)x, (int)_position.Y, (int)_dimensions.X,(int)_dimensions.Y);
            _spriteBatch.Draw(_pixle, r, Color.Green);
        }
        
        _spriteBatch.End();



        base.Draw(gameTime);
    }
}
