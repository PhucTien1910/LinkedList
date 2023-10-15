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
            MyList evenlist = new MyList(); //khởi tạo 1 MyList(danh sách) rỗng
            IntNode p = first;

            while(p != null)
            {
                if(p.Data % 2 == 0) //nếu p chia hết cho 2
                    evenlist.AddFirst(new IntNode(p.Data)); //thêm một node mới vào đầu danh sách(số chẵn)
                p = p.Next;
            }
            return evenlist; //trả về danh sách số chẵn
        }

        //Trả về danh sách chỉ chứa số lẻ
        public MyList GetOddList()
        {
            MyList oddlist = new MyList(); //khởi tạo 1 MyList(danh sách) rỗng
            IntNode p = first;

            while(p != null)
            {
                if (p.Data % 2 != 0) //nếu p không chia hết cho 2
                    oddlist.AddFirst(new IntNode(p.Data)); //thêm một node mới vào đầu danh sách (số lẻ)
                p = p.Next;
            }
            return oddlist; //trả về danh sách số lẻ
        }

        //VD:
        //5 -> 3 -> 7 -> 9
        //1. Đi tìm xem có node đó không? 
        //2. Chỉnh Next của node trước thành node sau node cần xóa

        //1.Xóa node đầu
        public void DeleteFirst()
        {
            if (IsEmpty())
            {
                return;
            }
            //5 -> 3 -> 7 -> 9
            //create node cần xóa 
            IntNode pDel = first;
            //Cập nhật lại FIRST là node sau của node hiện tại
            first = pDel.Next;

            //TH danh sách chỉ có 1 phần tử (VD: 5)
            if(first == null)
            {
                last = null;
            }
            pDel = null;
        }
        //2.Xóa node cuối
        public void DeleteLast()
        {
            //5 -> 3 -> 7 -> 9
            IntNode pDel = last;
            //2. Chỉnh Next của node trước(pTruoc) thành node sau node cần XÓA(pDel) (VD: xóa 9 => ... -> 7 -> null)
            IntNode pTruoc = SearchPrevious(pDel);
            if(pTruoc == null)
            {
                first = last = null;    
            }
            else
            {
                //chỉnh next của node trước là null
                pTruoc.Next = null;
                //cập nhật lại giá trị last
                last = pTruoc;
            }
            pDel = null;
        }
        //3.Xóa node ở vị trí bất kì
        public void RemoveX(int x) //truyền vào giá trị cần xóa
        {           
            //1. Đi tìm xem có node đó không? 
            IntNode pDel = SearchX(x);
            //Node đầu
            if (pDel == first)
            {
                DeleteFirst();
                return;
            }
            //Node cuối
            if (pDel == last)
            {
                DeleteLast();
                return;
            }
            //2. Chỉnh Next của node trước thành node sau node cần xóa
            //5 -> 3 -> 7 -> 9
            //5 -> 3 -> 9
            IntNode pTruoc = SearchPrevious(pDel);
            pTruoc.Next = pDel.Next;
            pDel = null;
        }

        //Tìm node TRƯỚC(pPrev) của node cần XÓA(p) 
        public IntNode SearchPrevious(IntNode p)//7
        {
            if(IsEmpty())
            {
                return null;
            }
            if(p==first)
            {
                return null;
            }
            //5 -> 3 -> 7 -> 9
            //VD xóa node 7: 5 -> 3 -> 9
            IntNode pPrev = first; //đặt con trỏ đến node đầu tiên
            while (pPrev.Next != p) 
            {
                pPrev = pPrev.Next; //di chuyển đến node tiếp theo và tiếp tục xét 
            }
            return pPrev; 
        }        
      
        //hàm thêm vào sau node p 
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
        //hàm hoán vị và thêm vào trước node p
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

        //chèn X vào sau node có giá trị nhỏ nhất
        public void InsertAfterMin(int min)
        {           
            IntNode pMin = GetMin();
            IntNode pNew = new IntNode(min);
            InsertAfterP(pMin, pNew);
        }
       
        //chèn X vào sau Y
        public void InsertXAfterY(int x, int y)
        {
            //5 -> 3 -> 7 -> 9
            //chèn giá trị x = 10 vào sau y = 7
            //5 -> 3 -> 7 -> (10) -> 9
            IntNode pX = new IntNode(x);
            IntNode p = first;
            while (p != null)
            {
                if(p.Data == y)
                {
                    InsertAfterP(p, pX);
                    return;                   
                }
                p = p.Next;
            }
            Console.WriteLine("Khong tim thay node co gia tri y !");
        }
        
        //chèn x vào trước node có giá trị lớn nhất
        public void InsertBeforeMax(int max)
        {
            IntNode pMax = GetMax();
            IntNode pNew = new IntNode(max);
            InsertBeforeP(pMax, pNew);
        }

        //chèn X vào trước Y
        public void InsertXBeforeY(int x, int y)
        {
            //5 -> 3 -> 7 -> 9
            //chèn giá trị x = 10 vào trước y = 7
            //5 -> 3 -> (10) -> 7 -> 9
            IntNode pX = new IntNode(x);
            IntNode p = first;
            while (p != null)
            {
                if (p.Data == y)
                {
                    InsertAfterP(p, pX);
                    HoanVi(p, pX);
                    return;
                }
                p = p.Next;
            }
            Console.WriteLine("Khong tim thay node co gia tri y !");
        }

        //hàm dịch chuyển xoay vòng (RShiftRight)
        public void RShiftRight()
        {
            if(IsEmpty() || Count == 1)
            {
                return; //Danh sách rỗng hoặc chỉ có 1 phần tử thì không dịch
            }

            last.Next = first; //Node cuối trỏ đến node đầu
            first = last; //Node đầu trở thành node cuối
            IntNode p = first;

            while (p.Next != last)
            {
                p = p.Next;
            }
            last = p;
            last.Next = null;
        }

        //phương thức sắp xếp theo thứ tự tăng dần(InterchangeSort)
        public void InterchangeSort()
        {
            IntNode p = first;

            while(p != null) //lặp qua toàn bộ danh sách
            {
                IntNode min = p; //giả sử node p là node có giá trị nhỏ nhất 
                IntNode compare = p.Next; //bắt đầu so sánh với các node tiếp theo

                while (compare != null) 
                {
                    if(compare.Data < min.Data) //so sánh GIÁ TRỊ của node so sánh(compare) với GIÁ TRỊ node nhỏ nhất(min)
                    {
                        min = compare; //cập nhật thành node nhỏ nhất
                    }
                    compare = compare.Next;
                }

                //Đổi chỗ giữa p và min(hoán đổi GIÁ TRỊ 2 node)
                int temp = p.Data;
                p.Data = min.Data;
                min.Data = temp;    

                p = p.Next; //di chuyển đến node tiếp theo để tiếp tục sắp xếp
            }
        }

        //phương thức sắp xếp danh sách theo thứ tự giảm dần(SelectionSort)
        public void SelectionSort()
        {
            IntNode p = first;

            while(p != null)
            {
                IntNode max = p; //giả sử node hiện tại là node có giá trị nhỏ nhất
                IntNode compare = p.Next; //bắt đầu so sánh với các node tiếp theo 

                while (compare != null)
                {
                    if(compare.Data > max.Data) //so sánh GIÁ TRỊ của node so sánh(compare) với GIÁ TRỊ node lớn nhất(max)
                    {
                        max = compare;
                    }
                    compare= compare.Next;
                }

                //Đổi chỗ giữa p và max(hoán đổi GIÁ TRỊ 2 node)
                int temp = p.Data;
                p.Data = max.Data;
                max.Data = temp;

                p = p.Next; //di chuyển đến node tiếp theo để tiếp tục sắp xếp
            }
        }
    }
}
