using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Test
{
    public class TestCollectionsTraversal : MonoBehaviour
    {
        private const  string TestTitle = "CollectionsTraversal";
        
        private TimeSpan _timeSpan;
        private DateTime _lastDateTime;
        
        void Start()
        {
            const int count = 1000000;
            TestList(count);
            TestArray(count);
            TestDictionary(count);
        }

        private void TestList(int count)
        {
            var l = new List<int>(count);
            for (var i = 0; i < count; ++i)
            {
                l.Add(i);
            }
            
            _lastDateTime = DateTime.Now;
            var n = l.Count;
            for (var i = 0; i < n; ++i)
            {
                var v = l[i];
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            LoggerHelper.Log($"{TestTitle}_List For Used Time {_timeSpan.TotalMilliseconds} milliseconds");

            _lastDateTime = DateTime.Now;
            foreach (var v in l)
            {
                var v2 = v;
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            LoggerHelper.Log($"{TestTitle}_List Foreach Used Time {_timeSpan.TotalMilliseconds} milliseconds");
        }

        private void TestArray(int count)
        {
            var array = new int[count];
            for (var i = 0; i < count; ++i)
            {
                array[i] = i;
            }
            
            _lastDateTime = DateTime.Now;
            var n = array.Length;
            for (var i = 0; i < n; ++i)
            {
                var v = array[i];
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            LoggerHelper.Log($"{TestTitle}_Array For Used Time {_timeSpan.TotalMilliseconds} milliseconds");

            _lastDateTime = DateTime.Now;
            foreach (var v in array)
            {
                var v2 = v;
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            LoggerHelper.Log($"{TestTitle}_Array Foreach Used Time {_timeSpan.TotalMilliseconds} milliseconds");
        }

        private void TestDictionary(int count)
        {
            var dic = new Dictionary<int, string>(count);
            for (var i = 0; i < count; ++i)
            {
                dic.Add(i, "test");
            }
            
            _lastDateTime = DateTime.Now;
            var n = dic.Count;
            for (var i = 0; i < n; ++i)
            {
                dic.TryGetValue(i, out var v);
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            LoggerHelper.Log($"{TestTitle}_Dic For Used Time {_timeSpan.TotalMilliseconds} milliseconds");
            
            _lastDateTime = DateTime.Now;
            foreach (var v in dic.Values)
            {
                var v2 = v;
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            LoggerHelper.Log($"{TestTitle}_Dic Foreach Used Time {_timeSpan.TotalMilliseconds} milliseconds");
            
        }
        
    }
}
