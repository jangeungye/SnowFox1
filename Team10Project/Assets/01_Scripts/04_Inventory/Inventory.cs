using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    

    [SerializeField]
    List<GameObject> items = new List<GameObject>();

    [SerializeField]
    List<GameObject> prefabItems = new List<GameObject>();

    [SerializeField]
    List<GameObject> getItem = new List<GameObject>();

    [SerializeField]
    List<Image> getItemImage = new List<Image>();

    [SerializeField]
    int itemNumber;
    int getItemNumber;

    float fadeSpeed = 0.5f;

    bool isDogTag;
    bool isFamilyPhoto;
    bool isRibbon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && isDogTag)
        {
            itemNumber = 0;
            items[itemNumber].SetActive(true);
            prefabItems[itemNumber].SetActive(false);
            
            getItemNumber = 0;
            StartImage();
        }
        else if (Input.GetKeyDown(KeyCode.N) && isFamilyPhoto)
        {
            itemNumber = 1;
            items[itemNumber].SetActive(true);
            itemNumber = 0;
            prefabItems[itemNumber].SetActive(false);
            
            getItemNumber = 4;
            StartImage();
        }
        else if (Input.GetKeyDown(KeyCode.N) && isRibbon)
        {
            itemNumber = 3;
            items[itemNumber].SetActive(true);
            itemNumber = 0;
            prefabItems[itemNumber].SetActive(false);
            
            getItemNumber = 2;
            StartImage();
        }
    }

    public void NPC1NumberPlus()
    {
        getItemNumber = 1;
    }
    public void NPC2NumberPlus()
    {
        getItemNumber = 5;
    }
    public void NPC3NumberPlus()
    {
        getItemNumber = 3;
    }
    public void StartImage()
    {
        getItem[getItemNumber].SetActive(true);

        SpriteRenderer spriteRenderer = getItem[getItemNumber].GetComponent<SpriteRenderer>();

        StartCoroutine(FadeIn()); //수정필요

    }

    IEnumerator FadeIn()
    {
        while (getItemImage[getItemNumber].color.a < 1f)
        {
            Color newColor = getItemImage[getItemNumber].color;
            newColor.a += Time.deltaTime * fadeSpeed;
            getItemImage[getItemNumber].color = newColor;
            yield return null;
        }

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (getItemImage[getItemNumber].color.a > 0f)
        {
            Color newColor = getItemImage[getItemNumber].color;
            newColor.a -= Time.deltaTime * fadeSpeed;
            getItemImage[getItemNumber].color = newColor;
            yield return null;
        }


        getItem[getItemNumber].SetActive(false);
    }



    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DogTag"))
        {
            //itemNumber = 0;
            isDogTag = true;          
        }
        if (collision.gameObject.CompareTag("FamilyPhoto"))
        {
            //itemNumber = 2;
            isFamilyPhoto = true;
        }
        if (collision.gameObject.CompareTag("Ribbon"))
        {
            //itemNumber = 4;
            isRibbon = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DogTag"))
        {
            isDogTag = false;
        }
        if (collision.gameObject.CompareTag("FamilyPhoto"))
        {
            isFamilyPhoto = false;
        }
        if (collision.gameObject.CompareTag("Ribbon"))
        {
            isRibbon = false;
        }
    }
}
