using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshControl : MonoBehaviour
{
    NavMeshAgent navMesh;
    public Transform direction;
    [SerializeField] float stoppingDistance = 2;
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        navMesh.SetDestination(direction.position);
        navMesh.stoppingDistance = stoppingDistance;
    }
}
