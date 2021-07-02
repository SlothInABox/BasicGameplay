using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float timeDelay = 1.0f;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        // Spawn delay
        timer += Time.deltaTime;
        if (timer >= timeDelay)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0.0f;
            }
        }
    }
}
