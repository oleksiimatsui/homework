#include "student.h"
#include "order.h"

int ask() {
	int ans = 1;
	do {
		printf("1 - open students\n");
		printf("2 - open orders\n");
		printf("0 - close program\n");
		scanf(" %d", &ans);
		if (ans == 1) {
			do {
				printf("STUDENTS. total: %d \n", count_m);
				print_m();
				printf("0 - go back\n");
				printf("1 - insert student\n");
				printf("2 - delete student\n");
				printf("3 - get student\n");
				printf("4 - update student\n");
				printf("5 - open index table\n");
				printf("6 - open trash array\n");
				printf("7 - open students (extended)\n");
				printf("8 - clear all students\n");
				scanf(" %d", &ans);
				if (ans == 0) ask();
				if (ans == 1) insert_m();
				if (ans == 2) del_m();
				if (ans == 3) get_m();
				if (ans == 4) update_m();
				if (ans == 5) print_index_m();
				if (ans == 6) print_trash_m();
				if (ans == 7) ext_m();
				if (ans == 8) clear_m();
			} while (ans);
		}
		else
		if (ans == 2) {
			do {
				printf("orders. total: %d \n", count_s);
				print_s();
				printf("0 - go back\n");
				printf("1 - insert orders\n");
				printf("2 - delete order\n");
				printf("3 - get order\n");
				printf("4 - update order\n");
				printf("5 - open index table\n");
				printf("6 - open trash array\n");
				printf("7 - open orders (extended)\n");
				printf("8 - clear all orders\n");

				scanf(" %d", &ans);
				if (ans == 0) ask();
				if (ans == 1) insert_s();
				if (ans == 2) del_s();
				if (ans == 8) clear_s();
				if (ans == 5) print_index_s();
				if (ans == 6) print_trash_s();
				if (ans == 3) get_s();
				if (ans == 4) update_s();
				if (ans == 7) ext_s();
			} while (ans);
		}
	} while (ans);
	return 0;
}

int main() {
	get_indexes_m();
	get_trash_m();
	get_indexes_s();
	get_trash_s();
	ask();
	save_indexes_m();
	save_trash_m();
	save_indexes_s();
	save_trash_s();
	return 0;
}