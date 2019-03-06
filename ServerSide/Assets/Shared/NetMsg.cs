public static class NetOperationCode
{
    public const int None = 0;

    public const int CreateAccount = 1;
    public const int LoginRequest = 2;
}

[System.Serializable]
public abstract class NetMsg
{
    public byte OperationCode { set; get; }

    public NetMsg()
    {
        OperationCode = NetOperationCode.None;
    }
}
