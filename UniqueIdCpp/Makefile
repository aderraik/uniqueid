CC = g++
CFLAGS = -c -Wall -DUSE_64
OUTPUTFILE = libUniqueId.a

# Default target
.PHONY: all
all: $(OUTPUTFILE)

$(OUTPUTFILE): md5.o UniqueId.o
	ar rcs $@ $^
	ranlib $@

md5.o: md5.cpp md5.h
	$(CC) $(CFLAGS) -o $@ $<

UniqueId.o: UniqueId.cpp UniqueId.h
	$(CC) $(CFLAGS) -o $@ $<

clean:
	rm *.o *.a

rebuild:
	make clean
	make

