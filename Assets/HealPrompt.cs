using UnityEngine;
using TMPro;

public class HealPrompt : MonoBehaviour
{
    [SerializeField] CourageSystem courageSystem; // Reference to the CourageSystem script
    public GameObject tmpChild; // Reference to the TMP child object

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the TMP child object is initially inactive
        if (tmpChild != null)
        {
            tmpChild.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if CourageSystem script reference is assigned and currentCourage is 3
        if (courageSystem != null && courageSystem.currentCourage == 3)
        {
           tmpChild.SetActive(true);
        }
        else if (courageSystem.currentCourage < 3)
        {
            tmpChild.SetActive(false);
        }
        else
        {
            return;
        }
    }
    
}
