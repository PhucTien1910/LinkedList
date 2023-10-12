using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class Program
    {
        static void TestInput()
        {
            MyList list = new MyList();
            list.Input();
            Console.WriteLine("DSLK so nguyen: ");
            list.ShowList();
            //list.ShowList1();
            int sophantu = list.Count;
            Console.WriteLine("So luong phan tu trong danh sach la: " + sophantu);

            Console.Write("Tim gia tri: ");
            int searchValue = int.Parse(Console.ReadLine());            
            IntNode resultNode = list.SearchX(searchValue);
            if(resultNode != null)
            {
                Console.WriteLine("Da tim thay duoc node co gia tri X can tim la " + resultNode.Data + " trong danh sach");
            }
            else
            {
                Console.WriteLine("Khong tim thay gia tri " + searchValue);
            }

            Console.WriteLine("Gia tri lon nhat la: " + list.GetMax().Data);
            Console.WriteLine("Gia tri nho nhat la: " + list.GetMin().Data);

            MyList evenlist = list.GetEvenList();
            Console.WriteLine("DSLK so chan: ");
            evenlist.ShowList();

            MyList oddlist = list.GetOddList();
            Console.WriteLine("DSLK so le: ");
            oddlist.ShowList();

            int min;
            Console.Write("Nhap gia tri can chen: ");
            int.TryParse(Console.ReadLine(), out min);
            list.InsertAfterMin(min);
            Console.WriteLine("DSLK sau khi chen la: ");
            list.ShowList();

            int max;
            Console.Write("Nhap gia tri can chen: ");
            int.TryParse(Console.ReadLine(), out max);
            list.InsertBeforeMax(max);
            Console.WriteLine("DSLK sau khi chen la: ");
            list.ShowList();
        }
        static void Main(string[] args)
        {
            TestInput();       
            Console.ReadKey();
        }
    }
}
