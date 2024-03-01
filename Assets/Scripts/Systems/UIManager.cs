using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    CourageSystem courageSystem;


    public List<Image> hearts;
    public Image hpPrefab;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject heartPrefab, hpArea;

    private void Start() {
        courageSystem = GameManager.instance.courageSystem;
    }

    private void Update() 
    {
        if(courageSystem.currentCourage > hearts.Count)
        {
            GameObject addedHeart = Instantiate(heartPrefab,hpArea.transform.position, quaternion.identity);
            hearts.Add(addedHeart.GetComponentInChildren<Image>());
            addedHeart.transform.SetParent(hpArea.transform, false);
        }
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < courageSystem.currentCourage; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

}