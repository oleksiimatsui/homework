#include <stdio.h>
#include "student.h"
#include "order.h"

int f(index a, index b) {
	if (a.key < b.key) return 1;
	else return 0;
}

void get_indexes_m() {
	file = fopen("student.ind", "a+");
	int i = 0;
	index ind;
	while (fread(&ind, sizeof(index), 1, file) && ind.link != -1) {
		indexes_m[i] = ind;
		++i;
	}
	count_m = i;
	ind.key = -1;
	ind.link = -1;
	indexes_m[i] = ind;
}

void save_indexes_m() {
	file = fopen("student.ind", "w");
	for (int i = 0; i < MAX_STUDENTS; i++) {
		fwrite(&indexes_m[i], sizeof(indexes_m[i]), 1, file);
	}
}

void get_trash_m() {
	file = fopen("student.fl", "r+");
	fseek(file, 0, SEEK_SET);
	fread(&trash_m, sizeof(tstudent), 1, file);
}

void save_trash_m() {
	FILE* file = fopen("student.fl", "r+");
	fseek(file, 0, SEEK_SET);
	fwrite(&trash_m, sizeof(tstudent), 1, file);
}


void print_index_m() {
	int i = 0;
	while (i < count_m) {
		printf("%10d %10d \n", indexes_m[i].key, indexes_m[i].link);
		i++;
	}
}

void print_trash_m() {
	int i = 0;
	while (i < MAX_STUDENTS) {
		printf("%3d ", trash_m[i]);
		i++;
	}
	printf("\n");
}

void print_m() {
	file = fopen("student.fl", "r");
	tstudent s;
	printf("%3s %10s %20s %7s %20s %3s \n", " ", "ID", "Name", "Group", "Speciality", "Course");

	for (int n = 0; n < count_m; n++) {
		fseek(file, indexes_m[n].link, SEEK_SET);
		fread(&s, sizeof(s), 1, file);
		if (s.deleted == 0) {
			printf("%3d %10d %20s %7s %20s %3d \n", n+1, s.id, &s.name, &s.group, &s.speciality, s.course);
		}
	}

	printf("\n");
	fclose(file);
}

void ext_m() {
	file = fopen("student.fl", "r");
	tstudent s;
	printf("%3s %4s %20s %7s %20s %3s %8s %20s \n", " ", "ID", "Name", "Group", "Speciality", "Course", "Deleted", "Order");
	for (int n = 0; n < count_m; n++) {
		fseek(file, indexes_m[n].link, SEEK_SET);
		fread(&s, sizeof(s), 1, file);
		printf("%3d %4d %20s %7s %20s %3d %8d %20d \n", n+1, s.id, &s.name, &s.group, &s.speciality, s.course, s.deleted, s.order);
	}
	printf("\n");
	fclose(file);
}

int get_link_toinsert_m() {
	int i=0;
	while (trash_m[i] > -1) {
		i++;
	}
	if (i == 0) return (count_m + 1) * sizeof(tstudent);
	
	int result = trash_m[i-1];
	trash_m[i - 1] = -1;
	return result;
	
}

void insert_m_index(int id, int link) {
	index ind;
	ind.key = id;
	ind.link = link;

	int i = 0;
	while (i < count_m && indexes_m[i].link != link) {
		i++;
	}

	indexes_m[i] = ind;
	
	if (i == count_m) {
		ind.key = -1;
		ind.link = -1;
		indexes_m[i + 1] = ind;
		count_m++;
	}
	else {
		qsort(indexes_m, count_m, sizeof(index), f);
	}
}

void insert_m() {
	tstudent s;
	file = fopen("student.fl", "r+");

	if (count_m == 0) s.id = 1;
	else s.id = indexes_m[count_m - 1].key + 1;

	s.deleted = 0;
	s.order = -1;
	printf(" name ?\n");
	scanf(" %[^\n]%*c", &s.name);
	printf(" group ? \n");
	scanf("%s", &s.group);
	printf(" speciality ? \n");
	scanf(" %[^\n]%*c", &s.speciality);
	printf(" course ? \n");
	scanf("%d", &s.course);

	int link = get_link_toinsert_m();
	insert_m_index(s.id, link);
	fseek(file, link, SEEK_SET);
	fwrite(&s, sizeof(tstudent), 1, file);
	fclose(file);
}

void clear_m() {
	file = fopen("student.fl", "w");
	fclose(file);
	index ind;
	ind.key = -1;
	ind.link = -1;
	for (int i = 0; i < MAX_STUDENTS; i++) {
		indexes_m[i] = ind;
		trash_m[i] = -1;
	}
	count_m = 0;
	clear_s();
	printf("students are cleared\n");
}

int get_link_m(id) {
	//searching for link of student with key id.
	for (int i = 0; i < MAX_STUDENTS; i++) {
		if (indexes_m[i].key == id)
			return indexes_m[i].link;
	}
	return -1;
}

void insert_m_with_link(int link, tstudent s) {
	file = fopen("student.fl", "r+");
	fseek(file, link, SEEK_SET);
	fwrite(&s, sizeof(s), 1, file);
	fclose(file);
}

tstudent get_m_by_link(int link) {
	file = fopen("student.fl", "r");
	tstudent s;
	fseek(file, link, SEEK_SET);
	fread(&s, sizeof(s), 1, file);
	fclose(file);
	return s;
}

void del_m_ind(int id) {
	int i = 0;
	while (indexes_m[i].key != id && indexes_m[i].link != -1) {
		i++;
	}
	index ind;
	while (indexes_m[i].link != -1) {
		indexes_m[i] = indexes_m[i + 1];
		i++;
	}
	count_m--;
}

void del_m() {
	int id;  
	printf(" id ?\n");
	scanf(" %d", &id);
	int link = get_link_m(id);
	if (link == -1) {
		printf(" no students with such id\n");
		ask();
	}
	//write to the trash
	int i = 0;
	while (trash_m[i] > -1) {
		i++;
	}
	trash_m[i] = link;
	trash_m[i + 1] = -1;
	//mark as deleted
	tstudent s = get_m_by_link(link);
	s.deleted = 1;

	del_s_of_m(id);

	s.order = -1;
	insert_m_with_link(link, s);
	//erase from indexes
	del_m_ind(id);
}

void get_m() {
	int id;
	printf("id ?\n");
	scanf(" %d", &id);

	int link = get_link_m(id);
	if(link == -1) printf("no student with such id\n");
	else {
		tstudent s = get_m_by_link(link);
		printf("%3s %10s %20s %7s %20s %3s \n", " ", "ID", "Name", "Group", "Speciality", "Course");
		printf("%3s %10d %20s %7s %20s %3d \n", " ", s.id, &s.name, &s.group, &s.speciality, s.course);
	}
	/*get_s_of_m(id);*/
}

void update_m_with_link(int link, int field) {
	tstudent s = get_m_by_link(link);
	switch (field){
	case 1:
		printf("change name to : \n");
		scanf(" %[^\n]%*c", &s.name);
		break;
	case 2:
		printf("change group to : \n");
		scanf(" %s", &s.group);
		break;
	case 3:
		printf("change course to : \n");
		scanf(" %s", &s.course);
		break;
	case 4:
		printf("change speciality to : \n");
		scanf(" %[^\n]%*c", &s.speciality);
		break;
	}
	insert_m_with_link(link, s);
}

void update_m() {
	int id;
	int field;
	printf("id ?\n");
	scanf(" %d", &id);

	int link = get_link_m(id);
	if (link == -1) printf("no student with such id\n");
	else {
		printf(" 1 - name \n 2 - group \n 3 - course \n 4 - speciality \n");
		scanf(" %d", &field);
		update_m_with_link(link, field);
	}
}
