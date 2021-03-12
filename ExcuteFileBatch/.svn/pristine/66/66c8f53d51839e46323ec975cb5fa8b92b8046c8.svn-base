using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationDLL {
    public class RuleCollection<T> : IEnumerable<T> {
        readonly List<T> _innerCollection = new List<T>();
        public event Action<T> ItemAdded;
        private Action<T> _capture = null;
		public void Add(T item) {
			if (_capture == null) {
				_innerCollection.Add(item);
			}
			else {
				_capture(item);
			}

			ItemAdded?.Invoke(item);
		}

		public int Count => _innerCollection.Count;

		public void Remove(T item) {
			_innerCollection.Remove(item);
		}

		public void AddRange(IEnumerable<T> collection) {
			_innerCollection.AddRange(collection);
		}

		public IEnumerator<T> GetEnumerator() {
			return _innerCollection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}