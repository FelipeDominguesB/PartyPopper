using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkScript : MonoBehaviour
{

    public DrinkTypeEnum drinkType;

    public int healAmount;
    public int damageAmount;
    public int scoreAmount;

    private LevelScript levelScript;
    // Start is called before the first frame update
    void Start()
    {
         levelScript = FindAnyObjectByType<LevelScript>().GetComponent<LevelScript>();

        levelScript.IncreaseScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Console.WriteLine("Teste");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Console.WriteLine("Collided");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            if(drinkType == DrinkTypeEnum.Damage)
                collision.gameObject.GetComponent<PlayerScript>().TakeDamage(1);

            if (drinkType == DrinkTypeEnum.Heal)
                collision.gameObject.GetComponent<PlayerScript>().HealDamage(1);

            if(drinkType == DrinkTypeEnum.Point)
                levelScript.IncreaseScore(scoreAmount);
            Destroy(gameObject);
        }

    }
}
