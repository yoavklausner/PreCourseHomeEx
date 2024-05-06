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
    

def print_data(values_list: list, sorted_list: list, avg_value: float, positive_count: int) -> None:
    print("avg: ", avg_value)
    print("positive count: ", positive_count)
    print("sorted list: ", sorted_list)
    print("pearson correlation: ", get_pearson_correlation(values_list, avg_value))
    plt.plot(range(len(values_list)), values_list, marker='+', color='red')
    plt.show()


def analyse_input() -> None:
    positive_count: int = 0
    numbers_list: list = []
    print("enter numbers")
    while (number := float(input())) != -1:
        positive_count += 1 if number > 0 else 0
        numbers_list.append(number)
    print_data(numbers_list, sorted(numbers_list), sum(numbers_list)/len(numbers_list), positive_count)


if __name__ == "__main__":
    analyse_input()

