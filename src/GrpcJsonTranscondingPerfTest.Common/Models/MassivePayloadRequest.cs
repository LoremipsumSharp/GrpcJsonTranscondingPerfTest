using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcJsonTranscondingPerfTest.Common.Models
{
    public class MassivePayloadRequest
    {
        public List<string> StringList { get; set; }
        public List<int> IntList { get; set; }
    }
}