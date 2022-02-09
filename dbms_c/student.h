#pragma once
#include <stdio.h>

# define NAME_LEN 20
# define GROUP_LEN 5
# define SPEC_LEN 20
# define MAX_STUDENTS 20
FILE* file;

typedef struct index {
	int key;
	int link;
} index;

index indexes_m[MAX_STUDENTS];
int trash_m[MAX_STUDENTS];
int count_m;

typedef struct student {
	int id;
	char name[NAME_LEN];
	char group[GROUP_LEN];
	int course;
	char speciality[SPEC_LEN];
	int deleted;
	int order;
} tstudent;

int f(index a, index b);

void get_indexes_m();

void save_indexes_m();

void get_trash_m();

void save_trash_m();

void print_index_m();

void print_trash_m();

void print_m();

int get_link_toinsert_m();

void insert_m_index(int id, int link);

void insert_m();

void clear_m();

int get_link_m(id);

void insert_m_with_link(int link, tstudent s);

tstudent get_m_by_link(int link);

void del_m_ind(int id);

void del_m();

void get_m();

void update_m_with_link(int link, int field);

void update_m();
void ext_m();
