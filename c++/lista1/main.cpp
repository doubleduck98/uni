#include <iostream>
#include <iomanip>
#include <cmath>
#include <string>
#include <fstream>

using namespace std;

double trojkat(double x1, double x2, double x3){
    if(x1 <= 0 || x2 <= 0 || x3 <= 0){
        cerr << "Dlugosci bokow nie moga byc mniejsze niz 0." << endl;
        throw invalid_argument("");
    }
    else if(x1 + x2 <= x3 || x1 + x3 <= x2 || x2 + x3 <= x1) {
        cerr << "Suma dlugosci dwoch bokow nie moze byc mniejsza od dlugosci trzeciego." << endl;
        throw invalid_argument("");
    }
    
    double p = (x1 + x2 + x3)/2;
    double pole = sqrt(p*(p-x1)*(p-x2)*(p-x3));
    return pole;
}

void z1(){
    double x1, x2, x3;
    clog << "Podaj 3 boki trojkata:" << endl;
    cin >> x1 >> x2 >> x3;
    double pole = trojkat(x1, x2, x3);
    cout << "Pole trojkata to: " << fixed << setprecision(3) << pole << endl;
}

void z1input(){
    string s1, s2, s3;
    ifstream f;
    try{
        f.open(R"(D:\Studia\C++\lista1\boki.txt)", ios::out);
        f >> s1 >> s2 >> s3;
        f.close();
    }
    catch (const exception& e){
        throw logic_error("blad przy wczytywaniu danych z pliku");
    }

    double pole = trojkat(stod(s1), stod(s2), stod(s3));
    cout << "Pole trojkata z wczytanych danych to: " << pole << endl;
}
double kolo(double p){
    if(p <= 0) {
        cerr << "Pole nie moze byc mniejsze niz 0." << endl;
        throw invalid_argument("");
    }

    double r = sqrt(p / M_PI);
    return r;
}

void z2(){
    double p;
    clog << "Podaj pole kola:" << endl;
    cin >> p;
    double r = kolo(p);
    cout << "Promien kola o polu " << p << " to " << r << endl;

    ofstream f;
    try{
        f.open(R"(D:\Studia\C++\lista1\pole.txt)", ios::in | ios::app);
        f << r << "\n";
        f.close();
    }
    catch (const exception& e){
        throw logic_error("blad przy zapisu do pliku");
    }
}

int main() {
    z1();
    z1input();

    z2();
    return 0;
}