using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay
{
    [Serializable]
    public class KeyValue<TKey, TValue> 
    {
        public KeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;                
        }
        public KeyValue()
        { }
        public TKey Key { get;  set; }
        public TValue Value { get; set; }
    }
}
