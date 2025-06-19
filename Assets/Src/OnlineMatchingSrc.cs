using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class OnlineMatchingSrc : MonoBehaviourPunCallbacks
{
    bool isEnterRoom = false; // 部屋に入ってるかどうか
    bool isMatching = false;  // マッチング済みかどうか

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnMatchingButton()
    {
        Debug.Log(HomeToBattle.AcardNum + HomeToBattle.BcardNum + HomeToBattle.CcardNum);
        if (HomeToBattle.AcardNum != 0 && HomeToBattle.BcardNum != 0 && HomeToBattle.CcardNum != 0)
        {
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings(); // まだ未接続なら接続
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom(); // ランダム入室
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // 入室失敗→部屋を作成（2人用）
        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(null, options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        isEnterRoom = true;
        Debug.Log("部屋に参加しました");
    }

    private void Update()
    {
        if (isMatching || !isEnterRoom) return;

        if (PhotonNetwork.CurrentRoom.PlayerCount >= PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            isMatching = true;
            Debug.Log("マッチング成功");

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel("Main"); // 全員をバトルシーンへ
            }
        }
    }
}
