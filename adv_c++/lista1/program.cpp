#include <cmath>
#include <iostream>
#include <set>

using namespace std;

// do flag kompilacji należy dodać -trigraphs
// żeby nie było brzydkich warningów to dodajemy -Wno-trigraphs
void zadanie1() ??< cout << "??-??(??)??<??!elo" << endl; }

void zadanie2()
{
    cout << R"(Instytut Informatyki Uniwersytetu Wrocławskiego)" << endl
         << R"(Fryderyka Joliot-Curie 15)" << endl
         << R"(50-383 Wrocław)" << endl;
    cout << R"(C:\Program Files)" << endl;
    cout << R"a()(())(()())("(")")a" << endl;
}

void zadanie3()
{
    using set = set<string>;
    set s{"qwe", "asd", "zxc"};
    for (auto str : s)
    {
        cout << str << endl;
    }
}

enum ziomek : uint16_t
{
    Szymon,
    Dawid,
    Basia,
    Kacper
};
void fun(string msg, ziomek z)
{
    switch (z)
    {
    case Szymon:
        cout << msg << " Szymon." << endl;
        break;

    case Dawid:
        cout << "Dawid, " << msg << endl;
        break;

    case Basia:
        cout << msg << " Basia." << endl;
        break;

    case Kacper:
        cout << msg << " Kacper!" << endl;
        break;

    default:
        break;
    }
};

void zadanie4()
{
    fun("Zapraszam na wykład", ziomek::Szymon); // albo ziomek(0)
}

auto lucas(uint32_t n)
{
    if (n == 0)
        return 2;
    else if (n == 1)
        return 1;
    else
        return lucas(n - 1) + lucas(n - 2);
}

void zadanie5()
{
    cout << lucas(38) << endl
         << lucas(27) << endl
         << lucas(2) << endl;
}

void miesjca_zerowe(double a, double b, double c)
{
    double epsilon = 1e-8;

    if (auto delta = pow(b, 2.0) - 4.0 * a * c; abs(delta) < epsilon) // ==0
    {
        double mz = -b / (2.0 * a);
        cout << mz << endl;
    }
    else if (delta > epsilon) // >0
    {
        double delta_sqrt = sqrt(delta);
        double x0 = (-b - delta_sqrt) / (2.0 * a);
        double x1 = (-b + delta_sqrt) / (2.0 * a);
        cout << x0 << ", " << x1 << endl;
    }
    else
    {
        cout << "nie ma" << endl;
    }
}

void zadanie6()
{
    miesjca_zerowe(1, 0, 1);
    miesjca_zerowe(1, -4, 4);
    miesjca_zerowe(1, -5, 6);
}

void slownie(string d)
{
    cout << d.substr(0, 2);

    switch (auto m = stoi(d.substr(3, 2)); m)
    {
    case 1:
        cout << " stycznia ";
        break;

    case 2:
        cout << " lutego ";
        break;

    case 3:
        cout << " marca ";
        break;

    case 4:
        cout << " kwietnia ";
        break;

    case 5:
        cout << " maja ";
        break;

    case 6:
        cout << " czerwca ";
        break;

    case 7:
        cout << " lipca ";
        break;

    case 8:
        cout << " sierpnia ";
        break;

    case 9:
        cout << " września ";
        break;

    case 10:
        cout << " października ";
        break;

    case 11:
        cout << " listopada ";
        break;

    case 12:
        cout << " grudnia ";
        break;

    default:
        break;
    }
    cout << d.substr(6, 4) << endl;
}

void zadanie7()
{
    // dd.mm.rrr
    slownie("16.11.1998");
    slownie("15.10.2020");
    slownie("20.01.1973");
}

int main()
{
    cout << "***1" << endl;
    zadanie1();
    cout << endl
         << "***2" << endl;
    zadanie2();
    cout << endl
         << "***3" << endl;
    zadanie3();
    cout << endl
         << "***4" << endl;
    zadanie4();
    cout << endl
         << "***5" << endl;
    zadanie5();
    cout << endl
         << "***6" << endl;
    zadanie6();
    cout << endl
         << "***7" << endl;
    zadanie7();
}