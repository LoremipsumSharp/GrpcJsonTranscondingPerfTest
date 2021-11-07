using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcJsonTranscondingPerfTest.Common
{
    public static class Utils
    {
        public static List<int> CreateIntList()
        {
            var intList = new List<int>();
            for (int i = 0; i < 150; i++)
                intList.Add(i);

            return intList;
        }

        public static List<string> CreateStringList()
        {
            var stringList = new List<string>();
            for (int i = 0; i < 150; i++)
                stringList.Add(System.Guid.NewGuid().ToString());

            return stringList;
        }
    }
}