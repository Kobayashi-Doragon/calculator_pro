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
            return 0;
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
