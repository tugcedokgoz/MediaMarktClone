﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Repository
{

    /*
     *RepositoryBase<Kategori>
     *RepositoryBase<Rol>
     *RepositoryBase<Kullanici>
     *tek tek yazmaktansa toplu halde aşağıdaki gibi yapıyoruz <T> generic bir yapı kullanıyoruz 
     *
     *new diye üretmemek için abstract diye tanımlıyoruz
     */
    public abstract class RepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        //bütün kayıtları getirir
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        //koşula göre getirme
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        //kayıt ekleme
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
