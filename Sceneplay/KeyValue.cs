using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay
{
    [Serializable]
    public struct KeyValue<TKey, TValue> 
    {
        public KeyValue(TKey key, TValue value)
        {
            this = new KeyValue<TKey,TValue>();
            Key = key;
            Value = value;                
        }
        public TKey Key { get;  set; }
        public TValue Value { get; set; }
    }
}
