using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfStones
{
    public class NodeValue
    {

        public String steps;
        public int numberOfStep;
        public int stonesEndStep;
        public int stonesBeginningGame;
        public NodeValue()
        {
            numberOfStep = 0;
        }
        public void Step(string a)
        {
            if (a.Contains('+'))
            {
                steps = steps + a;
                numberOfStep++;
                stonesEndStep += Convert.ToInt32(a.Substring(1));
            }
            else if (a.Contains('*'))
            {
                steps = steps + a;
                numberOfStep++;
                stonesEndStep *= Convert.ToInt32(a.Substring(1));
            }
        }

        public NodeValue Copy()
        {
            NodeValue newNodeValue = new NodeValue();
            newNodeValue.steps = steps;
            newNodeValue.numberOfStep = numberOfStep;
            newNodeValue.stonesEndStep = stonesEndStep;
            newNodeValue.stonesBeginningGame = stonesBeginningGame;
            return newNodeValue;
        }
    }
}
