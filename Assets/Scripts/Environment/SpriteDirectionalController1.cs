using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionalController1 : MonoBehaviour
{
    [SerializeField] float backAngle = 65f;
    [SerializeField] float sideAngle = 155f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    private void LateUpdate()
    {
        Vector3 camFormardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        Debug.DrawRay(Camera.main.transform.position, camFormardVector * 5f, Color.magenta);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camFormardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        if (angle < backAngle)

            animationDirection = new Vector2(0f, -1f);

        else if (angle < sideAngle)

            animationDirection = new Vector2(1f, 0f);

        else

            animationDirection = new Vector2(0f, 1f);
        
        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);
    }

    
}