using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Formula
    {
        private string formula_text;

        public Formula()
        {
            this.formula_text ="";
        }

        public bool formula_check()//クラス内メソッドなので引数いらない説
        {
            return true;
        }
        public int calculation() {
            //return 0;

            return calcRPN(convertRPN());
            
        }

        //式をRPNにして返す
        string[] convertRPN()
        {
            string[] tokens = formula_text.Split(' ');
            string[] rpn = new string[tokens.Length];
            Stack<string> st = new Stack<string>();
            count = 0;

            tokens = formula_text.Split(' ');


            for(int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    //入力で空白が二つ以上続いたとき用
                    case "":
                        break;
                    //")"のとき
                    case ")":
                        while (st.Peek()!="(")
                        {
                            rpn[count] = st.Pop();
                            count++;
                        }
                        st.Pop();
                        break;
                    //"|"のとき
                    case "|":
                        if (st.Contains("|"))
                        {
                            while (st.Peek() != "|")
                            {
                                rpn[count] = st.Pop();
                                count++;
                                if(st.Count==0)
                                    break;
                            }
                            rpn[count]=st.Pop();
                            count++;
                        }
                        else
                        {
                            st.Push("|");
                        }
                        break;
                    //"("のとき
                    case "(":
                        st.Push("(");
                        break;
                    //+-のとき
                    case "+":
                    case "-":
                        if (st.Count == 0)
                        {
                            st.Push(tokens[i]);
                        }
                        else
                        {
                            while (st.Peek() != "(" && st.Peek() != "|")
                            {
                                rpn[count] = st.Pop();
                                count++;
                                if(st.Count==0)
                                    break;
                            }
                            st.Push(tokens[i]);
                        }
                        break;
                    //*/のとき
                    case "*":
                    case "/":
                        if (st.Count == 0)
                        {
                            st.Push(tokens[i]);
                        }
                        else
                        {
                            while (st.Peek() != "(" && st.Peek() != "|" && st.Peek() != "+" && st.Peek() != "-")
                            {
                                rpn[count] = st.Pop();
                                count++;
                                if(st.Count==0)
                                    break;
                            }
                            st.Push(tokens[i]);
                        }
                        break;
                    //四則演算以外(優先順位が高いもの)
                    case "sin":
                    case "cos":
                    case "tan":
                    case "√":
                    case "^":
                    case "log":
                        if (st.Count == 0)
                        {
                            st.Push(tokens[i]);
                        }
                        else
                        {
                            while (st.Peek() != "(" && st.Peek() != "|" && st.Peek() != "+" && st.Peek() != "-" && st.Peek() != "*" && st.Peek() != "/")
                            {
                                rpn[count] = st.Pop();
                                count++;
                                if(st.Count==0)
                                    break;
                            }
                            st.Push(tokens[i]);
                        }
                        break;
                    //数字の時
                    default:
                        rpn[count] = tokens[i];
                        count++;
                        //e,pi
                        break;

                }
                    
            }

            while (st.Count!=0)
                {
                    rpn[count] = st.Pop();
                    count++;
                }

            return rpn;
        }

        //RPNを計算し答えを返す
        int calcRPN(string[] rpn)
        {
            Stack<int> st = new Stack<int>();
            int num;
            for(int i = 0; i < count; i++)
            {
                //数字ならスタックに
                if(int.TryParse(rpn[i],out num))
                {
                    st.Push(num);
                }
                //数字でないときそれぞれの計算処理
                else
                {
                    switch (rpn[i])//-------------------
                    {
                        //"|"のとき
                        case "|":
                            break;
                        //+-のとき
                        case "+":
                            st.Push(st.Pop()+st.Pop());
                            break;
                        case "-":
                            if(st.Count==1){
                                st.Push(-st.Pop());
                            }
                            else{
                                st.Push(-st.Pop()+st.Pop());
                            }
                            break;
                        //*/のとき
                        case "*":
                            st.Push(st.Pop()*st.Pop());
                            break;
                        case "/":
                            int a=st.Pop();
                            st.Push(st.Pop()/a);
                            break;
                        /*
                        //四則演算以外(優先順位が高いもの)
                        case "sin":
                        case "cos":
                        case "tan":
                        case "√":
                        case "^":
                        case "log":
                            if (st.Count == 0)
                            {
                                st.Push(tokens[i]);
                            }
                            else
                            {
                                while (st.Peek() != "(" || st.Peek() != "|" || st.Peek() != "+" || st.Peek() != "-" || st.Peek() != "*" || st.Peek() != "/")
                                {
                                    rpn[count] = st.Pop();
                                    count++;
                                }
                                st.Push(tokens[i]);
                            }
                            break;
                        */
                        //e,piの時
                        default:
                            break;
                        

                    }
                }
            }
            return st.Pop();
        }
        public void formula_delete() {
            this.formula_text = "";
        }
        public string getFormula_text() {
            return formula_text;
        }
        public void setFomula_text(string text) {
            formula_text = text;
        }
    }


}
