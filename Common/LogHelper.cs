using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LogHelper
    {
        public static log4net.ILog Log = log4net.LogManager.GetLogger("MV Log");
    }
}
