using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millionaire.Game.Code
{
    [Serializable]
    public class ViewStateItem
    {
        public int CurrentStep { get; set; }
        public DateTime Time { get; set; }
    }
}