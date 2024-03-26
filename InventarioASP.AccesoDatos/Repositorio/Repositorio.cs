using InventarioASP.AccesoDatos.Data;
using InventarioASP.AccesoDatos.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventarioASP.AccesoDatos.Repositorio
{                                 // control + . para implementar interfaz                      
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        // utilizamos un DbContext y le asignamos un nombre en este caso _db
        private readonly ApplicationDbContext _db;
        // utilizamos una propiedad agrego el objeto con el que voy a trabajar "T" y le asino nombre dbSet
        internal DbSet <T> dbSet;

        // Creamos el constructor e inicializamos

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad); // inser in to table
        }

        public  async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id); // select * from (solo por id)
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null, bool isTracking = true)
        {
                IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); //select /* from where
            }

            if (incluirPropiedades != null)

            {
                foreach (var incluirprop in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(incluirprop);
                }
                
            }

            if (orderBy != null) 
            
            {
                query = orderBy(query);
            
            }

            if (!isTracking) 
            {
            
                query = query.AsNoTracking();
            
            }

            return await query.ToListAsync();

        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro); //select /* from where
            }

            if (incluirPropiedades != null)

            {
                foreach (var incluirprop in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirprop);
                }

            }

            
            if (!isTracking)
            {

                query = query.AsNoTracking();

            }

            return await query.FirstOrDefaultAsync();
        }

        public void Remover(T entidad)
        {
           dbSet.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
          dbSet.RemoveRange(entidad);   
        }
    }

}

