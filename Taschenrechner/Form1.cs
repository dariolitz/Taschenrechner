using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += " + ";
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += " - ";
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += " * ";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += " / ";
        }

        private string calcStrings(string num1, string op, string num2)
        {
            float number1 = float.Parse(num1);
            float number2 = float.Parse(num2);

            switch (op)
            {
                case "+":
                    return (number1 + number2).ToString();

                case "-":
                    return (number1 - number2).ToString();

                case "*":
                    return (number1 * number2).ToString();

                case "/":
                    return (number1 / number2).ToString();

                default:
                    return "error";
            }
        }

        private readonly string[] PlusMinus = new string[] { "+", "-" };
        private readonly string[] MultDiv = new string[] { "*", "/" };

        private List<string> DeleteElements(List<string> ary, int[] indexes)
        {
            List<string> newAry = new List<string>();
            for (int i = 0; i < ary.Count; i++)
            {
                if (!indexes.Contains(i))
                {
                    newAry.Add(ary[i]);
                }
            }
            return newAry;
        }

        private List<string> Process(List<string> splittedText, int counter, string[] ops)
        {
            if (counter + 1 >= splittedText.Count) return splittedText;
            if (ops.Contains(splittedText[counter + 1]))
            {
                splittedText[counter] = calcStrings(splittedText[counter], splittedText[counter + 1], splittedText[counter + 2]);
                splittedText = DeleteElements(splittedText, new int[] { counter + 1, counter + 2 });
                return Process(splittedText, counter, ops);
            }
            else return splittedText;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            List<string> splittedText = resultBox.Text.Split(' ').ToList();
            int counter = 0;
            while (counter <= splittedText.Count)
            {
                if (splittedText.Count == 1)
                {
                    resultBox.Text = splittedText[0];
                    break;
                }
                if (MultDiv.Contains(splittedText[counter + 1]))
                {
                    splittedText = Process(splittedText, counter, MultDiv);
                    counter = 0; ;
                }
                else
                {
                    if (counter + 3 >= splittedText.Count || PlusMinus.Contains(splittedText[counter + 3]))
                    {
                        splittedText = Process(splittedText, counter, PlusMinus);
                    }
                    else counter++;
                }
            }
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "7";
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "8";
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "9";
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "4";
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "5";
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "6";
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "1";
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "2";
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "3";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += "0";
        }

        private void commaButton_Click(object sender, EventArgs e)
        {
            resultBox.Text += ",";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)48:
                    zeroButton_Click(sender, e);
                    break;

                case (char)49:
                    oneButton_Click(sender, e);
                    break;

                case (char)50:
                    twoButton_Click(sender, e);
                    break;

                case (char)51:
                    threeButton_Click(sender, e);
                    break;

                case (char)52:
                    fourButton_Click(sender, e);
                    break;

                case (char)53:
                    fiveButton_Click(sender, e);
                    break;

                case (char)54:
                    sixButton_Click(sender, e);
                    break;

                case (char)55:
                    sevenButton_Click(sender, e);
                    break;

                case (char)56:
                    eightButton_Click(sender, e);
                    break;

                case (char)57:
                    nineButton_Click(sender, e);
                    break;

                case (char)8:
                    clearButton_Click(sender, e);
                    break;

                case (char)44:
                    commaButton_Click(sender, e);
                    break;

                case (char)42:
                    multiplyButton_Click(sender, e);
                    break;

                case (char)43:
                    addButton_Click(sender, e);
                    break;

                case (char)45:
                    subtractButton_Click(sender, e);
                    break;

                case (char)47:
                    divideButton_Click(sender, e);
                    break;

                default:
                    break;
            }
        }
    }
}