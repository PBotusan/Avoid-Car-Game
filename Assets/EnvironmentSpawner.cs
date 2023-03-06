using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    // list used floors ref
    [SerializeField] List<GameObject> chunks;

    //instantiated chunks
    [SerializeField] List<GameObject> instantiatedChunks = new List<GameObject>();

    [SerializeField] float offset = 20f;





    // Start is called before the first frame update
    void Start()
    {
        // use in the future for 0 the begin platform
    /*    if (chunks != null && chunks.Count > 0)
        {
            chunks = chunks.OrderBy(f => f.transform.position.z).ToList();
        }*/

        //generate first section
        StartWorld();
    }

    private void StartWorld()
    {
        // reset positions
        foreach (var item in chunks)
        {
            item.transform.position = new Vector2(0, -20);
        }

        ShuffleList();

        float NewOffset = offset;

        foreach (var item in chunks)
        {
            float newYPosition = chunks[chunks.Count - 1].transform.position.y + NewOffset;
            item.transform.position = new Vector2(0, newYPosition);
            instantiatedChunks.Add(Instantiate(item));

            NewOffset += offset;
        }
    }

     void ShuffleList() {

        int lastIndex = chunks.Count -1;
        while (lastIndex > 0)
        {
            GameObject tempValue = chunks[lastIndex];
            int randomIndex = new System.Random().Next(0, lastIndex);
            chunks[lastIndex] = chunks[randomIndex];
            chunks[randomIndex] = tempValue;
            lastIndex--;
        }

     }

    public void MoveChunkToNewPosition()
    {
        GameObject movedChunk = instantiatedChunks[0];
        instantiatedChunks.Remove(movedChunk);

        float newYPosition = instantiatedChunks[instantiatedChunks.Count - 1].transform.position.y + offset;
        movedChunk.transform.position = new Vector2(0, newYPosition);

        movedChunk.gameObject.SetActive(false);
        movedChunk.gameObject.SetActive(true);

        instantiatedChunks.Add(movedChunk);
    }
}
