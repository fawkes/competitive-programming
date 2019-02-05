// HackerRank/Algorithms/Sorting
// Fraudulent Activity Notifications
// Link: https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem

#include <bits/stdc++.h>

using namespace std;

vector<string> split_string(string);

double get_median2(vector<int> &count, int d)
{
  const int m = static_cast<int>(d / 2);
  if (d % 2 == 1)
  {
    int sum = 0;
    for (int i = 0; i < 201; i++)
    {
      sum += count[i];
      if (sum > m)
      {
        return static_cast<double>(i) * 2.0;
      }
    }
  }
  else
  {
    int sum = 0;
    int first = -1, second = -1;
    for (int i = 0; i < 201; i++)
    {
      sum += count[i];
      if (sum == m)
      {
        first = i;
      }
      else if (sum > m)
      {
        if (first < 0)
          first = i;
        second = i;

        return static_cast<double>(first + second);
      }
    }
  }

  return 0.0;
}
// Complete the activityNotifications function below.
int activityNotifications(vector<int> expenditure, int d)
{
  if (expenditure.size() == static_cast<unsigned int>(d))
    return 0;

  int result = 0;
  deque<int> trail(d);
  vector<int> count(201);

  for (int i = 0; i < d; i++)
  {
    trail[i] = expenditure[i];
    count[expenditure[i]]++;
  }

  for (int i = d; i < expenditure.size(); i++)
  {
    const double median2 = get_median2(count, d);

    if (static_cast<double>(expenditure[i]) >= median2)
    {
      result++;
    }

    count[trail[0]]--;
    trail.pop_front();

    count[expenditure[i]]++;
    trail.push_back(expenditure[i]);
  }

  return result;
}

int main()
{
  ofstream fout(getenv("OUTPUT_PATH"));

  string nd_temp;
  getline(cin, nd_temp);

  vector<string> nd = split_string(nd_temp);

  int n = stoi(nd[0]);

  int d = stoi(nd[1]);

  string expenditure_temp_temp;
  getline(cin, expenditure_temp_temp);

  vector<string> expenditure_temp = split_string(expenditure_temp_temp);

  vector<int> expenditure(n);

  for (int i = 0; i < n; i++)
  {
    int expenditure_item = stoi(expenditure_temp[i]);

    expenditure[i] = expenditure_item;
  }

  int result = activityNotifications(expenditure, d);

  fout << result << "\n";

  fout.close();

  return 0;
}

vector<string> split_string(string input_string)
{
  string::iterator new_end = unique(input_string.begin(), input_string.end(), [](const char &x, const char &y) {
    return x == y and x == ' ';
  });

  input_string.erase(new_end, input_string.end());

  while (input_string[input_string.length() - 1] == ' ')
  {
    input_string.pop_back();
  }

  vector<string> splits;
  char delimiter = ' ';

  size_t i = 0;
  size_t pos = input_string.find(delimiter);

  while (pos != string::npos)
  {
    splits.push_back(input_string.substr(i, pos - i));

    i = pos + 1;
    pos = input_string.find(delimiter, i);
  }

  splits.push_back(input_string.substr(i, min(pos, input_string.length()) - i + 1));

  return splits;
}
