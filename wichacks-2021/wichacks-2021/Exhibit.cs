using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace wichacksSpring
{
    class Exhibit : GameObject
    {
        #region Fields
        private Texture2D asset;
        private Rectangle position;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        protected Exhibit(Texture2D asset, Rectangle pos)
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
