using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A22_Ex05_May_205703101_Osnat_208491605
{
    // $G$ RUL-004 (-20) Wrong zip name format / folder name format.
    // $G$ SFN-008 (-5) feedback doesn't shown corectlly.
    public static class Program
    {
        public static void Main()
        {
            StartGame startGame = new StartGame();
            startGame.ShowDialog();
        }
    }
}
