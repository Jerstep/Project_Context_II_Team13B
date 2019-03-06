using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyScene : MonoBehaviour
{

	public void OnClickCreateAccount()
    {
        string username = GameObject.Find("CreateUsername").GetComponent<TMP_InputField>().text;
        string passowrd = GameObject.Find("CreatePassword").GetComponent<TMP_InputField>().text;
        string email = GameObject.Find("CreateEmail").GetComponent<TMP_InputField>().text;

        Client.Instance.SendCreateAccount(username, passowrd, email);
    }

    public void OnClickLoginRequest()
    {
        string usernameOrEmail = GameObject.Find("LoginUsernameEmail").GetComponent<TMP_InputField>().text;
        string passowrd = GameObject.Find("LoginPassword").GetComponent<TMP_InputField>().text;

        Client.Instance.SendLoginRequest(usernameOrEmail, passowrd);
    }
}
