using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this controls the fire pattern for the boss bullets 
public class FirePattern : MonoBehaviour
{
    private float angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 0.1f);  
    }

    // Update is called once per frame
    private void Shoot() 
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        angle += 10f;
    }
}
