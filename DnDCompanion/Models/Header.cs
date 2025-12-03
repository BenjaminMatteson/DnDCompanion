using System;
using System.Collections.Generic;
using System.Text;

namespace DnDCompanion.Models
{
    internal sealed class Header
    {
        public Header() { }
        public string Index { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
