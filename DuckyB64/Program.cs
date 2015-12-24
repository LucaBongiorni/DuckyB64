using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckyB64
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguements = GetArgs(args);

            foreach (var arguement in arguements)
            {
                switch (arguement.Key)
                {
                    case "-i":
                        InputPath = arguement.Value;
                        break;

                    case "-o":
                        OutputPath = arguement.Value;
                        break;

                    case "-or":
                        if(string.IsNullOrEmpty(arguement.Value))
                            WriteErrorAndClose("Output restore path must be supplied.");

                        OutputRestorePath = arguement.Value;
                        OutputRestore = true;
                        break;

                    case "-base64only":
                        Base64Only = true;
                        break;

                    case "-a":
                        InputArguments = arguement.Value;
                        break;
                }
            }

            if (!File.Exists(InputPath))
                WriteErrorAndClose("Input file does not exist.");

            WriteText();

            if(OutputRestore)
                RestoreOutput();
        }

        private static string OutputPath;
        private static string OutputRestorePath;
        private static bool OutputRestore;
        private static string InputPath;
        private static bool Base64Only;
        private static string InputArguments;

        private static void WriteErrorAndClose(string error, Exception e = null)
        {
            Console.WriteLine();
            Console.WriteLine("Error: " + error);
            Console.WriteLine();

            if (e != null)
            {
                Console.WriteLine("<EXCEPTION>");

                Console.WriteLine(e);

                Console.WriteLine("</EXCEPTION>");
            }

            Environment.Exit(0);
        }

        private static Dictionary<string, string> GetArgs(string[] args)
        {
            var dic = new Dictionary<string, string>();

            for (var i = 0; i < args.Length; i++)
            {
                var key = args[i].StartsWith("-") ? args[i] : null;
                var val = args.Length - 1 > i
                          && !args[i + 1].StartsWith("-") ?
                          args[i + 1] :
                          null;

                if(key != null)
                    dic.Add(key, val);
            }
            
            return dic;
        }

        private static void WriteText()
        {
            byte[] zipBytes;

            using (var zippedStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(zippedStream, CompressionLevel.Optimal))
                    using(var fileStream = File.OpenRead(InputPath))
                        fileStream.CopyTo(gzipStream);

                zipBytes = zippedStream.ToArray();
            }

            var str = Convert.ToBase64String(zipBytes);

            if (!Base64Only)
            {
                var cs = Resources.Base64ToExe;

                var inputDucky = GetDuckyStringScript(str);

                str = string.Format(Resources.DuckyB64Template, 
                                    cs, 
                                    inputDucky, 
                                    Path.GetFileName(InputPath), InputArguments);
            }

            try
            {
                using (var file = File.CreateText(OutputPath))
                    file.WriteLine(str);
            }
            catch (Exception e)
            {
                WriteErrorAndClose("Could not write to output file.", e);
            }
        }

        static string GetDuckyStringScript(string input)
        {
            var splits = Split(input, 72);

            var str = "STRING ";
            foreach (var split in splits)
            {
                str += split;

                if (splits.IndexOf(split) != splits.Count - 1)
                    str += "\r\nENTER\r\nSTRING ";
            }

            return str;
        }

        static List<string> Split(string str, int chunkSize)
        {
            var list = new List<String>();
            string strTemp = "";
            
            for (int i = 0; i < str.Length; i++)
            {
                strTemp += str[i];

                if ((i + 1)%chunkSize == 0 || i == str.Length - 1)
                {
                    list.Add(strTemp);
                    strTemp = "";
                }
            }

            return list;
        }

        private static void RestoreOutput()
        {
            var text = File.ReadAllText(OutputPath)
                            .Replace("ENTER", "")
                            .Replace("STRING", "")
                            .Replace("\r\n", "")
                            .Replace(" ", "");

            var bytes = Convert.FromBase64String(text);

            using(var compressedStream = new MemoryStream(bytes))
                using(var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                    using (var decompressedStream = new MemoryStream())
                    {
                        zipStream.CopyTo(decompressedStream);
                        bytes = decompressedStream.ToArray();
                    }
            
            try
            {
                using (var file = File.Create(OutputRestorePath))
                    file.Write(bytes, 0, bytes.Length);  
            }
            catch (Exception e)
            {
                  WriteErrorAndClose("Could not restore output.", e);
            }
        }
    }
}
