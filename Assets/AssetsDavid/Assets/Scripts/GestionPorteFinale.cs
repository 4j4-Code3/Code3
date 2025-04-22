using UnityEngine;
using UnityEngine.Animations;

public class GestionPorteFinale : MonoBehaviour
{    
    static int chanceMDP;
    public bool interagis = false;
    public GestionCamera gestionCamera;

    void Start()
    {
        chanceMDP = 3;
    }
    
    void Update()
    {
        
    }

    public void InteractionConsole()
    {
        // interagis = !interagis;
        // Time.timeScale = interagis ? 0 : 1;

        // if(interagis)
        // {
        //     Transform infoEnfant = gameObject.transform.GetChild(0);
        //     GameObject enfant = infoEnfant.gameObject;
        //     Transform positionCameraConsole = enfant.transform;

        //     Camera.main.transform.position = positionCameraConsole.position;
        // }
        // else
        // {
        //     Camera.main.transform.position = gestionCamera.positionBaseCamera.position;
        //     Debug.Log("oui");
        // }
    }
}
