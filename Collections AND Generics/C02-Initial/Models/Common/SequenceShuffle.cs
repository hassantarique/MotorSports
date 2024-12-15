using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    internal class SequenceShuffle<T> : IEnumerator<T>
    {
        public SequenceShuffle(IEnumerable<T> sequence)
        {
            this.Data = sequence.ToArray();
        }

        public T Current => throw new NotImplementedException();

        private T[] Data { get; }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
