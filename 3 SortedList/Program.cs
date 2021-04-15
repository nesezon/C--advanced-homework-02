using System;
using System.Collections.Generic;

namespace SL {
  class Program {
    static void Main(string[] args) {
      
      var slist = new SortedList<string, int>();

      Console.WriteLine("-------- По алфавиту --------");

      slist["3    "] = 1;
      slist["1    "] = 2;
      slist["2    "] = 3;
      slist["b    "] = 4;
      slist["c    "] = 5;
      slist["a eng"] = 6;
      slist["а rus"] = 7;
      slist["я    "] = 8;
      
      foreach (var pair in slist) {
        Console.WriteLine($"{pair.Key} : {pair.Value}");
      }

      // еще один SortedList для обратной сортировки
      var comparer = Comparer<string>.Create((x, y) => y.CompareTo(x)); 
      var rlist = new SortedList<string, int>(comparer);

      foreach (var pair in slist) {
        rlist.Add(pair.Key, pair.Value);
      }

      Console.WriteLine("----- В обратном порядке -----");

      foreach (var pair in rlist) {
        Console.WriteLine($"{pair.Key} : {pair.Value}");
      }

      Console.ReadKey();
    }
  }
}
