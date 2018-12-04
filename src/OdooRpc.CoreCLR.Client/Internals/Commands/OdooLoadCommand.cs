// namespace OdooRpc.CoreCLR.Client.Internals.Commands
// {
//     public class OdooLoadCommand
//     {
//         public OdooCreateCommand(IJsonRpcClient rpcClient)
//             : base(rpcClient)
//         {
//         }

//         public Task<long> Execute<T>(OdooSessionInfo sessionInfo, string model, T newRecord)
//         {
//             return InvokeRpc<long>(sessionInfo, CreateCreateRequest(sessionInfo, model, newRecord));
//         }

//         private OdooRpcRequest CreateCreateRequest(OdooSessionInfo sessionInfo, string model, object newRecord)
//         {
//             return new OdooRpcRequest()
//             {
//                 service = "object",
//                 method = "execute_kw",
//                 args = new object[]
//                 {
//                     sessionInfo.Database,
//                     sessionInfo.UserId,
//                     sessionInfo.Password,
//                     model,
//                     "load",
//                     new object[]
//                     {
//                         newRecord
//                     }
//                 },
//                 context = sessionInfo.UserContext
//             };
//         }
//     }
// }