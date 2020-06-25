using System;
using System.Collections.Generic;

namespace GameOfStones
{
    class Program
    {
        static Node node;

        static void Main(string[] args)
        {
            Console.WriteLine(" Два игрока, I и II, играют в следующую игру. Перед игроками лежит общая куча камней.");
            Console.WriteLine(" Игроки ходят по очереди, первый ход делает I. За один ход игрок может увеличить количество");
            Console.WriteLine(" камней в куче одним из трех способов (a, b либо c), которые задаются до начала игры.");
            Console.WriteLine(" У каждого игрока есть неограниченное количество камней для совершения хода.Игра завершается");
            Console.WriteLine(" в тот момент, когда количество камней в общей куче становится большим либо равным заранее");
            Console.WriteLine(" оговоренному числу(N).Победителем считается игрок, сделавший последний ход, то есть первым");
            Console.WriteLine(" получивший кучу, в которой будет(N) или больше камней.В начальный момент в куче было");
            Console.WriteLine(" S камней, 1 ≤ S < N.");

            BenchmarkData.Conditions = new List<string>();
            Console.Write(" Введите значение а (например +2 или *2)  ");
            BenchmarkData.Conditions.Add(Console.ReadLine());
            Console.Write(" Введите значение b (например +2 или *2)  ");
            BenchmarkData.Conditions.Add(Console.ReadLine());
            Console.Write(" Введите значение c (например +2 или *2)  ");
            BenchmarkData.Conditions.Add(Console.ReadLine());
            Console.Write(" Введите значение n=  ");
            BenchmarkData.StonesForWin=Convert.ToInt32(Console.ReadLine());

            node = new Node();
            node.Create();
            Node a = node.FindResult(node);

            Console.WriteLine("камней на начело игры /  победная стратегия / камней в конце игры ");
            ResultOutput strategy = new ResultOutput();
            strategy.ConclusionStrategy(node.FindThen(a));

        }
    }
}
