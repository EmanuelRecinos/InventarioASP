using InventarioASP.AccesoDatos.Data;
using InventarioASP.AccesoDatos.Repositorio.IRepositorio;
using InventarioASP.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;                    //Se creo la interfaz IBodegaRepositorio y ahora la implementamos con esta clae BodegaRepositorio
using System.Text;
using System.Threading.Tasks;

namespace InventarioASP.AccesoDatos.Repositorio
{
    public class BodegaRepositorio : Repositorio<Bodega>, IBodegaRepositorio
    {

        private readonly ApplicationDbContext _db;

        public BodegaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Bodega bodega)
        {
            //capturamos el registro con base al id
            var bodegaBD = _db.Bodegas.FirstOrDefault(b => b.Id == bodega.Id);
            if (bodegaBD != null) 
            {
            
                bodegaBD.Nombre = bodega.Nombre;
                bodegaBD.Descripcion = bodega.Descripcion;
                bodegaBD.Estado = bodega.Estado;    
                _db.SaveChanges();
                
            }
        }
    }
}
