using Events;

MyEvents myEvents = new MyEvents();
myEvents.EntryPoint();

Publisher publisher = new Publisher();
WindowsSubscriber windowsSubscriber = new WindowsSubscriber();
MacSubscriber macSubscriber = new MacSubscriber();
windowsSubscriber.SubscribeLeftClick(publisher);
macSubscriber.SubscribeLeftClick(publisher);
macSubscriber.SubscribeRightClick(publisher);

publisher.OnLeftClick("Left Click Invoked ");
publisher.OnRightClick("Right Click Invoked");

MyArrayList list = new MyArrayList();
list.Added += (sender, args) =>
{
    Console.WriteLine($"Event is raised by {sender}, and now the count is {args.count}");
};

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);