using System;
using System.Collections.Generic;

namespace MyList {
  public interface IMyList<T> {
    void Add(T a);
    T this[int index] { get; }
    int Count { get; }
    void Clear();
    bool Contains(T item);
  }

  class MyList<T> : IMyList<T> {
    
    private T[] array;
    private int maxPos;

    public MyList() {
      Clear();
    }

    /// <summary>
    /// получение элемента массива из коллекции по индексу
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index] {
      get {
        if (index < 0 || index > maxPos) {
          throw new ArgumentOutOfRangeException("index");
        }
        return array[index];
      }
    }

    /// <summary>
    /// количество используемых элементов массива
    /// </summary>
    public int Count => maxPos + 1;

    /// <summary>
    /// Добавление элемента в коллекцию
    /// </summary>
    /// <param name="a"></param>
    public void Add(T a) {
      maxPos++;
      if (maxPos >= array.Length) upSize();
      array[maxPos] = a;
    }

    /// <summary>
    /// очистка коллекции
    /// </summary>
    public void Clear() {
      maxPos = -1;
      array = new T[3];
    }

    /// <summary>
    /// содержится ли элемент в коллекции
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item) {
      IEqualityComparer<T> comparer = EqualityComparer<T>.Default;
      foreach (T el in array) {
        if (comparer.Equals(item, el)) return true;
      }
      return false;
    }

    /// <summary>
    /// увеличение размера массива с небольшим запасом
    /// </summary>
    private void upSize() {
      T[] tmp_array = new T[array.Length + 3];
      for (int i = 0; i < array.Length; i++) {
        tmp_array[i] = array[i];
      }
      array = new T[tmp_array.Length];
      for (int i = 0; i < array.Length; i++) {
        array[i] = tmp_array[i];
      }
    }
  }

  class Program {
    static void Main(string[] args) {

      var mylist = new MyList<char>();

      Random rnd = new Random();
      for (int i = 0; i < 20; i++) {
        mylist.Add((char)rnd.Next('a','z'));
      }

      for (int i = 0; i < mylist.Count; i++) {
        Console.Write(mylist[i]);
        Console.Write(" ");
      }
      Console.WriteLine();

      Console.ReadKey();
    }
  }
}
