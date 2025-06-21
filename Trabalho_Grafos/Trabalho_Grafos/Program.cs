using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Grafos
{
    internal class Program
    {
        static Grafo grafo;
        static void ConstruirGrafo()
        {
            Console.Write("Digite a quantidade de vértices: ");
            int numVertices = int.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade de arestas: ");
            int numArestas = int.Parse(Console.ReadLine());

            Aresta[] arestas = new Aresta[numArestas];

            int v1, v2; double peso;

            for (int i = 0; i < arestas.Length; i++)
            {
                Console.WriteLine($"Aresta {i + 1}");

                Console.Write($"Digite o vértice de origem: ");
                v1 = int.Parse(Console.ReadLine());

                Console.Write($"Digite o vértice de destino: ");
                v2 = int.Parse(Console.ReadLine());

                Console.Write($"Digite o peso da aresta {v1} - {v2}: ");
                peso = double.Parse(Console.ReadLine());

                arestas[i] = new Aresta(v1, v2, peso);
            }

            Console.Clear();

            grafo = new Grafo(numVertices, arestas);

            grafo.CalcularDensidade();

            if (grafo.GetDensidade() >= 0.5)
                grafo.MatrizAdjacencia();
            else
                grafo.ListaAdjacencia();
        }
        static void ImprimirFormaRepresentacao()
        {
            if (grafo == null)
            {
                Console.WriteLine("Grafo não foi construído ainda");
            }
            else
            {

                if (grafo.GetDensidade() >= 0.5)
                {
                    grafo.MatrizAdjacencia();
                    grafo.ImprimirMatrizAdjacencia();
                }
                else
                {
                    grafo.ListaAdjacencia();
                    grafo.ImprimirListaAdjacencia();
                }
            }
        }
        static int Linhas(StreamReader arq)
        {
            int cont = 0;
            string linha;
            while ((linha = arq.ReadLine()) != null)
            {
                cont++;
            }
            return cont;
        }
        static void LerGrafoDoArquivo()
        {
            try
            {
                StreamReader arq = new StreamReader("arquivo.txt", Encoding.UTF8);
                int linhas = Linhas(arq);
                arq.Close();

                arq = new StreamReader("arquivo.txt", Encoding.UTF8);
                string informacoesGrafo = arq.ReadLine();
                string[] informacoes = informacoesGrafo.Split(' ');

                int numVertices = int.Parse(informacoes[0]);
                int numArestas = int.Parse(informacoes[1]);

                Aresta []aresta = new Aresta[numArestas];

                for (int i = 0; i < numArestas; i++)
                {
                    string infGrafos = arq.ReadLine();
                    string[] inf = infGrafos.Split(' ');
                    aresta[i] = new Aresta(int.Parse(inf[0]), int.Parse(inf[1]), int.Parse(inf[2]));
                }

                grafo = new Grafo(numVertices, aresta);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
        }
        static void ImprimirArestasAdjacentes()
        {
            Console.Write("Digite o primeiro vértice da aresta para verificar as arestas adjacentes: ");
            int v1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o segundo vértice da aresta para verificar as arestas adjacentes: ");
            int v2 = int.Parse(Console.ReadLine());

            grafo.ArestasAdjacentes(v1, v2);
        }
        static void ImprimirVerticesAdjacentes()
        {
            Console.Write("Digite o vértice para verificar os vértices adjacentes: ");
            int vertice = int.Parse(Console.ReadLine());

            grafo.VerticeAdjacente(vertice);
        }
        static void ImprimirArestasIncidentes()
        {
            Console.Write("Digite o vértice para verificar as arestas incidentes: ");
            int vertice = int.Parse(Console.ReadLine());

            grafo.ArestasIncidentes(vertice);
        }
        static void ImprimirVerticesIncidentes()
        {
            Console.Write("Digite o primeiro vértice da aresta para verificar as arestas incidentes: ");
            int v1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o segundo vértice da aresta para verificar as arestas incidentes: ");
            int v2 = int.Parse(Console.ReadLine());

            grafo.VerticesIncidentes(v1, v2);
        }
        static void ImprimirGrauVertice()
        {
            Console.Write("Digite o vértice a ser escolhido: ");
            int vertice = int.Parse(Console.ReadLine());

            grafo.Grau(vertice);
        }
        static void VerificarVerticesAdjacentes()
        {
            Console.Write("Digite o vértice 1: ");
            int v1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o vértice 2: ");
            int v2 = int.Parse(Console.ReadLine());

            grafo.DoisVerticesAdjacentes(v1, v2);
        }
        static void SubstituirPesoAresta()
        {
            Console.Write("Digite o primeiro vértice da aresta a ser substituída: ");
            int v1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o segundo vértice da aresta a ser substituída: ");
            int v2 = int.Parse(Console.ReadLine());

            Console.Write($"Digite o novo peso da aresta ({v1}, {v2}): ");
            double peso = double.Parse(Console.ReadLine());

            grafo.SubstituirPeso(v1, v2, peso);
        }
        static void TrocarVertices()
        {
            Console.Write("Digite o primeiro vértice: ");
            int v1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o segundo vértice: ");
            int v2 = int.Parse(Console.ReadLine());

            grafo.TrocarDoisVertices(v1, v2);
        }
        static void BuscaEmLargura()
        {
            Console.Write("Digite o vértice inicial: ");
            int verticeInicial = int.Parse(Console.ReadLine());

            grafo.InicializacaoBuscaLargura(verticeInicial);
        }
        static void BuscaEmProfundidade()
        {
            Console.Write("Digite o vértice inicial: ");
            int verticeInicial = int.Parse(Console.ReadLine());

            grafo.InicializacaoBuscaProfundidade(verticeInicial);
        }
        static void ExecutarDijkstra()
        {
            Console.Write("Digite o vértice de origem: ");
            int o = int.Parse(Console.ReadLine());
            Console.Write("Digite o vértice de destino: ");
            int d = int.Parse(Console.ReadLine());

            grafo.Dijkstra(o, d);
        }
        static void ExecutarFloydWarshall()
        {
            Console.Write("Digite o vértice de origem: ");
            int o = int.Parse(Console.ReadLine());

            grafo.FloydWarshall(o);
        }
        static int ExibirMenuPrincipal()
        {
            Console.WriteLine("Trabalho Prático - Grafos");
            Console.WriteLine("=======================");
            Console.WriteLine("1 - Construir grafo");
            Console.WriteLine("2 - Imprimir forma de representação do grafo");
            Console.WriteLine("3 - Ler grafo do arquivo");
            Console.WriteLine("4 - Imprimir arestas adjacentes a uma aresta");
            Console.WriteLine("5 - Imprimir vértices adjacentes a um vértice");
            Console.WriteLine("6 - Imprimir arestas incidentes a um vértice");
            Console.WriteLine("7 - Imprimir vértices incidentes a uma aresta");
            Console.WriteLine("8 - Imprimir grau de um vértice");
            Console.WriteLine("9 - Verificar se dois vértices são adjacentes");
            Console.WriteLine("10 - Substituir peso de uma aresta");
            Console.WriteLine("11 - Trocar dois vértices");
            Console.WriteLine("12 - Busca em largura");
            Console.WriteLine("13 - Busca em profundidade");
            Console.WriteLine("14 - Algoritmo de Dijkstra");
            Console.WriteLine("15 - Algoritmo de Floyd-Warshall");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("===============================");
            Console.WriteLine("Digite sua escolha");
            int escolha = int.Parse(Console.ReadLine());

            Console.Clear();

            return escolha;
        }
        static void Main(string[] args)
        {
            int opcao = -1;
            do
            {
                opcao = ExibirMenuPrincipal();
                switch (opcao)
                {
                    case 1:
                        ConstruirGrafo();
                        break;
                    case 2:
                        ImprimirFormaRepresentacao();
                        break;
                    case 3:
                        LerGrafoDoArquivo();
                        break;
                    case 4:
                        ImprimirArestasAdjacentes();
                        break;
                    case 5:
                        ImprimirVerticesAdjacentes();
                        break;
                    case 6:
                        ImprimirArestasIncidentes();
                        break;
                    case 7:
                        ImprimirVerticesIncidentes();
                        break;
                    case 8:
                        ImprimirGrauVertice();
                        break;
                    case 9:
                        VerificarVerticesAdjacentes();
                        break;
                    case 10:
                        SubstituirPesoAresta();
                        break;
                    case 11:
                        TrocarVertices();
                        break;
                    case 12:
                        BuscaEmLargura();
                        break;
                    case 13:
                        BuscaEmProfundidade();
                        break;
                    case 14:
                        ExecutarDijkstra();
                        break;
                    case 15:
                        ExecutarFloydWarshall();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa. Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
