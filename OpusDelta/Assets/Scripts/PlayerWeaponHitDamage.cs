﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHitDamage : MonoBehaviour
{
    public GameObject target;
    public Animator myAnimator;
    public string animatorState;
    public int layerIndex;
    AnimatorStateInfo state;
    AnimatorClipInfo[] animatorClip;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

        //myAnimator = transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        ////Debug.Log(myAnimator.GetLayerName(layerIndex)[0]);

        ////Debug.Log(myAnimator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.name);

        //if (myAnimator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip)
        //{
        //    Debug.Log(myAnimator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.name);
        //}


        state = myAnimator.GetCurrentAnimatorStateInfo(layerIndex);
        animatorClip = myAnimator.GetCurrentAnimatorClipInfo(layerIndex);

        float myTime = myAnimator.GetCurrentAnimatorClipInfo(layerIndex)[0].clip.length * state.normalizedTime;

        //float myTime = 0;
        //myTime += Time.deltaTime;


        if (myAnimator.GetCurrentAnimatorStateInfo(layerIndex).IsTag(animatorState) && myTime <= 1.5f)
        {          
            if (other.gameObject == target)
            {
                Debug.Log(myTime);
                target.GetComponent<Stats>().health -= 10;

                if (target.GetComponent<Stats>().health <= 0)
                {
                    target.GetComponent<Stats>().health = 0;
                }

                //Debug.Log(target.tag + " "+ target.GetComponent<Stats>().health);

            }
        }
    }
}