string localbase = AppContext.BaseDirectory;
string way = Path.Combine(localbase, "files", "wayfile.txt");

Console.WriteLine(File.ReadAllText(way));