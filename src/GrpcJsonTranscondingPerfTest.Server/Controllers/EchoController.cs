using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GrpcJsonTranscondingPerfTest.Server.Controllers
{
    [ApiController]
    public class Echo : ControllerBase
    {
        [HttpGet("small")]
        public Task<GrpcJsonTranscondingPerfTest.Common.Models.SmallPayloadResponse> EchoWithSmallPayloadByGet([FromQuery] GrpcJsonTranscondingPerfTest.Common.Models.SmallPayloadRequest request)
        {
            var response = new GrpcJsonTranscondingPerfTest.Common.Models.SmallPayloadResponse() { Message = request.Message };
            return Task.FromResult(response);
        }

        [HttpPost("small")]
        public Task<GrpcJsonTranscondingPerfTest.Common.Models.SmallPayloadResponse> EchoWithSmallPayloadByPost([FromBody] GrpcJsonTranscondingPerfTest.Common.Models.SmallPayloadRequest request)
        {
            var response = new GrpcJsonTranscondingPerfTest.Common.Models.SmallPayloadResponse() { Message = request.Message };
            return Task.FromResult(response);
        }

        [HttpPost("massive")]
        public Task<GrpcJsonTranscondingPerfTest.Common.Models.MassivePayloadResponse> EchoWithMassivePayloadByPost([FromBody] GrpcJsonTranscondingPerfTest.Common.Models.MassivePayloadRequest request)
        {
            var response = new GrpcJsonTranscondingPerfTest.Common.Models.MassivePayloadResponse() { IntList = request.IntList, StringList = request.StringList };
            return Task.FromResult(response);
        }
    }
}