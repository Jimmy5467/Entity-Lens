using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    [SerializeField]private RawImage buttonImage;


    private int _itemId;
    private Sprite _buttonTexture;
    public int ItemId
    {
        set
        {
            _itemId = value;
        }
    }
    public Sprite ButtonTexture
    {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(_itemId);
    }
    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.localScale = Vector3.one * 100 / 90;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
