using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(Guid id, Serie entidade)
        {
            if (id != entidade.Id)
                return;
            
            var serie = listaSerie.FirstOrDefault(s => s.Id == id);
            listaSerie.Remove(serie);
            listaSerie.Add(entidade);
        }

        public void Exclui(Guid id)
        {
            var serie = listaSerie.FirstOrDefault(s => s.Id == id);
            listaSerie.Remove(serie);
            serie.Exclui();
            listaSerie.Add(serie);
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public Guid ProximoId()
        {
            return Guid.NewGuid();
        }

        public Serie RetornaPorId(Guid id)
        {
            return listaSerie.FirstOrDefault(s => s.Id == id);
        }
    }
}
