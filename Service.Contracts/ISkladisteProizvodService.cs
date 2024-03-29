﻿using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISkladisteProizvodService
    {
        Task<(IEnumerable<SkladisteProizvodDto> skladisteProizvodi, MetaData metaData)> GetAllProizvodiAsync(SkladisteProizvodParameters proizvodParameters, Guid skladisteId, bool trackChanges);
        Task<SkladisteProizvodDto> GetProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges);
        Task<SkladisteProizvodDto> AddProizvodAsync(SkladisteProizvodForCreationDto skladisteProizvod);
        Task OrderProizvodAsync(SkladisteProizvodForOrderDto skladisteProizvod, bool trackChanges);
        Task DeliverProizvodAsync(SkladisteProizvodForDeliveryDto skladisteProizvod, bool trackChanges);
        Task RemoveProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges);
    }
}
