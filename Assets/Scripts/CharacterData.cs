using UnityEngine;

[CreateAssetMenu(
    fileName = "NuevoPersonaje",
    menuName = "Juego/Personaje"
)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite portrait;
    public GameObject characterPrefab;

    public int maxHealth = 100;
    public float moveSpeed = 5f;
    public int attackDamage = 10;
}
