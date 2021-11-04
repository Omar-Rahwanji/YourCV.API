﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.YourCV.Core.Common;
using Tahaluf.YourCV.Core.Data;

namespace Tahaluf.YourCV.Core.Repository
{
    public interface IEducationRepository
    {
        bool CreateEducation(Education education);
        Education GetEducation(int id);
        Education GetEducationByResumeId(int resumeId); 
        IEnumerable<Education> GetAllEducation();
        bool UpdateEducation(Education education);
        bool DeleteEducation(int id);
        bool DeleteEducationByResumeId(int resumeId);
    }
}
