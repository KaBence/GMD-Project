using UnityEngine;

public class LavaEmission : MonoBehaviour
{
    public Material lavaMaterial;
    public Vector2 scrollSpeed = new Vector2(0.1f, 0.1f);

    void Update()
    {
        if (lavaMaterial != null)
        {
            Vector2 offset = Time.time * scrollSpeed;
            lavaMaterial.SetTextureOffset("_EmissionMap", offset);
        }
    }
}