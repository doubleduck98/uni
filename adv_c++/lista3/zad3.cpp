#include <iostream>
#include <ratio>

using namespace std;

template <int N>
class harmonic : public std::ratio_add<std::ratio<1, N>, harmonic<N - 1>>{};

template <>
class harmonic<1> : public std::ratio<1, 1>{};

int main()
{
    using h = harmonic<46>; // 47 sie wykrzacza
    cout << h::num << "/" << h::den << endl;
}