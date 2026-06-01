#define _GNU_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>

// Change the number below to your student-id
#define STUDENT_ID 0

/*
 * A semi-random generator, which is dependent on
 * your student-id
 */
int32_t semi_random (void) {
    const static int32_t a = 214013U;
    const static int32_t c = 2531011U;

    static int32_t seed = (int32_t) STUDENT_ID;
    seed = seed * a + c;
    return (seed >> 16) & 0x7FFF;
}

/*
 * A function that ALLOCATES memory and fills it with the
 * value as a string.
 */
char *create_data_str(int32_t val) {
    char *text = NULL;
    asprintf(&text, "%d", val);
    return text;
}

typedef struct data_st {
    char *text;
    int32_t number;
} data_t;

/*
 * A memory pool is a way to allocate memory in blocks,
 * so you don't need to allocate every new number.
 * When required, you allocate "block_size" more spaces.
 */
typedef struct mem_pool_st {
    int block_size;
    int len;
    data_t *arr;
} mem_pool_t;


/*
 * A function that add the value to the list in sorted
 * order. Largest number first!
 *
 * Use the correct arguments
 */
void add_sorted(mem_pool_t *pool, int32_t value) {
    char *text = create_data_str(value);
    printf("add_sorted: to be implemented\n");
}

/*
 * A function to destroy the contents of the memory-pool
 */
void destroy(mem_pool_t *pool) {
    printf("destroy: to be implemented\n");
}


int main() {
    mem_pool_t mem_pool = {.block_size = 32, .len = 0, .arr = NULL};

    // Add 200 random numbers
    int i;
    for ( i = 0; i < 200; i++) {
        add_sorted(&mem_pool, semi_random());

    }
    // Print the first 10 numbers
    for (i = 0; i < 10; i++) {
        printf("%d\n", (i < mem_pool.len)?mem_pool.arr[i].number:-1);
    }
    destroy(&mem_pool);
    return 0;
}
