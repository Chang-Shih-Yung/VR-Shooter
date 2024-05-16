using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //給標題
    [Header("Size of spawner area")]
    public Vector3 spawnerSize;

    [Header("Rate of spawn")]
    public float spawnRate = 1f;
    [Header("Model to spawn")]
    [SerializeField] private GameObject[] asteroidModel;
    //生成多種小行星
    //public GameObject[] asteroidModels;
    


    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }


    //生成物體計時器
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        //假設計時器的時間大於1f，就會歸零重來算,然後生成小行星
        if (spawnTimer > spawnRate)
        {
            Debug.Log("Spawning");
            spawnTimer = 0;
            SpawnAsteroid();
        }
    }

    //小行星生成方法
    private void SpawnAsteroid()
    {
        //盒子大小內的隨機位置:X>>>>-10~10=20,y>>>-10~10=20,z>>>-20~20=40
        //將物件原本座標賦予隨機位置:實例化非靜態聲明新的位置
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
        UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
        UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));
        //生成小行星
        GameObject asteroid = Instantiate(asteroidModel[UnityEngine.Random.Range(0, asteroidModel.Length)], spawnPoint, transform.rotation);
        //將生成的小行星放到此腳本的遊戲物件內，避免生成一大堆編輯器會很亂
        //this.transform等效
        asteroid.transform.SetParent(transform);
    }
}

