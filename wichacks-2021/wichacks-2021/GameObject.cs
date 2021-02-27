using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace wichacksSpring
{
    abstract class GameObject
    {
        #region Fields
        private Texture2D asset;
        private Rectangle position;
        #endregion

        #region Properties
        public Rectangle Position { get { return this.position; } }
        #endregion

        #region Constructor
        public GameObject(Texture2D asset, Rectangle pos)
        {
            this.asset = asset;
            this.position = pos;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tells the object to draw itself
        /// </summary>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(asset, position, Color.White);
        }
        #endregion
    }
}
