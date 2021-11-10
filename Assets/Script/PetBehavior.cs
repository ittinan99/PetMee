using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Panda;
public class PetBehavior : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Rigidbody Rb;
    public Vector3 MaxRange;
    public Vector3 MinRange;
    [SerializeField] NavMeshAgent Nav;
    [SerializeField]
    private Vector3 RandPos;
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Nav = GetComponent<NavMeshAgent>();
    }
    public PetStats Pstat;
    [Task]
    void CheckedHungry()
    {
        if(Pstat.hungryLvl >= 93)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }
    [Task]
    void CheckedHealthy()
    {
        if (Pstat.healLvl >= 25)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }
    [Task]
    void Patrol()
    {
        float X = Random.Range(MinRange.x, MaxRange.x);
        float Z = Random.Range(MinRange.z, MaxRange.z);
        RandPos = new Vector3(X, 0.6f, Z);
        Nav.SetDestination(RandPos);
        if(Nav.remainingDistance <= 0.1)
        {
            Task.current.Succeed();
        } 
    }
    
   
}
