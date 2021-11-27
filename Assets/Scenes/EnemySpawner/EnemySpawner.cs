using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // attached to gameObject EnemySpawner
    public static EnemySpawner _Instance;
    public GameObject enemySpawner;
    public bool canSpawn = false;// can be usec for animation when loading the scene
   // public int cakesSpawnedTracker; // can be used to space out the number of cakes spawned in the lever, 
    // every 30 sec more cakes spawn
    public float delayTimerCake, timerResetCake;
    public float delayTimerCupcake, timerResetCupcake;
    private bool startedGame = true;

    private GameObject[] activeCakes;
    // Start is called before the first frame update
    void Start()
    {
        _Instance = this;  
        timerResetCake = delayTimerCake; 
        timerResetCupcake = delayTimerCupcake;
    }
    // Update is called once per frame
    void Update()
    {
        //first check is the player is dead
        // if player not dead then check is they can spawn
        activeCakes = GameObject.FindGameObjectsWithTag("Cake");
        if(!canSpawn){
            SpawnEnemies();
        }
    }
    public void SpawnEnemies(){
        if(startedGame){
            GetCake();
            GetCupcake();
            startedGame = false;
        }
        if(delayTimerCake > 0){ // checking to see if we can spawn more cakes again
            delayTimerCake -= Time.deltaTime;
        }else{
            delayTimerCake = timerResetCake;
            GetCake();
        }

        //cupcake spawner
        if(delayTimerCupcake > 0){
            delayTimerCupcake -= Time.deltaTime;
        }else{
            delayTimerCupcake = timerResetCupcake;
            GetCupcake();
        }

    }
    public void GetCake(){
        for(int i = 0; i < CakePooler._Instance.cakesPerWave; i++){ //spawning them in waves of 5's
            GameObject cake = CakePooler._Instance.SpawnCake();
            if(cake == null) return;
            var position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f), 0);
            // cake.transform.position = new Vector3 (enemySpawner.transform.position.x, enemySpawner.transform.position.y, enemySpawner.transform.position.z);
            cake.transform.position = position;
            cake.SetActive(true);

        }
    }

    public void GetCupcake(){
        for(int i = 0; i < CupcakePooler._Instance.cupcakesPerWave;i++){
            GameObject cupcake = CupcakePooler._Instance.SpawnCupcake();
            if(cupcake == null) return;
            var position = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f), 0);
            cupcake.transform.position = position;
            cupcake.SetActive(true);
        }
    }
}
