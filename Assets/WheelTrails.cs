using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrails : MonoBehaviour
{
    [SerializeField] TrailRenderer trailRendererLeft;
    [SerializeField] TrailRenderer trailRendererRight;

    public bool turning;

    public float resetTimer = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        trailRendererLeft.emitting = false;

        trailRendererRight.emitting = false;
    }

    private void Update()
    {
        ActivateTrail();
    }


    public void ActivateTrail() 
    {
        if (turning)
        {
            trailRendererLeft.emitting = true;
            trailRendererRight.emitting = true;

            resetTimer -= Time.deltaTime;
        }


        if (resetTimer < 0)
        {
            trailRendererLeft.emitting = false;
            trailRendererRight.emitting = false;
            turning = false;
            resetTimer = .5f;
        }
        

       

    }

}
