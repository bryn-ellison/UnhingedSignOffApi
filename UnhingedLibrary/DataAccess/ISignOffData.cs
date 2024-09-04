using UnhingedLibrary.Models;

namespace UnhingedLibrary.DataAccess
{
    public interface ISignOffData
    {
        Task ApproveSignOff(int id);
        Task CreateSignOff(string signOff, string author);
        Task<List<SignOffModel>> LoadAllApprovedSignOffs();
        Task<List<SignOffModel>> LoadAllSignDeletedSignOffs();
        Task<List<SignOffModel>> LoadAllSignOffsToBeApproved();
        Task<List<SignOffModel>> LoadRandomSignOff();
    }
}