using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toyspawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnAnchor;
    [SerializeField]
    private GameObject[] toyPrefabs;
    [SerializeField]
    private int numberOfInitialToys;

    private List<GameObject> toyList = new List<GameObject>();

    private void Start()
    {
        SpawnNewToys();
        PositionRandomToy();
    }

    private void SpawnNewToys()
    {
        foreach (GameObject toyPref in toyPrefabs)
        {
            for (int i = 0; i < numberOfInitialToys; i++)
            {
                GameObject newToy = Instantiate(toyPref, spawnAnchor.position, Quaternion.identity);
                newToy.GetComponent<ToyMovement>().toyspawner = this;
                toyList.Add(newToy);
                newToy.SetActive(false);
            }
        }
    }

    public void PositionRandomToy()
    {
        int rndNum = Random.Range(0, toyList.Count);
        GameObject toy = toyList[rndNum];
        toy.transform.position = transform.position;
        toyList.Remove(toy);
        toy.SetActive(true);
    }

    public void DestroyToy(ToyMovement toy)
    {
        toy.gameObject.SetActive(false);
        toy.transform.position = spawnAnchor.position;
        toyList.Add(toy.gameObject);
        PositionRandomToy();
    }
}
