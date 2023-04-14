using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerComponentsContainer playerComponentsContainer;

    private void Start()
    {
        GameManager.GetInstance().RegisterPlayer(playerComponentsContainer.HealthController);
    }
}
