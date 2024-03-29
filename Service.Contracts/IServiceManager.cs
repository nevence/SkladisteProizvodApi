﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ISkladisteService SkladisteService { get; }
        IProizvodService ProizvodService { get; }
        ISkladisteProizvodService SkladisteProizvodService {  get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
