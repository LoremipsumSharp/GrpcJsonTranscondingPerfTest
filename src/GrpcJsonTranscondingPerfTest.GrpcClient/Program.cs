
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcJsonTranscondingPerfTest.Common;

namespace GrpcJsonTranscondingPerfTest.GrpcClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
        }

    }

    public class BenchmarkClass
    {

        private static EchoService.EchoServiceClient _client;



        static BenchmarkClass()
        {
            var channel = GrpcChannel.ForAddress("http://192.168.31.106:5500", new GrpcChannelOptions() { Credentials = ChannelCredentials.Insecure });
            _client = new EchoService.EchoServiceClient(channel);
        }

        [Benchmark]
        public async Task SendSmallPayloadByGet()
        {
            await _client.EchoWithSmallPayloadByGetAsync(new SmallPayloadRequest() { Message = System.Guid.NewGuid().ToString() });
        }

        [Benchmark]
        public async Task SendSmallPayloadByPost()
        {
            await _client.EchoWithSmallPayloadByPostAsync(new SmallPayloadRequest() { Message = System.Guid.NewGuid().ToString() });
        }

        [Benchmark]
        public async Task SendMassivePayloadByPost()
        {

            var intList = Utils.CreateIntList();
            var stringList = Utils.CreateStringList();

            await _client.EchoWithMassivePayloadByPostAsync(new MassivePayloadRequest() { IntList = { intList }, StringList = { stringList } });
        }



    }
}