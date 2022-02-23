using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("connecting using settings");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        print("joining lobby");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("loading Scene");
        SceneManager.LoadScene("Lobby");
    }

}
