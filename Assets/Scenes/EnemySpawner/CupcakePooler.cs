using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakePooler : MonoBehaviour
{

    public static CupcakePooler _Instance;
    public GameObject enemySpawner;
    public GameObject cupcakeObj;
    private List<GameObject> cupcakeList;

    public int cupcakesPerWave;
    public int totalCupcakesToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _Instance = this;
        cupcakeList = new List<GameObject>();
        for(int i = 0; i < totalCupcakesToSpawn; i++){
            GameObject gameObject;
            gameObject = Instantiate(cupcakeObj, enemySpawner.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            cupcakeList.Add(gameObject);
        }
    }
    public GameObject SpawnCupcake(){
        for(int i = 0; i < cupcakeList.Count; i ++){
            if(!cupcakeList[i].activeInHierarchy){
                return cupcakeList[i];
            }
        }
        return null;
    }
}
