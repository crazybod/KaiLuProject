using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace KL_Project.Untity
{
    [Description("保存日志")]
    public class Log
    {
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="LogInfo">日志信息</param>
        /// <param name="Path">保存路径</param>
        public static void WriteLog(string LogInfo, string Path)
        {
            using (StreamWriter sw = new StreamWriter(Path, true, Encoding.UTF8))
            {
                sw.WriteLine(LogInfo);
            }
        }

        /// <summary>
        /// 根据异常类型生成 消息日志
        /// </summary>
        /// <param name="e">异常对象</param>
        /// <returns></returns>
        public static string PrintStackTrace(Exception e)
        {
            var sb = new StringBuilder(1024);
            sb.Append($"Exception Type {e.GetType().Name}, Message:{e.Message},Stack:{e.StackTrace}\n");
            if (e.InnerException != null)
            {
                sb.Append(" inner Exception: ");
                sb.Append(PrintStackTrace(e.InnerException));
            }
            return sb.ToString();
        }
    }
}
