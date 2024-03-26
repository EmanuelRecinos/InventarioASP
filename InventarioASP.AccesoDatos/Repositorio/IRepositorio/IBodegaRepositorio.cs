using InventarioASP.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioASP.AccesoDatos.Repositorio.IRepositorio
{
    // esta interfaz hereda de la interfaz generica "IRepositorio"
    public interface IBodegaRepositorio : IRepositorio <Bodega>
    {

        void Actualizar(Bodega bodega);
    }


}
