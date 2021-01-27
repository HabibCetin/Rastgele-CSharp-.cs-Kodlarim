//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateALegitTerrain : MonoBehaviour
{

    #region Variables
    public GameObject[] terrainPrefebs;
    public GameObject generatorObject;
    public GameObject firstTerrain;
    public List<GameObject> cloneTerrain = new List<GameObject>();
    public List<GameObject> aktifTerrain = new List<GameObject>();
    int cloneIndexi = 0;
    public float spawnMesafesi = 1f;
    private float invokeSuresi = 6f;
    #endregion

    private void Awake()
    {
        firstTerrain = GameObject.FindWithTag("FirstTerrain");
        aktifTerrain.Add(firstTerrain);
        generatorObject = GameObject.FindWithTag("TerrainSpawnPoint");
    }

    void Update()
    {
        cloneIndexi = AGameManager.secilenHarita;
    
        if (Collidedetection.terrainYapakMi || Input.GetKeyDown(KeyCode.T))
        {
            EkleKardesim(0, cloneIndexi);
            Invoke("SilKardesim", invokeSuresi);
        }
    }


    #region Methods
    public void SilKardesim()
    {
        Destroy(aktifTerrain[0]);
        aktifTerrain.RemoveAt(0);
        cloneTerrain.RemoveAt(0);
    }

    public void EkleKardesim(int tileIndex, int cloneIndex)
    {
        cloneTerrain.Add(Instantiate(terrainPrefebs[cloneIndex], generatorObject.transform.position * spawnMesafesi, generatorObject.transform.rotation));
        aktifTerrain.Add(cloneTerrain[tileIndex]);
    }
    #endregion
}
