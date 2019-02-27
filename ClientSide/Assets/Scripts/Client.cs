using UnityEngine.Networking;
using UnityEngine;

public class Client : MonoBehaviour {

    private const int MAX_USER = 100;
    private const int PORT = 26000;
    private const int WEB_PORT = 26001;
    private const int BYTE_SIZE = 1024;

    private const string SERVER_IP = "127.0.0.1";

    private byte reliableChannel;
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
        NetworkTransport.Connect(hostID, SERVER_IP, WEB_PORT, 0, out error);
        Debug.Log("Connecting from Web");
#else
        // Standalone Client
        NetworkTransport.Connect(hostID, SERVER_IP, PORT, 0, out error);
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
            Debug.Log("Data");
            break;

            default:
            case NetworkEventType.BroadcastEvent:
            Debug.Log("Unexxpected network event type");
            break;
        }
    }
}
