using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Grafos
{
    class Aresta
    {
        private int _verticeInicio;
        private int _verticeFim;
        private double _peso;

        public Aresta(int vInicio, int vFim, double peso)
        {
            _verticeInicio = vInicio;
            _verticeFim = vFim;
            _peso = peso;
        }

        public Aresta(int vInicio, int vFim)
        {
            _verticeInicio = vInicio;
            _verticeFim = vFim;
        }

        public int _VerticeInicio
        {
            get { return _verticeInicio; }
            set { _verticeInicio = value; }
        }
        public int _VerticeFim
        {
            get { return _verticeFim; }
            set { _verticeFim = value; }
        }
        public double _Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }
    }
}
