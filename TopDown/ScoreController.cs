using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDown
{
    class ScoreController
    {
        public static int score = 0;

        public static void Add(int points)
        {
            score += points;
        }
    }
}
