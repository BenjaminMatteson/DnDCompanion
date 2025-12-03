using System;
using System.Collections.Generic;
using System.Text;

namespace DnDCompanion.Services
{
    public interface IAPIService
    {
        public Task<IList<Models.SpellListItem>> GetSpellsList(CancellationToken cancellationToken = default);
        public Task<ViewModels.Spells.SpellDetailsViewModel> GetSpellDetails(string spellIndex, CancellationToken cancellationToken = default);
    }
}
