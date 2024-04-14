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
        public Dictionary<char, State> Transitions = new Dictionary<char, State>();
        public bool IsAcceptState;
    }

    private State start = new State { IsAcceptState = false };
    private State oneZero = new State { IsAcceptState = false };
    private State oneZeroOne = new State { IsAcceptState = true };

    public FA1()
    {
        start.Transitions['0'] = oneZero;
        start.Transitions['1'] = start;
        oneZero.Transitions['1'] = oneZeroOne;
    }

    public bool? Run(string s)
    {
        State current = start;
        foreach (char c in s)
        {
            if (!current.Transitions.TryGetValue(c, out current))
                return null;
        }
        return current.IsAcceptState;
    }
}

public class FA2
{
    private class State
    {
        public Dictionary<char, State> Transitions = new Dictionary<char, State>();
        public bool IsAcceptState;
    }

    private State start = new State();
    private State oddZero = new State();
    private State oddOne = new State();
    private State oddBoth = new State { IsAcceptState = true };

    public FA2()
    {
        start.Transitions['0'] = oddZero;
        start.Transitions['1'] = oddOne;
        oddZero.Transitions['0'] = start;
        oddZero.Transitions['1'] = oddBoth;
        oddOne.Transitions['0'] = oddBoth;
        oddOne.Transitions['1'] = start;
        oddBoth.Transitions['0'] = oddOne;
        oddBoth.Transitions['1'] = oddZero;
    }

    public bool? Run(string s)
    {
        State current = start;
        foreach (char c in s)
        {
            if (!current.Transitions.TryGetValue(c, out current))
                return null;
        }
        return current.IsAcceptState;
    }
}
  
public class FA3
{
    private class State
    {
        public Dictionary<char, State> Transitions = new Dictionary<char, State>();
        public bool IsAcceptState;
    }

    private State start = new State();
    private State one = new State();
    private State twoOnes = new State { IsAcceptState = true };

    public FA3()
    {
        start.Transitions['0'] = start;
        start.Transitions['1'] = one;
        one.Transitions['0'] = start;
        one.Transitions['1'] = twoOnes;
        twoOnes.Transitions['0'] = twoOnes;
        twoOnes.Transitions['1'] = twoOnes;
    }

    public bool? Run(string s)
    {
        State current = start;
        foreach (char c in s)
        {
            if (!current.Transitions.TryGetValue(c, out current))
                return null;
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
