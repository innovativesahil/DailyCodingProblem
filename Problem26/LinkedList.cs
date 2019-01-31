﻿namespace Problem26
{
	public class LinkedList<T>
	{
		protected class Node
		{
			public Node(T value)
			{
				Value = value;
			}

			public Node(T value, Node previous)
				: this(value)
			{
				previous.Next = this;
			}

			public T Value { get; set; }

			public Node Next { get; set; }
		}

		protected Node root;
		protected int count;

		public void Add(T element)
		{
			if (this.root == null)
			{
				this.count = 0;
				this.root = new Node(element);
			}
			else
			{
				var currentNode = this.root;
				var previousNode = (Node)null;

				while (currentNode != null)
				{
					previousNode = currentNode;
					currentNode = currentNode.Next;
				}

				currentNode = new Node(element, previousNode);
			}

			this.count++;
		}

		public T RemoveKthLastElement(int k)
		{
			var iterations = this.count - k;

			var currentNode = this.root;
			var previousNode = (Node)null;

			while (iterations > 0)
			{
				previousNode = currentNode;
				currentNode = currentNode.Next;
				iterations--;
			}

			previousNode.Next = currentNode.Next;
			this.count--;

			return currentNode.Value;
		}
	}
}
