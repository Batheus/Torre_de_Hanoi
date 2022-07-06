namespace Torre_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTorre de Hanoi");
            int discos = 0;

            while (discos < 3 || discos > 10)
            {
                Console.WriteLine("Insira o número de discos: (3-10)");
                discos = Convert.ToInt32(Console.ReadLine());
            }
            Torre torre = new Torre(discos);
            torre.ResolverTorre();
            Console.WriteLine($"Movimentos totais: {torre.Movimentos}");
        }
    }
}