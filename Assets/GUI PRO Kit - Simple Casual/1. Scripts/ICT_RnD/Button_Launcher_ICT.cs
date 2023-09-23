using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Launcher_ICT : MonoBehaviour, IPointerClickHandler
{
    /*
     * 0923 �ش� �Ǵ� ��ư ����� ������ TRUE �Ǵ� �Է� �� �� 
     * 
     *
     **/

    private GameObject Launcher;
    public string Mode = null;
    public int Contents = -1;
    public bool Back = false;
    public bool Setting = false;

    // Start is called before the first frame update
    void Start()
    {
        Launcher = GameObject.Find("Launcher");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (Mode != null)
        {
            Launcher.GetComponent<GameLauncher_ICT>().Button_Modes(Mode);
        }

        if (Contents != -1)
        {
            Launcher.GetComponent<GameLauncher_ICT>().Button_Contents(Contents);
        }

        if (Back)
            Launcher.GetComponent<GameLauncher_ICT>().Button_Back_ToMode();

        if (Setting)
            Launcher.GetComponent<GameLauncher_ICT>().Button_Back_ToMode();

        //�켱�� ���Ŀ� ���ߵ� UI�鵵 ���⼭ ���������� �����ϴ°ɷ�
    }

    //�ڷ� ���� ��ư�� �����Ϸ��� ON�Ǿ��ִ� ���� �����ؾ��� �ʿ䰡 ������
}
