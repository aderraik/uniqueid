OUTPUTFILE = UniqueIdCppCmd
UNIQUEIDDIR = ../UniqueIdCpp

CC = g++
CFLAGS = -c -Wall -I$(UNIQUEIDDIR) -DUSE_64

# Default target
.PHONY: all
all: $(OUTPUTFILE)

$(OUTPUTFILE): main.o $(UNIQUEIDDIR)/libUniqueId.a
	$(CC) -o $@ $^

main.o: main.cpp $(UNIQUEIDDIR)/UniqueId.h
	$(CC) $(CFLAGS) -o $@ $<

clean:
	rm *.o $(OUTPUTiFILE)

rebuild:
	make clean
	make

