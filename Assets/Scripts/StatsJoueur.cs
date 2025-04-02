using UnityEngine;

[CreateAssetMenu(fileName = "StatsJoueur", menuName = "StatsJoueur")]
public class StatsJoueur : ScriptableObject
// Stats du joueur
{
    public float radiation;
    public float maxRadiation;
    public float energie;
    public int efficaciteSeringue;
}
