namespace Torre_de_Hanoi
{
    public class Torre
    {
        public Pilhas[] Pilhas { get; set; }
        public int Movimentos = 0;
        public int Discos { get; set; }
        /// <summary>
        /// Construtor padrão com 4 discos.
        /// Inicia um novo objeto de Torre com uma array de objetos de Pilhas.
        /// Inicia e dá um push dos 4 objetos de Discos padrão para o primeiro stack da Pilha.
        /// </summary>
        public Torre()
        {
            Discos = 4;
            Pilhas = new Pilhas[]
                {
                    new Pilhas(4, 1),
                    new Pilhas(4, 2),
                    new Pilhas(4, 3)
                 };
            for (int i = 4; i > 0; i--)
                Pilhas[0].Pilha.Push(new Discos($"Disco-{i}"));
        }
        /// <summary>
        /// Construtor com número de discos definido pelo usuário.
        /// Inicia um novo objeto de Torre com uma array de objetos de Pilhas.
        /// Inicia e dá um push dos N objetos de Discos padrão para o primeiro stack da Pilha.
        /// </summary>
        /// <param name="discos"> int: numero de discos </param>
        public Torre(int discos)
        {
            Discos = discos;
            Pilhas = new Pilhas[]
                {
                    new Pilhas(discos, 1),
                    new Pilhas(discos, 2),
                    new Pilhas(discos, 3)
                };
            for (int i = discos; i > 0; i--)
                Pilhas[0].Pilha.Push(new Discos($"Disco-{i}"));
        }
        /// <summary>
        /// Método para resolver a torre e retornar a array de Pilha.
        /// </summary>
        /// <returns></returns>
        public Torre ResolverTorre() =>
            Resolver(Discos, Pilhas[0], Pilhas[2], Pilhas[1]);

        public Torre Resolver(int n, Pilhas from, Pilhas to, Pilhas holder)
        {
            Discos disco = new Discos();
            Movimentos++;

            if (n == 1)
            {
                disco = from.Pilha.Pop();
                to.Pilha.Push(disco);
                Console.WriteLine($"Movendo {disco.Disco} da Pilha {from.Posicao} para a Pilha {to.Posicao}");
                return this;
            }

            Resolver(n - 1, from, holder, to);

            disco = from.Pilha.Pop();
            to.Pilha.Push(disco);
            Console.WriteLine($"Movendo {disco.Disco} da Pilha {from.Posicao} para a Pilha {to.Posicao}");

            Resolver(n - 1, holder, to, from);

            return this;
        }

    }
    /// <summary>
    /// Classe de Pilha para a array de Pilha no objeto de Torre.
    /// </summary>
    public class Pilhas
    {
        public Stack<Discos> Pilha { get; set; }
        public int Posicao { get; set; }
        public Pilhas(int discs, int posicao)
        {
            Pilha = new Stack<Discos>();
            Posicao = posicao;
        }
    }
    /// <summary>
    /// Classe de Disco para as Pilhas na Torre.
    /// </summary>
    public class Discos
    {
        public string Disco { get; set; }
        public Discos() { }
        public Discos(string disco)
        {
            Disco = disco;
        }
    }
}