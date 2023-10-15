using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PipeGeneration : MonoBehaviour
{
    [SerializeField]
    public GameObject pipe;
    public int pipeCount = 3;
    private Rigidbody2D rb;
    private List<GameObject> pipes = new List<GameObject>();
    private static Random rand;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rand = new Random();
        pipe.transform.position = new Vector2(pipe.transform.position.x, RandomFloat(-5, 0));
        pipes.Add(pipe);
        for (int i = 1; i < pipeCount; i++)
        {
            pipes.Add(Instantiate(pipe, new Vector2(pipe.transform.position.x + 5 * i, RandomFloat(-5, 0)), Quaternion.identity));
        }
    }

    void Update()
    {
        for (int i = 0; i < pipes.Count; i++)
        {
            if (rb.transform.position.x - 5 >= pipes[i].transform.position.x)
            {
                MovePipe(pipes[i]);
            }
        }
    }

    void MovePipe(GameObject obj)
    {
        Vector2 pos = obj.transform.position;
        obj.transform.position = new Vector2(pos.x + 5 * pipeCount, RandomFloat(-5, 0));
    }

    private static float RandomFloat(float min, float max)
    {
        float range = max - min;
        return (float)rand.NextDouble() * range + min;
    }
}
