import sys





def is_sorted_polyndrom(sequence: str)->bool:
    prevchar: chr = ' '   # white space preior to numbers and letters in ascii
    length: int = len(sequence)
    for i, char in enumerate(sequence[:int(length/2)+1]):
        if char != sequence[length-1 - i] or char < prevchar:
            return False
        prevchar = char
    return True



if __name__ == "__main__":
    if len(sys.argv) == 2:
        print(f"answer: {is_sorted_polyndrom(sys.argv[1])}\n")
    else:
        print("no fitting params entered...\n")
    print(" tests:")
    print(is_sorted_polyndrom("abcba"))
    print(is_sorted_polyndrom("12344321"))
    print(is_sorted_polyndrom("9876aha6789"))
    print(is_sorted_polyndrom("abc01"))



