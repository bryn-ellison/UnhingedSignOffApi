using System.Threading.Tasks;
using UnhingedLibrary.Models;

namespace UnhingedLibrary.DataAccess;

public class SignOffData : ISignOffData
{
    private readonly ISqliteDataAccess _db;
    private readonly string connectionStringName = "Default";
    public SignOffData(ISqliteDataAccess db)
    {
        _db = db;
    }

    public Task<List<SignOffModel>> LoadAllApprovedSignOffs()
    {
        string sqlQuery = "select * from SignOffs where Approved = 1 and Deleted = 0;";

        var returnedData = _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionStringName);

        return returnedData;
    }

    public Task<List<SignOffModel>> LoadAllSignOffsToBeApproved()
    {
        string sqlQuery = "select * from SignOffs where Approved = 0 and Deleted = 0;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionStringName);
    }
    public Task<List<SignOffModel>> LoadAllSignDeletedSignOffs()
    {
        string sqlQuery = "select * from SignOffs where Deleted = 1;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionStringName);
    }
    public Task<List<SignOffModel>> LoadRandomSignOff()
    {
        string sqlQuery = "select * from SignOffs where Approved = 1 and Deleted = 0 ORDER BY RANDOM() LIMIT 1;";

        return _db.LoadData<SignOffModel, dynamic>(sqlQuery, "", connectionStringName);
    }
    public Task CreateSignOff(string signOff, string author)
    {
        string sqlQuery = @"insert into SignOffs (SignOff, Author) values (@SignOff, @Author);";

        return _db.SaveData<dynamic>(sqlQuery, new { SignOff = signOff, Author = author }, connectionStringName);
    }
    public Task ApproveSignOff(int id)
    {
        string sqlQuery = @"update SignOffs set Approved = 1 where Id = @Id;";

        return _db.SaveData<dynamic>(sqlQuery, new { Id = id }, connectionStringName);
    }
    public Task AmendSignOff(string signOff, string author, int id)
    {
        string sqlQuery = @"update SignOffs set SignOff = @SignOff, Author = @Author where Id = @Id;";

        return _db.SaveData<dynamic>(sqlQuery, new { SignOff = signOff, Author = author, Id = id }, connectionStringName);
    }
    public Task DeleteSignOff(int id)
    {
        string sqlQuery = @"update SignOffs set Deleted = 1 where Id = @Id;";

        return _db.SaveData<dynamic>(sqlQuery, new { Id = id }, connectionStringName);
    }
}
