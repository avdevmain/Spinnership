using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolRoute : MonoBehaviour
{
    [SerializeField] private Transform[] nodes;
    
    private int currPoint;

    public bool sequence;

    private void Start() {
        
    }

    public Vector3 getNextPoint()
    {
        if (sequence)
        {
            int index = currPoint;
            currPoint++;
            if (currPoint==nodes.Length)
                currPoint = 0;
            return nodes[index].position;
        }
        else
        {
            int newPoint = 0;
            if (nodes.Length>1)
                while (newPoint==currPoint)
                    newPoint = Random.Range(0, nodes.Length);
            currPoint = newPoint;
            return nodes[currPoint].position;
        }
            
    }

    private void OnDrawGizmos() {

        if (nodes.Length==0) return;

        for (int i =0; i<nodes.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(nodes[i].position, 0.1f);
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(nodes[currPoint].position, 0.2f);
    }
}
