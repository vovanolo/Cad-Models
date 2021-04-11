using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication4
{
  public class Program
  {
    struct edge_t
    {
      public int x, y;
      public int w;
    }
    static int[] nodes = new int[100];
    static int last_n = 0;

    static void Main(string[] args)
    {
      edge_t[] edges = new edge_t[100];
      int NV;
      int NE;
      int i;
      Console.WriteLine("Введіть кількість вершин і ребер: ");
      NV = Convert.ToInt32(Console.ReadLine());
      NE = Convert.ToInt32(Console.ReadLine());
      for (i = 0; i < NV; i++)
      {
        nodes[i] = -1 - i;
      }
      Console.WriteLine("Введіть матрицю: ");
      for (i = 0; i < NE; i++)
      {
        edges[i].x = Convert.ToInt32(Console.ReadLine());
        edges[i].y = Convert.ToInt32(Console.ReadLine());
        edges[i].w = Convert.ToInt32(Console.ReadLine());

      }
      Console.WriteLine("Мінімальне остове: ");

      var sVes = from h in edges orderby h.w select h;
      foreach (var s in sVes)
      {
        for (i = 0; i < NE; i++)
        {
          int c = getColor(s.y);
          if (getColor(s.x) != c)
          {
            nodes[last_n] = s.y;
            Console.Write(s.x + " " + s.y + " " + s.w + " ");
          }
        }
      }


      Console.ReadLine();
    }

    static public int getColor(int n)
    {
      int c;
      if (nodes[n] < 0)
      {
        return nodes[last_n = n];
      }
      c = getColor(nodes[n]);
      nodes[n] = last_n;
      return c;
    }
  }
}