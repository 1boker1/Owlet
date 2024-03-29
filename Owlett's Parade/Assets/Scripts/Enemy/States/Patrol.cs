﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    #region Variables
    float randomPosX;
    float randomPosZ;

    Vector3 patrolPoint;
    float distanceToPoint;
    [Space(10)]

    public GameObject PosRight;
    public GameObject PosLeft;
    #endregion

    private Melee melee;

    public override void Enter()
    {
        melee = GetComponent<Melee>();
        distanceToPoint = 1.0f;

        melee.enemy_animator.SetTrigger("Walk");
        AssignRandom();
        melee.enemy_navmesh.speed = melee.speed; 
    }

    public override void Execute()
    {
        if (melee.GetDistance(patrolPoint) < distanceToPoint) AssignRandom();
        if (melee.GetDistance(melee.player.transform.position) <= melee.distanceToChase) melee.ChangeState(melee.chase);


    }

    public void AssignRandom()
    {
        randomPosX = Random.Range(PosLeft.transform.position.x, PosRight.transform.position.x);
        randomPosZ = Random.Range(PosLeft.transform.position.z, PosRight.transform.position.z);

        patrolPoint = new Vector3(randomPosX, transform.position.y, randomPosZ);

        melee.enemy_navmesh.SetDestination(patrolPoint);
    }

   

    public float GetDistance(Vector3 patrolPoint)
    {
        return Vector3.Distance(patrolPoint, transform.position);
    }
}

