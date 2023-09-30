using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LungPae.Manager;

namespace LungPae.Core
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameStateManager gsm;
       // SpriteFont f;
        //Texture2D tx;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
           
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = Data.ScreenW;
            _graphics.PreferredBackBufferHeight = Data.ScreenH;
            _graphics.ApplyChanges();
            gsm = new GameStateManager();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //f = Content.Load<SpriteFont>("Font");
          //  tx = Content.Load<Texture2D>("Dwarf");
            gsm.LoadContent( Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            gsm.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            //   _spriteBatch.Draw(tx,new Vector2(200,400),Color.White);
            //_spriteBatch.DrawString(f,"Hello", new Vector2(300, 500), Color.Wheat);
            gsm.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}