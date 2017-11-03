        var aTxt;
        var bTxt;
        var opStr;


        function fNum(p)
        {
            tbCalc.value += p.value;
        }

        function fOp(p)
        {
            if (p.value == '=')
            {
                var aNum = parseInt(aTxt);
                var bNum = parseInt(tbCalc.value);
                var oPer = opStr;
                var res = Calc(aNum, bNum, oPer);
                tbCalc.value = res;
            }
            else
            {
                aTxt = tbCalc.value;
                tbCalc.value = "";
                opStr = p.value;
            }
        }

        function Calc(a1, a2, op) {
            var res;
            switch (op) {
                case "*":
                    res = a1 * a2;
                    break;
                case "+":
                    res = a1 + a2;
                    break;
                case "-":
                    res = a1 - a2;
                    break;
                case "/":
                    res = a1 / a2;
                    break;
                default:
                    res = 0;
                    break;
            }
            return res;
        };
