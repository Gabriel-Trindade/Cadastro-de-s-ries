using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    public class SerieRepositório : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void exclui(int id)
        {
            listaSerie[id].Exclui();
        }

        public void insere(Serie objeto)
        {
            listaSerie.Add(objeto); 
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int proximoId()
        {
            return listaSerie.Count;
        }

        public Serie retornaporId(int id)
        {
            return listaSerie[id];
        }
    }
}