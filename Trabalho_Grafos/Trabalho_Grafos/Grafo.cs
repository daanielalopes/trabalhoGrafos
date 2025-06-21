using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Grafos
{
    class Grafo
    {
        private int _numVertices;
        private int _numArestas;
        private Aresta[] _arestas;
        private double _densidade;
        public List<Aresta>[] listaSucessores;
        public double[,] _matrizAdjacencia;

        public Grafo(int numVertices, Aresta[] arestas)
        {
            _numVertices = numVertices;
            _arestas = arestas;

            listaSucessores = new List<Aresta>[_numVertices];
            for (int i = 0; i < _numVertices; i++)
                listaSucessores[i] = new List<Aresta>();
        }
        public double GetDensidade()
        {
            return _densidade;
        }
        public int _NumVertices
        {
            get { return _NumVertices; }
            set { _NumVertices = value; }
        }
        public int _NumArestas
        {
            get { return _NumArestas; }
            set { _NumArestas = value; }
        }
        public Aresta _Arestas
        {
            get { return _Arestas; }
            set { _Arestas = value; }
        }

        public double CalcularDensidade()
        {
            int numArestas = _arestas.Length;
            _densidade = (double)numArestas / (_numVertices * (_numVertices - 1));
            return _densidade;
        }

        public double[,] MatrizAdjacencia()
        {
            _matrizAdjacencia = new double[_numVertices, _numVertices];

            for (int i = 0; i < _numVertices; i++)
            {
                for (int j = 0; j < _numVertices; j++)
                {
                    _matrizAdjacencia[i, j] = 0;
                }
            }

            foreach (var a in _arestas)
            {
                _matrizAdjacencia[a._VerticeInicio - 1, a._VerticeFim - 1] = a._Peso;
            }

            return _matrizAdjacencia;
        }
        public void ImprimirMatrizAdjacencia()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int i = 0; i < _matrizAdjacencia.GetLength(0); i++)
            {
                for (int j = 0; j < _matrizAdjacencia.GetLength(1); j++)
                {
                    Console.Write($"{_matrizAdjacencia[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void ListaAdjacencia()
        {
            for (int i = 0; i < _numVertices; i++)
                listaSucessores[i].Clear();

            foreach (var a in _arestas)
            {
                listaSucessores[a._VerticeInicio - 1].Add(new Aresta(a._VerticeInicio, a._VerticeFim, a._Peso));
            }

        }
        public void ImprimirListaAdjacencia()
        {
            Console.WriteLine("Lista de Adjacência:");
            for (int i = 0; i < listaSucessores.Length; i++)
            {
                Console.Write($"Vértice {i + 1}: ");
                foreach (Aresta a in listaSucessores[i])
                {
                    Console.Write($" -> (Destino: {a._VerticeFim}, Peso: {a._Peso}) ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void ArestasAdjacentes(int v1, int v2)
        {
            bool possui = false;

            Console.Write("Arestas adjacentes: {");

            for (int i = 0; i < _arestas.Length; i++)
            {
                if (_arestas[i]._VerticeInicio != v1 || _arestas[i]._VerticeFim != v2)
                    if ((_arestas[i]._VerticeInicio == v1 || _arestas[i]._VerticeFim == v2) || (_arestas[i]._VerticeFim == v1 || _arestas[i]._VerticeInicio == v2))
                    {
                        Console.Write($" ({_arestas[i]._VerticeInicio}, {_arestas[i]._VerticeFim}) ");
                        possui = true;
                    }
            }

            if (!possui)
            {
                Console.Write("Não possui arestas adjacentes");
            }

            Console.Write("}");
            Console.ReadLine();
            Console.Clear();
        }
        public void VerticeAdjacente(int vertice)
        {
            Console.Write($"Vértices adjacentes a ({vertice}) = ");
            Console.Write("{ ");
            for (int i = 0; i < _arestas.Length; i++)
            {
                if (_arestas[i]._VerticeInicio == vertice)
                {
                    Console.Write($"{_arestas[i]._VerticeFim} ");
                }
                else if (_arestas[i]._VerticeFim == vertice)
                {
                    Console.Write($"{_arestas[i]._VerticeInicio} ");
                }
            }
            Console.Write("}");
            Console.ReadLine();
            Console.Clear();
        }
        public void ArestasIncidentes(int vertice)
        {
            bool possui = false;

            Console.Write("Arestas incidentes: {");

            for (int i = 0; i < _arestas.Length; i++)
            {
                if ((_arestas[i]._VerticeInicio == vertice) || (_arestas[i]._VerticeFim == vertice))
                {
                    Console.Write($" ({_arestas[i]._VerticeInicio}, {_arestas[i]._VerticeFim}) ");
                    possui = true;
                }
            }

            if (!possui)
            {
                Console.Write("Não possui arestas incidentes");
            }

            Console.Write("}");
            Console.ReadLine();
            Console.Clear();
        }

        public void VerticesIncidentes(int v1, int v2)
        {
            bool possui = false;

            Console.Write($"Vértices incidentes: ");
            for (int i = 0; i < _arestas.Length; i++)
            {
                if ((_arestas[i]._VerticeInicio == v1 && _arestas[i]._VerticeFim == v2))
                {
                    Console.Write($" ({_arestas[i]._VerticeInicio}, {_arestas[i]._VerticeFim}) ");
                    possui = true;
                }
            }

            if (!possui)
            {
                Console.Write("Não possui arestas incidentes");
            }

            Console.ReadLine();
            Console.Clear();
        }
        public void Grau(int vertice)
        {
            int grauEntrada = 0, grauSaida = 0;

            for (int i = 0; i < _arestas.Length; i++)
            {
                if (_arestas[i]._VerticeInicio == vertice)
                {
                    grauSaida++;
                }
                if (_arestas[i]._VerticeFim == vertice)
                {
                    grauEntrada++;
                }
            }

            Console.WriteLine($"Grau de entrada do vértice {vertice}: {grauEntrada}");
            Console.WriteLine($"Grau de saída do vértice {vertice}: {grauSaida}");

            Console.ReadLine();
            Console.Clear();
        }
        public void DoisVerticesAdjacentes(int v1, int v2)
        {
            bool possui = false;

            for (int i = 0; i < _arestas.Length; i++)
            {
                if ((_arestas[i]._VerticeInicio == v1 && _arestas[i]._VerticeFim == v2))
                {
                    possui = true;
                }
            }

            if (!possui)
            {
                Console.Write($"Os vértices {v1} e {v2} não são adjacentes");
            }
            else
            {
                Console.Write($"Os vértices {v1} e {v2} são adjacentes");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void SubstituirPeso(int v1, int v2, double peso)
        {
            bool possui = false;
            int posicao = 0;

            for (int i = 0; i < _arestas.Length; i++)
            {
                if ((_arestas[i]._VerticeInicio == v1 && _arestas[i]._VerticeFim == v2))
                {
                    possui = true;
                    posicao = i;
                }
            }

            if (possui)
            {
                _arestas[posicao]._Peso = peso;
                Console.WriteLine($"Peso atual da aresta ({v1}, {v2}): {_arestas[posicao]._Peso}");
            }
            else
            {
                Console.WriteLine("Aresta não encontrada");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void TrocarDoisVertices(int v1, int v2)
        {
            for (int i = 0; i < _arestas.Length; i++)
            {
                if (_arestas[i]._VerticeInicio == v1)
                    _arestas[i]._VerticeInicio = int.MaxValue;

                if (_arestas[i]._VerticeFim == v1)
                    _arestas[i]._VerticeFim = int.MaxValue;
            }

            for (int i = 0; i < _arestas.Length; i++)
            {
                if (_arestas[i]._VerticeInicio == v2)
                    _arestas[i]._VerticeInicio = v1;

                if (_arestas[i]._VerticeFim == v2)
                    _arestas[i]._VerticeFim = v1;
            }

            for (int i = 0; i < _arestas.Length; i++)
            {
                if (_arestas[i]._VerticeInicio == int.MaxValue)
                    _arestas[i]._VerticeInicio = v2;

                if (_arestas[i]._VerticeFim == int.MaxValue)
                    _arestas[i]._VerticeFim = v2;
            }
        }
        public void InicializacaoBuscaLargura(int verticeInicial)
        {
            int tempo = 0;
            Queue<int> fila = new Queue<int>();

            int[] indice = new int[_numVertices];
            int[] nivel = new int[_numVertices];
            int[] pai = new int[_numVertices];
            for (int i = 0; i < _numVertices; i++)
            {
                indice[i] = 0;
                nivel[i] = 0;
                pai[i] = -1;
            }

            int raiz = verticeInicial - 1;

            tempo++;
            indice[raiz] = tempo;
            fila.Enqueue(raiz);

            Busca_Largura(raiz, ref tempo, fila, indice, nivel, pai);

            Console.WriteLine("\nResultado da Busca em Largura a partir do vértice " + verticeInicial + ":\n");
            for (int i = 0; i < _numVertices; i++)
            {
                if (indice[i] != 0) 
                {
                    string paiTexto = pai[i] != -1 ? (pai[i] + 1).ToString() : "0";
                    Console.WriteLine($"Vértice {i + 1}: Índice = {indice[i]}, Nível = {nivel[i]}, Pai = {paiTexto}");
                }
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void Busca_Largura(int raiz, ref int tempo, Queue<int> fila, int[] indice, int[] nivel, int[] pai)
        {
            while(fila.Count > 0)
            {
                int v = fila.Dequeue();

                for(int i = 0; i < _arestas.Length; i++)
                {
                    Aresta a = _arestas[i];

                    if (a._VerticeInicio - 1 == v)
                    {
                        int w = a._VerticeFim - 1;

                        if (indice[w] == 0)
                        {
                            pai[w] = v;
                            nivel[w] = nivel[v] + 1;
                            tempo++;
                            indice[w] = tempo;
                            fila.Enqueue(w);
                        }
                    }
                }
            }
        }
        public void InicializacaoBuscaProfundidade(int verticeInicial)
        {
            int tempo = 0;

            int[] TD = new int[_numVertices]; 
            int[] TT = new int[_numVertices];
            int[] pai = new int[_numVertices];

            for (int i = 0; i < _numVertices; i++)
            {
                TD[i] = 0;
                TT[i] = 0;
                pai[i] = -1;
            }

            int raiz = verticeInicial - 1;

            if (TD[raiz] == 0)
            {
                Busca_Profundidade(ref tempo, raiz, TD, TT, pai);
            }

            for (int v = 0; v < _numVertices; v++)
            {
                if (TD[v] == 0)
                {
                    Busca_Profundidade(ref tempo, v, TD, TT, pai);
                }
            }

            Console.WriteLine("\nResultado da Busca em Profundidade:\n");
            for (int i = 0; i < _numVertices; i++)
            {
                string paiTexto = pai[i] != -1 ? (pai[i] + 1).ToString() : "0";
                Console.WriteLine($"Vértice {i + 1}: TD = {TD[i]}, TT = {TT[i]}, Pai = {paiTexto}");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void Busca_Profundidade(ref int tempo, int v, int[] TD, int[] TT, int[] pai)
        {
            tempo++;

            TD[v] = tempo;

            for (int i = 0; i < _arestas.Length; i++)
            {
                Aresta a = _arestas[i];

                if (a._VerticeInicio - 1 == v) 
                {
                    int w = a._VerticeFim - 1;

                    if (TD[w] == 0) 
                    {
                        pai[w] = v;
                        Busca_Profundidade(ref tempo, w, TD, TT, pai);
                    }
                }
            }

            tempo++;
            TT[v] = tempo;
        }

        public void Dijkstra(int verticeOrigem, int verticeDestino)
        {
            int origem = verticeOrigem - 1;
            int destino = verticeDestino - 1;

            int infinito = int.MaxValue;
            int[] dist = new int[_numVertices];
            bool[] visitado = new bool[_numVertices];
            int[] pred = new int[_numVertices];

            for (int i = 0; i < _numVertices; i++)
            {
                dist[i] = infinito;
                visitado[i] = false;
                pred[i] = -1;
            }

            dist[origem] = 0;

            for (int count = 0; count < _numVertices; count++)
            {
                int minDist = infinito;
                int u = -1;
                for (int i = 0; i < _numVertices; i++)
                {
                    if (!visitado[i] && dist[i] < minDist)
                    {
                        minDist = dist[i];
                        u = i;
                    }
                }

                if (u == -1) break;
                visitado[u] = true;

                for (int j = 0; j < _arestas.Length; j++)
                {
                    Aresta a = _arestas[j];
                    if (a._VerticeInicio - 1 == u)
                    {
                        int w = a._VerticeFim - 1;
                        int peso = (int)a._Peso;

                        if (!visitado[w] && dist[u] != infinito && dist[u] + peso < dist[w])
                        {
                            dist[w] = dist[u] + peso;
                            pred[w] = u;
                        }
                    }
                }
            }

            if (dist[destino] == infinito)
            {
                Console.WriteLine($"Não existe caminho do vértice {verticeOrigem} até {verticeDestino}.");
            }

            List<int> caminho = new List<int>();
            int atual = destino;
            while (atual != -1)
            {
                caminho.Insert(0, atual);
                atual = pred[atual];
            }

            Console.WriteLine($"Caminho mínimo do vértice {verticeOrigem} ao {verticeDestino}:");
            for (int i = 0; i < caminho.Count - 1; i++)
            {
                int v1 = caminho[i];
                int v2 = caminho[i + 1];
                int pesoAresta = 0;
                for (int j = 0; j < _arestas.Length; j++)
                {
                    Aresta a = _arestas[j];
                    if (a._VerticeInicio - 1 == v1 && a._VerticeFim - 1 == v2)
                    {
                        pesoAresta = (int)a._Peso;
                        break;
                    }
                }
                Console.Write($"{v1 + 1} --({pesoAresta})--> ");
            }
            Console.WriteLine(caminho[caminho.Count - 1] + 1);

            Console.WriteLine($"Distância total: {dist[destino]}");
            Console.ReadLine();
            Console.Clear();
        }
        public void FloydWarshall(int verticeOrigem)
        {
            int infinito = int.MaxValue;
            int[,] dist = new int[_numVertices, _numVertices];

            for (int i = 0; i < _numVertices; i++)
            {
                for (int j = 0; j < _numVertices; j++)
                {
                    if (i == j)
                        dist[i, j] = 0;
                    else
                        dist[i, j] = infinito;
                }
            }

            for (int i = 0; i < _arestas.Length; i++)
            {
                int u = _arestas[i]._VerticeInicio - 1;
                int v = _arestas[i]._VerticeFim - 1;
                int peso = (int)_arestas[i]._Peso;
                dist[u, v] = peso;
            }

            for (int k = 0; k < _numVertices; k++)
            {
                for (int i = 0; i < _numVertices; i++)
                {
                    for (int j = 0; j < _numVertices; j++)
                    {
                        if (dist[i, k] != infinito && dist[k, j] != infinito && dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            int origem = verticeOrigem - 1;
            Console.WriteLine($"Menores distâncias a partir do vértice {verticeOrigem}:");
            for (int j = 0; j < _numVertices; j++)
            {
                if (dist[origem, j] == infinito)
                    Console.WriteLine($"até {j + 1}: INFINITO (sem caminho)");
                else
                    Console.WriteLine($"até {j + 1}: {dist[origem, j]}");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
