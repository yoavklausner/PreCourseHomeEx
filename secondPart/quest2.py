import sys


def pythagorian_triplet_by_sum(sum: int) -> None:
    for a in range(1, sum):
        b_plus_c: int = sum - a
        for b in range(a, b_plus_c):
            c: int = b_plus_c - b
            if a**2 + b**2 == c**2:
                print(f"{a}<{b}<{c}")


if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("please enter sum to test...")
        exit(-1)

    pythagorian_triplet_by_sum(int(sys.argv[1]))



