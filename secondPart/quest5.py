import sys
from mpmath import mp

# the program is taking a while because the mp pi calculation is slow up to 10000...
# in order to speed up you can decrease the dps.
# there are more simple ways to do this function like recursion etc. but they are less acurate or less efficient

def reverse_n_pi_digits(dig_num: int) -> str:
    reversed_pi = ''.join(['3' if i == 1 else str(mp.pi)[i] for i in range(dig_num, 0, -1)])
    return reversed_pi
    '''if dig_num == 0:
        return ''
    return '3' if dig_num == 1 else str(mp.pi)[dig_num] + reverse_n_pi_digits(dig_num-1)
    '''
    
if __name__ == "__main__":
    mp.dps = 10000
    if len(sys.argv) != 2:
        print("please enter number of digits...")
        exit(-1)
    print(reverse_n_pi_digits(int(sys.argv[1])))