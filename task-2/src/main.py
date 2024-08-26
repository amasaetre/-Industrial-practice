from optimization import optimize_production

def main():
    cost_per_unit = 10   # Себестоимость
    price_per_unit = 20  # Цена продажи

    optimal_production, max_profit = optimize_production(cost_per_unit, price_per_unit)

    print(f"Оптимальный объем производства: {optimal_production:.2f} единиц")
    print(f"Максимальная прибыль: {max_profit:.2f}  единиц")

if __name__ == "__main__":
    main()
