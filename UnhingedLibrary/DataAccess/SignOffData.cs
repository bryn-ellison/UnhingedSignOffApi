using System.Threading.Tasks;
using UnhingedLibrary.Models;

namespace UnhingedLibrary.DataAccess;

public class SignOffData
{
    private readonly ISqliteDataAccess _db;
    private readonly string connectionString = "Default";
    public SignOffData(ISqliteDataAccess db)
    {
        _db = db;
    }

    public Task<List<SignOffModel>> GetAllApprovedSignOffs()
    {
        string sqlQuery = "select * from SignOffs where Approved = 1 and Deleted = 0;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionString);
    }

    public Task<List<SignOffModel>> GetAllSignOffsToBeApproved()
    {
        string sqlQuery = "select * from SignOffs where Approved = 0 and Deleted = 0;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionString);
    }
    public Task<List<SignOffModel>> GetAllSignDeletedSignOffs()
    {
        string sqlQuery = "select * from SignOffs where Approved = 0 and Deleted = 0;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionString);
    }
    public Task<List<SignOffModel>> GetRandomSignOff()
    {
        string sqlQuery = "select * from SignOffs where Approved = 1 and Deleted = 0 ORDER BY RANDOM() LIMIT 1;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionString);
    }
    public Task CreateSignOff(string signOff, string author)
    {
        string sqlQuery = @"insert into SignOffs(SignOff, Author) values (@signOff, @author);";

        return _db.SaveData<dynamic>(sqlQuery, new { SignOff = signOff, Author = author }, connectionString);
    }
    public Task ApproveSignOff(int id)
    {
        string sqlQuery = @"update SignOffs set Approved = 1 where Id = @id;";

        return _db.SaveData<dynamic>(sqlQuery, new { Id = id }, connectionString);
    }
}
