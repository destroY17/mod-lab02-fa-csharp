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
        private static State initialState = new State()
        {
            Name = "Initial",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State contains0State = new State()
        {
            Name = "Contains0",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State contains1State = new State()
        {
            Name = "Contains1",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State acceptingState = new State()
        {
            Name = "Accepting",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        private static State negativeState = new State()
        {
            Name = "NegativeAbsorbing",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        public FA1()
        {
            SetTransitions();
        }

        private static void SetTransitions()
        {
            initialState.Transitions['0'] = contains0State;
            initialState.Transitions['1'] = contains1State;

            contains0State.Transitions['0'] = negativeState;
            contains0State.Transitions['1'] = acceptingState;

            contains1State.Transitions['0'] = acceptingState;
            contains1State.Transitions['1'] = contains1State;

            acceptingState.Transitions['0'] = negativeState;
            acceptingState.Transitions['1'] = acceptingState;

            negativeState.Transitions['0'] = negativeState;
            negativeState.Transitions['1'] = negativeState;
        }

        public bool? Run(IEnumerable<char> word)
        {
            State currentState = initialState;

            foreach(var symbol in word)
            {
                currentState = currentState.Transitions[symbol];

                if (currentState == null)
                    return null;
            }
            return currentState.IsAcceptState;
        }
    }


    public class FA2
    {
        private static State initialState = new State()
        {
            Name = "Initial",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State contains0State = new State()
        {
            Name = "Contains0",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State contains1State = new State()
        {
            Name = "Contains1",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State acceptingState = new State()
        {
            Name = "Accepting",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        public FA2()
        {
            SetTransitions();
        }

        private static void SetTransitions()
        {
            initialState.Transitions['0'] = contains0State;
            initialState.Transitions['1'] = contains1State;

            contains0State.Transitions['0'] = initialState;
            contains0State.Transitions['1'] = acceptingState;

            contains1State.Transitions['0'] = acceptingState;
            contains1State.Transitions['1'] = initialState;

            acceptingState.Transitions['0'] = contains1State;
            acceptingState.Transitions['1'] = contains0State;
        }

        public bool? Run(IEnumerable<char> word)
        {
            State currentState = initialState;

            foreach (var symbol in word)
            {
                currentState = currentState.Transitions[symbol];

                if (currentState == null)
                    return null;
            }
            return currentState.IsAcceptState;
        }
    }

    public class FA3
    {
        private static State initialState = new State()
        {
            Name = "Initial",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State contains1State = new State()
        {
            Name = "Contains1",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = false
        };

        private static State acceptingState = new State()
        {
            Name = "Accepting",
            Transitions = new Dictionary<char, State>(),
            IsAcceptState = true
        };

        public FA3()
        {
            SetTransitions();
        }

        private static void SetTransitions()
        {
            initialState.Transitions['0'] = initialState;
            initialState.Transitions['1'] = contains1State;

            contains1State.Transitions['0'] = initialState;
            contains1State.Transitions['1'] = acceptingState;

            acceptingState.Transitions['0'] = acceptingState;
            acceptingState.Transitions['1'] = acceptingState;
        }

        public bool? Run(IEnumerable<char> word)
        {
            State currentState = initialState;

            foreach (var symbol in word)
            {
                currentState = currentState.Transitions[symbol];

                if (currentState == null)
                    return null;
            }
            return currentState.IsAcceptState;
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
