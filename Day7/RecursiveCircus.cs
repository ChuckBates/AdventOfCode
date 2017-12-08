using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day7
{
    public class RecursiveCircus
    {
        public int GetWeightMisbalance(List<string> towerPrimitiveList)
        {
            var towers = new List<Tower>();
            foreach (var towerPrimitive in towerPrimitiveList)
            {
                towers.Add(ParseTower(towerPrimitive));
            }

            return BalanceTower(towers, IndexOfTower(towers, "bsfpjtc"));
        }

        public int BalanceTower(List<Tower> towers, int index)
        {
            var parent = towers[index];
            var weights = new List<int>();
            if (parent.UpperTowerNames.Length > 0)
            {
                foreach (var parentUpperTowerName in parent.UpperTowerNames)
                {
                    weights.Add(BalanceTower(towers, IndexOfTower(towers, parentUpperTowerName)));
                }

                if (weights.Count > 0 && !AreWeightsBalanced(weights))
                {
                    Debugger.Launch();
                }
            }

            return parent.Weight + weights.Sum();
        }

        public bool AreWeightsBalanced(List<int> weights)
        {
            return weights.Sum() % weights[0] == 0;
        }

        public string GetBottomProgram(List<string> towerPrimitiveList)
        {
            var bottomTower = "INVALID LIST";
            if (towerPrimitiveList != null && towerPrimitiveList.Count > 0)
            {
                if (towerPrimitiveList.Count == 1)
                {
                    return ParseTower(towerPrimitiveList[0]).Name;
                }

                var towers = new List<Tower>();
                foreach (var towerPrimitive in towerPrimitiveList)
                {
                    var tower = ParseTower(towerPrimitive);
                    if (tower != null)
                    {
                        towers.Add(tower);
                    }
                }

                var sortedTowers = SortTowers(towers);
                bottomTower = sortedTowers.First().Name;
            }

            return bottomTower;
        }

        public Tower ParseTower(string towerPrimitive)
        {
            if (!towerPrimitive.Contains(" "))
            {
                return null;
            }
            var name = towerPrimitive.Substring(0, towerPrimitive.IndexOf(" ", StringComparison.Ordinal));
            if (towerPrimitive.Length <= name.Length + 2)
            {
                return null;
            }
            var weightPrimitive = "";
            try
            {
                weightPrimitive = towerPrimitive.Substring(name.Length,
                    towerPrimitive.IndexOf(")", StringComparison.Ordinal) - name.Length);
            }
            catch (Exception)
            {
                Debugger.Launch();
            }
            var weightPrmitiveLength = weightPrimitive.Length;
            weightPrimitive = weightPrimitive.Replace('(', ' ');
            weightPrimitive = weightPrimitive.Replace(')', ' ');
            var weight = int.Parse(weightPrimitive.Trim());

            var upperParentNames = new string[] {};
            if (towerPrimitive.Length > name.Length + weightPrmitiveLength + 3)
            {
                var upperParentNamesPrimitve = towerPrimitive.Substring(name.Length + weightPrmitiveLength + 1);
                upperParentNamesPrimitve = upperParentNamesPrimitve.Replace('-', ' ');
                upperParentNamesPrimitve = upperParentNamesPrimitve.Replace('>', ' ');
                upperParentNamesPrimitve = upperParentNamesPrimitve.Trim();
                upperParentNames = upperParentNamesPrimitve.Split(',').Select(x => x.Trim()).ToArray();
            }
            return new Tower
            {
                Name = name,
                Weight = weight,
                UpperTowerNames = upperParentNames
            };
        }

        public List<Tower> SortTowers(List<Tower> towers)
        {
            var sortedTowers = new List<Tower>();
            if (towers.Count <= 1)
            {
                return towers;
            }

            foreach (var tower in towers)
            {
                foreach (var upperTowerName in tower.UpperTowerNames)
                {
                    if (TowersContainsTower(sortedTowers, upperTowerName))
                    {
                        var insertIndex = IndexOfTower(sortedTowers, upperTowerName) - 1;
                        if (insertIndex < 0)
                        {
                            insertIndex = 0;
                        }
                        sortedTowers.Insert(insertIndex, tower);
                    }
                }

                if (!TowersContainsTower(sortedTowers, tower.Name))
                {
                    sortedTowers.Add(tower);
                }
            }

            return sortedTowers;
        }

        private bool TowersContainsTower(List<Tower> towers, string candidate)
        {
            foreach (var tower in towers)
            {
                if (tower.Name.Equals(candidate))
                {
                    return true;
                }
            }

            return false;
        }

        private int IndexOfTower(List<Tower> towers, string candidate)
        {
            var index = 0;
            foreach (var tower in towers)
            {
                if (tower.Name.Equals(candidate))
                {
                    return index;
                }
                index++;
            }

            return index;
        }
    }

    public class Tower
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public string[] UpperTowerNames { get; set; }

        public override bool Equals(object obj)
        {
            var tower = (Tower) obj;
            return tower?.Name == Name && tower?.Weight == Weight && tower?.UpperTowerNames.Length == UpperTowerNames.Length;
        }
    }
}
