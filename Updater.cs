using System.Diagnostics;
using System.IO.Compression;

namespace simnationupdater;

public class Updater()
{
    public void Update(string gamePath, string patchFile)
    {
        ZipArchive zipArchive;

        if (OperatingSystem.IsWindows())
        {
            if (Directory.Exists(gamePath))
            {
                Console.WriteLine("SimNation folder detected!");

                foreach (var f in Directory.GetFiles(gamePath + "\\PatchFiles\\"))
                {
                    if (f.StartsWith(patchFile) && File.Exists(f))
                    {
                        Console.WriteLine("Update detected: " + f);

                        zipArchive = new ZipArchive(File.OpenRead(f));
                        Console.WriteLine("Extracting....");
                        try
                        {
                            zipArchive.ExtractToDirectory(gamePath, true);
                            File.Delete(f);
                            Console.WriteLine("Extracted successfully");
                            Process.Start(gamePath + "\\FreeSO.exe", "-dx");
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = System.ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                        }
                    }

                }
            }
            else
            {
                gamePath = Directory.GetCurrentDirectory();
                foreach (var z in Directory.GetFiles(gamePath + "\\PatchFiles\\"))
                {
                    if (File.Exists(z) && z.StartsWith("path"))
                    {
                        zipArchive = new ZipArchive(File.OpenRead(z));
                        Console.WriteLine("New update detected! Extracting....");
                        try
                        {
                            zipArchive.ExtractToDirectory(gamePath, true);
                            File.Delete(z);
                            Console.WriteLine("Extracted successfully");
                            Process.Start(gamePath + "/FreeSO.exe", "-dx");
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = System.ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                        }
                    }
                }

            }
        }

        if (OperatingSystem.IsLinux())
        {
            if (Directory.Exists(gamePath))
            {
                Console.WriteLine("SimNation detected on " + gamePath);
                foreach (var file in Directory.GetFiles(gamePath + "/PatchFiles/"))
                {
                    if (File.Exists(file) || file.StartsWith("path"))
                    {
                        Console.WriteLine("New update detected! Extracting files");
                        zipArchive = new ZipArchive(File.OpenRead(file));
                        try
                        {
                            zipArchive.ExtractToDirectory(gamePath, true);
                            File.Delete(file);
                            Console.WriteLine("Extracted successfully");
                            Process.Start("mono", gamePath + "/FreeSO.exe");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No update found!");

                    }
                }
            }
            else
            {
                Console.WriteLine("No SimNation folder found!");
            }
        }

        if (OperatingSystem.IsMacOS())
        {
            if (Directory.Exists(gamePath))
            {
                Console.WriteLine("SimNation detected on " + gamePath);
                foreach (var f in Directory.GetFiles(gamePath + "/PatchFiles/"))
                {
                    if (f.StartsWith("path") && File.Exists(f))
                    {
                        Console.WriteLine("New update detected! Extracting files");
                        zipArchive = new ZipArchive(File.OpenRead(f));
                        try
                        {
                            zipArchive.ExtractToDirectory(gamePath, true);
                            File.Delete(f);
                            Console.WriteLine("Extracted successfully");
                            Process.Start("Library/Frameworks/Mono.framework/Versions/Current/Commands/mono",
                                gamePath + "/FreeSO.exe");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No update found!");

                    }
                }
            }
            else
            {
                Console.WriteLine("No SimNation path detected!");
            }
        }
    }
}
