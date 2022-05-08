
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] rocks;

    float Timer;
    float Ding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per fram
    void Update()
    {
        transform.Translate( new Vector2(1, 0) * 1f);

        Timer += Time.deltaTime;

        Ding = Random.Range(0.33f , 0.39f);
        if (Timer >= Ding)
        {
            Instantiate(rocks[Random.Range(0, 2)], new Vector2(transform.position.x, -2.58f) , Quaternion.identity);
            Timer = 0;
        }
        if (transform.position.x == 9000)
        {
            Destroy(gameObject);
        }

    }
}
