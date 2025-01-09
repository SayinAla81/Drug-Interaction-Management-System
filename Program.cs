using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace project
{
    class node
    {
        public node left { get; set; }
        public node righ { get; set; }
        public string name { get; set; }
        public node()
        {
            name = null;
        }
    }
    class BT_Drug_Disaes
    {
        public node root { get; set; }
        public void insert(string x)
        {
            node before = null, after = this.root;
            while (after != null)
            {
                before = after;
                if (x.GetHashCode() < after.name.GetHashCode())
                    after = after.left;
                else
                    after = after.righ;
            }
            node now = new node();
            now.name = x;
            if (this.root == null)
                this.root = now;
            else
            {
                if (x.GetHashCode() > before.name.GetHashCode())
                    before.left = now;
                else
                    before.righ = now;
            }
        }
        public node delete(node now, string x)
        {
            if (now == null)
                return now;
            if (x.GetHashCode() < now.name.GetHashCode())
                now.left = delete(now.left, x);
            else if (x.GetHashCode() > now.name.GetHashCode())
                now.righ = delete(now.righ, x);
            else
            {
                if (now.left == null)
                    return now.righ;
                else if (now.righ == null)
                    return now.left;
                now.name = getmin(now.righ);
                now.righ = delete(now.righ, now.name);
            }
            return now;
        }
        public string getmin(node x)
        {
            string minx = x.name;
            while (x.left != null)
            {
                minx = x.left.name;
                x = x.left;
            }
            return minx;
        }
        public Boolean search(string x)
        {
            node temp = root;
            bool mark = false, iss = true;
            while (iss == true)
            {
                if ( temp!= null && string.Compare(temp.name, x) == 0)
                {
                    mark = true;
                    iss = false;
                }
                else if (temp != null && temp.name.GetHashCode() > x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp != null && temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    mark = false;
                    iss = false;
                }
            }
            if (mark == true)
                return true;
            else
                return false;
        }
        public void preorder(node x)
        {
            if (x != null)
            {
                Write(x.name + " ");
                preorder(x.left);
                preorder(x.righ);
            }
        }
        public void preorder_write(node x, int y)
        {
            if (x != null)
            {
                var path = "alergies.txt";
                string ans = "(Drug_";
                ans += x.name;
                if (y == 1)
                    ans += ",+) ; ";
                else
                    ans += ",-) ; ";
                File.WriteAllText(path, ans);
                preorder_write(x.left, y);
                preorder_write(x.righ, y);
            }
            
        }
    }
    class DRUG
    {
        public DRUG left { get; set; }
        public DRUG righ { get; set; }
        public string name { get; set; }
        public DRUG()
        {
            name = null;
        }
        public double price { get; set; }
        public BT_Drug_Disaes Destructive_drug = new BT_Drug_Disaes();
        public BT_Drug_Disaes positive = new BT_Drug_Disaes();
        public BT_Drug_Disaes negative = new BT_Drug_Disaes();
    }
    class DISEAS
    {
        public DISEAS left { get; set; }
        public DISEAS righ { get; set; }
        public string name { get; set; }
        public DISEAS()
        {
            name = null;
        }
        public BT_Drug_Disaes positive = new BT_Drug_Disaes();
        public BT_Drug_Disaes negative = new BT_Drug_Disaes();
    }
    class BinaryTree_Drug
    {
        public DRUG root { get; set; }
        public void insert(DRUG x)
        {
            DRUG before = null, after = this.root;
            while (after != null)
            {
                before = after;
                if (x.name.GetHashCode() < after.name.GetHashCode())
                    after = after.left;
                else
                    after = after.righ;
            }
            DRUG now = new DRUG();
            now.name = x.name;
            now.price = x.price;
            if (this.root == null)
                this.root = now;
            else
            {
                if (x.name.GetHashCode() <  before.name.GetHashCode())
                    before.left = now;
                else
                    before.righ = now;
            }
        }
        public void insert_drug(string x, string xx)
        {
            DRUG temp = root;
            bool iss = true;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    temp.Destructive_drug.insert(xx);
                    iss = false;
                }
                else if (temp.name.GetHashCode() > x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    iss = false;
                }
            }
        }
        public string getmin(DRUG x)
        {
            string minx = x.name;
            while (x.left != null)
            {
                minx = x.left.name;
                x = x.left;
            }
            return minx;
        }
        public DRUG delete(DRUG now, string x)
        {
            if (now == null)
                return now;
            if (x.GetHashCode() <  now.name.GetHashCode())
                now.left = delete(now.left, x);
            else if (x.GetHashCode() > now.name.GetHashCode())
                now.righ = delete(now.righ, x);
            else
            {
                if (now.left == null)
                    return now.righ;
                else if (now.righ == null)
                    return now.left;
                now.name = getmin(now.righ);
                now.righ = delete(now.righ, now.name);
            }
            return now;
        }
        public Boolean search(string x)
        {
            DRUG temp = root;
            bool mark = false, iss = true; 
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode()) 
                {
                    mark = true;
                    iss = false;
                }
                else if (temp.name.GetHashCode() >  x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    mark = false;
                    iss = false;
                }
            }
            if (mark == true)
                return true;
            else
                return false;
        }
        public double search_price(string x)
        {
            DRUG temp = root;
            bool iss = true;
            double mark = 0;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    mark = temp.price;
                    iss = false;
                }
                else if (temp.name.GetHashCode() > x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    iss = false;
                }
            }
            return mark;
        }
        public Boolean search_drug(string x, string xx)
        {
            DRUG temp = root;
            bool mark = false, iss = true;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    mark = temp.Destructive_drug.search(xx);
                    iss = false;
                }
                else if (temp.name.GetHashCode() >  x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() <  x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    mark = false;
                    iss = false;
                }
            }
            if (mark == true)
                return true;
            else
                return false;
        }
        public void increase_price(DRUG x, double rate)
        {
            if (x != null)
            {
                x.price += x.price * rate / 100;
                increase_price(x.left, rate);
                increase_price(x.righ, rate);
            }
        }
        public void preorder_delete(DRUG x, string xx)
        {
            if (x != null)
            {
                if (x.Destructive_drug.search(xx) == true)
                    x.Destructive_drug.delete(x.Destructive_drug.root, xx);
                preorder_delete(x.left, xx);
                preorder_delete(x.righ, xx);
            }
        }
        public DRUG preorder(DRUG x)
        {
            if (x != null)
            {
                var path = "drugs.txt";
                string ans = "Drug_";
                ans += x.name;
                ans += " : ";
                ans += x.price;
                File.WriteAllText(path, ans);
                preorder(x.left);
                preorder(x.righ);
            }
            return x;
        }
        public void print_effects(string x)
        {
            DRUG temp = root;
            bool iss = true, mark = false;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    WriteLine("Destructive Drugs : ");
                    temp.Destructive_drug.preorder(temp.Destructive_drug.root);
                    WriteLine("\n");
                    WriteLine("Positive Effect On The Disease : ");
                    temp.positive.preorder(temp.positive.root);
                    WriteLine("\n");
                    WriteLine("Negative Effect On The Disease : ");
                    temp.negative.preorder(temp.negative.root);
                    WriteLine("\n");
                    mark = true;
                    iss = false;
                }
                else if (temp.name.GetHashCode() > x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() <  x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
            }
            if (mark == false)
                WriteLine("Error");
        }
        public string travel_rand(DRUG now, int x, int y)
        {
            for (int i = 0; i < x && now.left != null; i++)
                now = now.left;
            for (int i = 0; i < y && now.righ != null; i++)
                now = now.righ;
            return now.name;
        }

    }
    class BinaryTree_DISEAS
    {
        public DISEAS root { get; set; }
        public void insert(DISEAS x)
        {
            DISEAS before = null, after = this.root;
            while (after != null)
            {
                before = after;
                if (x.name.GetHashCode() <  after.name.GetHashCode())
                    after = after.left;
                else
                    after = after.righ;
            }
            DISEAS now = new DISEAS();
            now.name = x.name;
            if (this.root == null)
                this.root = now;
            else
            {
                if (x.name.GetHashCode() <  before.name.GetHashCode())
                    before.left = now;
                else
                    before.righ = now;
            }
        }
        public void insert_drug(string x, string xx, int y)
        {
            DISEAS temp = root;
            bool iss = true;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    if (y == 0)
                        temp.negative.insert(xx);
                    else
                        temp.positive.insert(xx);
                    iss = false;
                }
                else if (temp.name.GetHashCode() > x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    iss = false;
                }
            }
        }
        public string getmin(DISEAS x)
        {
            string minx = x.name;
            while (x.left != null)
            {
                minx = x.left.name;
                x = x.left;
            }
            return minx;
        }
        public DISEAS delete(DISEAS now, string x)
        {
            if (now == null)
                return now;
            if (x.GetHashCode() <  now.name.GetHashCode())
                now.left = delete(now.left, x);
            else if (x.GetHashCode() > now.name.GetHashCode())
                now.righ = delete(now.righ, x);
            else
            {
                if (now.left == null)
                    return now.righ;
                else if (now.righ == null)
                    return now.left;
                now.name = getmin(now.righ);
                now.righ = delete(now.righ, now.name);
            }
            return now;
        }
        public Boolean search(string x)
        {
            DISEAS temp = root;
            bool mark = false, iss = true;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    mark = true;
                    iss = false;
                }
                else if (temp.name.GetHashCode() >  x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    mark = false;
                    iss = false;
                }
            }
            if (mark == true)
                return true;
            else
                return false;
        }
        public Boolean search_diseas(string x, string xx)
        {
            DISEAS temp = root;
            bool mark = false, iss = true;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    mark = temp.negative.search(xx);
                    iss = false;
                }
                else if (temp.name.GetHashCode() > x.GetHashCode() && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
                else
                {
                    mark = false;
                    iss = false;
                }
            }
            if (mark == true)
                return true;
            else
                return false;
        }
        public void preorder_delete(DISEAS x, string xx)
        {
            if (x != null)
            {
                if (x.positive.search(xx) == true)
                    x.positive.delete(x.positive.root, xx);
                if (x.negative.search(xx) == true)
                    x.negative.delete(x.negative.root, xx);
                preorder_delete(x.left, xx);
                preorder_delete(x.righ, xx);
            }
        }
        public void print_positive_drugs(string x)
        {
            DISEAS temp = root;
            bool mark = false, iss = true;
            while (iss == true)
            {
                if (temp.name.GetHashCode() == x.GetHashCode())
                {
                    WriteLine("Drugs Have Positive Effect On Disease : ");
                    temp.positive.preorder(temp.positive.root);
                    WriteLine("\n");
                    mark = true;
                    iss = false;
                }
                else if (temp.name.GetHashCode() >  x.GetHashCode()  && temp.left != null)
                    temp = temp.left;
                else if (temp.name.GetHashCode() < x.GetHashCode() && temp.righ != null)
                    temp = temp.righ;
            }
            if (mark == false)
                WriteLine("Error");
        }
        public DISEAS preorder(DISEAS x)
        {
            if (x != null)
            {
                var path = "sayin.txt";
                string ans = "Dis_";
                ans += x.name;
                File.WriteAllText(path, ans);
                preorder(x.left);
                preorder(x.righ);
            }
            return x;
        }
        public DISEAS preorder_drug(DISEAS x)
        {
            if (x != null)
            {
                var path = "D:\\sayin.txt";
                string ans = "Dis_";
                ans += x.name;
                ans += " : ";
                File.WriteAllText(path, ans);
                x.positive.preorder_write(x.positive.root, 1);
                x.negative.preorder_write(x.positive.root, 1);
                preorder_drug(x.left);
                preorder_drug(x.righ);
            }
            return x;
        }
        public string travel_rand(DISEAS now, int x, int y)
        {
            for (int i = 0; i < x && now.left != null; i++)
                now = now.left;
            for (int i = 0; i < y && now.righ != null; i++)
                now = now.righ;
            return now.name;
        }
    }
    class program
    {
        static Stopwatch sw = new Stopwatch();
        static List<List<string>> log = new List<List<string>>();
        static BinaryTree_DISEAS bt_diseas = new BinaryTree_DISEAS();
        static BinaryTree_Drug bt_drug = new BinaryTree_Drug();
        public void show_tasks()
        {
            sw.Start();
            WriteLine("Memory :  " + GC.GetTotalMemory(true));
            WriteLine("Time :  " + sw.Elapsed.TotalMilliseconds / 1000);
            sw.Reset();
            Write("\t -------------------------------------------------------- \n");
            Write("\t|                                                        |\n");
            Write("\t|                                                        |\n");
            Write("\t|                        TASKS                           |\n");
            Write("\t|                                                        |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   1-       Read Information From The Files             |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   2-      Drug Interactions In Drug Prescription       |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   3-    Drug Allergies In Prescription With Patients   |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   4-       Invoice Price Of Prescription Drugs         |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   5-         Increase Prices Of All Drugs              |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   6-       Add Information In Data Structure           |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   7-     Delete Information In Data Structure          |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   8-          Searching In Data Structure              |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   9-                     Log                           |\n");
            Write("\t|                                                        |\n");
            Write("\t|--------------------------------------------------------|\n");
            Write("\t|                                                        |\n");
            Write("\t|   10-                    Exit                          |\n");
            Write("\t|                                                        |\n");
            Write("\t -------------------------------------------------------- \n");
            WriteLine("\n\n\t\tEnter The Task You Want :  ");
        }
        public void User_Input()
        {
            DRUG drug = new DRUG();
            DISEAS diseas = new DISEAS();
            program doo = new program();
            int user_input;
            do
            {
                doo.show_tasks();
                user_input = int.Parse(ReadLine());
                Console.Clear();
                switch (user_input)
                {
                    case 1:
                        doo.Read_Information();
                        break;
                    case 2:
                        doo.Drug_interactions();
                        break;
                    case 3:
                        doo.Drug_Diseas_Allergies();
                        break;
                    case 4:
                        doo.Drug_Price();
                        break;
                    case 5:
                        doo.Increase_Drug_Price();
                        break;
                    case 6:
                        doo.insert();
                        break;
                    case 7:
                        doo.delete();
                        break;
                    case 8:
                        doo.Searching();
                        break;
                    case 9:
                        doo.Log();
                        break;
                    case 10:
                        break;
                    default:
                        WriteLine("Error");
                        break;
                }
                sw.Stop();
                Console.Clear();
            } while (user_input != 10);
        }
        public List<string> Drug_list()
        {
            List<string> ans = new List<string>();
            char mark = 'Y';
            do
            {
                Write("Do You Want To Add Drug(Y/N) :  ");
                mark = ReadLine()[0];
                if (mark == 'Y')
                {
                    WriteLine("Enter The Name Of Drug");
                    string give = ReadLine();
                    if (bt_drug.search(give) == true)
                        ans.Add(give);
                    else
                        WriteLine("The Name is Invalid !!!");
                }
            } while (mark == 'Y');
            return ans;
        }
        public List<string> Diseas_list()
        {
            List<string> ans = new List<string>();
            char mark = 'Y';
            do
            {
                Write("Do You Want To Add Diseas(Y/N) :  ");
                mark = ReadLine()[0];
                if (mark == 'Y')
                {
                    WriteLine("Enter The Name Of Diseas");
                    string give = ReadLine();
                    if (bt_diseas.search(give) == true)
                        ans.Add(give);
                    else
                        WriteLine("The Name is Invalid !!!");
                }
            } while (mark == 'Y');
            return ans;
        }
        public void Read_Information()
        {
            List<string> log2 = new List<string>();
            log2.Add("Read Information From The Files");
            log.Add(log2);
            try
            {
                string[] line = File.ReadAllLines(".\\drugs.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    DRUG drug_new = new DRUG();
                    string[] ss = line[i].Split(' ');
                    string[] ss2 = ss[0].Split('_');
                    drug_new.name = ss2[1];
                    drug_new.price = Convert.ToInt32(ss[2]);
                    bt_drug.insert(drug_new);
                }
            }
            catch { }
            try
            {
                string[] line = File.ReadAllLines(".\\diseases.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    DISEAS diseas_new = new DISEAS();
                    string[] ss = line[i].Split('_');
                    diseas_new.name = ss[1];
                    bt_diseas.insert(diseas_new);
                }
            }
            catch { }
            try
            {
                string[] line = File.ReadAllLines(".\\alergies.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    string[] ss = line[i].Split(' ');
                    string[] ss2 = ss[0].Split('_');
                    for (int j = 2; j < ss.Length; j++)
                    {
                        if (ss[j].Length != 1)
                        {
                            string[] ss3 = ss[j].Split('(', ',', ')', '_');
                            int sign = 1;
                            if (ss3[3] == "-")
                                sign = 0;
                            bt_diseas.insert_drug(ss2[1], ss3[2], sign);
                        }
                    }
                }
            }
            catch { }
            try
            {
                string[] line = File.ReadAllLines(".\\effects.txt");
                for (int i = 0; i < line.Length; i++)
                {
                    string[] ss = line[i].Split(' ');
                    string[] ss2 = ss[0].Split('_');
                    DRUG drug_new = new DRUG();
                    for (int j = 2; j < ss.Length; j++)
                        if (ss[j].Length != 1)
                        {
                            string[] ss3 = ss[j].Split('(', ',', ')', '_');
                            bt_drug.insert_drug(ss2[1], ss3[2]);
                        }
                }
            }
            catch { }
            WriteLine("Done");
            ReadLine();
        }
        public void Drug_interactions()
        {
            List<string> log2 = new List<string>();
            log2.Add("Drug Interactions In Drug Prescription");
            program doo = new program();
            List<string> give = doo.Drug_list();
            bool mark = true;
            for (int i = 0; i < give.Count; i++)
            {
                log2.Add(give[i]);
                for (int j = 0; j < i; j++)
                {
                    if (bt_drug.search_drug(give[i], give[j]) == true)
                    {
                        mark = false;
                        WriteLine(give[i] + "    " + give[j]);
                    }
                }
            }
            if (mark == true)
                WriteLine("There were found no interactions between the two drugs");
            log.Add(log2);
            ReadLine();
        }
        public void Drug_Diseas_Allergies()
        {
            program doo = new program();
            List<string> log2 = new List<string>();
            log2.Add("Drug Allergies In Prescription With Patients");
            List<string> give_drug = doo.Drug_list();
            List<string> give_diseas = doo.Diseas_list();
            bool mark = true;
            for (int i = 0; i < give_drug.Count; i++)
            {
                log2.Add(give_drug[i]);
                for (int j = 0; j < give_diseas.Count; j++)
                {
                    if (bt_diseas.search_diseas(give_diseas[j], give_drug[i]) == true)
                    {
                        mark = false;
                        WriteLine(give_drug[i] + "    " + give_diseas[j]);
                    }
                }
            }
            for (int i = 0; i < give_diseas.Count; i++)
                log2.Add(give_diseas[i]);
            log.Add(log2);
            if (mark == true)
                WriteLine("There Were Found No Allergic For Drugs And Diseas");
            ReadLine();
        }
        public void Drug_Price()
        {
            double sum = 0;
            program doo = new program();
            List<string> log2 = new List<string>();
            log2.Add("Invoice Price Of Prescription Drugs");
            List<string> give = doo.Drug_list();
            for (int i = 0; i < give.Count; i++)
            {
                log2.Add(give[i]);
                sum += bt_drug.search_price(give[i]);
            }
            log.Add(log2);
            WriteLine("The Total Price Is :  " + sum);
            ReadLine();
        }
        public void Increase_Drug_Price()
        {
            List<string> log2 = new List<string>();
            log2.Add("Increase Prices Of All Drugs");
            log.Add(log2);
            WriteLine("Enter The Inflation Rate Value");
            double rate = double.Parse(ReadLine());
            bt_drug.increase_price(bt_drug.root, rate);
            WriteLine("Done");
            ReadLine();
        }
        public void insert()
        {
            WriteLine("You Want TO Creat Drug(1) Or Diseas(2) : ");
            int gett = int.Parse(ReadLine());
            Random rand = new Random();
            List<string> log2 = new List<string>();
            log2.Add("Add Information In Data Structure");
            if (gett == 1)
            {
                DRUG now = new DRUG();
                WriteLine("Enter The Name Of Drug : ");
                now.name = ReadLine();
                log2.Add(now.name);
                WriteLine("Enter The Price Of Drug : ");
                now.price = double.Parse(ReadLine());
                log2.Add(Convert.ToString(now.price));
                for (int i = 0; i < rand.Next(0, 3); i++)
                {
                    bt_drug.insert_drug(now.name, bt_drug.travel_rand(bt_drug.root, rand.Next(0, 4), rand.Next(0, 4)));
                    bt_diseas.insert_drug(now.name, bt_diseas.travel_rand(bt_diseas.root, rand.Next(0, 4), rand.Next(0, 4)), rand.Next(0, 2));
                }
                bt_drug.insert(now);
            }
            else
            {
                DISEAS now = new DISEAS();
                WriteLine("Enter The Name Of Diseas : ");
                now.name = ReadLine();
                log2.Add(now.name);
                for (int i = 0; i < rand.Next(0, 3); i++)
                {
                    bt_diseas.insert_drug(now.name, bt_drug.travel_rand(bt_drug.root, rand.Next(0, 4), rand.Next(0, 4)), 0);
                    bt_diseas.insert_drug(now.name, bt_drug.travel_rand(bt_drug.root, rand.Next(0, 4), rand.Next(0, 4)), 1);
                }
                bt_diseas.insert(now);
            }
            log.Add(log2);
            ReadLine();
        }
        public void delete()
        {
            WriteLine("Enter The Name Of Drug\\Diseas : ");
            List<string> log2 = new List<string>();
            log2.Add("Delete Information In Data Structure");
            string give = ReadLine();
            log2.Add(give);
            if (bt_drug.search(give) == true)
            {
                bt_drug.preorder_delete(bt_drug.root, give);
                bt_drug.delete(bt_drug.root, give);

            }
            else if (bt_diseas.search(give) == true)
            {
                bt_diseas.preorder_delete(bt_diseas.root, give);
                bt_diseas.delete(bt_diseas.root, give);
            }
            else
                WriteLine("The Name is Invalid !!!");
            log.Add(log2);
            ReadLine();
        }
        public void Searching()
        {
            List<string> log2 = new List<string>();
            log2.Add("Searching In Data Structure");
            WriteLine("Enter The Name Of Drug/ Diseas :  ");
            string name = ReadLine();
            log2.Add(name);
            WriteLine("\n\n");
            if (bt_diseas.search(name) == true)
                bt_diseas.print_positive_drugs(name);
            else if (bt_drug.search(name) == true)
                bt_drug.print_effects(name);
            else
                WriteLine("The Name is Invalid !!!");
            log.Add(log2);
            ReadLine();
        }
        public void Log()
        {
            List<string> log2 = new List<string>();
            log2.Add("Log");
            log.Add(log2);
            for (int i = 0; i < log.Count; i++)
            {
                WriteLine("****  " + log[i][0] + "  *****");
                for (int j = 1; j < log[i].Count; j++)
                    WriteLine(log[i][j]);
                WriteLine();
            }
            ReadLine();
        }
        static void Main()
        {
            program doo = new program();
            doo.User_Input();
            bt_drug.preorder(bt_drug.root);
            bt_diseas.preorder(bt_diseas.root);
            bt_diseas.preorder_drug(bt_diseas.root); 

            /*TextWriter diseases_write = new StreamWriter(".\\diseases.txt");
            TextWriter alergies_write = new StreamWriter(".\\alergies.txt");
            TextWriter drugs_write = new StreamWriter(".\\drugs.txt");
            TextWriter effects_write = new StreamWriter(".\\effects.txt");*/
        }
    }
}
