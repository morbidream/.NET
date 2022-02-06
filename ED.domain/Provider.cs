﻿using System;

namespace ED.domain
{
    public class Provider
    {
        public static int count;
        public string confirmPassword;
        public string password;

        public Provider()
        {
            count++;
        }
        public int Id
        {
            // set{ id = value; }
            // get{ return id; }

            set;
            get;
        }
        public string Nom
        {
            set;
            get;

        }
        public string Password
        {
            set
            {
                if (value.Length < 5 || value.Length > 20)
                    Console.WriteLine("longueur");
                else
                    password = value;
            }
            get { return password; }

        }
        public string ConfirmPassword
        {
            set
            {
                if (value == Password)
                { confirmPassword = value;
                    System.Console.WriteLine("passwords match");
                }
                else
                { System.Console.WriteLine("passwords don't match"); }
            }
            get { return confirmPassword; }
        }
        public string Email
        {
            set;
            get;
        }
        public Boolean IsApproved
        {
            set;
            get;
        }
        public override string ToString()
        {
            //return base.ToString();
            return $"id= {Id}, name= {Nom}, email= {Email}";
        }

        //************************************

        public bool Login(string nom, string password, string email = null)
        {
           if(email != null)  return nom == Nom && password == Password && email==Email  ;
            else return nom == Nom && password == Password;
        }
        //*****************************************
        /*public static void SetIsApproved(Provider provider)
        {
                provider.IsApproved = provider.Password == provider.ConfirmPassword;          }
        }*/
        public static void SetIsApproved(string confirmPassword, string password, out bool isApproved) // ref/out
        {
            isApproved = password == confirmPassword;
        }

    }
}
