[System.Serializable]
public class Net_OnCreateAccount : NetMsg
{
    public Net_OnCreateAccount()
    {
        OperationCode = NetOperationCode.OnCreateAccount;
    }

    public byte Success { set; get; }
    public string Information { get; set; }
}
