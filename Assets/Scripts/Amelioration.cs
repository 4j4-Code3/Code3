using UnityEngine;
using UnityEngine.UI;

public class Amelioration : MonoBehaviour
{
    public Inventaire inventaire;
    public StatsJoueur statsJoueur;
    public Slider slider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
