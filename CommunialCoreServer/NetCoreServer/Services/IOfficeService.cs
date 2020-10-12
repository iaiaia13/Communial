using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.ViewModels;
using System.Collections.Generic;

namespace NetCoreServer.Services
{
    public interface IOfficeService
    {
        public IEnumerable<Office> Search(OfficeFilterViewModel viewModel);
    }
}