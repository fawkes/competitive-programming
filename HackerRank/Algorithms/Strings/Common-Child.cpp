// HackerRank/Algorithms/Strings
// Common Child
// Link: https://www.hackerrank.com/challenges/common-child/problem

#include <bits/stdc++.h>

using namespace std;

int commonChild(string s1, string s2)
{
  vector<int> cache1(s2.size() + 1);
  vector<int> cache2(s2.size() + 1);

  vector<int> *pre_cache = &cache1;
  vector<int> *cur_cache = &cache2;

  for (int i = 0; i < s1.size(); i++)
  {
    for (int j = 0; j < s2.size(); j++)
    {
      if (s1[i] == s2[j])
      {
        (*cur_cache)[j + 1] = (*pre_cache)[j] + 1;
      }
      else
      {
        (*cur_cache)[j + 1] = max((*pre_cache)[j + 1], (*cur_cache)[j]);
      }
    }
    swap(pre_cache, cur_cache);
  }

  return (*pre_cache)[s2.size()];
}

int main()
{
  ofstream fout(getenv("OUTPUT_PATH"));

  string s1;
  getline(cin, s1);

  string s2;
  getline(cin, s2);

  int result = commonChild(s1, s2);

  fout << result << "\n";

  fout.close();

  return 0;
}
