#include <iostream>
#include <limits>
#include <cmath>

using namespace std;

int main()
{
    cout << "max: " << numeric_limits<long long int>::max() << endl
         << "min: " << numeric_limits<long long int>::min() << endl
         << "na " << sizeof(long long int) * 8 << " bitach" << endl
         << numeric_limits<long long int>::digits10 << " cyfr dziesiętnych" << endl;
}