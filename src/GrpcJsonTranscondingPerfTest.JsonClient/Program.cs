
using System.Net.Http;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using GrpcJsonTranscondingPerfTest.Common;
using GrpcJsonTranscondingPerfTest.Common.Models;
using Newtonsoft.Json;

namespace GrpcJsonTranscondingPerfTest.JsonClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
        }

        public class BenchmarkClass
        {
            private static readonly HttpClient _client = new HttpClient() { BaseAddress = new System.Uri("http://192.168.31.106:5000") };


            [Benchmark]
            public async Task SendSmallPayloadByGet()
            {
                var response = await _client.GetStringAsync($"small?message={System.Guid.NewGuid().ToString()}");
                var result = JsonConvert.DeserializeObject<SmallPayloadResponse>(response);
            }

            [Benchmark]
            public async Task SendSmallPayloadByPost()
            {
                var response = await _client.PostAsync("small", new StringContent(JsonConvert.SerializeObject(new SmallPayloadRequest() { Message = System.Guid.NewGuid().ToString() }), Encoding.UTF8, "application/json"));
                var result = JsonConvert.DeserializeObject<SmallPayloadResponse>(await response.Content.ReadAsStringAsync());
            }

            [Benchmark]
            public async Task SendMassivePayloadByPost()
            {

                var intList = Utils.CreateIntList();
                var stringList = Utils.CreateStringList();

                var response = await _client.PostAsync("massive", new StringContent(JsonConvert.SerializeObject(new MassivePayloadRequest() { IntList = intList, StringList = stringList }), Encoding.UTF8, "application/json"));
                var result = JsonConvert.DeserializeObject<MassivePayloadResponse>(await response.Content.ReadAsStringAsync());
            }

        }

    }
}