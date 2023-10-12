using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class MyList 
    {
        //Thuộc tính
        private IntNode first; //nút đầu tiên trong danh sách
        private IntNode last; //nút cuối cùng trong danh sách                       

        //get, set để truy cập nút đầu và nút cuối
        public IntNode First
        {
            get { return first; }
            set { first = value; }
        }
        public IntNode Last
        {
            get { return last; }
            set { last = value; }
        }

        //khởi tạo danh sách liên kết rỗng
        public MyList()
        {
            first = null;
            last = null;
        }

        //Số phần tử trong mảng
        public int Count
        {
            get
            {
                int count = 0;
                IntNode p = first;

                while (p != null)
                {
                    count++;
                    p = p.Next;
                }
                return count;
            }
        }

        //kiểm tra xem có rỗng hay không?
        public bool IsEmpty()
        {
            return first == null;
        }

        //thêm một node mới vào đầu danh sách
        public void AddFirst(IntNode newNode)
        {
            if (IsEmpty())
            {
                first = last = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }
        }

        //thêm một node mới vào cuối danh sách
        public void AddLast(IntNode newNode)
        {
            if(IsEmpty())
                first = last = newNode;
            else
                last.Next = newNode;
                last = newNode;
        }

        //nhập dữ liệu của người dùng và thêm vào đầu danh sách
        public void Input()
        {
            int x;
            do
            {
                Console.Write("Gia tri (0 ket thuc): ");
                int.TryParse(Console.ReadLine(), out x);
                if (x == 0)
                {
                    return; //kết thúc nhập liệu nếu người dùng nhập 0
                }
                IntNode newNode = new IntNode(x); //tạo một đối tượng IntNode mới
                AddFirst(newNode);
                //AddLast(newNode);
            } while (true);
        }

        //hiển thị danh sách liên kết ra màn hình
        public void ShowList()
        {
            IntNode p = first; //tạo biến p và gán bằng với nút đầu danh sách(tức là p = first)                      
            while (p != null)
            {
                Console.Write(p.Data + " -> ");
                p = p.Next;
            }
            Console.WriteLine("null");
        }

        public void ShowList1()
        {
            IntNode p = first;
            while(p != null)
            {
                Console.Write(p.Data + " -> ");
                p = p.Next;
            }
            Console.WriteLine("null");
        }
        //Trả về node có giá trị X
        public IntNode SearchX(int x)
        {
            IntNode p = first;
            while(p != null)
            {
                if(p.Data == x)
                    return p;
                p = p.Next;
            }
            return null;
        }

        //Trả về node có giá trị lớn nhất
        public IntNode GetMax()
        {
            if (IsEmpty())
            {
                return null;
            }

            IntNode maxNode = first;
            IntNode p = first;     
            
            while (p != null)
            {
                if(p.Data > maxNode.Data)
                    maxNode = p; //cập nhật maxNode = p
                p = p.Next;
            }
            return maxNode;
        }

        //Trả về node có giá trị nhỏ nhất
        public IntNode GetMin()
        {
            if (IsEmpty())
            {
                return null;
            }

            IntNode minNode = first;
            IntNode p = first;

            while (p != null)
            {
                if(p.Data < minNode.Data)
                    minNode = p;
                p = p.Next;
            }
            return minNode;
        }

        //Trả về danh sách chỉ chứa số chẵn
        public MyList GetEvenList()
        {
            MyList evenlist = new MyList();
            IntNode p = first;

            while(p != null)
            {
                if(p.Data % 2 == 0)
                    evenlist.AddFirst(new IntNode(p.Data));
                p = p.Next;
            }
            return evenlist;
        }

        //Trả về danh sách chỉ chứa số lẻ
        public MyList GetOddList()
        {
            MyList oddlist = new MyList();
            IntNode p = first;

            while(p != null)
            {
                if (p.Data % 2 != 0)
                    oddlist.AddFirst(new IntNode(p.Data));
                p = p.Next;
            }
            return oddlist;
        }

        //chèn x vào sau node có giá trị nhỏ nhất
        public void InsertAfterP(IntNode p, IntNode pNew)
        {
            if(p == last)
                AddLast(pNew);
            else
            {
                pNew.Next = p.Next;
                p.Next = pNew;
            }
        }
        public void InsertAfterMin(int min)
        {           
            IntNode pMin = GetMin();
            IntNode pNew = new IntNode(min);
            InsertAfterP(pMin, pNew);
        }

        //chèn x vào trước node có giá trị lớn nhất
        public void HoanVi(IntNode a, IntNode b) 
        {
            int temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;
        }
        public void InsertBeforeP(IntNode p, IntNode pNew)
        {
            InsertAfterP(p, pNew);
            HoanVi(p, pNew);
        }
        public void InsertBeforeMax(int max)
        {
            IntNode pMax = GetMax();
            IntNode pNew = new IntNode(max);
            InsertBeforeP(pMax, pNew);
        }



    }
}
