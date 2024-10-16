using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;

namespace TextNumberSizeChange {
    class ToHankakuProcessor : ITextFileService{

        private int _count;

        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {
            _count++;
        }

        public void Terminate() {
            Console.WriteLine("{0} 行", _count);
        }


    }
}
