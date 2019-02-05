// HackerRank/Data Structures/Linked Lists
// Cycle Detection
// Link: https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle/problem

/*
 * For your reference:
 *
 * SinglyLinkedListNode {
 *     int data;
 *     SinglyLinkedListNode* next;
 * };
 *
 */
bool has_cycle(SinglyLinkedListNode *head)
{
  if (head == nullptr)
    return false;

  auto p = head;
  while (p != nullptr)
  {
    if (p->data == numeric_limits<int>::min())
      return true;
    p->data = numeric_limits<int>::min();
    p = p->next;
  }

  return false;
}
