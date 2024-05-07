using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private GameObject character;

    void Update()
    {
        Vector3 newPosition = new Vector3(
            character.transform.position.x - 0.2239542f,
            character.transform.position.y + 5.1f,
            character.transform.position.z - 5.024759f
        );

        transform.position = newPosition;
    }
}