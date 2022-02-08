namespace SuggestionAppLibrary.DataAccess;

public class MongoUserData
{
    private readonly IDbConnection db;

    public MongoUserData(IDbConnection db)
    {
        this.db = db;
    }
}
