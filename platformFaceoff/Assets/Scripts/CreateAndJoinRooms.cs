using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    public void createRoom()
    {
        print("Created Room");
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void joinRoom()
    {
        
        PhotonNetwork.JoinRoom(joinInput.text);
        print("joining Room");
    }

    public override void OnJoinedRoom()
    {
        
        PhotonNetwork.LoadLevel("Main");
        print("loading Mainscene");
    }
}
