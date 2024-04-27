using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private float moveAmount = 10f;
    private bool isVisible = true;

    void Update()
    {
        CheckVisibility();
    }

    private void CheckVisibility()
    {
        Vector3[] frustumCorners = new Vector3[4];
        Camera.main.CalculateFrustumCorners(new Rect(0, 0, 1, 1), Camera.main.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);

        Vector3 worldPosition = transform.position;

        foreach (Vector3 corner in frustumCorners)
        {
            if (Vector3.Distance(worldPosition, corner) > 0)
            {
                isVisible = false;
                MoveObjectOutOfView();
                break;
            }
        }

        if (isVisible && !Application.isPlaying)
        {
            MoveObjectIntoView();
        }
    }

    private void MoveObjectOutOfView()
    {
        transform.Translate(Vector3.forward * moveAmount);
    }

    private void MoveObjectIntoView()
    {
        transform.Translate(-Vector3.forward * moveAmount);
    }
}
