﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicField : SkillBasicData
{
    public Collider[] hitColliders;
    private Collider[] targetColliders;
    public Transform Rectangle_p;

    public ParticleSystem _particle;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //進入CD
        CDing();


        //獲取範圍內敵人
        hitColliders = Physics.OverlapSphere(transform.position, _distance, 1 << LayerMask.NameToLayer("Enemy"));


        if (CanUseSkill && Input.GetKey(KeyCode.Alpha3))
        { DrawTool.DrawCircle(Rectangle_p, Rectangle_p.localPosition, _distance); }//攻擊範圍標示

        if (Input.GetKeyUp(KeyCode.Alpha3))
        { UseSkill(); }

        if (CanUseSkill && isUse && isAnimation)
        {
            CostMP();
            if (level == 1)
            {
                _particle.Play(true);
                targetColliders = hitColliders;
                settle();
            }
            else if (level == 2)
            { targetColliders = hitColliders; StartCoroutine(Settle()); }
            StartCD();
        }
        if (isAnimation)
        {
            DrawTool.EndDraw(Rectangle_p, false);
            isAnimation = false;
        }
    }
    IEnumerator Settle()
    {
        while (true)
        {
            settle();
            _particle.Play(true);
            yield return new WaitForSeconds(3);
            break;
        }
    }

    void settle()//結算
    {
        int i;
        int _d = CalculateDamege();
        for (i = 0; i < hitColliders.Length; i++)
        {
            targetColliders[i].GetComponentInParent<AI>().Hurt(_d);
            //show_damage(_d, targetColliders[i].transform.position);
        }
        isUse = false;
    }

    /// <summary>  
    /// 不定点式圆形攻击  
    /// </summary>  
    /// <param name="attacked">被攻击方</param>  
    /// <param name="skillPosition">技能释放位置</param>  
    /// <param name="radius">半径</param>  
    /// <returns></returns>  
    public bool CircleAttack(Transform attacked, Transform skillPosition, float radius)
    {
        float distance = Vector3.Distance(attacked.position, skillPosition.position);
        if (distance < radius)
        {
            return true;
        }
        return false;
    }
}
