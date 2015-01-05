#include <iostream>
#include <string>
#include <set>
#include <queue>

using namespace std;

/*
Patrēnējamies kārtot un meklēt priekš eksāmena!
*/

class Node {
public:
	Node(int value) {
		this->value = value;
		left = NULL;
		right = NULL;
	}

	int value;
	Node* left;
	Node* right;
};

Node* createTree();
void printTree(Node* node, int level = 0);
Node* breadthFirstSearch(Node* root, int needToFind);

int main()
{
	// izveidosim koku
	Node* root = createTree();
	//printTree(root);

	int needToFind = 3;
	try {
		cout << breadthFirstSearch(root, needToFind)->value;
	}
	catch (...) {
		cout << "neizdevās!";
	}
	

	char readKey;
	cin >> readKey;
}

//procedure BFS(G, root) is
//      create a queue Q
//      create a set V
//      add root to V
//      enqueue root onto Q
//      while Q is not empty loop
//         t ← Q.dequeue()
//         if t is what we are looking for then
//            return t
//        end if
//        for all edges e in G.adjacentEdges(t) loop
//           u ← G.adjacentVertex(t, e)
//           if u is not in V then
//               add u to V
//               enqueue u onto Q
//           end if
//        end loop
//     end loop
//     return none
//end BFS

Node* breadthFirstSearch(Node* root, int needToFind) {
	// izprintēsim visu ceļu pie reizes

	set<Node*> set;
	queue<Node*> queue;
	set.insert(root);
	queue.push(root);

	while (!queue.empty()) {
		Node* node = queue.front();
		cout << node->value; // debug
		queue.pop();

		if (node->value == needToFind)
			return node;

		if (node->left != NULL) {
			Node* nextNode = node->left;
			if (set.find(nextNode) == set.end()) {
				set.insert(nextNode);
				queue.push(nextNode);
			}
		}

		if (node->right != NULL) {
			Node* nextNode = node->right;
			if (set.find(nextNode) == set.end()) {
				set.insert(nextNode);
				queue.push(nextNode);
			}
		}
	}

	return NULL;
}

void printTree(Node* node, int level) {
	cout << "level " << level << ": " << node->value << endl;
	level++;
	if (node->left != NULL)
		printTree(node->left, level);
	if (node->right != NULL)
	printTree(node->right, level);
}

Node* createTree() {
	Node* root = new Node(0);
	Node* node1 = new Node(1);
	Node* node2 = new Node(2);
	Node* node3 = new Node(3);
	Node* node4 = new Node(4);
	Node* node5 = new Node(5);
	Node* node6 = new Node(6);
	Node* node7 = new Node(7);
	Node* node8 = new Node(8);

	root->left = node1;
	root->right = node2;
	root->left->left = node3;
	root->left->right = node4;
	root->right->left = node5;
	root->right->right = node6;
	root->left->left->left = node7;
	root->left->left->right = node8;
	return root;
}