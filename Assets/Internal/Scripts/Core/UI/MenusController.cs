using System;
using UnityEngine;
using Utils;

namespace BeeColony.Core.UI.Birth
{
    public class MenusController : MonoBehaviourBase
    {
        [SerializeField] private Menu[] menus;

        public void Show(Menu menu)
        {
            menu.gameObject.SetActive(true);
        }
        
        public void ShowOnly(Menu menu)
        {
            HideAll();
            menu.gameObject.SetActive(true);
        }

        public void Hide(Menu menu)
        {
            menu.gameObject.SetActive(false);
        }

        public void HideAll()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                Hide(menus[i]);
            }
        }
    }
}