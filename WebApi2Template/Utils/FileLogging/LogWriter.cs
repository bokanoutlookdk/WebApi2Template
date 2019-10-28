using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApi2Template.Utils.FileLogging
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;

        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }
        public void LogWrite(string logMessage)
        {
            m_exePath = GetExePath();
            if (m_exePath.Contains("WebApi2Template"))
                m_exePath = m_exePath.Substring(0, m_exePath.IndexOf("dof-gratisalloen") + "dof-gratisalloen".Length);
            //else
            // if (m_exePath.Contains("dofgratisal"))
            //    m_exePath = m_exePath.Substring(0, m_exePath.IndexOf("dof-gratisalloen") + "dof-gratisalloen".Length);
            else
            if (m_exePath.Contains("test")) // test server
                m_exePath = m_exePath.Substring(0, m_exePath.IndexOf("test") + "test".Length);

            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch
            {
                throw new Exception($"file log not enabled! on path: {m_exePath}");
            }

            //Logger.Info(logMessage); 
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

        private string GetExePath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path).ToLower();
        }
    }
}