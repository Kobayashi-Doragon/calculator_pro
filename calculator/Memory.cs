using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Memory
    {
        private String[] memory = new String[4];

        public Memory()
        {
            int i;
            for (i = 0; i < 4; i++)
                memory[i] = "0";
        }

        void memory_save(int number,String data)
        {
        }
        String memory_read(int number) {
            return "a";
        }
        void memory_delete(int number)
        {
            
        }
        bool memory_check(int number)
        {
            return this.memory[number] == null;
        }

    }
    
}
