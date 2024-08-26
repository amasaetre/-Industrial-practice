from scipy.optimize import differential_evolution
from model import economic_model

def optimize_production(cost_per_unit, price_per_unit):

    def objective(production_volume):
        return -economic_model(production_volume, cost_per_unit, price_per_unit)

    bounds = [(0, 1e6)]  # Здесь я задал верхнюю границу для объема производства

    result = differential_evolution(objective, bounds)

    optimal_production = result.x[0]
    max_profit = -result.fun
    return optimal_production, max_profit
