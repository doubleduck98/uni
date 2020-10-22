#include <iostream>
#include <memory>

using namespace std;

int main()
{
    weak_ptr<int> weak;
    cout << (weak.expired() ? "true" : "false") << endl;

    auto shared = make_shared<int>(1);
    weak = shared;
    cout << (weak.expired() ? "true" : "false") << endl;

    shared.reset();
    cout << (weak.expired() ? "true" : "false") << endl;
}