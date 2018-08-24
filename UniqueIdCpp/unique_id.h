#ifndef UNIQUE_ID_BIND_H
#define UNIQUE_ID_BIND_H
extern "C" {
	void* unique_id_c(const char *label);
	void unique_id_release_c(const void *id);
	unsigned int unique_id_get(const void *id);
#ifdef USE_64
	unsigned long long unique_id_get64(const void *id);
#endif
}

#endif
