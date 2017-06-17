using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown.Buttons
{
    class Buy : Button
    {
        private static String name = "Buy";
        public Buy(Vector2 position) : base (position, name)
        {
        }

        public override void TakeAction()
        {
			BuyItem(BoughtController.GetCurrentItem());
        }

		private void BuyItem(string item)
		{
			BoughtController.buy(item);
		}
    }
}
