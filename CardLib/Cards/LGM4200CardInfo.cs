using System;

namespace CardLibrary.Cards
{
    public class Lgm4200CardInfo : CardInfo
    {
        public override string IDString
        {
            get
            {
                var s = string.Empty;
                for (var i = 0; i < idLen; i++)
                {
                    s += $"{id[i]:X02}";
                }

                return s;
            }
        }
    }
}
