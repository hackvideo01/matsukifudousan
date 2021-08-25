using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matsukifudousan.ViewModel
{
    public class SessionVM : BaseViewModel
    {

        private Dictionary<string, object> _listObject = new Dictionary<string, object>();
        private void Add(string key, object value)
        {
            if (_listObject.ContainsKey(key))
                _listObject[key] = value;
            else
                _listObject.Add(key, value);
        }
        private object Get(string key)
        {
            if (_listObject.ContainsKey(key))
                return _listObject[key];
            else
                return null;
        }

        public object this[string key] { set { Add(key, value); } get { return Get(key); } }

        public void Clear()
        {
            _listObject.Clear();
        }
        public SessionVM()
        {
            
        }
    }
}
