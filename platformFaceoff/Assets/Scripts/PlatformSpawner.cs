using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public float seperationDistance;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(spawnTime);
    }
}
