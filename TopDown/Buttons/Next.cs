using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Buttons
{
    class Next : Button
    {
        private static String name = "Next";
        public Next(Vector2 position) : base (position, name)
        {
        }

        public override void TakeAction()
        {
			NextItem();
			MenuController.ShopMessage = "Click \"Buy\" to Buy the Selected Item";
        }

		private void NextItem()
		{
			BoughtController.NextItem();
		}
    }
}
