using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfStones
{
    public class Node
    {
        public List<Node> nexts;
        public Node last;
        public NodeValue value;
        public Node nodeFinded;
        public Node()
        {
            nexts = new List<Node>();
            value = new NodeValue();
        }
        public void Create()
        {
            for (int i = 1; i < BenchmarkData.StonesForWin; i++)
            {
                value.stonesEndStep = i;
                value.stonesBeginningGame = i;
                CreateGraph();
            }
        }
        public void CreateGraph()
        {
            foreach (String i in BenchmarkData.Conditions)
            {
                if (value.numberOfStep < 3)
                {
                    Node newNode = new Node();
                    newNode.value = value.Copy();
                    newNode.value.Step(i);
                    nexts.Add(newNode);
                    newNode.last = this;
                    newNode.CreateGraph();
                }
            }

        }
        public Node FindResult(Node node)
        {

            if (node.nexts.Count != 0)
            {
                foreach (Node n in node.nexts)
                {
                    node = n;
                    FindResult(n);
                }
            }
            else
            {
                if (node.last != null && node.last.value.stonesEndStep < BenchmarkData.StonesForWin && node.value.stonesEndStep >= BenchmarkData.StonesForWin)
                {
                    if (nodeFinded == null)
                    {
                        nodeFinded = new Node();
                    }

                    nodeFinded.nexts.Add(node);

                }
            }
            return nodeFinded;
        }

        public Node FindThen(Node node)
        {
            Node node1 = new Node();
            NodeValue m1, m2, m3;
            bool isFinish = false;
            int umn = 0, max = 0;
            foreach (String a in BenchmarkData.Conditions)
            {
                if (a.Contains('*'))
                {
                    if (umn < Convert.ToInt32(a.Substring(1)))
                    {
                        umn = Convert.ToInt32(a.Substring(1));
                        isFinish = true;
                    }
                }
            }
            foreach (String a in BenchmarkData.Conditions)
            {
                if (a.Contains('*'))
                {
                    if (max < Convert.ToInt32(a.Substring(1)))
                    {
                        max = Convert.ToInt32(a.Substring(1));

                    }
                }
            }
            for (int i = 0; i < node.nexts.Count - 3; i++)
            {
                m1 = node.nexts[i].last.last.value;
                m2 = node.nexts[i + 1].last.last.value;
                m3 = node.nexts[i + 2].last.last.value;

                if (m1.steps == m2.steps && m1.steps == m3.steps)
                {
                    if (m1.stonesEndStep == m2.stonesEndStep && m1.stonesEndStep == m3.stonesEndStep)
                    {

                        if (m1.stonesEndStep <= (BenchmarkData.StonesForWin / umn) && isFinish)
                        {
                            node1.nexts.Add(node.nexts[i]);
                            node1.nexts.Add(node.nexts[i + 1]);
                            node1.nexts.Add(node.nexts[i + 2]);
                            i += 2;
                        }
                        else if (m1.stonesEndStep <= (BenchmarkData.StonesForWin - max) && umn == 0)
                        {
                            node1.nexts.Add(node.nexts[i]);
                            node1.nexts.Add(node.nexts[i + 1]);
                            node1.nexts.Add(node.nexts[i + 2]);
                            i += 2;
                        }
                    }
                }
            }
            return node1;
        }    
    }
}

