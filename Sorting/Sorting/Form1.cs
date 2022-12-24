using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ArrToStr(int[] array)
        {
            String Output = "" ;
            
            for (int i = 0; i < array.Length; i++)
            {
                Output += array[i] + " , ";
            }
            return Output;
        }

        public int[] InsertionSort(int[] array, int length)
        {
            for (int i = 1; i < length; i++)
            {
                var key = array[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            return array;
        }


        public int[] MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                MergeArray(array, left, middle, right);
            }
            return array;
        }

        public void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<int> myNumbers = new List<int>();
            int i;
            foreach (string str in textBox1.Text.Split(' '))
            {

                if (int.TryParse(str, out i))
                    myNumbers.Add(int.Parse(str));

            }

            int[] myNum = myNumbers.ToArray();

            if (InsertionSortRB.Checked == true)
            {
                InsertionSort(myNum, myNum.Length);
            }

            else if (MergeSortRB.Checked == true)
            {
                MergeSort(myNum, 0, myNum.Length - 1);
            }

            textBox2.Text = ArrToStr(myNum);
        }
    }
}
