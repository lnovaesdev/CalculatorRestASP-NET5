using RestWithASPNET.Model;
using System.Collections.Generic;


namespace RestWithASPNET.Services
{
    public interface IVeiculoService
    {
        Veiculo Create(Veiculo veiculo);
        Veiculo FindByID(long id);
        List<Veiculo> FindAll();
        Veiculo Update(Veiculo veiculo);
        void Delete(long id);
    }
}
