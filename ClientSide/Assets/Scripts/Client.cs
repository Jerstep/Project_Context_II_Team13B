using UnityEngine.Networking;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Client : MonoBehaviour {

    private const int MAX_USER = 100;
    private const int PORT = 26000;
    private const int WEB_PORT = 26001;
    private const int BYTE_SIZE = 1024;

    private const string SERVER_IP = "127.0.0.1";

    private byte reliableChannel;
    private int connectionId;
    private int hostID;
    private byte error;

    private bool isStarted = false;

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
        NetworkTransport.Init();

        ConnectionConfig cc = new ConnectionConfig();
        reliableChannel = cc.AddChannel(QosType.Reliable);

        HostTopology topo = new HostTopology(cc, MAX_USER);

        // Client Only
        hostID = NetworkTransport.AddHost(topo, 0);


#if UNITY_WEBGL && !UNITY_EDITOR
        // Web Client
        connectionId = NetworkTransport.Connect(hostID, SERVER_IP, WEB_PORT, 0, out error);
        Debug.Log("Connecting from Web");
#else
        // Standalone Client
        connectionId = NetworkTransport.Connect(hostID, SERVER_IP, PORT, 0, out error);
        Debug.Log("Connecting from Standalone");
#endif
        Debug.Log(string.Format("Attempting to connect on {0}...", SERVER_IP));
        isStarted = true;
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
            Debug.Log("We have connected to the server");
            break;

            case NetworkEventType.DisconnectEvent:
            Debug.Log("We have been disconected");
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
        }
    }
    #endregion

    #region Send
    public void SendServer(NetMsg msg)
    {
        // This is where we hold our data
        byte[] buffer = new byte[BYTE_SIZE];

        // This is where you would cruch your data into a byte []
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream ms = new MemoryStream(buffer);
        formatter.Serialize(ms, msg);

        NetworkTransport.Send(hostID, connectionId, reliableChannel, buffer, BYTE_SIZE, out error);
    }
    #endregion

    // Delete when build
    public void TESTFUNCTIONCREATEACCOUNT()
    {
        Net_CreateAccount ca = new Net_CreateAccount();

        ca.Username = "Big Chungus";
        ca.Password = "YeahBoiiiiii";
        ca.Email = "IsYaBoi@hotmail.com";

        SendServer(ca);
    }
}
