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
    private float range;  // ������ ������ ������ �ִ� �Ÿ�

    private bool pickupActivated = false;  // ������ ���� �����ҽ� True 

    private RaycastHit hitInfo;  // �浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask;  // Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� ������ �� �־�� �Ѵ�.

    [SerializeField]
    //private Text actionText;  // �ൿ�� ���� �� �ؽ�Ʈ
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
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�.");  // �κ��丮 �ֱ�
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
