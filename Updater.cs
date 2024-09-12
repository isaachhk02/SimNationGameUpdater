using System.IO.Compression;

namespace simnationupdater;

public class Updater() {
    public void Update(string gamePath, string patchFile) {
        ZipArchive zipArchive;
        if (OperatingSystem.IsWindows()) {
            if (Directory.Exists(gamePath)) {
                Console.WriteLine("SimNation folder detected!");
                if (File.Exists(gamePath + "\\PatchFiles\\" + patchFile)) {
                    zipArchive = new ZipArchive(File.OpenRead(gamePath + "\\PatchFiles\\" + patchFile));
                    Console.WriteLine("New update detected! Extracting....");
                    try {
                        zipArchive.ExtractToDirectory(gamePath,true);
                        File.Delete("./PatchFiles/" + patchFile);
                        Console.WriteLine("Extracted successfully");
                    } catch (Exception e) {
                        Console.ForegroundColor = System.ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                    

                }
            }
            else {
                gamePath = Directory.GetCurrentDirectory();
                if (File.Exists(gamePath + "/PatchFiles/" + patchFile)) {
                    zipArchive = new ZipArchive(File.OpenRead(gamePath + "/PatchFiles/" + patchFile));
                    Console.WriteLine("New update detected! Extracting....");
                    try {
                        zipArchive.ExtractToDirectory(gamePath,true);
                        File.Delete(gamePath + "/PatchFiles/" + patchFile);
                        Console.WriteLine("Extracted successfully");
                    } catch (Exception e) {
                        Console.ForegroundColor = System.ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }
                }
                }
            }
        if (OperatingSystem.IsLinux())
        {
            if (Directory.Exists(gamePath)) {
                Console.WriteLine("SimNation detected on "+ gamePath);
                if (File.Exists(gamePath + "/PatchFiles/" + patchFile)) {
                    Console.WriteLine("New update detected! Extracting from PatchFiles/path0.zip");
                    zipArchive = new ZipArchive(File.OpenRead(gamePath + "/PatchFiles/" + patchFile));
                    try {
                        zipArchive.ExtractToDirectory(gamePath,true);
                        File.Delete(gamePath + "/PatchFiles/" + patchFile);
                        Console.WriteLine("Extracted successfully");
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
                else {
                    Console.WriteLine("No update found!");
                    
                }
            }
            else {
                Console.WriteLine("No SimNation folder found!");
            }
        }
        if (OperatingSystem.IsMacOS())
        {
            if (Directory.Exists(gamePath)) {
                Console.WriteLine("SimNation detected on "+ gamePath);
                if (File.Exists(gamePath + "/PatchFiles/" + patchFile)) {
                    Console.WriteLine("New update detected! Extracting from PatchFiles/path0.zip");
                    zipArchive = new ZipArchive(File.OpenRead(gamePath + "/PatchFiles/" + patchFile));
                    try {
                        zipArchive.ExtractToDirectory(gamePath,true);
                        File.Delete(gamePath + "/PatchFiles/" + patchFile);
                        Console.WriteLine("Extracted successfully");
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
                else {
                    Console.WriteLine("No update found!");
                    
                }
            }
            else {
                Console.WriteLine("No SimNation folder found!");
            }
        }

    }
}