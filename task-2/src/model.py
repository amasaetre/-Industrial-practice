def economic_model(production_volume, cost_per_unit, price_per_unit):

    revenue = production_volume * price_per_unit  # Выручка
    costs = production_volume * cost_per_unit  # Затраты
    profit = revenue - costs  # Прибыль
    return profit
