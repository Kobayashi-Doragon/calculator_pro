using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Memory
    {
        private String[] memory = new String[4];//フォームに反映するためゲッタ必要かも----------------------------

        //コンストラクタ　nullでメモリを初期化
        public Memory()
        {
            int i;
            for (i = 0; i < 4; i++)
                this.memory[i] = null;
        }

        //指定番号のメモリにデータを格納
        void memory_save(int number, String data)
        {
            this.memory[number] = data;
        }

        //指定番号のメモリのデータを返す
        String memory_read(int number)
        {
            return this.memory[number];
        }

        //指定番号のメモリのデータを削除
        void memory_delete(int number)
        {
            this.memory[number] = null;
        }

        //指定番号のメモリにデータがあるか
        bool memory_check(int number)//どこで?-----------------------------------
        {
            return this.memory[number] == null;
        }

    }

}