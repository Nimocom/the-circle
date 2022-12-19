using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager inst;

    [SerializeField] Rigidbody dice1, dice2;

    [SerializeField] float throwingPower;
    [SerializeField] float torquePower;

    Vector3 startPos1, startPos2;

    Coroutine checkingForStop;

    int result;

    public bool diceThrown;

    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        startPos1 = dice1.transform.position;
        startPos2 = dice2.transform.position;
    }

    public void ThrowTheDice()
    {
        if (diceThrown)
            return;

        diceThrown = true;

        dice1.position = startPos1;
        dice2.position = startPos2;

        result = 0;

        var dir = Random.onUnitSphere;

        Throw(dice1, dir);
        Throw(dice2, dir);

        if (checkingForStop != null)
            StopCoroutine(checkingForStop);

        checkingForStop = StartCoroutine(CheckForStop());
    }

    public void Throw(Rigidbody dice, Vector3 direction)
    {
        float dirX = Random.Range(0, 500f);
        float dirY = Random.Range(0, 500f);
        float dirZ = Random.Range(0, 500f);

        dice.AddForce(direction * throwingPower);
        dice.AddTorque(Random.onUnitSphere * torquePower);
    }

    IEnumerator CheckForStop()
    {
        yield return new WaitForFixedUpdate();

        while (dice1.velocity.magnitude + dice2.velocity.magnitude > 0f)
            yield return null;

        if (CheckResult(dice1.transform) && CheckResult(dice2.transform))
        {
            print(result);
            IndicatorsManager.inst.MoveIndicator(result, 0);
        }
        else
        {
            print("Reroll!");
            diceThrown = false;
        }
    }

    bool CheckResult(Transform dice)
    {
        if (Vector3.Angle(dice.forward, Vector3.up) < 3f)
            result += 2;
        else if (Vector3.Angle(dice.right, Vector3.up) < 3f)
            result += 6;
        else if (Vector3.Angle(dice.up, Vector3.up) < 3)
            result += 3;
        else if (Vector3.Angle(-dice.forward, Vector3.up) < 3f)
            result += 5;
        else if (Vector3.Angle(-dice.right, Vector3.up) < 3f)
            result += 1;
        else if (Vector3.Angle(-dice.up, Vector3.up) < 3f)
            result += 4;
        else
            return false;

        return true;
    }
}
