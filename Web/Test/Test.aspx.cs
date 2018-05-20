using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Break down task into 2 tasks.Get 
        // 1. Prime List and 2. Adjacent Sums

        // Task 1 Get Prime List, use List<> or Array[] 
        List<int> myPrimeList = Get_PrimeList(1, 99);

        // Task 2 adjacent sums. 
        Adjacent_Sum(myPrimeList);
    }

    private List<int> Get_PrimeList(int minnumber, int maxnumber)
    {
        // Break down first task into 2 smaller tasks.
        // 1. Create container to stroe list. 2. test number

        // Create my Prime List 
        List<int> myPrimeList = new List<int>();

        for (int i = minnumber; i < maxnumber; i++)
        {
            // Test number
            if (Check_Prime(i))
            {
                // Add to my Prime List
                myPrimeList.Add(i);

                // Print List if needed
                // Console.WriteLine(i);
                // Label_PrimeList.Text += i.ToString() + " ";
            }
        }

        return myPrimeList;

    }

    private bool Check_Prime(int number)
    {
        // Test whether the input number is a prime number.
        if ((number & 1) == 0)
        {
            if (number == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        for (int i = 3; (i * i) <= number; i += 2)
        {
            if ((number % i) == 0)
            {
                return false;
            }
        }

        return number != 1;
    }

    private void Adjacent_Sum(List<int> myprimelist)
    {
        // Create List or Array if need store the result
        List<int> myAdjacent_Sum_List = new List<int>();

        // Start adjacent sum if numbers count more than 2
        if (myprimelist.Count > 1)
        {
            for (int i = 1; i < myprimelist.Count; i++)
            {
                myAdjacent_Sum_List.Add(myprimelist[i - 1] + myprimelist[i]);

                // Print List if needed
                // Console.WriteLine(myprimelist[i - 1] + myprimelist[i]);
                //Label_AdjacentSums.Text += (myprimelist[i - 1] + myprimelist[i]).ToString() + " ";
            }
        }
    }
}