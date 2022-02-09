#include <stdio.h>
#include "student.h"
#include "order.h"
#include <stdlib.h>

int del_s_of_m(id) {
	tstudent m;
	int m_link = get_link_m(id);
	m = get_m_by_link(m_link);
	int link = m.order;
	int link1 = m.order;
	if (link != -1) {
		while (link != -1) {
			link = get_next(link);
			if (link != -1) del_s_by_link(link);
		}
	}
	del_s_by_link(link1);
	return 1;
}

void get_indexes_s() {
	file = fopen("order.ind", "a+");
	int i = 0;
	index ind;
	while (fread(&ind, sizeof(index), 1, file) && ind.link != -1) {
		indexes_s[i] = ind;
		++i;
	}
	count_s = i;
	ind.key = -1;
	ind.link = -1;
	indexes_s[i] = ind;
}

void del_s_by_link(link) {
	//write to the trash
	int i = 0;
	while (trash_s[i] > -1) {
		i++;
	}
	trash_s[i] = link;
	trash_s[i + 1] = -1;
	//mark as deleted
	torder o = get_s_by_link(link);
	o.deleted = 1;
	insert_s_with_link(link, o);
	//erase from indexes
	del_s_ind_bylink(link);
	//change links
	int next = get_next(link);
	int prev = indexes_s[0].link;
	i = 0;
	torder s;
	while (i < count_s) {
		prev = indexes_s[i].link;
		s = get_s_by_link(prev);
		if (s.next == link) break;
		i++;
	}
	if (i == count_s - 1) {
		i = 0;
		tstudent m;
		int linkm;
		while (i < count_m) {
			linkm = indexes_m[i].link;
			m = get_m_by_link(linkm);
			if (m.order == link) break;
			i++;
		}
		m.order = -1;
		insert_m_with_link(linkm, m);
		return;
	}
	else {
		s = get_s_by_link(prev);
		s.next = next;
		insert_s_with_link(prev, s);
		return;
	}
}

void del_s() {
	int id;
	printf(" id ?\n");
	scanf(" %d", &id);
	int link = get_link_s(id);
	if (link == -1) {
		printf("no order with such id\n");
	}else 
	del_s_by_link(link);
}

torder get_s_by_link(int link) {
	file = fopen("order.fl", "r");
	torder o;
	fseek(file, link, SEEK_SET);
	fread(&o, sizeof(o), 1, file);
	fclose(file);
	return o;
}

void save_indexes_s() {
	file = fopen("order.ind", "w");
	for (int i = 0; i < MAX_ORDERS; i++) {
		fwrite(&indexes_s[i], sizeof(indexes_s[i]), 1, file);
	}
}

void get_trash_s() {
	file = fopen("order.fl", "r+");
	fseek(file, 0, SEEK_SET);
	fread(&trash_s, sizeof(torder), 1, file);
}

void save_trash_s() {
	FILE* file = fopen("order.fl", "r+");
	fseek(file, 0, SEEK_SET);
	fwrite(&trash_s, sizeof(torder), 1, file);
}

void print_index_s() {
	int i = 0;
	while (i < count_s) {
		printf("%10d %10d \n", indexes_s[i].key, indexes_s[i].link);
		i++;
	}
}

void print_trash_s() {
	int i = 0;
	while (i < MAX_ORDERS) {
		printf("%3d ", trash_s[i]);
		i++;
	}
	printf("\n");
}


void print_s() {
	file = fopen("order.fl", "r");
	torder o;
	printf("%3s %10s %20s %10s\n", " ", "ID", "Date", "Payment");
	for (int n = 0; n < count_s; n++) {
		fseek(file, indexes_s[n].link, SEEK_SET);
		fread(&o, sizeof(o), 1, file);
		if (o.deleted == 0) {
			printf("%3d %10d %20s %10d\n", n+1, o.id, &o.date, o.payment);
		}
	}
	printf("\n");
	fclose(file);
}

void ext_s() {
	file = fopen("order.fl", "r");
	torder o;

	printf("%3s %10s %20s %10s %8s %8s\n", " ", "ID", "Date", "Payment", "Deleted", "Next");
	for (int n = 0; n < count_s; n++) {
		fseek(file, indexes_s[n].link, SEEK_SET);
		fread(&o, sizeof(o), 1, file);
		printf("%3d %10d %20s %10d %8d %8d\n", n+1, o.id, &o.date, o.payment, o.deleted, o.next);
	}

	printf("\n");
	fclose(file);
}

int get_link_toinsert_s() {
	int i = 0;
	while (trash_s[i] > -1) {
		i++;
	}
	if (i == 0) return (count_s + 1) * sizeof(torder);

	int result = trash_s[i - 1];
	trash_s[i - 1] = -1;
	return result;
}

void insert_s_index(int id, int link) {
	index ind;
	ind.key = id;
	ind.link = link;
	int i = 0;
	while (i < count_s && indexes_s[i].link != link) {
		i++;
	}
	indexes_s[i] = ind;
	if (i == count_s) {
		ind.key = -1;
		ind.link = -1;
		indexes_s[i + 1] = ind;
		count_s++;
	}
	else {
		qsort(indexes_s, count_s, sizeof(index), f);
	}
}

void insert_s_with_link(int link, torder s) {
	file = fopen("order.fl", "r+");
	fseek(file, link, SEEK_SET);
	fwrite(&s, sizeof(s), 1, file);
	fclose(file);
	return;
}

int get_next(int link) {
	file = fopen("order.fl", "r");
	fseek(file, link, SEEK_SET);
	if (feof(file)) {
		printf ("end of file \n");
		return -1;
	}
	torder o;
	fread(&o, sizeof(o), 1, file);
	return o.next;
}
void del_s_ind_bylink(int link) {
	int i = 0;
	while (indexes_s[i].link != link && indexes_s[i].link != -1) {
		i++;
	}
	index ind;
	while (indexes_s[i].link != -1) {
		indexes_s[i] = indexes_s[i + 1];
		i++;
	}
	count_s--;
}

int get_link_s(id) {
	//searching for link of order with key id.
	for (int i = 0; i < count_s; i++) {
		if (indexes_s[i].key == id)
			return indexes_s[i].link;
	}
	return -1;
}

void update_s() {
	int id;
	int field;
	printf("id ?\n");
	scanf(" %d", &id);

	int link = get_link_s(id);
	if (link == -1) printf("no order with such id\n");
	else {
		printf(" 1 - date \n 2 - payment \n");
		scanf(" %d", &field);
		update_s_with_link(link, field);
	}
}

void update_s_with_link(int link, int field) {
	torder s = get_s_by_link(link);
	switch (field) {
	case 1:
		printf("change date to : \n");
		scanf(" %s", &s.date);
		insert_s_with_link(link, s);
		break;
	case 2:
		printf("change payment to : \n");
		scanf(" %d", &s.payment);
		insert_s_with_link(link, s);
		break;
	return;
	}
}

void clear_s() {
	file = fopen("order.fl", "w");
	fclose(file);
	index ind;
	ind.key = -1;
	ind.link = -1;
	for (int i = 0; i < MAX_ORDERS; i++) {
		indexes_s[i] = ind;
		trash_s[i] = -1;
	}
	tstudent s; int link;
	for (int i = 0; i < count_m;  i++ ) {
		link = indexes_m[i].link;
		s = get_m_by_link(link);
		s.order = -1;
		insert_m_with_link(link, s);
	}
	count_s = 0;
	printf("orders are cleared\n");
}

void get_s() {
	int id;
	printf("id ?\n");
	scanf(" %d", &id);

	int link = get_link_s(id);
	if (link == -1) printf("no student with such id\n");
	else {
		torder s = get_s_by_link(link);
		printf("%3s %10s %20s %10s\n", " ", "ID", "Date", "Payment");
		printf("%3d %10d %20s %10d\n", " ", s.id, &s.date, s.payment);
	}
}

//void get_s_of_m(int id) {
//	int link = get_link_m(id);
//	if (link == -1) printf("no student with such id\n");
//	else {
//		printf("%3s %10s %20s %10s\n", " ", "ID", "Date", "Payment");
//		tstudent m = get_m_by_link(link);
//		link = m.order;
//		if (link == -1) printf("no orders\n");
//		int n = 1;
//		while (link != -1) {
//			torder s = get_s_by_link(link);
//			printf("%3d %10d %20s %10d\n", n, s.id, &s.date, s.payment);
//			link = s.next;
//			n++;
//		}
//		printf("\n");
//	}
//}


void insert_s() {
	torder o;
	if (count_s == 0) o.id = 1;
	else o.id = indexes_s[count_s - 1].key + 1;

	//get student
	int m_id, m_link;
	printf(" student id ?\n");
	scanf(" %d", &m_id);
	m_link = get_link_m(m_id);
	if (m_link == -1) {
		printf("no students with such id\n");
		return;
	}

	//fill new struct
	printf(" date ?\n");
	scanf(" %[^\n]%*c", &o.date);
	printf(" payment ? \n");
	scanf("%d", &o.payment);
	o.deleted = 0;
	o.next = -1;
	int s_link = get_link_toinsert_s();

	//update list
	update_list(m_link, s_link, o.id);

	//insert in files
	insert_s_index(o.id, s_link);

	file = fopen("order.fl", "r+");
	fseek(file, s_link, SEEK_SET);
	fwrite(&o, sizeof(torder), 1, file);	
	fclose(file);
}


void update_list(int m_link, int s_link, int s_id) {
	tstudent m = get_m_by_link(m_link);
	if (m.order == -1) {
		m.order = s_link;
		insert_m_with_link(m_link, m);
	}
	else {
		int link = m.order;
		while (get_next(link) != -1) {
			link = get_next(link);
		}
		torder s = get_s_by_link(link);
		s.next = s_link;
		insert_s_with_link(link, s);

	}
	
}