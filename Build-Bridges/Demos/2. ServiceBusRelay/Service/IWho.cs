using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    interface IWho
    {
        [OperationContract]
        string Who();
    }
}
