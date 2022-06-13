using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public Bounds bounds { get; private set; }
    [SerializeField] private RectTransform gameArea;


    void Awake()
    {
        this.bounds = new Bounds(gameArea.position, gameArea.rect.size);
    }
}