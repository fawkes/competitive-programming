// HackerRank/Algorithms/Dynamic Programming
// Abbreviation
// Link: https://www.hackerrank.com/challenges/abbr/problem

#include <bits/stdc++.h>

using namespace std;

// Complete the abbreviation function below.
string abbreviation(string a, string b)
{
  const int a_length = a.length();
  const int b_length = b.length();
  if (a_length < b_length)
    return "NO";

  vector<vector<bool>> cache(a_length + 1);
  for (int i = 0; i <= a_length; i++)
  {
    cache[i].resize(b_length + 1);
  }
  cache[0][0] = true;

  bool encounteredCapital = false;
  for (int i = 1; i <= a_length; i++)
  {
    if (encounteredCapital || (a[i - 1] >= 'A' && a[i - 1] < 'a'))
    {
      cache[i][0] = false;
      encounteredCapital = true;
    }
    else
    {
      cache[i][0] = true;
    }
  }

  for (int i = 1; i <= a_length; i++)
  {
    for (int j = 1; j <= b_length; j++)
    {
      if (a[i - 1] == b[j - 1])
      {
        cache[i][j] = cache[i - 1][j - 1];
      }
      else if (a[i - 1] - 32 == b[j - 1])
      {
        cache[i][j] = cache[i - 1][j - 1] || cache[i - 1][j];
      }
      else if (a[i - 1] >= 'A' && a[i - 1] < 'a')
      {
        cache[i][j] = false;
      }
      else
      {
        cache[i][j] = cache[i - 1][j];
      }
    }
  }

  return cache[a_length][b_length] ? "YES" : "NO";
}

int main()
{
  ofstream fout(getenv("OUTPUT_PATH"));

  int q;
  cin >> q;
  cin.ignore(numeric_limits<streamsize>::max(), '\n');

  for (int q_itr = 0; q_itr < q; q_itr++)
  {
    string a;
    getline(cin, a);

    string b;
    getline(cin, b);

    string result = abbreviation(a, b);

    fout << result << "\n";
  }

  fout.close();

  return 0;
}
