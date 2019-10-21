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

        public void memory_save(int number,String data)
        {
            memory[number] = data;
        }
        public String memory_read(int number) {
            return memory[number];
        }
        public void memory_delete(int number)
        {
            memory[number] = "0";
        }
        public bool memory_check(int number)
        {
            return this.memory[number] != "0";
        }
    }
}
