import sys
from mpmath import mp


def reverse_n_pi_digits(dig_num: int) -> str:
    mp.dps = dig_num
    reversed_pi: str = '0' if dig_num == 0 else '3'
    return str(mp.pi)[:1:-1] + '3' if dig_num > 1 else reversed_pi

    
if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("please enter number of digits...")
        exit(-1)
    print(reverse_n_pi_digits(int(sys.argv[1])))