using System;
using System.Collections.Generic;
using System.Text;

namespace transnfc_v4
{
    public interface ITagScanner
    {
        bool NfcAvaible { get; }
        void Scan(Action<byte[]> on_result);
    }
}
