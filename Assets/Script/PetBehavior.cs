using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Panda;

public class PetBehavior : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Rigidbody Rb;
    public Vector3 MaxRange;
    public Vector3 MinRange;
    public bool IsCamLook;
    [SerializeField] NavMeshAgent Nav;
    [SerializeField]
    private Vector3 RandPos;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    public GameObject IK;
    public Image Hungry,Thirsty,Sad,Sick;
    public int DelayTime;
    private void Start()
    {
        IsCamLook = false;
        Rb = GetComponent<Rigidbody>();
        Nav = GetComponent<NavMeshAgent>();
    }
    public PetStats Pstat;
    [Task]
    void CheckedHungry()
    {
        if(Pstat.hungryLvl >= 93)
        {
            Hungry.gameObject.SetActive(false);
            Task.current.Succeed();
        }
        else
        {
            Hungry.gameObject.SetActive(true);
            Task.current.Fail();
        }
    }
    [Task]
    void IsCamLookAt()
    {
        if (IsCamLook)
        {
            anim.SetBool("Sit",true);
            Task.current.Succeed();
        }
        else
        {
            anim.SetBool("Sit", false);
            Task.current.Fail();
        }
    }
    [Task]
    void CheckedHealthy()
    {
        if (Pstat.healLvl >= 25)
        {
            Sick.gameObject.SetActive(false);
            Task.current.Succeed();
        }
        else
        {
            Sick.gameObject.SetActive(true);
            Task.current.Fail();
        }
    }
    [Task]
    void Patrol()
    {
        if (!IsCamLook)
        {
            anim.SetBool("Sit", false);
            anim.SetBool("Walk", true);
            float X = Random.Range(MinRange.x, MaxRange.x);
            float Z = Random.Range(MinRange.z, MaxRange.z);
            RandPos = new Vector3(X, 0.6f, Z);
            Nav.SetDestination(RandPos);
            Task.current.Succeed();
        }
        else
        {
            anim.SetBool("Sit", true);
            anim.SetBool("Walk", false);
            Task.current.Fail();
        }
    }
    [Task]
    void IsReachedDestination()
    {
        if (Nav.remainingDistance <= 0.2)
        {
            anim.SetBool("Walk", false);
            Task.current.Succeed();
        }
        else
        {
            anim.SetBool("Walk", true);
        }
    }
}
