import matplotlib.pyplot as plt
import math



def get_pearson_correlation(y_values: list, y_avg: float) -> float:
    x_avg = sum(range(len(y_values)))/len(y_values)
    correlated_sum: float = 0
    y_sqr_sum: float = 0
    x_sqr_sum: float = 0
    for x, y in enumerate(y_values):
        correlated_sum += (y-y_avg) * (x-x_avg)
        y_sqr_sum += (y-y_avg)**2
        x_sqr_sum += (x-x_avg)**2
    return correlated_sum / math.sqrt(y_sqr_sum*x_sqr_sum)
    
    

def analyse_input() -> None:
    positive_count: int = 0
    sorted_list: list = []
    numbers_list: list = []
    avg_val: float = 0
    print("enter numbers")
    number = float(input())
    while number != -1:
        if number > 0:
            positive_count += 1
        sorted_list.append(number)
        number = float(input())
    numbers_list = sorted_list.copy()
    sorted_list.sort()
    avg_val = sum(sorted_list)/len(sorted_list)
    print("avg: ", avg_val)
    print("positive count: ", positive_count)
    print("sorted list: ", sorted_list)
    print("pearson correlation: ", get_pearson_correlation(numbers_list, avg_val))
    plt.plot(range(len(numbers_list)), numbers_list)
    plt.show()


if __name__ == "__main__":
    analyse_input()

