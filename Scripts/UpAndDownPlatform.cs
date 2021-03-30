using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownPlatform : MonoBehaviour
{
private Vector2 startPosition;
private Vector2 newPosition;

[SerializeField] private int speed = 3;
[SerializeField] private int maxDistance = 1;

void Start()
{
    startPosition = transform.position;
    newPosition = transform.position;
}

void Update()
{
    newPosition.y = startPosition.y + (maxDistance * Mathf.Sin(Time.time * speed));
    transform.position = newPosition;
}
}
