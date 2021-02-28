using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace wichacksSpring
{
    class Slide : GameObject
    {
        #region Fields
        private Texture2D asset;
        private Rectangle position;
        private bool isClicked;
        #endregion

        #region Properties
        public bool IsClicked { get { return this.isClicked; } }
        #endregion

        #region Constructor
        public Slide(Texture2D asset, Rectangle pos)
            :base(asset, pos)
        {
            this.asset = asset;
            this.position = pos;
        }
        #endregion

        #region Methods
        public void ClickSlide()
        {

        }
        public void DisplaySlide()
        {

        }
        #endregion
    }
}
