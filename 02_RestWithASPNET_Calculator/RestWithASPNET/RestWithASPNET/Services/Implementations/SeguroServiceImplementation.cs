using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RestWithASPNET.Services.Implementations
{
    public class SeguroServiceImplementation : ISeguroService
    {
        private MySQLContext _context;

        public SeguroServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        //Criar/Calcular seguro
        public Seguro Create(Seguro seguro)
        {
            try
            {

                Person segurado = new Person();
                Veiculo veiculo = new Veiculo();



                _context.Add(seguro);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return seguro;
        }

        //Deletar seguro
        public void Delete(long id)
        {
            var result = _context.Seguros.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Seguros.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        //Buscar lista de seguros
        public List<Seguro> FindAll()
        {
            return _context.Seguros.ToList();
        }

        //Buscar seguro por id 
        public Seguro FindByID(long id)
        {
            return _context.Seguros.SingleOrDefault(p => p.Id.Equals(id));
        }


        //Atualizar seguro
        public Seguro Update(Seguro seguro)
        {
            if (!Exist(seguro.Id)) return new Seguro();
            var result = _context.Seguros.SingleOrDefault(p => p.Id.Equals(seguro.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(seguro);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return seguro;

        }


        private bool Exist(long id)
        {
            return _context.Seguros.Any(p => p.Id.Equals(id));
        }

    }
    
}
