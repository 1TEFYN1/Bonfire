using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesController : MonoBehaviour
{
    [SerializeField] private GameObject[] _treesList;
    [SerializeField] private Transform[] _spawnPositionsList;

    private List<GameObject> _treeSpawnedList;

    private List<int> _busyPositionsList;

    private int _spawnTime = 0;
    [SerializeField] private int _countTreesOnScene;

    bool IsFreePositionFound = false;

    private void Start()
    {
        _treeSpawnedList = new List<GameObject>();
        _busyPositionsList = new List<int>();
        for (int i = 0; i < _countTreesOnScene; i++)
        {
            SpawnTrees();
        }
        _spawnTime = 20;
    }
    private void SpawnTrees()
    {
        if (_treeSpawnedList.Count <= _countTreesOnScene)
        {
            StartCoroutine(SpawnTreesOverTime(_spawnTime));
        }
    }
    private GameObject CreateTree()
    {
        return Instantiate(_treesList[GetRandomTree()], _spawnPositionsList[GetRandomPosition()]);
    }
    private int GetRandomTree()
    {
        return Random.Range(0, _treesList.Length);
    }
    private int GetRandomPosition()
    {
        int randomPosition = 0;
        bool IsBusyPosition = false;

        IsFreePositionFound = false;

        while (!IsFreePositionFound)
        {
            randomPosition = Random.Range(0, _spawnPositionsList.Length);
            for (int i = 0; i < _busyPositionsList.Count; i++)
            {
                if (randomPosition == _busyPositionsList[i])
                {
                    IsBusyPosition = true;
                    break;
                }
            }
            if (!IsBusyPosition)
            {
                _busyPositionsList.Add(randomPosition);
                IsFreePositionFound = true;
                return randomPosition;
            }
            IsBusyPosition = false;
        }
        return randomPosition;
    }
    public void DestroyTree(GameObject tree)
    {
        int index = _treeSpawnedList.IndexOf(tree);
        if (index != -1)
        {
            int destroyedPosition = _busyPositionsList[index];
            _busyPositionsList.Remove(destroyedPosition);
            _treeSpawnedList.RemoveAt(index);
        }
        Destroy(tree);
        SpawnTrees();
    }
    private IEnumerator SpawnTreesOverTime(int time)
    {
        yield return new WaitForSeconds(time);
        _treeSpawnedList.Add(CreateTree());
    }
}
