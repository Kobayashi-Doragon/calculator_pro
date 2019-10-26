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
        private int count;
        private Stack<string> st = new Stack<string>();
        private bool preoperator=true;//*を省略したとき用

        public Formula()
        {
            this.formula_text ="";
        }

        public bool formula_check()//クラス内メソッドなので引数いらない説
        {
            return true;
        }
        public double calculation() {
            //return 0;

            return calcRPN(convertRPN());
            
        }

        //式をRPNにして返す
        string[] convertRPN()
        {
            string[] tokens = formula_text.Split(' ');
            string[] rpn = new string[tokens.Length*2];
            count = 0;
            preoperator=true;

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
                        preoperator=false;
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
                            preoperator=false;
                        }
                        else
                        {
                            if(!preoperator){
                                multi_add(rpn);
                            }
                            preoperator=true;
                            st.Push("|");
                        }
                        break;
                    //"("のとき
                    case "(":
                        if(!preoperator && st.Peek()!="log"){
                            multi_add(rpn);
                        }
                        preoperator=true;
                        st.Push("(");
                        break;
                    //+-のとき
                    case "+":
                    case "-":
                        if(preoperator){
                            zero_add(rpn);
                        }
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
                        preoperator=true;
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
                        preoperator=true;
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
                            if(!preoperator){
                                multi_add(rpn);
                            }
                            
                            while (st.Peek() != "(" && st.Peek() != "|" && st.Peek() != "+" && st.Peek() != "-" && st.Peek() != "*" && st.Peek() != "/")
                            {
                                rpn[count] = st.Pop();
                                count++;
                                if(st.Count==0)
                                    break;
                            }
                            st.Push(tokens[i]);
                        }
                        preoperator=true;
                        break;
                    //数字,e,piの時
                    default:
                        if(!preoperator){
                            multi_add(rpn);
                        }
                        preoperator=false;
                        rpn[count] = tokens[i];
                        count++;
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

        //*演算子が省略されてるとき*をスタックに追加
        private void multi_add(string[] rpn){
            if (st.Count == 0)
            {
                st.Push("*");
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
                st.Push("*");
            }
        }

        //演算子でない"-"の値の時計算できるように0を追加
        private void zero_add(string[] rpn){
            rpn[count] = "0";
            count++;
        }

        //RPNを計算し答えを返す
        double calcRPN(string[] rpn)
        {
            Stack<double> st = new Stack<double>();
            double num;
            for(int i = 0; i < count; i++)
            {
                //数字ならスタックに
                if(double.TryParse(rpn[i],out num))
                {
                    st.Push(num);
                }
                else if(rpn[i]=="e"){
                    st.Push(Math.E);
                }
                else if(rpn[i]=="π"){
                    st.Push(Math.PI);
                }
                //数字でないときそれぞれの計算処理
                else
                {
                    switch (rpn[i])
                    {
                        //"|"のとき---
                        case "|":
                            st.Push(Math.Abs(st.Pop()));
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
                            double a=st.Pop();
                            st.Push(st.Pop()/a);
                            break;
                        //四則演算以外
                        case "sin":
                            st.Push(Math.Sin(st.Pop()));
                            break;
                        case "cos":
                            st.Push(Math.Cos(st.Pop()));
                            break;
                        case "tan":
                            st.Push(Math.Tan(st.Pop()));
                            break;
                        case "√":
                            st.Push(Math.Sqrt(st.Pop()));
                            break;
                        case "^":
                            a=st.Pop();
                            st.Push(Math.Pow(st.Pop(),a));
                            break;
                        case "log":
                            st.Push(Math.Log(st.Pop(),st.Pop()));
                            break;
                        default:
                            break;
                        

                    }
                }
            }
            if(st.Count==0){
                return 0;
            }
            else if(st.Count==1){
                return st.Pop();
            }
            else{
                return 00;
            }
            
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
