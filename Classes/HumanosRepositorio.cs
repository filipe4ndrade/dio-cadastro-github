using System;
using System.Collections.Generic;
using DIO.Humanos.Interfaces;

namespace DIO.Humanos
{
    public class HumanoRepositorio : IRepositorio<Humano>
    {
         private List<Humano> listaHumano = new List<Humano>();
        public void Atualiza(int id, Humano objeto)
        {
            listaHumano[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaHumano[id].Excluir();
        }

        public void Insere(Humano objeto)
        {
            listaHumano.Add(objeto);
        }

        public List<Humano> Lista()
        {
            return listaHumano;
        }

        public int ProximoId()
        {
            return listaHumano.Count;
        }

        public Humano RetornaPorId(int id)
        {
            return listaHumano[id];
        }
    }
}