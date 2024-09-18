using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Vector2 speed;

    private Material backgroundMaterial;

    private void Awake()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.mainTextureOffset += speed * Time.deltaTime;
    }
}