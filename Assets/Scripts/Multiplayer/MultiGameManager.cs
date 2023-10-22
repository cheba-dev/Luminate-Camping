using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiGameManager : MonoBehaviourPunCallbacks
{
    public List<Transform> SpawnPoints;

    void Start()
    {
        StartCoroutine(spawnPlayer());
    }

    IEnumerator spawnPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 pos = SpawnPoints[Random.RandomRange(0, SpawnPoints.Count)].position;
        PhotonNetwork.Instantiate("Player", pos, Quaternion.identity, 0);
    }

    void Update()
    {
        
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player entered room");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left room");
    }
}
