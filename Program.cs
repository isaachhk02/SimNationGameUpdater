namespace simnationupdater;

class Program
{
    private static void Main(string[] args) {
        var updater = new Updater();
        if (OperatingSystem.IsWindows()) {
            updater.Update("C:\\Games\\SimNation","path0.zip");
        }
        if (OperatingSystem.IsLinux()) {
            updater.Update(Environment.GetEnvironmentVariable("HOME") + "/SimNation","path0.zip");
        }
        if (OperatingSystem.IsMacOS()) {
            updater.Update(Environment.GetEnvironmentVariable("HOME") + "/Documents/SimNation","path0.zip");
        }
    }
    
}
