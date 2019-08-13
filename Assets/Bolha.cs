using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bolha : MonoBehaviour, IPointerClickHandler
{

    SpriteRenderer sRender;

    void Start()
    {
        sRender = GetComponent<SpriteRenderer>();

        Color c = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0.7f, 0.9f);
        c.a = 0.5f;
        sRender.color = c;
    }

    Vector3 addPos()
    {
        return Random.insideUnitCircle * 0.01f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.localScale.magnitude < 0.5f)
        {
            Destroy(gameObject);
            return;
        }
        transform.localScale *= 0.8f;
        transform.position += addPos();
        Bolha b = Instantiate<Bolha>(this, transform.position + addPos(), Quaternion.identity);
    }

    [ContextMenu("Save")]
    void save()
    {
        SaveBolha saveBolha = new SaveBolha();
        saveBolha.pos = transform.position;
        saveBolha.scale = transform.localScale;
        saveBolha.cor = sRender.color;

        string dados = JsonUtility.ToJson(saveBolha);

        string position = transform.position.ToString();
        string color = sRender.color.ToString();
        string scale = transform.localScale.ToString();

        PlayerPrefs.SetString("pos", position);
        PlayerPrefs.SetString("cor", color);
        PlayerPrefs.SetString("scale", scale);
    }
    [ContextMenu("Load")]
    void load()
    {
        print("posição: " + PlayerPrefs.GetString("pos"));
        print("Cor: " + PlayerPrefs.GetString("cor"));
        print("Escala: " + PlayerPrefs.GetString("scale"));


    }
}