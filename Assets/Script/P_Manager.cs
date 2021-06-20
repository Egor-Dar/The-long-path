using UnityEngine;

public class P_Manager : MonoBehaviour
{
    private P_InputManager inputManager;
    private P_Locomotion locomotion;

    private void Awake()
    {
        inputManager = GetComponent<P_InputManager>();
        locomotion = GetComponent<P_Locomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        locomotion.AllUpdatesHandlers();
    }

    private void FixedUpdate()
    {
        locomotion.AllFixedUpdatesHandlers();
    }
}
