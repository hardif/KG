using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChasePlayer : MonoBehaviour
{
    GameObject[] players;
    Transform[] PlayerTrs;
    float[] PlayerAndGhostDist;

    private Transform ghostTr;
    private Transform targetTr;
    private int targetInt = 0;

    private NavMeshAgent nvAgent;

    // Start is called before the first frame update
    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();

        players = GameObject.FindGameObjectsWithTag("Player");
        PlayerTrs = new Transform[players.Length];
        PlayerAndGhostDist = new float[players.Length];

        for(int i=0; i<players.Length;i++)
        {
            PlayerTrs[i] = players[i].GetComponent<Transform>();
        }

        targetTr = PlayerTrs[0];
        StartCoroutine(SearchTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SearchTarget()
    {
        while(true)
        { 
       
            yield return new WaitForSeconds(0.2f);
            for (int i=0; i<players.Length;i++)
            {
            PlayerAndGhostDist[i] = Mathf.Abs(Vector3.Distance(PlayerTrs[i].position, transform.position));
            }
            targetTr = PlayerTrs[0];

            if (players.Length ==1)
            {

            }
            else
            {
                for (int i =0; i<players.Length-1;i++)
                {
                    if(PlayerAndGhostDist[targetInt]<= PlayerAndGhostDist[i+1])
                    {
                        targetTr = PlayerTrs[targetInt];
                    }
                    else
                    {
                        targetInt = i + 1;
                        targetTr = PlayerTrs[targetInt];
                    }
                }
            }
            nvAgent.destination = targetTr.position;
            targetInt = 0;

            
            
        }
    }
}
