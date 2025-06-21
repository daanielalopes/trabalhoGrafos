using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Grafos
{
    internal class Desafio
    {
        private List<int>[] grafo;
        private bool[] visitado;

        public void BuscaProfundidade(int v, List<char> componente)
        {
            visitado[v] = true;
            componente.Add((char)(v + 'a'));

            foreach (int vizinho in grafo[v])
            {
                if (!visitado[vizinho])
                    BuscaProfundidade(vizinho, componente);
            }
        }

        public void MainDesafio()
        {
            int N = int.Parse(Console.ReadLine());

            for (int caso = 1; caso <= N; caso++)
            {
                string[] parts = Console.ReadLine().Split();
                int V = int.Parse(parts[0]);
                int E = int.Parse(parts[1]);

                grafo = new List<int>[V];
                visitado = new bool[V];

                for (int i = 0; i < V; i++)
                    grafo[i] = new List<int>();

                for (int i = 0; i < E; i++)
                {
                    string[] aresta = Console.ReadLine().Split();
                    int u = aresta[0][0] - 'a';
                    int v = aresta[1][0] - 'a';
                    grafo[u].Add(v);
                    grafo[v].Add(u);
                }

                List<List<char>> componentes = new List<List<char>>();

                for (int i = 0; i < V; i++)
                {
                    if (!visitado[i])
                    {
                        List<char> componente = new List<char>();
                        BuscaProfundidade(i, componente);
                        componente.Sort();
                        componentes.Add(componente);
                    }
                }

                Console.WriteLine($"Case #{caso}:");
                foreach (var comp in componentes)
                {
                    foreach (char c in comp)
                        Console.Write($"{c},");
                    Console.WriteLine();
                }
                Console.WriteLine($"{componentes.Count} connected components\n");
            }
        }
    }
}
