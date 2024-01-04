using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Services;
using System.ComponentModel;
using System.Reflection;

namespace Car_Rental_Management_System_C__Console_
{
    internal class Program
    {


        //METHOD FOR ADDING THE CAR IN THE FILE

        public static void Addcar(string cardetails)
        {

            string carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Cars Details.txt";

            using (FileStream fs2 = new FileStream(carfilepath, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs2, Encoding.UTF8))
                {
                    sw.WriteLine(cardetails);

                }

            }
        }

        //METHOD FOR UPDATING THE CAR IN THE FILE

        public static void Updatecar(int carnumber, int length)
        {
            int counter = 0;
            Console.WriteLine("Update the Car");
            string updatetext = Console.ReadLine();



            Console.WriteLine("Updating the Car..");
            string[] Cars = new string[10];

            string carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Cars Details.txt";
            using (FileStream fss = new FileStream(carfilepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                using (StreamReader sr = new StreamReader(fss))
                {
                    string carsdata = "";
                    for (int i = 0; i < length; i++)
                    {
                        Cars[i] = sr.ReadLine();
                        counter += 1;

                    }

                }

            }
            Cars[carnumber - 1] = updatetext;


            using (FileStream fss = new FileStream(carfilepath, FileMode.Open, FileAccess.Write, FileShare.Write))
            {

                using (StreamWriter sw = new StreamWriter(fss, Encoding.UTF8))
                {
                    for (int i = 0; i < counter; i++)
                    {
                        sw.WriteLine(Cars[i]);
                    }

                }

            }
            Console.WriteLine("Car Updated Successfully");

        }
        //METHOD FOR DELETING THE CAR IN THE FILE
        public static void DeleteCar(int length, int index, int number)
        {
            int counter = 0;
            Console.WriteLine("Deleteting  the Car...\n");
            Console.WriteLine("Deleted Successfuly");
            string updatetext = Console.ReadLine();


            string[] Cars = new string[10];

            string carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Cars Details.txt";
            using (FileStream fss = new FileStream(carfilepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                using (StreamReader sr = new StreamReader(fss))
                {
                    string carsdata = "";
                    for (int i = 0; i < length; i++)
                    {
                        Cars[i] = sr.ReadLine();
                        counter += 1;

                    }

                }

            }

            for (int i = index; i < number; i++)
            {
                Cars[i] = Cars[i + 1];
            }

            Cars[number] = " ";

            using (FileStream fss = new FileStream(carfilepath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {

                using (StreamWriter sw = new StreamWriter(fss, Encoding.UTF8))
                {
                    for (int i = 0; i < number; i++)
                    {
                        sw.WriteLine(Cars[i]);
                    }

                }

            }

        }

        //METHOD FOR SELECTING CAR BY THE CUSTOMER

        public static void SelectCar(int length , string name  , int option)
        {
            int counter = 0;
            Console.WriteLine("Select  the Car...\n");
         
            string[] Cars = new string[10];

            string carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Cars Details.txt";
            using (FileStream fss = new FileStream(carfilepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                using (StreamReader sr = new StreamReader(fss))
                {
                    string carsdata = "";
                    for (int i = 0; i < length; i++)
                    {
                        Cars[i] = sr.ReadLine();
                        counter += 1;

                    }

                }

            }
          
            string userchoice = Cars[option - 1].Replace("   " , ",");
            string[] cardata = userchoice.Split(',');
            int rent = Convert.ToInt32(cardata[4]);
            Console.WriteLine("Enter how much time(in days) you want to borrow the Car?");
            int days = Convert.ToInt32(Console.ReadLine());
            int payment = days * rent;
            Console.WriteLine("Your charges are {0}", payment);
        }


        static void Main(string[] args)
        {
            //User Credentials file path
            string usercredentialsfile = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\User Credentials.txt";

            int carscount = 0;
            Console.WriteLine("=================Welcome to SK Car Rental Services====================");

            //Asking for Login 

            Console.WriteLine("Enter how you want to Login\n\n");


            Console.WriteLine("Press 1 for Admin: \nPress 2 for User: ");
            int loginoption = Convert.ToInt32(Console.ReadLine());
            bool Loggedin = false;
            bool customerloggedin = false;


            //----------------------------------------------ADMIN SECTION-----------------------------------------





            //ADMIN LOGIN
            string confirm = null;
            do
            {
                if (loginoption == 1)
                {



                    Console.WriteLine("Enter Admin Username");
                    string adminusername = Console.ReadLine();

                    Console.WriteLine("Enter Admin Password");
                    string adminpass = Console.ReadLine();


                    string[] admindata = { adminusername + "," + adminpass };




                    string path = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Admin Credentials.txt";
                    string[] data = new string[2];


                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {

                            for (int i = 0; i < data.Length; i++)
                            {
                                data[i] = sr.ReadLine();
                            }
                            for (int i = 0; i < data.Length; i++)
                            {
                                if (admindata[0] == data[i])
                                {
                                    Console.WriteLine("Login Successful!!!");
                                    Loggedin = true;
                                    confirm = "No";
                                    break;
                                }
                                else

                                {

                                    Console.WriteLine("Login Failed!! Please press Yes to try Again and No to Leave ");
                                    confirm = Console.ReadLine();
                                    break;


                                }


                            }
                        }
                    }
                }

            }
            while (confirm == "Yes");


        
            if (Loggedin)

            {
            dashboard:
                int i = 0;
                Console.WriteLine(" =====================CARS===========================\n\n");

                Console.WriteLine(" Make   Model   Tax  Regsitration.no  Rent  Availibity \n");

                string carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Cars Details.txt";

                using (FileStream fss = new FileStream(carfilepath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fss))
                    {

                        string cardata = "";
                        while ((cardata = sr.ReadLine()) != null)
                        {

                            Console.WriteLine($"{i + 1}" + "." + cardata);
                            i += 1;
                            carscount += 1;

                        }

                    }

                }



                //WRITING  THE CARS DATA TO THE FILE

                carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Login Files\\Cars Details.txt";

              

                // ADDING A CAR IN THE FILE
                Console.WriteLine("\n");
                Console.WriteLine("Press add for adding a car and update for updating and delete for deleting");

                string option = Console.ReadLine();

                if (option == "add")
                {
                    Console.WriteLine(" Make    Model   Tax  Regsitration.no   Rent   Availibity ");
                    string Update = Console.ReadLine();
                    Addcar(Update);
                    goto dashboard;
                }

                //SELECTING THE CAR FOR UPDATE

                if (option == "update")
                {



                    Console.WriteLine("Press the car  number for updating the car");
                    int Carnumber = Convert.ToInt32(Console.ReadLine());

                    Updatecar(Carnumber, carscount);
                    goto dashboard;
                }

                //SELECTING THE CAR FOR DELETE

                if (option == "delete")
                {
                    Console.WriteLine("Press the car  number for deleting the car");
                    int Carnumber = Convert.ToInt32(Console.ReadLine());
                    DeleteCar(carscount, Carnumber - 1, carscount - 1);
                    goto dashboard;

                }

            }


            //--------------------------------------------USER SECTION-------------------------------------

            //USER LOGIN OR SIGNUP
            

            else if (loginoption == 2)
                do{
                {
                userlogin:
                    Console.WriteLine("-------------User Resgistration-----------");

                    Console.WriteLine("Enter L for  Login and S for Sign");
                    char loginorsignup = Convert.ToChar(Console.ReadLine());

                    if (loginorsignup == 'S')
                    {

                        Console.WriteLine("Enter your email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter your Password.Must be 8 characters or more:");
                        string Password = Console.ReadLine();

                        if (string.IsNullOrEmpty(email))
                        {
                            Console.WriteLine("Email is necessary!!");
                            goto userlogin;

                        }
                        else if (Password.Length < 8)
                        {
                            Console.WriteLine("Password Length must be atleast 8");
                            goto userlogin;
                        }

                        else
                        {
                            string customerdata = email + "," + Password;
                            using (FileStream fss = new FileStream(usercredentialsfile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                            {

                                using (StreamWriter sw = new StreamWriter(fss, Encoding.UTF8))
                                {
                                    sw.WriteLine(customerdata);

                                }

                            }

                        }

                    }

                    else if (loginorsignup == 'L')
                    {


                    signup:
                        Console.WriteLine("Enter your email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter your Password.Must be 8 characters or more");
                        string Password = Console.ReadLine();



                        string[] customerdata = { email + "," + Password };

                        string[] data = new string[20];



                        using (FileStream fs = new FileStream(usercredentialsfile, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {

                                for (int i = 0; i < data.Length; i++)
                                {
                                    data[i] = sr.ReadLine();
                                }
                                for (int i = 0; i < data.Length; i++)
                                {
                                    if (customerdata[0] == data[i])
                                    {
                                        Console.WriteLine("Login Successful!!!");
                                            
                                            customerloggedin = true;
                                            confirm = "No";


                                            break;
                                    }
                                     
                                    else

                                    {

                                        Console.WriteLine("Login Failed!! Please press Yes to try Again and No to Leave ");
                                        confirm = Console.ReadLine();
                                        goto signup;
                                    }

                                }
                            }

                        }

                    }

                    if (customerloggedin)
                    {
   

                            //---FORM FOR CUSTOMER---

                            Console.WriteLine("Please Fill the form!!\n");

                            Console.WriteLine("Enter your name");
                            string name = Console.ReadLine();


                            Console.WriteLine("Enter your age");
                            int age = Convert.ToInt32(Console.ReadLine());

                            if (age < 18 || age > 60)
                            {
                                Console.WriteLine("Your age must be between 18 to 60!!");
                                Console.WriteLine("Sorry we are taking you back!!...");
                                Thread t1 = Thread.CurrentThread;
                                Thread.Sleep(2000);
                                goto userlogin;
                            }

                            Console.WriteLine("Enter Your Address");
                            string address = Console.ReadLine();

                            string Useregistration = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\User Details.txt";
                            string[] userdata = { name + "," + age + "," + address };
                            using (FileStream fss = new FileStream(Useregistration, FileMode.Create, FileAccess.Write, FileShare.Write))
                            {

                                using (StreamWriter sw = new StreamWriter(fss, Encoding.UTF8))
                                {
                                    sw.WriteLine(userdata[0]);

                                }

                            }

                            //DISPLAY THE CARS TO CUSTOMERS

                            int i = 0;
                            Console.WriteLine(" =====================CARS===========================\n\n");

                            Console.WriteLine("Make  Model  Tax  Regsitration.no  Rent  Availibity \n\n");

                            string carfilepath = @"E:\\My Projects\\Simple Car Rental Management System(C# Console)\\Files\\Cars Details.txt";

                            using (FileStream fss = new FileStream(carfilepath, FileMode.OpenOrCreate, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fss))
                                {

                                    string cardata = "";
                                    while ((cardata = sr.ReadLine()) != null)
                                    {

                                        Console.WriteLine($"{i + 1}" + "." + cardata);
                                        carscount += 1;
                                        i += 1;


                                    }

                                }

                            }

                            Console.WriteLine("Thank You!!!");
                            Console.WriteLine("Enter Exit to exit");
                            string exit = Console.ReadLine();
                            if (exit == "Exit")
                            {
                                System.Environment.Exit(0);
                            }

                            Console.WriteLine("Press which Car you want to select");
                        int option = Convert.ToInt32(Console.ReadLine());

                        SelectCar(carscount, "", option);

                        Console.WriteLine("\n\n");



                        }


                    Console.ReadLine();
                }
            }
            while (confirm == "Yes");
            }
       
    }
}







