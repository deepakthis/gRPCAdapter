using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public class GRPCAdapter
    {
        // client 
        public async Task<string> OutGoingRequestAsync(string url, Object requestModel)
        {
            var channel = GrpcChannel.ForAddress(url);
            var client = new GRPCRequestResponse.GRPCRequestResponseClient(channel);

            var grpcRequest = JsonConvert.DeserializeObject<GRPCRequest>(JsonConvert.SerializeObject(requestModel));
            
            var reply = await client.GRPCCheckAsync(grpcRequest);

            channel.ShutdownAsync().Wait();
            return reply.Message;
        }

    }
}
