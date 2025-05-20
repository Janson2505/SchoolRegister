﻿using SchoolRegister.Dal.EF;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
namespace SchoolRegister.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext DbContext = null!;
        protected readonly ILogger Logger = null!;
        protected readonly IMapper Mapper = null!;
        public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
    }
}