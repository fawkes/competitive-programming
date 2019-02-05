// HackerRank/Algorithms/Greedy
// Candies
// Link: https://www.hackerrank.com/challenges/candies/problem

#include <bits/stdc++.h>

using namespace std;

// Complete the candies function below.
long candies(int n, vector<int> arr)
{
  vector<int> candyCounts(n);
  candyCounts[0] = 1;
  long cache = 1;
  for (int i = 1; i < n; i++)
  {
    if (arr[i] > arr[i - 1])
    {
      cache++;
    }
    else
    {
      cache = 1;
    }

    candyCounts[i] = cache;
  }

  long sum = candyCounts[n - 1];
  for (int i = n - 2; i >= 0; i--)
  {
    if (arr[i] > arr[i + 1])
    {
      cache++;
    }
    else
    {
      cache = 1;
    }
    if (cache > candyCounts[i])
    {
      candyCounts[i] = cache;
    }

    sum += candyCounts[i];
  }

  return sum;
}

int main()
{
  ofstream fout(getenv("OUTPUT_PATH"));

  int n;
  cin >> n;
  cin.ignore(numeric_limits<streamsize>::max(), '\n');

  vector<int> arr(n);

  for (int i = 0; i < n; i++)
  {
    int arr_item;
    cin >> arr_item;
    cin.ignore(numeric_limits<streamsize>::max(), '\n');

    arr[i] = arr_item;
  }

  long result = candies(n, arr);

  fout << result << "\n";

  fout.close();

  return 0;
}
