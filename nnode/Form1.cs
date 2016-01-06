using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        public struct treeNode1
        {
            public int data;
            private object _father;
            public treeNode1 father
            {
                get { return (treeNode1)_father; }
                set { _father = value; }
            }

            public object[] _children;
            public int maxLayer()
            {
                treeNode1 t = this;
                int i = 0;
                while (hasFNode(t))
                {
                    i++;
                    t = t.father;
                }
                return i;
            }

            private bool hasFNode(treeNode1 node)
            {
                return node.father.data != -100000;
            }

            public long calculateSelf() {
                long rtn = data;
                //Console.WriteLine(data);
                if (_children != null) {
                    foreach (object i in _children)
                    {
                        treeNode1 t = (treeNode1)i;
                        rtn += t.calculateSelf();
                    }
                }
                return rtn;
            }

            public long calculateSelf2()
            {
                
                long rtn = 0;
                //Console.WriteLine(data);
                if (father.data != -100000)
                {
                    foreach (object i in father._children)
                    {
                        treeNode1 t = (treeNode1)i;
                        Console.WriteLine(t.data);
                        rtn += t.data;
                    }
                }
                return rtn;
            }

        }  


        static long count;
        static treeNode1 lastNode;
        private void button1_Click(object sender, EventArgs e)
        {
            //Random rd = new Random();
            //long xd = 0;
            //for (int i = 0; i < 111111111; i++)
            //{
                
            //    int x = rd.Next(10000);
            //    //Console.WriteLine(i + "  " + x);
            //    xd += x;
            //}
            //Console.WriteLine(xd);


            count = 0;
            treeNode tmpNode = new treeNode();
            tmpNode.xvalue = 100000;

           

           generateChildNodes(tmpNode, new Random());

            //tmpNode.printself();
            Console.WriteLine("+++++++++++++++++=" + tmpNode.calculateSelf()) ;
        }

        private void generateChildNodes(treeNode tmpNode, Random rd) {
            count++;
            //Console.WriteLine(count);
            tmpNode.childNodeList = new List<treeNode>();
            for (int i = 0; i < 9; i++) {
                treeNode t = new treeNode();
                t.fNode = tmpNode;
                tmpNode.childNodeList.Add(t);
                t.xvalue = rd.Next(100);
            }
            int layer = Convert.ToInt16(textBox1.Text) - 1;
            if (layer < 0 ){
                layer = 7;
            }
            foreach (treeNode t in tmpNode.childNodeList ){
                
                if (t.maxLayer() < layer)
                {

                    generateChildNodes(t, rd);
                }
                else {
                    
                    break;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeNode1 tmpNode = new treeNode1();
            tmpNode.data = 100000;

            treeNode1 father = new treeNode1();
            father.data = -100000;
            tmpNode.father = father;

            int nodecount = Convert.ToInt16(textBox2.Text);
            int layer = Convert.ToInt16(textBox3.Text);

           generateChildNodesStruct(ref tmpNode, new Random(), nodecount, layer);

            Console.WriteLine("+++++++++++++++++=" + lastNode.calculateSelf());
        }

        private void generateChildNodesStruct(ref treeNode1 tmpNode, Random rd, int nodecount, int layer)
        {

           
            tmpNode._children = new object[nodecount];

            for (int i = 0; i < nodecount; i++)
            {
                treeNode1 t = new treeNode1();
                t.father = tmpNode;
                t.data = rd.Next(100);
                tmpNode._children[i] = t;
               
            }

            for(int i = 0; i < nodecount; i++)
            {
                treeNode1 t = (treeNode1)tmpNode._children[i];
                if (t.maxLayer() < layer)
                {
                    generateChildNodesStruct(ref t, rd, nodecount, layer);
                }
                else {
                    if (i == nodecount - 1)
                    {
                        lastNode = t;
                    }
                }
               
            }
            
        }

    }
}
