// HackerRank/Algorithms/Strings
// Sherlock and the Valid String
// Link: https://www.hackerrank.com/challenges/sherlock-and-valid-string/problem

#include <bits/stdc++.h>

using namespace std;

// Complete the isValid function below.
string isValid(string s)
{
  vector<int> counts(26);

  for (auto c : s)
  {
    counts[c - 'a']++;
  }

  map<int, int> counts_map;
  for (int i = 0; i < 25; i++)
  {
    if (counts[i] == 0)
      continue;

    counts_map[counts[i]]++;
  }

  if (counts_map.size() > 2)
    return "NO";

  if (counts_map.size() == 2)
  {
    int i = 0;
    int k[2];
    int v[2];
    for (auto c : counts_map)
    {
      k[i] = c.first;
      v[i] = c.second;
      i++;
    }

    if (abs(k[0] - k[1]) == 1 && (v[0] == 1 || v[1] == 1))
      return "YES";

    const int minKIndex = k[0] < k[1] ? 0 : 1;
    if (k[minKIndex] == 1 && v[minKIndex] == 1)
      return "YES";
  }
  else
  {
    return "YES";
  }

  return "NO";
}

int main()
{
  ofstream fout(getenv("OUTPUT_PATH"));

  string s;
  getline(cin, s);

  string result = isValid(s);

  fout << result << "\n";

  fout.close();

  return 0;
}
