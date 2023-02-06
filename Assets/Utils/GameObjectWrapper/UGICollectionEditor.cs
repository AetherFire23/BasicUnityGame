using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Utils.GameObjectWrapper
{
    // want T to be an instanceHelper
    // IH asks for AccessScript<TSpecific>
    // InstanceHelper is not an accessScript, so cant pass in T to instanceHelper
    // UGICollectionEditor<SquareHelper> 

    //public class UGICollectionEditor<THelper, TScript> 
    //    where THelper : InstanceHelper<TScript> 
    //    where TScript : AccessScript<TScript>
    //{
    //}

    public class UGICollectionEditor<THelper, TScript>
        where THelper : InstanceHelper<TScript>
        where TScript : AccessScript<TScript>
    {
        public ReadOnlyCollection<THelper> Instances => _instances.AsReadOnly();
        private List<THelper> _instances = new();

        public void RemoveAndDestroy(THelper ugi)
        {
            var ugiInList = _instances.First(x => object.ReferenceEquals(x, ugi));
            ugiInList.GameObject.SelfDestroy();
            _instances.Remove(ugiInList);
        }

        public void Clear()
        {
            _instances.ForEach(x => x.GameObject.SelfDestroy());
            _instances.Clear();
        }

        public void RemoveMany(List<THelper> remove)
        {
            foreach (var ugi in remove)
            {
                RemoveAndDestroy(ugi);
            }
        }

        public bool Contains(THelper ugi)
        {
            var ugiInList = _instances.FirstOrDefault(x => object.ReferenceEquals(x, ugi));
            return ugiInList is not null;
        }

        public THelper Add(THelper ugi)
        {
            _instances.Add(ugi);
            return ugi;
        }

        public void AddMany(List<THelper> ugis)
        {
            _instances.AddRange(ugis);
        }
    }
}
