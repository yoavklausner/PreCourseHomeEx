import sys



def num_len(number: int) -> int:
    return 1 if number < 10 else num_len(int(number/10)) + 1




if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("enter number please...")
        exit(-1)

    print(num_len(int(sys.argv[1])))


