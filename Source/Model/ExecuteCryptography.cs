using CrypterMode.Source;

string localbase = AppContext.BaseDirectory;

for (int i = 0; i < 4; i++)
{
    localbase = Directory.GetParent(localbase)!.FullName;
}

string textmode = Path.Combine(localbase, "files", "mode.txt");
string localFileWay = Path.Combine(localbase, "files", "wayFile.txt");
string localFileText = Path.Combine(localbase, "files", "textFile.txt");
string secret = Path.Combine(localbase, "files", "key.txt");

string encrypt = Path.Combine(localbase, "crypted", "Encrypt.txt");
string decrypt = Path.Combine(localbase, "crypted", "Decrypt.txt");

string fileWay = File.ReadAllText(localFileWay).Trim();
string fileText = File.ReadAllText(localFileText).Trim();

if (File.ReadAllText(textmode).Trim().Contains("RunModeOne"))
{
    if (fileWay.Contains("nullArId277068"))
    {
        string text = Encrypt.Connect(File.ReadAllText(fileText), null, File.ReadAllText(secret).Trim());
        using (StreamWriter writer = new StreamWriter(encrypt))
        {
            writer.Write(text);
            writer.Close();
        }
    } else if (fileText.Contains("nullArId277068"))
    {
        string text = Encrypt.Connect(null, File.ReadAllLines(fileWay), File.ReadAllText(secret).Trim());
        using (StreamWriter writer = new StreamWriter(encrypt))
        {
            writer.Write(text);
            writer.Close();
        }
    }    
} else if (File.ReadAllText(textmode).Trim().Contains("RunModeTwo"))
{
    string text = Decrypt.Connect(File.ReadAllText(fileWay), File.ReadAllText(secret).Trim());
    using (StreamWriter writer = new StreamWriter(decrypt))
    {
        writer.Write(text);
        writer.Close();
    }
}
