using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace wichacksSpring
{
    class Player : GameObject
    {
        #region Fields
        private Texture2D asset;
        private Rectangle position;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public Player(Texture2D asset, Rectangle pos)
            : base(asset, pos)
        {
            this.asset = asset;
            this.position = pos;
        }
        #endregion

        #region Methods
        public virtual void Draw()
        {
            
        }
        #endregion
    }
}
