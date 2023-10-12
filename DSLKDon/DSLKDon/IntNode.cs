using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class IntNode
    {
        //thuộc tính
        private int data; //dữ liệu của node
        private IntNode next; //node kế tiếp

        //get, set để truy cập vào dữ liệu của node kế tiếp
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public IntNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public IntNode(int x = 0)
        {
            data = x;
            next = null;
        }
    }
}
