using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {

        public string LogType { get; set; }

        public int LogSeverity { get; set; }



        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawl(int logBalanceAfterWithdrawl);

        string MessageWIthReturrStr(string message);

        bool LogWithOutputResult(string str, out string outputstr);

        bool LogWithREfObject(ref Customer customer);
    }
    public class LogBook : ILogBook
    {
        public string LogType { get; set; }
        public int LogSeverity { get; set; }




        public void Message(string message)
        {
            Console.WriteLine(message);
        }
        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return false;
        }

        public bool LogBalanceAfterWithdrawl(int logBalanceAfterWithdrawl)
        {
            if(logBalanceAfterWithdrawl >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failiure");
            return false;
        }

        public string MessageWIthReturrStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public bool LogWithOutputResult(string str,  out string outputstr)
        {
            outputstr = "Hello " + str;
            return true;
        }

        public bool LogWithREfObject(ref Customer customer)
        {
            return true;
        }
    }

    //public class LogFaker : ILogBook
    //{
    //    public void Message(string message)
    //    {
    //    }
       
    //}
}
