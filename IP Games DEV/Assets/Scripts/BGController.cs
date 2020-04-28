using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script controls the scroll of the background 
public class BGController : MonoBehaviour
{
    private float speed = 2.5f;
    public GameObject BackGroundPrefab;
    public static BGController singleton;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scrollBG();
    }
    void scrollBG()
    {
        foreach(Transform t in this.transform)
        {
            Vector2 pos = t.transform.position;
            pos.y -= speed * Time.deltaTime;
            t.transform.position = pos;
        }
    }
    public void spawnBG()
    {
        GameObject go = this.transform.GetChild(0).gameObject;
        BG b = go.GetComponent<BG>();
        Transform t = b.spawnPoint;
        Instantiate(BackGroundPrefab, t.position, Quaternion.identity, this.transform);

        Destroy(go);
    }
    
}
