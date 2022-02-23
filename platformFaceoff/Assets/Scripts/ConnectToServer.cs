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
        
        PhotonNetwork.ConnectUsingSettings();
        print("connecting using settings");
    }
    public override void OnConnectedToMaster()
    {
        
        PhotonNetwork.JoinLobby();
        print("joining lobby");
    }
    public override void OnJoinedLobby()
    {
        
        SceneManager.LoadScene("Lobby");
        print("loading Scene");
    }

}
