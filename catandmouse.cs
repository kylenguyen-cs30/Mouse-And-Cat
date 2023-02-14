// Name : Hoang Nguyen
// Email: Hnguyen1193@csu.fullerton.edu
// Application 

using System;
using System.Windows.Forms;

public class CatAndMouse
{
    public static void Main()
    {
        System.Console.WriteLine("Welcome to the Main Method of the Cat and Mouse program");
        CatAndMouseUI newapp = new CatAndMouseUI();
        Application.Run(newapp);
        System.Console.WriteLine("Main Method will now Shut down");
        
    }
}