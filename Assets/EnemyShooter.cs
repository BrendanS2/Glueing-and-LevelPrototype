using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public SpriteRenderer cube;
    public SpriteRenderer Enemy;
    private float Distance;
    [SerializeField] float apart;
    public GameObject glue;
    public Transform bulletPos;
    private GameObject player;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        Color orginColor = Enemy.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        Distance = Vector3.Distance(cube.transform.position, Enemy.transform.position);
        if (Distance < apart)
        {

            Enemy.color = Color.red;
            timer += Time.deltaTime;
            Vector3 direction = player.transform.position - transform.position;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);

            if (timer > 2)
            {
                timer = 0;
                GlueBlast();
            }
        }
        else
        {
            
            Enemy.color = Color.gray;

        }
        
        
    }

    void GlueBlast() {
        Instantiate(glue, bulletPos.position, Quaternion.identity);

    }
    
}
