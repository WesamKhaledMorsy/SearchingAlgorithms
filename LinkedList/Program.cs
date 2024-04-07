using System;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Linq;

namespace SearchingAlgorithms
{

    class SearchingAlgorithms_LinkedList
    {
        public sealed class DLinkedListNode<T>
        {
            public DLinkedListNode() { }
            public DLinkedListNode(T value)
            {
                node_data=value;
            }
            private T node_data;
            public DLinkedListNode<T> Next_node { get; internal set; } = null;
            public DLinkedListNode<T> Previous_node { get; internal set; } = null;
            public DLinkedListNode<T> List { get; internal set; } = null;
            public DLinkedListNode(T value, DLinkedListNode<T> next_elem, DLinkedListNode<T> previous_elem)
            {
                node_data=value;
                Next_node=next_elem;
                Previous_node=previous_elem;
            }

            public T get_node_data() 
            { 
                return node_data;
            }
            
            public DLinkedListNode<T> get_next_node()
            {
                return Next_node;
            }
            public DLinkedListNode<T> get_previous_node()
            {
                return Previous_node;
            }
            public void set_node_data(T value)
            {
                node_data=value;
            }
            public void set_next_node(DLinkedListNode<T> node)
            {
                Next_node = node;
            }
            public void set_previous_node(DLinkedListNode<T> node)
            {
                Previous_node= node;
            }


            internal void Invalidate () { }
        }
        public class DoubleLinkedList<T>
        {
            private int size_of_list;
            private readonly List<DLinkedListNode<T>> list_data;

            public DoubleLinkedList() 
            { 
                size_of_list=0;
                list_data = new List<DLinkedListNode<T>>();
                head = null;
                tail = null;
            }
            public DoubleLinkedList(IEnumerable<T> collection) 
            {
                
            }
            public DLinkedListNode<T> head { get; protected set; }
            public DLinkedListNode<T> tail { get; protected set; }
            public int Count { get; protected set; } = 0;
            public int Size()
            {
                return size_of_list;
            }
            public bool isEmpty()
            {
                if(Size() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public T PeekHead()
            {
                if (!isEmpty())
                {
                    return head.get_node_data();
                }
                else
                {
                    throw new Exception("Cannot peek head, Stack is Empty");
                }
            }
            public T PeekTail()
            {
                if (!isEmpty())
                {
                    return tail.get_node_data();
                }
                else
                {
                    throw new Exception("Cannot peek tail, Stack is Empty");
                }
            }

            //public DLinkedListNode<T> AddFirst(T value) { }
            /* // this method or AddFirst method
             *   public void PushStart(T item)
                {
                    ++size_of_list;
                    list_data.Add(new DoubleNode<T>(item, head, null));
                    head = list_data[size_of_list - 1];
                }
             */
            public void AddFirst (DLinkedListNode<T> node) 
            { 
                // Add the new node at the start of the LinkedList<T>
                if(head == null)
                {
                    node.Next_node=null;
                    node.Previous_node =null;                    
                    ++ size_of_list;
                    head = tail = node;
                }
                else
                {
                    // Case of existing list nodes -> Prepend Node.
                    head.Previous_node = node;
                    node.Next_node=head;
                    node.Previous_node = null;
                    ++size_of_list;
                    head = node;
                }
                //node.List = this;
                Count++;
            }
            //public DLinkedListNode<T> AddLast(T value) { }
            //** this methods to add last node or the next method  *//
            //public void AddLast(T node) 
            //{ 
            //    if(head == null)
            //    {
            //        list_data.Add(new DLinkedListNode<T>(node, null, null));
            //        ++size_of_list;
            //        head = tail = list_data[0];
            //    }
            //    else
            //    {
            //        list_data.Add(new DLinkedListNode<T>(node, null, list_data[size_of_list-1]));
            //        ++size_of_list;
            //        tail.set_next_node(list_data[size_of_list-1]);
            //        tail = list_data[size_of_list - 1];
            //    }
            //}

            public void AddLast(DLinkedListNode<T> node)
            {
                // Add the new node to the end of the LinkedList<T>.
                if (head == null)
                {
                    // Case of empty list -> Add the first node.
                    node.Next_node = node.Previous_node = null;
                    ++size_of_list;
                    head = tail =node;
                }
                else
                {
                    // case of existing list nodes -> Append Node.
                    tail.Next_node=node;
                    node.Previous_node = tail;
                    node.Next_node=null;
                    ++size_of_list;
                    tail= node;
                }
            }
            //public DLinkedListNode<T> AddAfter(DLinkedListNode<T> node,T value) { }
            public void Clear() 
            {
                size_of_list =0;
                list_data.Clear();
                head = tail = null;
            }
            public void AddAfter(DLinkedListNode<T> node, DLinkedListNode<T> newNode) 
            { 
                if(!isEmpty())
                {
                    // Insert the new node after the specified node
                    if (node.Next_node== null)
                    {
                        // Case of single last node -> Append the new node.
                        AddLast( newNode);
                    }
                    else
                    {
                        // Case of intermediate node -> Insert the new node.         
                        DLinkedListNode<T> temp = node.Next_node;
                        ++ size_of_list;
                        node.Next_node = newNode;
                        newNode.Previous_node = node;
                        newNode.Next_node = temp;
                        temp.Previous_node= newNode;
                    }
                    Count++;
                }
                else
                {
                    throw new Exception("Cannot add new node ,Stack is Empty");
                }
            }
            //public DLinkedListNode<T> AddBefore(DLinkedListNode<T> node, T value) { }
            public void AddBefore(DLinkedListNode<T> node, DLinkedListNode<T> newNode)
            { 
                if(node.Previous_node == null)
                {
                    AddFirst(newNode);
                }
                else
                {
                    DLinkedListNode<T> temp = node.Previous_node;
                    ++ size_of_list;
                    node.Previous_node = newNode;
                    newNode.Next_node= node;
                    newNode.Previous_node= temp;
                    temp.Next_node=newNode;
                }
                Count++;
            }
            public DLinkedListNode<T> Find(T value) {
                EqualityComparer<T> ec = EqualityComparer<T>.Default;
                DLinkedListNode<T> node = head;
                while (node != null && !ec.Equals(node.get_node_data() ,value))
                {
                    node = node.Next_node;
                }
                return node;
                /* Return Value: The first LinkedListNode<T> that contains 
                    * the specified value, if found; otherwise, null. */

            }
            //public bool Remove (T value) {
            // // Find the node containing value.
            // DLinkedListNode<T> node = Find(value);
            // Remove the node containing value.
            //if (node == null)
            //{ // Node with value is not in the current LinkedList<T>.
            //return false;
            //}
            //else
            // { // Node with value exists in the current LinkedList<T>
            // Remove(node);
            //return true;

            /* Return Value = true if the element containing value is
            * successfully removed; otherwise, false. This method also
            * returns false if value was not found in the original 
            * LinkedList<T>. */
            //}
            public void Remove(DLinkedListNode<T> node) 
            { 
                if(head == tail)  // Case of one node.
                {
                    head = tail =null;
                }else if(node == head)  // Case of first node.
                {
                    head = head.Next_node;
                    --size_of_list;
                    head.Previous_node=null;
                }else if(node == tail)  // Case of last node.
                {
                    tail =tail.Previous_node;
                    --size_of_list;
                    tail.Next_node=null;
                }
                else // Case of intermediate node.
                {
                    node.Previous_node.Next_node = node.Next_node;
                    node.Next_node.Previous_node = node.Previous_node;
                    --size_of_list;
                }
                node=null;
                Count--;    
            }
            /// <summary>
            /// /////Helper Functions 
            /// </summary>
            public void ValidateNode(DLinkedListNode<T> node) { }
            public void ValidateNewNode(DLinkedListNode<T> node) { }


        }
       

        static void Main(string[] args)
        {

        }

    }
}