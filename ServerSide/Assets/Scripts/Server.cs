using UnityEngine.Networking;
using UnityEngine;

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


        // Server Only
        hostID =  NetworkTransport.AddHost(topo, PORT, null);
        webHostID = NetworkTransport.AddWebsocketHost(topo, WEB_PORT, null);

        Debug.Log(string.Format("Opening connection on port {0} and webport {1}", PORT, WEB_PORT));
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
                Debug.Log(string.Format("User {0} had connected has  connected  to  host {1}!", connectionId, recHostId));
                break;

            case NetworkEventType.DisconnectEvent:
                Debug.Log(string.Format("User {0} had disconeced!", connectionId));
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
