﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Repositories

{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ToursContext RepositoryContext { get; set; }

        public RepositoryBase( ToursContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

public async Task<List<T>> FindAll() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) => await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();

        public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);
        public async Task Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public async Task Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}