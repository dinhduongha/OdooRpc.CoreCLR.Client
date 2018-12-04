using System.Linq;
using System.Threading.Tasks;
using OdooRpc.CoreCLR.Client.Interfaces;
using OdooRpc.CoreCLR.Client.Models;
using OdooRpc.CoreCLR.Client.Models.Parameters;
using OdooRpc.CoreCLR.Client.Internals;
using JsonRpc.CoreCLR.Client.Models;
using Xunit;
using Newtonsoft.Json.Linq;
using System;
using OdooRpc.CoreCLR.Client.Tests.Helpers;

namespace OdooRpc.CoreCLR.Client.Tests
{
    public partial class OdooRpcClientTests
    {
        [Fact]
        public async Task Load_ShouldCallRpcWithCorrectParameters()
        {
            var data = new[] {
                new [] {"data", "data"},
                new [] {"data", "data"}
            };
            var header = new[] { "name", "display_name" };

            var response = new JsonRpcResponse<dynamic>();
            response.Id = 1;
            response.Result = 78;

            await TestOdooRpcCall(new OdooRpcCallTestParameters<dynamic>()
            {
                Model = "res.partner",
                Method = "load",
                Validator = (p) =>
                {
                    Assert.Equal(6, p.args.Length);

                    dynamic args = p.args[5];
                    Assert.Equal(1, args.Length);
                    Assert.Equal(
                        new object[]
                        {
                            header,
                            data
                        },
                        args
                    );
                },
                ExecuteRpcCall = () => RpcClient.Load<dynamic>("res.partner", data, header),
                TestResponse = response
            });
        }
    }
}
