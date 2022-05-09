using Delegates;

SimpleDelegates simpleDelegates = new SimpleDelegates();
simpleDelegates.EntryPoint();

DelegatesWithAnonymousAndLamba lamba = new DelegatesWithAnonymousAndLamba();
lamba.EntryPoint();

MulticastingDelegates multicast = new MulticastingDelegates();
multicast.EntryPoint();

Calculator c  = new Calculator();   
c.EntryPoint();