using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfStones
{
    public class ResultOutput
    {
        public void Write()
        {
            for (int i = 0; i < BenchmarkData.Conditions.Count; i++)
            {
                Console.WriteLine(BenchmarkData.Conditions[i]);
            }
        }

        public void ConclusionStrategy(Node nod)
        {
            if (nod.nexts.Count != 0)
            {
                foreach (Node n in nod.nexts)
                {
                    nod = n;
                    ConclusionStrategy(nod);
                }
            }
            else
            {
                Console.Write($"        {nod.value.stonesBeginningGame}       ");
                Console.Write($"               {nod.value.steps}    ");
                Console.Write($"           =   {nod.value.stonesEndStep}");
                Console.WriteLine();
            }

        }
    }
}
