using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2of5codigo
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "027516159972700000010048456";            
            
            Console.WriteLine("{0}", Interleaved25(cadena));
            //Console.WriteLine("{0}", GenerarCodigoBarras(cadena));
            Console.ReadLine();
        }

        static string GenerarCodigoBarras(string codigoBarras)
        {
            var codigo = String.Empty;
            char[] array = codigoBarras.ToCharArray();
            var valorx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                    valorx += Convert.ToInt32(array[i].ToString()) * 1;
                else
                    valorx += Convert.ToInt32(array[i].ToString()) * 3;
                
            }
            
            var residuo = valorx % 10;
            var codigoVerificador = 10 - int.Parse(residuo.ToString());
            codigo = codigoBarras + codigoVerificador.ToString();

            return codigo;
        }

        static string Interleaved25(string input)
        {
            if (input.Length <= 0) return "";

            if (input.Length % 2 != 0)
            {
                input = "0" + input;
            }

            string result = "";
            string codigo = "";
            
            for (int i = 0; i <= input.Length - 1; i += 2)
            {
                int pair = Int32.Parse(input.Substring(i, 2));

                if (pair <= 93)
                    pair = pair + 33;
                else if (pair > 93)
                    pair = pair + 101;
                
                result = result + Convert.ToChar(pair);
            }
            
            codigo = (char)201 + result + (char)202;

            return codigo;
        }
    }
}
