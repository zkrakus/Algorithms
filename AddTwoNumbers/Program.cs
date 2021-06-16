using System;
using System.Collections.Generic;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head1 = new ListNode(1, new ListNode(2, new ListNode(3)));
            ListNode head2 = new ListNode(4, new ListNode(5, new ListNode(6)));

            ListNode head3 = head1.next.next;
            ListNode head4 = head2.next.next;

            AddTwoNumbersReverse(head1, head2);

            ListNode cur1 = head3;
            while (cur1 != null)
            {
                Console.WriteLine(cur1.val);
                cur1 = cur1.next;
            }

            ListNode cur2 = head4;
            while (cur2 != null)
            {
                Console.WriteLine(cur2.val);
                cur2 = cur2.next;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Algorith: 
        /// Iterate through the lists while neither list is at the end of the list. 
        /// Add the numbers as you iterate. Add 1 if carry is true.
        /// Keep track of carrying as you add. If you carry set carry to true and store only ones position of sum.
        /// Store the sum inside a new list node.
        /// Move to the next listnode in your list.
        /// Move to the next position of the two inputs.
        /// 
        /// When either list is finished iterating. Finish iterating through the other list while constructing the return list.
        /// Keep adding the carry if you overflow.
        /// After finishing iterating check for overflow one last time
        /// 
        /// Notes:
        /// The lists are in reverse order so you don't need to worry about leading zeros to align integer positions.
        /// Since you can't carry more than 1 when adding a bool is sufficient to represent the carry.
        /// Since you are dealing with a list you will need to keep track of the head and the current position as you iterate.
        /// 
        /// Anal: 
        /// 
        /// f(t) = O(max(m,n))
        /// f(s) = = max(m,n) + 1 = O(max(m,n))
        /// 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Handle constraints and arguments
            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;
            else if (l1 == null && l2 == null)
                return null;

            // Iterate through lists
            bool carry = false;
            ListNode sumListHead = null;
            ListNode sumList = null;
            while (l1 != null && l2 != null)
            {

                //Add the numbers as you iterate. 
                int sum = l1.val + l2.val;

                // Add 1 if carry is true.
                if (carry)
                    sum++;

                // Carry if overflow
                carry = (sum > 9) ? true : false;
                if (carry)
                    sum = (sum % 10) / 10;

                // Store the sum inside a new list node while keeping track of new list head;
                if (sumListHead != null)
                {
                    sumList.next = new ListNode(sum);
                    sumList = sumList.next;
                }
                else
                {
                    sumListHead = new ListNode(sum);
                    sumList = sumListHead;
                }

                // Increment position of lists
                l1 = l1.next;
                l2 = l2.next;
            }

            // Finish iterating through the other list while constructing the return list.
            while (l1 != null)
            {
                // Add carry
                int sum = l1.val;
                if (carry)
                    sum++;

                // Carry if overflow
                carry = (sum > 9) ? true : false;
                if (carry)
                    sum = (sum % 10);

                // Store sum inside new new list node
                sumList.next = new ListNode(sum);

                // Increment position of lists
                sumList = sumList.next;
                l1 = l1.next;
            }

            while (l2 != null)
            {
                // Add carry
                int sum = l2.val;
                if (carry)
                    sum++;

                // Carry if overflow
                carry = ((sum & 10) == 10) ? true : false;

                // Store sum inside new new list node
                sumList.next = new ListNode(sum);

                // Increment position of lists
                sumList = sumList.next;
                l2 = l2.next;
            }

            if (carry)
                sumList.next = new ListNode(1);

            return sumListHead;
        }
        public static ListNode AddTwoNumbersReverse(ListNode l1, ListNode l2)
        {
            l1 = listReverse(l1);
            l1 = listReverse(l2);

            return AddTwoNumbers(l1, l2);
        }

        /// <summary>
        /// Pseudocode: 
        /// Initialize head list node
        /// Initialize stack
        /// Loop through l1 list nodes where cur is the current node
        ///     Push l1.node to stack
        /// 
        /// Loop through stack by pop node
        ///     
        /// return 
        /// </summary>
        /// <param name="l1"></param>
        /// <returns></returns>
        public static ListNode listReverse(ListNode l1)
        {
            if (l1 == null)
                return null;
            else if (l1.next == null)
                return l1;

            Stack<ListNode> stack = listToStack(l1);

            ListNode head = stack.Pop();
            ListNode cur = head;
            while (stack.Count != 0)
            {
                cur.next = stack.Pop();
                cur = cur.next;
            }

            cur.next = null;

            return head;
        }

        public static Stack<ListNode> listToStack(ListNode l1)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            while (l1 != null)
            {
                ListNode cur = l1;
                stack.Push(cur);
                l1 = l1.next;
            }

            return stack;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
}
