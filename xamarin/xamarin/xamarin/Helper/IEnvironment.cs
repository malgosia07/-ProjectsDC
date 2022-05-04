using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace xamarin.Helper
{
    interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
