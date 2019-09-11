# UnityPerformanceTest

## Unity C#容器(Array, List, Dictionay)性能测试

### 测试条件

1. 平台环境: Unity2018.4 ，Window Android
2. 编译环境：IL2CPP
3. List，Array，Dictionay 3个容器，通过For和Foreach分别遍历100万次，记录执行时间，同时测试了5次，记录结果；
   由于Array数据比较近似，后面增加到遍历1000万次，也是测试了5次，记录结果。
4. 测试结果可能有波动，结果取平均值。 

### 测试结果 

1. Array效率高于List<T>, 如果固定长度数据，选择Array。
2. 遍历数据时Array采用Foreach，List<T>采用For的形式。
3. Dictionay如果遍历，采用foreach (var v in dictionary.Values)，同时dictionary.TryGetValue()消耗较大。
4. 容器选择很重要，前期数据结构设计好，减少cpu压力，避免cpu发热量过高导致掉帧。
5. 尽量减少在Update中每帧都通过容器遍历数据。

### 测试代码

``` c#

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

        private readonly StringBuilder _logTmp = new StringBuilder();

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


```

### 测试Log记录 [详细数据](TestLogs/)⁩   

#### Test Windows Editor
![Windows](images/0.png)

#### Test Android Platform(HuaiWei Honour Note 8) 
![Android](images/1.png)

### 待完成 iOS平台没有测试
