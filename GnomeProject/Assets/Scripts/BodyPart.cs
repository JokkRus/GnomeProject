﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BodyPart : MonoBehaviour
{
    public Sprite detachedSprite;
    public Sprite burnedSprite;
    public Transform bloodFountainOrigin;
    bool detached = false;

    public void Detach()
    {
        detached = true;
        this.tag = "Untagged";
        transform.SetParent(null, true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detached == false) 
        {
            return; 
        }
        var rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody.IsSleeping())
        {
            Debug.Log("Detac");
            foreach (Joint2D joint in GetComponentsInChildren<Joint2D>())
            {
                Destroy(joint);
            }
            foreach (Rigidbody2D body in GetComponentsInChildren<Rigidbody2D>())
            { 
                Destroy(body); 
            }
            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
            { 
                Destroy(collider); 
            }
            Destroy(this);
        }
    }
    public void ApplyDamageSprite(Gnome.DamageType damageType)
    {
        Sprite spriteToUse = null;
        switch (damageType)
        {
            case Gnome.DamageType.Burning:
                spriteToUse = burnedSprite;
                break;
            case Gnome.DamageType.Slicing:
                spriteToUse = detachedSprite;
                break;
        }
        if (spriteToUse != null)
        {
            GetComponent<SpriteRenderer>().sprite = spriteToUse;
        }
    }
}
