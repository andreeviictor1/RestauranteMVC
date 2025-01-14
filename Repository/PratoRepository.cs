using CardapioMVC.Infrastructure;
using CardapioMVC.Models;

namespace CardapioMVC.Repository
{
    public class PratoRepository : IPratoRepository
    {
        private readonly AppDbContext _context;

        public PratoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Prato AddPrato(Prato prato)
        {
            _context.Pratos.Add(prato);
            _context.SaveChanges();

            return prato;
        }

        List<Prato> IPratoRepository.GetAllPratos()
        {
            return _context.Pratos.ToList();
        }

        public Prato GetPrato(int id)
        {
            return _context.Pratos.FirstOrDefault(x => x.Id == id);
        }


        public Prato UpdatePrato (Prato prato)
        {
            Prato pratoDB = GetPrato(prato.Id);

            if (pratoDB == null)
            {
                throw new Exception("Houve um erro na alteracao");
            }

            pratoDB.Name = prato.Name;
            pratoDB.Description = prato.Description;
            pratoDB.Preco = prato.Preco;
            pratoDB.CategoriaString = prato.CategoriaString;
            pratoDB.Bebida = prato.Bebida;

            _context.Pratos.Update(pratoDB);
            _context.SaveChanges();
            return pratoDB;
        }


        public bool DeletePrato(int id)
        {
            var prato = _context.Pratos.FirstOrDefault(p => p.Id == id);

            if (prato == null)
            {
                return false; 
            }

            _context.Pratos.Remove(prato);
            _context.SaveChanges();
            return true;
        }
    }   
}
