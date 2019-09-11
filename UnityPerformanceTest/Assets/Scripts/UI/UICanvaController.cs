using Test;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UICanvaController : MonoBehaviour
    {
        private void Start()
        {
            var btn = transform.Find("BtnCollectionsTraversal").GetComponent<Button>();
            btn.onClick.AddListener(BtnCollectionsTraversalClick);
        }
        
        private static void BtnCollectionsTraversalClick()
        {
            var test = new TestCollectionsTraversal();
            test.StartTest();
        }

    }
}
