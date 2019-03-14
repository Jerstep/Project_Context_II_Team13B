using MongoDB.Driver;
using UnityEngine;

public class Database
{
    private const string MONGO_URI = "mongodb+srv://Jerstep:<Pironada19>@lobbydb-uxytr.mongodb.net/test?retryWrites=true";
    private const string DATABASE_NAME = "lobbydb";

    private MongoClient client;
    private MongoServer server;
    private MongoDatabase db;

    private MongoCollection accounts;

    public void Init()
    {
        client = new MongoClient(MONGO_URI);
        server = client.GetServer();
        db = server.GetDatabase(DATABASE_NAME);

        // This is where we would initialize collections
        accounts = db.GetCollection<Model_Account>("account");

        Debug.Log("Database has been initalized");
    }
    public void Shutdown()
    {
        client = null;
        server.Shutdown();
        db = null;
    }
   
    #region Insert
    public bool InsertAccount(string username, string password, string email)
    {
        Model_Account newAccount = new Model_Account();
        newAccount.Username = username;
        newAccount.ShaPassword = password;
        newAccount.Email = email;
        newAccount.Discriminator = "0000";

        accounts.Insert(newAccount);

        return true;

    }
    #endregion

    #region Fetch
    #endregion

    #region Update
    #endregion    
    

    #region Delete
    #endregion
}
