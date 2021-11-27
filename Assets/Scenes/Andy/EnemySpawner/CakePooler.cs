using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePooler : MonoBehaviour
{
    //attached to gameObject CakePooler
    // used in EnemySpawner
    public static CakePooler _Instance;
    public GameObject enemySpawner; // game object that will determine where the enemies spawn
    public GameObject cakeObj;
    private List<GameObject> cakeList;
    public int cakesPerWave; // 40, max number of cakes spawning per wave
    public int totalCakesToSpawn; // 100, max number of cakes to have in the game
    // Start is called before the first frame update
    void Start()
    {
        _Instance = this;
        cakeList = new List<GameObject>();
        // creating the pool of cakes that will be spawned in the game
        for(int i = 0; i < totalCakesToSpawn; i++){
            GameObject obj;
            obj = Instantiate(cakeObj, enemySpawner.transform.position, Quaternion.identity);
            obj.SetActive(false);
            cakeList.Add(obj);
        }
    }
    // iterating to the list of cake object, will be turned active in the EnemySpawner script in GetCake()
    public GameObject SpawnCake(){
        for(int i = 0; i < cakeList.Count; i++){
            if(!cakeList[i].activeInHierarchy){
                return cakeList[i];
            }
        }
        return null;
    }
}
