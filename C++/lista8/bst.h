//
// Created by szipi on 11.05.19.
//

#ifndef LISTA8_BST_H
#define LISTA8_BST_H

#include <iostream>
#include <stdexcept>
#include <algorithm>

using namespace std;

template<class T>
class bst {
private:
    class Node {
    public:
        Node *left;
        Node *right;
        T key;

        Node() = default;

        explicit Node(T value) {
            this->key = value;
            left = nullptr;
            right = nullptr;
        }

        ~Node() {
            delete left;
            delete right;
        }
    } *node = nullptr;

    void dodajxd(T value, Node *cnode) {
        if (cnode->key >= value) {
            if (cnode->left == nullptr)
                cnode->left = new Node(value);
            else
                dodajxd(value, cnode->left);
        } else {
            if (cnode->right == nullptr)
                cnode->right = new Node(value);
            else
                dodajxd(value, cnode->right);
        }
    }

    Node *minKey(Node *cnode) {
        Node *curr = cnode;
        while (curr && curr->left != nullptr)
            curr = curr->left;

        return curr;
    }

    Node *usunxd(T value, Node *cnode) {
        if (cnode == nullptr) return cnode;
        if (value < cnode->key)
            cnode->left = usunxd(value, cnode->left);
        else if (value > cnode->key)
            cnode->right = usunxd(value, cnode->right);
        else {
            if (cnode->left == nullptr) {
                Node *temp = cnode->right;
                cnode->right = nullptr;
                delete cnode;
                return temp;
            } else if (cnode->right == nullptr) {
                Node *temp = cnode->left;
                cnode->left = nullptr;
                delete cnode;
                return temp;
            }
            Node *temp = minKey(cnode->right);
            cnode->key = temp->key;
            cnode->right = usunxd(temp->key, cnode->right);
        }
        return cnode;
    }


    T znajdzxd(T value, Node *cnode) {
        if (cnode == nullptr)
            throw invalid_argument("nie ma takiej wartosci w drzewie");
        else if (value < cnode->key)
            znajdzxd(value, cnode->left);
        else if (cnode->key == value)
            return cnode->key;
        else
            znajdzxd(value, cnode->right);
    }

    void wypiszxd(Node *cnode) {
        if (cnode->left != nullptr)
            wypiszxd(cnode->left);
        cout << cnode->key << " ";
        if (cnode->right != nullptr)
            wypiszxd(cnode->right);
    }

public:
    bst() = default;

    bst(initializer_list<T> list) {
        for (auto &x: list) {
            this->dodajWezel(x);
        }
    }

    bst<T>(const bst<T> &drzewo) {
        if (drzewo.node != nullptr) {
            this->node = new Node();
            copy_n(drzewo.node, 1, this->node);
        }
    }

    bst<T> &operator=(const bst<T> &drzewo) {
        if (drzewo.node != nullptr) {
            this->node = new Node();
            copy_n(drzewo.node, 1, this->node);
        }
        return *this;
    }

    ~bst() {
        delete this->node;
    }

    void dodajWezel(T value) {
        if (this->node == nullptr)
            this->node = new Node(value);
        else
            dodajxd(value, this->node);
    }

    Node *usunWezel(T value) {
        if (this->node == nullptr)
            throw invalid_argument("drzewo jest puste");
        else
            usunxd(value, this->node);
    }

    T znajdzWezel(T value) {
        return znajdzxd(value, this->node);
    }

    void wypisz() {
        if (this->node == nullptr)
            cout << "drzewo jest puste";
        else
            wypiszxd(this->node);
        cout << endl;
    }
};


#endif //LISTA8_BST_H