using System.Threading.Tasks;
using Grpc.Core;
using GrpcJsonTranscondingPerfTest;

namespace GrpcJsonTranscondingPerfTest.Server.Grpc
{
    public class EchoService : GrpcJsonTranscondingPerfTest.EchoService.EchoServiceBase
    {
        public override Task<MassivePayloadResponse> EchoWithMassivePayloadByPost(MassivePayloadRequest request, ServerCallContext context)
        {
            var response = new MassivePayloadResponse() { IntList = { request.IntList }, StringList = { request.StringList } };
            return Task.FromResult(response);

        }

        public override Task<SmallPayloadResponse> EchoWithSmallPayloadByGet(SmallPayloadRequest request, ServerCallContext context)
        {
            var response = new SmallPayloadResponse() { Message = request.Message };
            return Task.FromResult(response);

        }

        public override Task<SmallPayloadResponse> EchoWithSmallPayloadByPost(SmallPayloadRequest request, ServerCallContext context)
        {
            var response = new SmallPayloadResponse() { Message = request.Message };
            return Task.FromResult(response);
        }
    }
}