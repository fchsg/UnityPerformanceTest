using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Utils;

namespace Test
{
    public class TestCollectionsTraversal : MonoBehaviour
    {
        private TimeSpan _timeSpan;
        private DateTime _lastDateTime;

        private readonly StringBuilder _logTmp = new StringBuilder(1000);

        private void Start()
        {
             var count = 1000000;

            LoggerHelper.LogNormal(DeviceInfo.Info());
            LoggerHelper.LogNormal($"CollectionsTraversal_TraversalCount_{count}\n");

            for (var i = 0; i < 5; i++)
            {
                _logTmp.Clear();
                _logTmp.Append($"-----------------Test the {i + 1} times \n");
                
                TestList(count);
                TestArray(count);
                TestDictionary(count);
                
                LoggerHelper.LogNormal(_logTmp.ToString());
            }

            count = 10000000;
            LoggerHelper.LogNormal($"Array_TraversalCount_{count}\n");
            for (var i = 0; i < 5; i++)
            {
                _logTmp.Clear();
                _logTmp.Append($"-----------------Test the {i + 1} times \n");
                
                TestArray(count);
                
                LoggerHelper.LogNormal(_logTmp.ToString());
            }
            
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
            _logTmp.Append($"List For Used Time {_timeSpan.TotalMilliseconds} milliseconds\n");

            _lastDateTime = DateTime.Now;
            foreach (var v in l)
            {
                var v2 = v;
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            _logTmp.Append($"List Foreach Used Time {_timeSpan.TotalMilliseconds} milliseconds\n");
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
            _logTmp.Append($"Array For Used Time {_timeSpan.TotalMilliseconds} milliseconds\n");

            _lastDateTime = DateTime.Now;
            foreach (var v in array)
            {
                var v2 = v;
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            _logTmp.Append($"Array Foreach Used Time {_timeSpan.TotalMilliseconds} milliseconds\n");
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
            _logTmp.Append($"Dictionary For Used Time {_timeSpan.TotalMilliseconds} milliseconds\n");
            
            _lastDateTime = DateTime.Now;
            foreach (var v in dic.Values)
            {
                var v2 = v;
            }
            _timeSpan =  DateTime.Now.Subtract(_lastDateTime);
            _logTmp.Append($"Dictionary Foreach Used Time {_timeSpan.TotalMilliseconds} milliseconds\n");
            
        }
        
    }
}
