using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float speed;
    GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("Main Camera").GetComponent<GameManager>();
        Invoke("SelfDestruct", 8f);
    }
    private void Update()
    {
        speed = gm.speedPipes;
        transform.position = Vector2.MoveTowards(transform.position, transform.right * -1000, speed * Time.deltaTime);
    }

    void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

}
