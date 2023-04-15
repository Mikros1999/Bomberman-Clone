using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float animationTime = 0.25f;
    private int animationFrame;

    public Sprite idleSprite;
    public Sprite[] animationSprites;
    public bool loopAnimation = true;
    public bool idleAnimation = true;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Start()
    {
      InvokeRepeating(nameof(NextFrame), animationTime, animationTime);  
    }

    private void NextFrame()
    {
        animationFrame++;

        if (loopAnimation && animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        if (idleAnimation)
        {
            spriteRenderer.sprite = idleSprite;
        } else if (animationFrame >= 0 && animationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[animationFrame];
        }
    }
}
