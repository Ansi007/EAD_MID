using System.Data;

List<string> list = new List<string>();
list.Add("HONDA");
list.Add("TOYOTA");
list.Add("FERRARI");
list.Add("LAMBORGHINI");
list.Add("CHEVERLOT");
list.Add("NISAAN");
list.Add("TESLA");

var query = from x in list where x.Contains('A') select x.Substring(0,3);
foreach(var item in query)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------------------------------");
list.Where(x => x.Contains('A')).Select(x=>x.Substring(0,3)).OrderBy(x=>x).ToList().ForEach(x=>Console.WriteLine(x));

DataTable t = new DataTable();
t.Columns.Add(new DataColumn("ID", typeof(int)));
t.Columns.Add(new DataColumn("Name", typeof(string)));
DataRow r = t.NewRow();
r["ID"] = 1;
r["Name"] = "FIRST";
DataRow r2 = t.NewRow();
r2["ID"] = 2;
r2["Name"] = "SECOND";
t.Rows.Add(r);
t.Rows.Add(r2);

t.AsEnumerable()
    .Where(x => (int)x["ID"] > 0)
    .Select(x => x)
    .ToList()
    .ForEach(x => Console.WriteLine(x["ID"] + " AND " + x["NAME"]));

var query2 = from x in t.AsEnumerable() /*where (int)x["ID"] > 0*/ select new { V = x["ID"], V1 = x["Name"] };
foreach(var i in query2)
{
    Console.WriteLine(i.V);
    Console.WriteLine(i.V1);
}