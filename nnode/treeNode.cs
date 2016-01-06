using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class treeNode
    {
        public treeNode fNode;
        public List<treeNode> childNodeList;
        public int xvalue;

        public int maxLayer() {
            treeNode t = this;
            int i = 0;
            while (hasFNode(t)) {
                i++;
                t = t.fNode;
            }
            return i;
        }

        private bool hasFNode(treeNode node)
        {
            return node.fNode != null;
        }

       

        public treeNode getFNode(treeNode t){
            if (hasFNode(t))
            {
                t = t.fNode;
                return getFNode(t);
            }
            else {
                return t;
            }
    }
        public long calculateSelf()
        {


            if (this.childNodeList != null)
            {
                long xcount = this.xvalue;
                foreach (treeNode t in this.childNodeList)
                {
                    xcount += t.calculateSelf();
                }
                return xcount;
            }
            else
            {

                return this.xvalue;
            }

        }

        //public long calculateSelf()
        //{


        //    if (this.childNodeList != null)
        //    {
        //        long xcount = 1;
        //        foreach (treeNode t in this.childNodeList)
        //        {
        //            xcount += t.calculateSelf();
        //        }
        //        return xcount;
        //    }
        //    else
        //    {

        //        return 1;
        //    }

        //}

        public void printself()
        {

            ////Console.WriteLine(this.xvalue);
            //if (this.childNodeList != null)
            //{
            //    Console.WriteLine(this.xvalue + "  " + this.childNodeList.Count + "  " + this.maxLayer());
            //    foreach (treeNode t in this.childNodeList)
            //    {
            //        t.printself();
            //    }
            //}
            //else
            //{

            //    Console.WriteLine(this.xvalue + "  0  " + "  " + this.maxLayer());
            //}

        }
    }
}
