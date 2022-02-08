#pragma once
#include <stdio.h>
# define DATE_LEN 20
# define MAX_ORDERS 20
FILE* file;

typedef struct order {
	int id;
	char date[DATE_LEN];
	int payment;
	int next;
	int deleted;
} torder;

index indexes_s[MAX_ORDERS];
int trash_s[MAX_ORDERS];
int count_s;

int del_s_of_m(id);

void get_indexes_s();

void del_s_by_link(link);

void del_s();

//void get_s_of_m(int id);

torder get_s_by_link(int link);

void save_indexes_s();

void get_trash_s();

void save_trash_s();
void print_index_s();

void print_trash_s();

void print_s();

void ext_s();

int get_link_toinsert_s();

void insert_s_index(int id, int link);

void insert_s_with_link(int link, torder s);
int get_next(int link);
void del_s_ind_bylink(int link);

int get_link_s(id);

void update_s();
void update_s_with_link(int link, int field);
void clear_s();
void get_s();
void insert_s();

void update_list(int m_link, int s_link, int s_id);