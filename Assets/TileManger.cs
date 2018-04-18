using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManger : MonoBehaviour {

	public GameObject[] tilePrefabs;
	//public GameObject Player;
	private Transform playerTransform;
	private float spawnPoint =- 4.0f;
	private float tileLength = 8.0f;
	private int numTiles = 7;
	private float safeZone = 10.0f;
	private List<GameObject> activeTiles;
	private int lastPrefabIndex = 0;
	// Use this for initialization


	void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		for (int i = 0; i < numTiles; i++)
		{
			if (i < 2)
				SpawnTile(0);
			else
				SpawnTile();
		}
		}
	 
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z -safeZone > (spawnPoint -numTiles *tileLength))
		{
			SpawnTile();
			DeleteTiles();
		}

	}
	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject ob;
		if (prefabIndex == -1)
			ob = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
		else
			ob = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		ob.transform.SetParent(transform);
		ob.transform.position = Vector3.forward * spawnPoint;
		spawnPoint += tileLength;
		activeTiles.Add(ob);
	}


	private void DeleteTiles()
	{
		Destroy(activeTiles[0]);
		activeTiles.RemoveAt(0);
	}

	private int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex)
		{			randomIndex = Random.Range(0, tilePrefabs.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
