
using UnityEngine;

public class DiceAnimator : MonoBehaviour
{
    [SerializeField] Rigidbody dice1, dice2;

    [SerializeField] float power;
    [SerializeField] float setTime;

    Vector3 targetRotation1, targetRotation2;

    void Start()
    {
        InvokeRepeating("SetRotation", 0f, setTime);
    }

    void FixedUpdate()
    {
        dice1.AddTorque(targetRotation1 * power);
        dice2.AddTorque(targetRotation2 * power);
    }

    void SetRotation()
    {
        targetRotation1 = Random.onUnitSphere;
        targetRotation2 = Random.onUnitSphere;
    }
}
