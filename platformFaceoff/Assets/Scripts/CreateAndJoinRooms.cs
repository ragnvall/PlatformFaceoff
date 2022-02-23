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
        print("joining Room");
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        print("loading Mainscene");
        PhotonNetwork.LoadLevel("Main");
    }
}
