using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.Demo
{
    public class Test_WRandomPick : MonoBehaviour
    {
        public bool _flag;
        private void OnValidate()
        {
            if (_flag)
            {
                _flag = false;
                Test();
            }
        }

        void Test()
        {
            var wrPicker = new Rito.WeightedRandomPicker<string>();

            // 아이템 및 가중치 목록 전달
            wrPicker.Add(

                ("효과", 1000),
                ("모자", 1),
                ("총", 2)


            );

            for (int i = 0; i < 10; i++)
            {
                Debug.Log(wrPicker.GetRandomPick());
            }

            Debug.Log("");
            foreach (var item in wrPicker.GetItemDictReadonly())
            {
                Debug.Log(item);
            }

            Debug.Log("");
            foreach (var item in wrPicker.GetNormalizedItemDictReadonly())
            {
                Debug.Log(item);
            }
        }
    }
}