using RestWithASPNET.Model;
using System.Collections.Generic;

namespace RestWithASPNET.Services
{
    public interface ISeguroService
    {
        Seguro Create(Seguro seguro);
        Seguro FindByID(long id);
        List<Seguro> FindAll();
        Seguro Update(Seguro seguro);
        void Delete(long id);
    }
}
