using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RestWithASPNET.Services.Implementations
{
    public class VeiculoServiceImplementation : IVeiculoService
    {
        private MySQLContext _context;

        public VeiculoServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        //Criar veículo
        public Veiculo Create(Veiculo veiculo)
        {
            try
            {
                _context.Add(veiculo);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return veiculo;
        }

        //Deletar veículo
        public void Delete(long id)
        {
            var result = _context.Veiculos.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Veiculos.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        //Buscar lista de veículo
        public List<Veiculo> FindAll()
        {
            return _context.Veiculos.ToList();
        }

        //Buscar seveículo gurado por id 
        public Veiculo FindByID(long id)
        {
            return _context.Veiculos.SingleOrDefault(p => p.Id.Equals(id));
        }


        //Atualizar veículo
        public Veiculo Update(Veiculo veiculo)
        {
            if (!Exist(veiculo.Id)) return new Veiculo();
            var result = _context.Veiculos.SingleOrDefault(p => p.Id.Equals(veiculo.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(veiculo);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return veiculo;

        }


        private bool Exist(long id)
        {
            return _context.Veiculos.Any(p => p.Id.Equals(id));
        }

    }
}
