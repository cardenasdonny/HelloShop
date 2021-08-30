using HelloShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Business.Abstract
{
    public interface ITipoDocumentoBusiness
    {
        Task<IEnumerable<TipoDocumento>> ObtenerTiposDocumento();
    }
}
