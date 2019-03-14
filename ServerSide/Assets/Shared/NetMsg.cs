﻿public static class NetOperationCode
{
    public const int None = 0;

    public const int CreateAccount = 1;
    public const int LoginRequest = 2;

    public const int OnCreateAccount = 3;
    public const int OnLoginRequest = 4;
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
