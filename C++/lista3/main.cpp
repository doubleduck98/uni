#include <iostream>
#include <iomanip>
#include "trojkat.h"
#include "odcinek.h"
#include "punkt.h"

using namespace std;

int main() {
    punkt pa(0, 1);
    punkt pb = pa;
    pb.obroc(punkt(0, 0), 90);
    cout << pa << " obrocony o 90st wzgledem [0, 0] to " << pb << endl;
    punkt pc = pa;
    pc.przesun(7, -4);
    cout << pa << " przesuniety o [7, -4] to " << pc << endl;
    cout << "dystans pomiedzy " << pb << " a " << pc << " to " << dystans_pomiedzy_punktami(pb, pc) << endl;

    odcinek oa(punkt(0, 0), punkt(10, 10));
    cout << endl << "dlugosc odcinka " << oa << " to " << oa.dlugosc_odcinka() << endl;
    odcinek ob(punkt(0, 1), punkt(10, 11));
    cout << "czy " << oa << " i " << ob << " sa rownolegle?: " << czy_rownolegle(oa, ob) << endl;
    punkt pd(2, 2);
    cout << "czy punkt " << pd << " lezy na odcinku " << oa << " ?: " << oa.czy_punkt_lezy_na_odcinku(pd) << endl;
    punkt pe = oa.srodek_odcinka();
    cout << "srodek odcinka " << oa << " to " << pe << endl;
    return 0;
}