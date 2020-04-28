using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script controls the boss bullet
public class BossBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed;
    public float damage;

    // Start is called before the first frame update
     private void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    private void Start()
    {
        moveSpeed = 5f;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
