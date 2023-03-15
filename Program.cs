using System;
using System.Collections.Generic;

namespace Berkeley
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateOne = new DateTime(1, 1, 1, 3, 0, 0);
            var dateTwo = new DateTime(1, 1, 1, 2, 50, 0);
            var dateThree = new DateTime(1, 1, 1, 3, 20, 0);
            var dateFour = new DateTime(1, 1, 1, 3, 10, 0);


            var listComputers = new List<Computer>() { new Computer(1, dateOne, true, true), new Computer(2, dateTwo, false, true), new Computer(3, dateThree, false, true), new Computer(4, dateFour, false, true) };

            var master = new Master(listComputers);

            master.Execute();
        }
    }
}
