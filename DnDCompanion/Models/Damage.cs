using System;
using System.Collections.Generic;
using System.Text;

namespace DnDCompanion.Models
{
    internal sealed class Damage
    {
        public Damage() { }

        public DamageType DamageType { get; set; } = new DamageType();

        public IDictionary<short, string> DamageAtSlotLevel { get; set; } = new Dictionary<short, string>();

    }
}
