using UnityEngine;

public class LavaEmission : MonoBehaviour
{
    [SerializeField] private Material lavaMaterial;
    [SerializeField] private Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);

    void Update()
    {
        if (lavaMaterial != null)
        {
            Vector2 offset = Time.time * scrollSpeed;
            lavaMaterial.SetTextureOffset("_EmissionMap", offset);
        }
    }
}