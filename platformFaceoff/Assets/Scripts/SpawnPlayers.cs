using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Transform[] platforms;
    public bool Test;
    public float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 randomPos = new Vector3(Random.Range(minX, maxX), 3, Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(PlayerPrefab.name, chooseTransform(platforms), Quaternion.identity);
        
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 chooseTransform(Transform[] platforms)
    {
        float rNum = Random.Range(0, platforms.Length - 1);
        return platforms[Mathf.CeilToInt(rNum)].position + new Vector3(0, 3, 0);
       
    }
}
