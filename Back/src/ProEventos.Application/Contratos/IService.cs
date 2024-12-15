using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Contratos
{
    public interface IService<ID, TModel> where TModel : class
    {
        Task<TModel> Add(TModel model);
        Task<TModel> Update(ID id, TModel model);
        Task<bool> Delete(ID id);
    }
}
