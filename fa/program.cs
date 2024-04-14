using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


public class FA1
{
    private class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    private State InitialState { get; set; }

    public FA1()
    {
        State onlyOneZero = new State { Name = "onlyOneZero", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
        State start = new State { Name = "start", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State dead = new State { Name = "dead", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

        start.Transitions['0'] = onlyOneZero;
        start.Transitions['1'] = start;
        onlyOneZero.Transitions['0'] = dead;
        onlyOneZero.Transitions['1'] = onlyOneZero;
        dead.Transitions['0'] = dead;
        dead.Transitions['1'] = dead;

        InitialState = start;
    }

    public bool Run(string input)
    {
        State current = InitialState;
        foreach (char symbol in input)
        {
            if (!current.Transitions.TryGetValue(symbol, out current))
                return false;
        }
        return current.IsAcceptState;
    }
}

public class FA2
{
    private class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    private State InitialState { get; set; }

    public FA2()
    {
        State oddZerosOddOnes = new State { Name = "oddZerosOddOnes", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
        State oddZerosEvenOnes = new State { Name = "oddZerosEvenOnes", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State evenZerosOddOnes = new State { Name = "evenZerosOddOnes", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State evenZerosEvenOnes = new State { Name = "evenZerosEvenOnes", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

        oddZerosOddOnes.Transitions['0'] = evenZerosOddOnes;
        oddZerosOddOnes.Transitions['1'] = oddZerosEvenOnes;
        oddZerosEvenOnes.Transitions['0'] = evenZerosEvenOnes;
        oddZerosEvenOnes.Transitions['1'] = oddZerosOddOnes;
        evenZerosOddOnes.Transitions['0'] = oddZerosOddOnes;
        evenZerosOddOnes.Transitions['1'] = evenZerosEvenOnes;
        evenZerosEvenOnes.Transitions['0'] = oddZerosEvenOnes;
        evenZerosEvenOnes.Transitions['1'] = evenZerosOddOnes;

        InitialState = evenZerosEvenOnes;
    }

    public bool Run(string input)
    {
        State current = InitialState;
        foreach (char symbol in input)
        {
            if (!current.Transitions.TryGetValue(symbol, out current))
                return false;
        }
        return current.IsAcceptState;
    }
}
  
public class FA3
{
    private class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    private State InitialState { get; set; }

    public FA3()
    {
        State start = new State { Name = "start", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State oneRead = new State { Name = "oneRead", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State twoOnesRead = new State { Name = "twoOnesRead", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
        
        start.Transitions['0'] = start;
        start.Transitions['1'] = oneRead;
        oneRead.Transitions['0'] = start;
        oneRead.Transitions['1'] = twoOnesRead;
        twoOnesRead.Transitions['0'] = twoOnesRead;
        twoOnesRead.Transitions['1'] = twoOnesRead;
        
        InitialState = start;
    }

    public bool Run(string input)
    {
        State current = InitialState;
        foreach (char symbol in input)
        {
            if (!current.Transitions.TryGetValue(symbol, out current))
                return false;
        }
        return current.IsAcceptState;
    }
}
  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
