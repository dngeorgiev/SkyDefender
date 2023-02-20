using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        this.material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        this.offset = this.moveSpeed * Time.deltaTime;
        this.material.mainTextureOffset += this.offset;
    }
}
