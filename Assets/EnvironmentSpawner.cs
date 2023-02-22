using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> chunks;
    [SerializeField] float offset = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if (chunks != null && chunks.Count > 0)
        {
            chunks = chunks.OrderBy(f => f.transform.position.z).ToList();
        }
    }

    public void MoveChunkToNewPosition()
    {
        GameObject movedChunk = chunks[0];
        chunks.Remove(movedChunk);
        float newYPosition = chunks[chunks.Count - 1].transform.position.y + offset;
        movedChunk.transform.position = new Vector2(0, newYPosition);
        chunks.Add(movedChunk);
    }
}
