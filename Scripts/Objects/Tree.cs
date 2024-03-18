using UnityEngine;

public class Tree : MonoBehaviour
{
    private TreesController _treesController;
    public void RemoveTree()
    {
        _treesController.DestroyTree(this.gameObject); 
    }
    public int GetRandomLog()
    {
        return Random.Range(2, 6);
    }
}
