using System;
using System.Collections.Generic;
using series.interfaces;

namespace series
{
    public class SeriesRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(Serie objeto, int id)
        {
            listaSerie[id] = objeto;
        }
        
        public void Exclui(int id)
        {
            // listaSerie.removeAt(id);
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorID(int id)
        {
            return listaSerie[id];
        }
    }
}