using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
   public float minHeight = 0f; // Minimum height
    public float maxHeight = 2f; // Maximum height
    public float moveSpeed = 1f; // Movement speed

    private float targetHeight;
    float step;
    void Start()
    {
        SetRandomTargetHeight();
        
    }

    void Update()
    {

        StartCoroutine("UpAndDown");
        
       
    }

    void SetRandomTargetHeight()
    {
        
        targetHeight = Random.Range(minHeight, maxHeight * 2);
        
        if (targetHeight > maxHeight)
        {
            targetHeight = 2 * maxHeight - targetHeight;
        }
    }

    private IEnumerator UpAndDown(){
        
        step = moveSpeed * Time.deltaTime;
        yield return new WaitForSeconds(1f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), step);

    
        if (transform.position.y == targetHeight)
        {
            
            SetRandomTargetHeight();
            StartCoroutine(UpAndDown());
        }
        
    }
}
