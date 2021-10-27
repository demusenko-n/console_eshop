using System.Collections.Generic;

namespace SolidBLL
{
    public class Session
    {
        private readonly Dictionary<string, object> _props;

        public Session()
        {
            _props = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get => _props[key];
            set => _props[key] = value;
        }
    }
}