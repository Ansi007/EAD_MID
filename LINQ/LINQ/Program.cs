List<string> list = new List<string>();
list.Add("HONDA");
list.Add("TOYOTA");
list.Add("FERRARI");
list.Add("LAMBORGHINI");
list.Add("CHEVERLOT");
list.Add("NISAAN");
list.Add("TESLA");

var query = from x in list where x.Contains('A') select x;
foreach(var item in query)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------------------------------");
list.Where(x => x.Contains('A')).Select(x=>x.Substring(0,3)).OrderBy(x=>x).ToList().ForEach(x=>Console.WriteLine(x));