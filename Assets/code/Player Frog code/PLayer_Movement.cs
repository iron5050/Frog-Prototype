using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Movement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originPosistion, targetPosistion;
    private float timeToMove = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
            MovePlayer(Vector3.up);

        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
            MovePlayer(Vector3.left);

        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
            MovePlayer(Vector3.down);

        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
            MovePlayer(Vector3.right);
    }

    private IEnumerable MovePlayer(Vector3 direction) 
    {
        isMoving = true;

        float elapsedTime = 0;

        originPosistion = transform.position;
        targetPosistion = originPosistion + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originPosistion, targetPosistion, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosistion;

        isMoving = false;
    }

}

