using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raffles.DomainObjects.Converters
{
    public static class Extensions
    {
        /// <summary> Creates an ObservableCollection from a System.Collections.Generic.IEnumerable&lt;T&gt; </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source) {
            if (source == null) throw new ArgumentNullException("source");
            return new ObservableCollection<T>(source);
        }

        /// <summary> Creates an ObservableCollection from a System.Collections.Generic.ICollection&lt;T&gt; </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this ICollection<T> source) {
            if (source == null) throw new ArgumentNullException("source");
            return new ObservableCollection<T>(source);
        }
    }
}
