using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    //this is a dictionary for all the ship types which includes the ships acceleration, bulletSpeed, lazerSpeed, 
    //bulletCoolDown,  lazerCoolDown, bulletLastFired, lazerLastFired,   bulletDamage,  lazerDamage, and health
    public static Dictionary<shipType, shipData> shipDataDictionary = new Dictionary<shipType, shipData>()
    {
        //acceleration, bulletSpeed, lazerSpeed, bulletCoolDown,  lazerCoolDown, bulletLastFired, lazerLastFired,   bulletDamage,  lazerDamage, health
        // 
        {shipType.Player, new shipData(new Vector2(10,10), 20f, 25f, 0.2f, 0.8f, 1f, 1f, 10f, 25f, 600f)},
        {shipType.Enemy1, new shipData(new Vector2(8 ,8), 10f, 25f, 2f, 3f, 1f, 1f, 10f, 5f, 20f)},
        {shipType.Enemy2, new shipData(new Vector2(9,9), 10f, 25f, 1f, 3f, 1f, 1f, 10f, 5f, 40f)},
        {shipType.Enemy3, new shipData(new Vector2(10,10), 10f, 25f, 0.8f, 3f, 1f, 1f, 10f, 5f, 60f)},
        {shipType.Enemy4, new shipData(new Vector2(10,10), 10f, 25f, 0.5f, 2f, 1f, 1f, 10f, 5f, 100f)},
        {shipType.Boss, new shipData(new Vector2(10, 10), 20f, 25f, 0.4f, 1.5f, 1f, 1f, 10f, 15f, 1000f)},
    };




    public static GameManager singleton;

    private void Awake()
    {

        singleton = this;
    }

    // this is the move list for the enemy ships 
    public static Dictionary<shipType, List<Move>> moveSetDictionary = new Dictionary<shipType, List<Move>>
    {
        {shipType.Enemy1, new List<Move>(){
        new Move(KeyCode.D, 1),
        new Move(KeyCode.S, 1),
        new Move(KeyCode.D, 1),
        new Move(KeyCode.A, 1),
        }},
        {shipType.Enemy2, new List<Move>(){
        new Move(KeyCode.S, 1),
        new Move(KeyCode.A, 1),
        new Move(KeyCode.D, 1),
        new Move(KeyCode.A, 1),
        }},
        {shipType.Enemy3, new List<Move>(){
        new Move(KeyCode.D, 1),
        new Move(KeyCode.S, 1),
        new Move(KeyCode.W, 1),
        new Move(KeyCode.A, 1),
        }},
        {shipType.Enemy4, new List<Move>(){
        new Move(KeyCode.D, 1),
        new Move(KeyCode.A, 1),
        new Move(KeyCode.S, 1),
        new Move(KeyCode.A, 1),
        }},
        {shipType.Boss,  new List<Move>(){
        new Move(KeyCode.S, 1),
        new Move(KeyCode.A, 1),
        new Move(KeyCode.W, 1),
        new Move(KeyCode.D, 1),
        }},
       

    };
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
// this is the ship types which can then be assigned to the ship objects in unity
public enum shipType
{
    Player,
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4,
    Boss,
    
}
// this is the data that makes up the ship types 
public class shipData
{
    public Vector2 acceleration;
    public float bulletSpeed;
    public float lazerSpeed;
    public float bulletCoolDown;
    public float lazerCoolDown;
    public float bulletLastFired;
    public float lazerLastFired;
    public float bulletDamage;
    public float lazerDamage;
    public float health;

    public shipData(Vector2 acceleration, float bulletSpeed, float lazerSpeed, float bulletCoolDown, float lazerCoolDown, float bulletLastFired, 
    float lazerLastFired,  float bulletDamage, float lazerDamage,  float health)
    {
    this.acceleration = acceleration;
    this.bulletSpeed = bulletSpeed;
    this.lazerSpeed = lazerSpeed;
    this.bulletCoolDown = bulletCoolDown;
    this.lazerCoolDown = lazerCoolDown;
    this.bulletLastFired = bulletLastFired;
    this.lazerLastFired = lazerLastFired;
    this.bulletDamage = bulletDamage;
    this.lazerDamage = lazerDamage;
    this.health = health;
}

}

public class Move
{
    public KeyCode whichKey;
    public float duration;

    public Move(KeyCode whichKey, float duration)
    {
        this.whichKey = whichKey;
        this.duration = duration;
    }
}


