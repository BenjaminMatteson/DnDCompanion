using System;
using System.Collections.Generic;
using System.Text;

namespace DnDCompanion.Classes
{
    public sealed class SpellListItem
    {
        public SpellListItem(string index, string name, short level, string url)
        {
            Index = index;
            Name = name;
            Level = level;
            Url = url;
        }

        public string Index { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public short Level { get; set; } = 0;
        public string Url { get; set; } = string.Empty;
    }
}
