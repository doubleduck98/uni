#include <cmath>
#include <iomanip>
#include <iostream>
#include <iterator>
#include <numeric>
#include <vector>

using namespace std;

double variance(double mean, vector<double>& vec) {
    auto add_square = [mean](double sum, int i) {
        auto d = i - mean;
        return sum + d * d;
    };
    double sum = accumulate(vec.begin(), vec.end(), 0.0, add_square);
    return sum / (vec.size() - 1);
}

double mean(vector<double>& vec) {
    return accumulate(vec.begin(), vec.end(), 0.0) / vec.size();
}

int main() {
    vector<double> vec = vector<double>(istream_iterator<double>(cin),
                                        istream_iterator<double>());
    cout << "srednia: " << fixed << setprecision(3) << mean(vec) << endl;
    cout << "odchylenie standardowe: " << fixed << setprecision(3)
         << sqrt(variance(mean(vec), vec)) << endl;
}