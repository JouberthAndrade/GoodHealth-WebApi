﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Shared.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();

    }
}
