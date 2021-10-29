using System.Collections.Generic;
using SolidDAL.Entities;

namespace SolidBLL
{
    public class Session
    {
        private readonly Dictionary<string, object> _props;

        public Session()
        {
            _props = new Dictionary<string, object>
            {
                ["User"] = new User("", "", "", "") { Role = Role.Guest },
                ["Cart"] = new Cart()
            };
        }

        public object this[string key]
        {
            get => _props[key];
            set => _props[key] = value;
        }
    }
}