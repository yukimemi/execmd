using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace execmd
{
  class Program
  {
    static void Main(string[] args)
    {
      var cmdPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      var cmdDir = System.IO.Path.GetDirectoryName(cmdPath);
      var cmdName = System.IO.Path.GetFileNameWithoutExtension(cmdPath);
      var execmd = System.IO.Path.Combine(cmdDir, cmdName + ".cmd");
      var proc = new System.Diagnostics.Process();
      proc.StartInfo.FileName = execmd;
      proc.StartInfo.Arguments = string.Join(" ", args);

      proc.Start();

      proc.WaitForExit();

      System.Environment.Exit(proc.ExitCode);

    }
  }
}
