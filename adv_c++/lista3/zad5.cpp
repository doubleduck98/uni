#include <iostream>
#include <array>
#include <random>
#include <chrono>
#include <memory>

using namespace std;

class matrix
{
private:
    int n;
    double *ns;

    double rand(double lb, double ub)
    {
        uniform_real_distribution<double> unif(lb, ub);
        default_random_engine re;
        return unif(re);
    }

    void fill()
    {
        for (int i = 0; i < n * n; ++i)
        {
            this->ns[i] = this->rand(0.5, 2.0);
        }
    }

public:
    matrix(int n)
    {
        this->n = n;
        this->ns = new double[n * n];
        this->fill();
    }

    ~matrix()
    {
        delete[] ns;
    }

    void square()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                double r = 0.0;
                for (int k = 0; k < n; k++)
                {
                    r += ns[i * n + k] * ns[k * n + j];
                }
                ns[i * n + j] = r;
            }
        }
    }
};

int main()
{
    auto m_10 = make_shared<matrix>(10);
    auto begin = chrono::high_resolution_clock::now();
    for (int i = 0; i < 100; ++i)
    {
        m_10->square();
    }
    auto end = chrono::high_resolution_clock::now();
    cout << "10x10: " << chrono::duration<double, micro>(end - begin).count() / 100 << "µs" << endl;

    auto m_100 = make_shared<matrix>(100);
    begin = chrono::high_resolution_clock::now();
    for (int i = 0; i < 10; ++i)
    {
        m_100->square();
    }
    end = chrono::high_resolution_clock::now();
    cout << "100x100: " << chrono::duration<double, milli>(end - begin).count() / 10 << "ms" << endl;

    auto m_1000 = make_shared<matrix>(1000);
    begin = chrono::high_resolution_clock::now();
    m_1000->square();
    end = chrono::high_resolution_clock::now();
    cout << "1000x1000: " << chrono::duration<double, ratio<1, 1>>(end - begin).count() << "s" << endl;

    // auto m_10000 = make_shared<matrix>(10000);
    // begin = chrono::high_resolution_clock::now();
    // m_10000->square();
    // end = chrono::high_resolution_clock::now();
    // cout << "10000x10000: " << chrono::duration<double, ratio<1, 1>>(end - begin).count() << "s" << endl;
}