using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionalController : MonoBehaviour
{
    [SerializeField] Transform mainTransform;
    [SerializeField] float sideAngle = 155f;
    [SerializeField] float backAngle = 65f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite _left;
    [SerializeField] Sprite _front;
    [SerializeField] Sprite _right;
    [SerializeField] Sprite _back;
    
    void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        Debug.DrawRay(Camera.main.transform.position, camForwardVector * 5f, Color.magenta);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        float angle = Mathf.Abs(signedAngle);

        

        if(angle < backAngle)
        {
            spriteRenderer.sprite = _back;
        }
        else if (angle < sideAngle)
        {
            spriteRenderer.sprite = _right;

            if (signedAngle < 0)
            {
                spriteRenderer.sprite = _left;
            }

        }
        else
        {
            spriteRenderer.sprite = _front;
        }
        

    }
}
