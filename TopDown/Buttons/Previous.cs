using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Buttons
{
    class Previous : Button
    {
        private static String name = "Previous";
        public Previous(Vector2 position) : base (position, name)
        {
        }

        public override void TakeAction()
        {
			PreviousItem();
			MenuController.ShopMessage = "Click \"Buy\" to Buy the Selected Item";
		}

		private void PreviousItem()
		{
			BoughtController.PreviousItem();
		}
    }
}
