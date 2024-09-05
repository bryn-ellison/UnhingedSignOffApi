using UnhingedLibrary.Models;

namespace UnhingedLibrary.DataAccess
{
    public interface ISignOffData
    {
        Task DeleteSignOff(int id);
        Task ApproveSignOff(int id);
        Task CreateSignOff(string signOff, string author);
        Task<List<SignOffModel>> LoadAllApprovedSignOffs();
        Task<List<SignOffModel>> LoadAllSignDeletedSignOffs();
        Task<List<SignOffModel>> LoadAllSignOffsToBeApproved();
        Task<List<SignOffModel>> LoadRandomSignOff();
        Task AmendSignOff(string signOff, string author, int id);
    }
}