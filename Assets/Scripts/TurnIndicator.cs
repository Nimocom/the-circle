using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
    public static TurnIndicator inst;

    [SerializeField] float movingSpeed;

    PlayerPanel[] playerPanels;

    Coroutine lerpingPosition;

    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        playerPanels = PlayersTable.inst.playerPanels;
    }

    public void SetTurnIndicatorPosition(int playerIndex)
    {
        Transform targetPanel = playerPanels[playerIndex].transform;
        Vector3 targetPosition = new Vector3(transform.position.x, targetPanel.position.y, transform.position.z);

        if (lerpingPosition != null)
            StopCoroutine(lerpingPosition);

        lerpingPosition = StartCoroutine(LerpTurnIndicator(targetPosition));
    }

    IEnumerator LerpTurnIndicator(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
