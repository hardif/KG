using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    public GameObject FlashImg;
    public GameObject RingImg;
    public GameObject EarplugImg;
    public GameObject SunImg;


    public AudioSource audiosource;

    FlashLight fl = new FlashLight();
    [SerializeField]
    private float range;  // 아이템 습득이 가능한 최대 거리

    private bool pickupActivated = false;  // 아이템 습득 가능할시 True 

    private RaycastHit hitInfo;  // 충돌체 정보 저장

    [SerializeField]
    private LayerMask layerMask;  // 특정 레이어를 가진 오브젝트에 대해서만 습득할 수 있어야 한다.

    [SerializeField]
    //private Text actionText;  // 행동을 보여 줄 텍스트
    private TMP_Text tmp;

    private void Start()
    {
        audiosource = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "FlashLight")
            {
                FlashLight.getFlash();
                FlashImg.SetActive(true);
            }
            else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "EarPlug")
            {
                EarplugImg.SetActive(true);
            }
            else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Ring")
            {
                RingImg.SetActive(true);
            }
            else if (hitInfo.transform.GetComponent<ItemPickUp>().item.itemName == "Sunglass")
            {
                SunImg.SetActive(true);
            }
            else
            {

            }


            CanPickUp();
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
            ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        tmp.gameObject.SetActive(true);
        tmp.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " Get " + "<color=yellow>" + "(E)" + "</color>";
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        tmp.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                audiosource.Play();
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " 획득 했습니다.");  // 인벤토리 넣기
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
