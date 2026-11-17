using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{
    public Vector3 thrustUnitVector;
    public float fuelMass;
    public float maxThrust;
    [Range(0, 1f)]
    public float thurstPercent;
    private float currentThrust;
    public PhysicsEngine physicsEngine;
    void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.mass += fuelMass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fuelMass > FuelThisUpdate())
        {
            fuelMass -= FuelThisUpdate();
            physicsEngine.mass -= FuelThisUpdate();
            ExtertForce();
        }
        else
            Debug.LogWarning("out of rocket fuel");
    }
    float FuelThisUpdate()
    {
        float exhaustMassFlow;
        float effectiveExhausVelocity;
        effectiveExhausVelocity = 4462f;
        exhaustMassFlow = currentThrust / effectiveExhausVelocity;
        return exhaustMassFlow * Time.deltaTime;
    }
    void ExtertForce()
    {
        currentThrust = thurstPercent * maxThrust * 1000f;
        Vector3 thrustVector = thrustUnitVector.normalized * currentThrust;
        physicsEngine.AddForce(thrustVector);
    }
}
