using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Interfaces;
using OdooRpc.CoreCLR.Client.Models;

namespace OdooRpc.CoreCLR.Client.Internals.Commands
{
    internal class OdooLoadCommand : OdooAbstractCommand
    {
        public OdooLoadCommand(IJsonRpcClient rpcClient)
            : base(rpcClient)
        {
        }

        public Task<dynamic> Execute<T>(OdooSessionInfo sessionInfo, string model, T data, params string[] header)
        {
            return InvokeRpc<dynamic>(sessionInfo, CreateLoadRequest(sessionInfo, model, data, header));
        }

        private OdooRpcRequest CreateLoadRequest(OdooSessionInfo sessionInfo, string model, object data, object header)
        {
            return new OdooRpcRequest()
            {
                service = "object",
                method = "execute_kw",
                args = new object[]
                {
                    sessionInfo.Database,
                    sessionInfo.UserId,
                    sessionInfo.Password,
                    model,
                    "load",
                    new object[]
                    {
                        data,
                        header
                    }
                },
                context = sessionInfo.UserContext
            };
        }
    }
}