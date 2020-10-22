#include <iostream>
#include <memory>

using namespace std;

class prosta_klasa
{
private:
    uint64_t licznik;

public:
    explicit prosta_klasa()
    {
        this->licznik = 1;
    }
    virtual ~prosta_klasa()
    {
        cerr << this->licznik << endl;
    }
    void add(int v)
    {
        this->licznik += v;
    }
    friend ostream &operator<<(ostream &out, const prosta_klasa &k)
    {
        out << k.licznik;
        return out;
    }
};

unique_ptr<prosta_klasa[]> funkcja(unique_ptr<prosta_klasa[]> ptr, int n, int m, int i)
{
    if (i >= m)
        return ptr;
    for (int k = 0; k < 10; k++)
    {
        ptr[rand() % n].add(i);
    }
    return funkcja(move(ptr), n, m, ++i);
}

int main()
{
    int n = 20;
    int m = 100;
    unique_ptr<prosta_klasa[]> tab{new prosta_klasa[n]};

    tab = funkcja(move(tab), n, m, 0);

    for (int i = 0; i < n; i++)
    {
        cout << tab[i] << endl;
    }

    cout << "***" << endl;
}