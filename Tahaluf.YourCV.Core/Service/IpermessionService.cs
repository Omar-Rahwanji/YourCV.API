﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.YourCV.Core.Data;

namespace Tahaluf.YourCV.Core.Service
{
   public interface IPermessionService
    {
        bool CreatePermession(Permession Permession);
        bool UpdatePermession(Permession Permession);
        bool DeletePermession(int id);
        List<Permession> GetPermessionByName(Permession Permession);
        List<Permession> GetPermessionById(Permession Permession);
        List<Permession> GetAllPermession();
    }
}
