#include <iostream>
using namespace std;

int main() {
	
	/* A big change from my previous code was
	storing the operation from a string:
	    if ( char == '+'){	
	        string op = 'plus'} 

	to storing the operation in an interger: 
        int sum = _; 1 is addition, 0 is subtraction
	*/

	int result, num;
	int sum = -1;
	char op;
	
	//the following code takes in account the first number in the file
	cin >> num;
	result = num;

	//this while loop goes from the first operation and on
	while( cin >> op ){
		//if the first operation signals addition, store that as sum = 1		
		if( op == '+' ){
			sum = 1;
			cin >> num;
			result = result + num;
		}//if the first operation signals subtraction, store that as sum = 0
		else if ( op == '-' ){
			sum = 0;
			cin >> num;
			result = result - num;
		}//if the first operation signals a square...
		else if ( op == '^' ){
			//... check to see if there was addition before
			if ( sum == 1 ){
				//if addition was done, undo it and square the number
				result = result - num;
				result = result + (num * num);
			}//... check to see if there was subtraction before
			else if ( sum == 0 ){
				//if subtraction was done, undo it and square the number
				result = result + num;
				result = result - (num * num);
			}else {
				//if there was no previous addition or subtraction, square the number as is
				result = num * num;
			}
		}//if there is no operation, store the first number as the result
		else{
			sum = -1;
			cout << result << endl;
			result = num;
			if ( op == ';' ){
				//if "Clear" or ";", the next number in the next formula is the new number stored 
				cin >> num;
				result = num;
			}
		}
	}
return 0;
}