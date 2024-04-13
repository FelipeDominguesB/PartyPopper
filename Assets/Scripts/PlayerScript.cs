using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IPawn
{

    public Rigidbody2D character;
    public float moveSpeed;
    public int lifePoints;
    private int currentHealth;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public void Destroy()
    {

        Console.WriteLine("Morreu, babaca!");
    }

    public void HealDamage(int damage)
    {

        if (currentHealth != 0 && currentHealth != lifePoints)
            currentHealth++;
    
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth != 0)
            currentHealth--;

        if(currentHealth == 0)
            Destroy();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = lifePoints;
        gameObject.tag = "Player";
    }

    // Update is called once per frame
    void Update()
    {

        float xMovement = 0;
        float yMovement = 0;

        int rotationAngle = 0;
        int currentPresses = 0;

        spriteRenderer.sprite = sprites.ElementAt(currentHealth);
        

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            xMovement -= moveSpeed;
            rotationAngle += 270;
            currentPresses++;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xMovement += moveSpeed;
            rotationAngle += 90;
            currentPresses++;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            yMovement += moveSpeed;
            rotationAngle += 180;
            currentPresses++;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            yMovement -= moveSpeed;

            if (rotationAngle > 180)
                rotationAngle += 360;
            else
                rotationAngle += 0;

            currentPresses++;
        }

        if (currentPresses > 0)
        {
            character.transform.position = new Vector3(character.transform.position.x + xMovement, character.transform.position.y + yMovement);
            character.transform.eulerAngles = new Vector3(character.transform.rotation.x, character.transform.rotation.y, rotationAngle/currentPresses);
        }

        if (Input.GetKeyDown(KeyCode.E))
            this.HealDamage(1);

        if(Input.GetKeyDown(KeyCode.Q))
            this.TakeDamage(1);
    }
}
