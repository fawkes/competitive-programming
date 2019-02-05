// HackerRank/Data Structures/Trees
// Tree - Huffman Decoding
// Link: https://www.hackerrank.com/challenges/tree-huffman-decoding/problem

/* 
The structure of the node is

typedef struct node {

	int freq;
    char data;
    node * left;
    node * right;
    
} node;

*/

void decode_huff(node *root, string s)
{
  node *current = root;
  for (int i = 0; i < s.length(); i++)
  {
    if (s[i] == '0')
    {
      current = current->left;
    }
    else if (s[i] == '1')
    {
      current = current->right;
    }

    if (current->left == nullptr && current->right == nullptr)
    {
      cout << current->data;
      current = root;
    }
  }
}
