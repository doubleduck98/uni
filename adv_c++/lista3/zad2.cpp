#include <iostream>
#include <limits>

using namespace std;

int main()
{
    cout << "max float: " << numeric_limits<float>::max() << endl
         << "max double: " << numeric_limits<double>::max() << endl
         << "min float: " << numeric_limits<float>::min() << endl
         << "min double: " << numeric_limits<double>::min() << endl
         << "min float(zdenormalizowana): " << numeric_limits<float>::epsilon() << endl
         << "min double(zdenormalizowana): " << numeric_limits<double>::denorm_min() << endl
         << "1 - min float: " << 1 - numeric_limits<float>::min() << endl
         << "1 - min double: " << 1 - numeric_limits<double>::min() << endl
         << "1 - min float(zdenormalizowana): " << 1 - numeric_limits<float>::denorm_min() << endl
         << "1 - min double(zdenormalizowana): " << 1 - numeric_limits<double>::denorm_min() << endl;
}