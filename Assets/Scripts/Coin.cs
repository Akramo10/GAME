using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        // Détruire la pièce si elle touche un obstacle
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        // Si ce n’est pas le joueur, ignorer
        if (!other.CompareTag("Player"))
        {
            return;
        }

        // Incrémenter le score
        GameManager.inst.IncrementScore();

        // Détruire la pièce
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
