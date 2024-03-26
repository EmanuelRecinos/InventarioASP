using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventarioASP.AccesoDatos.Repositorio.IRepositorio
{   
    //Estamos haciendo esta interfaz generica para que trabaje con cualquier tipo de objeto
    //T es el objeto 
    public interface IRepositorio <T> where T : class
    {
        Task <T> Obtener(int id);

        //para las Listas
        Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T,bool >>filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null,
            bool isTracking = true  
             
           );
        // no retorna una lista si no un objeto segun el filtro
        Task <T> ObtenerPrimero(

            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null,
            bool isTracking = true
            );
        Task Agregar( T entidad);

        void Remover ( T entidad );

        void RemoverRango(IEnumerable<T> entidad);

    }
}
