using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCarColor : MonoBehaviour
{
    [SerializeField] private List<Sprite> carSprites;

    [SerializeField] private SpriteRenderer spriteRenderer;



    private void OnEnable()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        if (carSprites.Count > 0)
        {
            int carSprite = Random.Range(0, carSprites.Count);
            spriteRenderer.sprite = carSprites[carSprite];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
