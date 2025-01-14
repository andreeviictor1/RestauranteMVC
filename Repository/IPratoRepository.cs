using CardapioMVC.Models;

namespace CardapioMVC.Repository
{
    public interface IPratoRepository
    {
        Prato AddPrato (Prato prato);

        List<Prato> GetAllPratos ();
        Prato GetPrato (int id);
        Prato UpdatePrato (Prato prato);
        bool DeletePrato(int id);
    }
}
