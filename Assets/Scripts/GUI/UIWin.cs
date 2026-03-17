using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIWin : UIElement
{
    public override bool ManualHide => true;
    public override bool DestroyOnHide => false;
    public override bool UseBehindPanel => false;

    [SerializeField] private Button btn_next;

    private void Start()
    {
        btn_next.onClick.AddListener(NextGame);
    }

    private void NextGame()
    {
        Hide();
    }
}
