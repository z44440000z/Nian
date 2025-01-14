﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill_trigger : MonoBehaviour
{
    public Collider[] hitColliders;

    public float _distance;
    public float _angle;

    //public bool isLock = false;

    float deg;
    int n = 0;

    // Use this for initialization
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Player_State.islock == true)
            {
                if (n == hitColliders.Length - 1)
                { Player_State.islock = false; n = 0; }
                else
                { n++; }
            }

            else
            {
                Player_target._target = hitColliders[n].transform;
                Player_State.islock = true;
            }

        }
    }

    void FixedUpdate()
    {
        Find_Target();
    }

    public void Find_Target()
    {
        hitColliders = Physics.OverlapSphere(transform.position, _distance, 1 << LayerMask.NameToLayer("Enemy"));

        if (Player_State.islock == false)
        {
            for (int k = 0; k < hitColliders.Length; k++)
            {
                if (hitColliders[k] != null)
                    if (detection(hitColliders[k].transform.position))
                    {
                        Player_target._target = hitColliders[k].transform;
                        break;
                    }
            }
        }

        /*
        if (Player_State.islock == true)
        {
            if (Player_target._target != null && Vector3.Distance(Player_target._target.position, transform.position) > _distance * 1.2)
            { Player_State.islock = false; }
            else if (Player_target._target != null && !detection(Player_target._target.position))
            { Player_State.islock = false; }
        }
        */

    }

    bool detection(Vector3 target)
    {

        Vector3 front_direction = transform.forward;
        Vector3 target_direction = target - transform.position;
        deg = Mathf.Acos(Vector3.Dot(front_direction.normalized, target_direction.normalized)) * Mathf.Rad2Deg;
        /* RaycastHit hit;
        Physics.Raycast(transform.position, target_direction, out hit);hit.collider.tag == */
        {
            if (deg < _angle / 2)
            { return true; }
            else
            { return false; }
        }
    }
}