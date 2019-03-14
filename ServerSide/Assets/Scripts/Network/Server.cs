using UnityEngine.Networking;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Server : MonoBehaviour
{
    private const int MAX_USER = 100;
    private const int PORT = 26000;
    private const int WEB_PORT = 26001;
    private const int BYTE_SIZE = 1024;

    private byte reliableChannel;
    private int hostID;
    private int webHostID;

    private bool isStarted = false;
    private byte error;

    private Database db;

    #region Monobehaviour
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();
    }
    private void Update()
    {
        UpdateMessagePunp();
    }
    #endregion

    private void Init()
    {
        db = new Database();
        db.Init();

        NetworkTransport.Init();

        ConnectionConfig cc = new ConnectionConfig();
        reliableChannel = cc.AddChannel(QosType.Reliable);

        HostTopology topo = new HostTopology(cc, MAX_USER);


        // Server Only
        hostID =  NetworkTransport.AddHost(topo, PORT, null);
        webHostID = NetworkTransport.AddWebsocketHost(topo, WEB_PORT, null);

        Debug.Log(string.Format("Opening connection on port {0} and webport {1}", PORT, WEB_PORT));
        isStarted = true;

        // $$ TEST
        db.InsertAccount("Bambooz", "Super", "Blush");
    }
    private void Shutdown()
    {
        isStarted = false;
        NetworkTransport.Shutdown();
    }

    public void UpdateMessagePunp()
    {
        if(!isStarted)
            return;

        int recHostId;      // From Web or Standalone?
        int connectionId;   // What User?
        int channelId;      // What lane is it from?

        byte[] recBuffer = new byte[BYTE_SIZE];
        int dataSize;

        NetworkEventType type = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, BYTE_SIZE, out dataSize, out error);
        switch(type)
        {
            case NetworkEventType.Nothing:
                break;

            case NetworkEventType.ConnectEvent:
                Debug.Log(string.Format("User {0} had connected has  connected  to  host {1}!", connectionId, recHostId));
                break;

            case NetworkEventType.DisconnectEvent:
                Debug.Log(string.Format("User {0} had disconeced!", connectionId));
                break;

            case NetworkEventType.DataEvent:
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(recBuffer);
            NetMsg msg = (NetMsg)formatter.Deserialize(ms);

            OnData(connectionId, channelId, recHostId, msg);
            break;

            default:
            case NetworkEventType.BroadcastEvent:
                Debug.Log("Unexxpected network event type");
                break;
        }
    }

    #region OnData
    private void OnData(int cnnId, int channelId, int recHosteId, NetMsg msg)
    {
        switch(msg.OperationCode)
        {
            case NetOperationCode.None:
            Debug.Log("unexpected NetOP");
                break;

            case NetOperationCode.CreateAccount:
                CreateAccount(cnnId, channelId, recHosteId, (Net_CreateAccount)msg);
                break;

            case NetOperationCode.LoginRequest:
                LoginRequest(cnnId, channelId, recHosteId, (Net_LoginRequest)msg);
                break;
        }
    }

    private void CreateAccount(int cnnId, int channelId, int recHosteId, Net_CreateAccount ca)
    {
        Debug.Log(string.Format("{0},{1},{2}", ca.Username, ca.Password, ca.Email));

        Net_OnCreateAccount oca = new Net_OnCreateAccount();
        oca.Success = 0;
        oca.Information = "Account was created :)";

        SendClient(recHosteId, cnnId, oca);
    }

    private void LoginRequest(int cnnId, int channelId, int recHosteId, Net_LoginRequest lr)
    {
        Debug.Log(string.Format("{0},{1}", lr.UsernameOrEmail, lr.Password));

        Net_OnLoginRequest olr = new Net_OnLoginRequest();
        olr.Success = 0;
        olr.Information = "Everything is good";
        olr.Username = "n3rkmind";
        olr.Discriminator = "0000";
        olr.Token = "Token";

        SendClient(recHosteId, cnnId, olr);
    }
    #endregion

    #region Send
    public void SendClient(int recHost, int cnnId, NetMsg msg)
    {
        // This is where we hold our data
        byte[] buffer = new byte[BYTE_SIZE];

        // This is where you would cruch your data into a byte []
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream ms = new MemoryStream(buffer);
        formatter.Serialize(ms, msg);

        if(recHost == 0)
            NetworkTransport.Send(hostID, cnnId, reliableChannel, buffer, BYTE_SIZE, out error);
        else
            NetworkTransport.Send(webHostID, cnnId, reliableChannel, buffer, BYTE_SIZE, out error);
    }
    #endregion
}
