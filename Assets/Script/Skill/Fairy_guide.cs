﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy_guide : SkillBasicData
{
    public GameObject sword;
    public GameObject _trigger;
    public AnimationClip fairy_guide;
    float ani_time;
    //public Collider[] targetColliders;
    public Transform Rectangle_p;

    // Use this for initialization
    void Start()
    {
        ani_time = fairy_guide.length;
        //DrawTool.DrawRectangleSolid(transform, transform.localPosition, 5, 2);  
    }

    // Update is called once per frame
    void Update()
    {
        //DrawTool.DrawRectangleSolid(Rectangle_p, Rectangle_p.position, _distance, transform.localScale.x * 2);//攻擊範圍標示

        //進入CD
        CDing();

        //使用技能
        if (CanUseSkill && Input.GetKeyDown(KeyCode.Alpha2))
        { UseSkill(); }

        if (CanUseSkill && isUse && isAnimation)
        {
            CostMP();
            _animator.Play("Fairy_guide");
            GameObject _sword = Instantiate(sword, transform.position, transform.rotation);
            if (level == 2)
            {
                GameObject sword1 = Instantiate(sword, transform.position, transform.rotation * Quaternion.Euler(0, 0, 45));
                GameObject sword2 = Instantiate(sword, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
            }
            StartCD(); isUse = false;
            //settle();
        }
    }

    //獲取範圍內敵人
    /* 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            for (int j = 0; j < targetColliders.Length; j++)
            {
                if (targetColliders[j] == other)
                { }
                else
                {
                    // 調整陣列的大小
                    System.Array.Resize(ref targetColliders, targetColliders.Length + 1);
                    // 指定新的陣列值
                    targetColliders[targetColliders.Length - 1] = other;
                }
            }
        }
    }
    */

    /* 
    void settle()//結算
    {
        int _d = CalculateDamege();
        for (int i = 0; i < targetColliders.Length; i++)
        {
            if (targetColliders[i] != null)
            {
                targetColliders[i].GetComponentInParent<Enemy_Health>()._health -= _d;
                targetColliders[i].GetComponentInParent<AI>().isHurt = true;//打擊感
                //show_damage(_d, targetColliders[i].transform.position);
                targetColliders[i] = null;
            }
        }
        
    }
    */

    /*
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, transform.position.z + _distance / 2), new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * _distance));
    }
    */
}
