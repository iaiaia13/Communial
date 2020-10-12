using Microsoft.IdentityModel.Tokens;
using NetCoreData.Models;
using NetCoreData.ReposInterface;
using NetCoreServer.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCoreServer.Services
{
    public class OfficeService : IOfficeService
    {
        private IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository foodRepository)
        {
            this._officeRepository = foodRepository;
        }

        public IEnumerable<Office> Search(OfficeFilterViewModel viewModel)
        {
            var model = new OfficeFilterModel
            {
                Name = viewModel.Name,
                Address = viewModel.Name,
                Capacity = string.IsNullOrEmpty(viewModel.StrCapacity) ? 0 : int.Parse(viewModel.StrCapacity),
                PriceFrom = string.IsNullOrEmpty(viewModel.PriceFrom) ? 0 : int.Parse(viewModel.PriceFrom),
                PriceTo = string.IsNullOrEmpty(viewModel.PriceTo) ? 0 : int.Parse(viewModel.PriceTo),
            };

            var result = _officeRepository.Search(model);
            return result;
        }
    }
}