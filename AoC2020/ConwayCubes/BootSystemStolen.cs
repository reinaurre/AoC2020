using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Linq;

namespace AoC2020.ConwayCubes
{
    public class BootSystemStolen
    {
        public BootSystemStolen(string[] inputs, bool part2 = false)
        {
            var input = inputs.Select(line => line.ToCharArray()).ToArray();

            if (!part2)
            {
                var cubes = input
                    .Select((row, y) => row.Select((cube, x) => (Vector: new Vector3(x, y, 0), Value: cube)))
                    .SelectMany(v => v)
                    .ToDictionary(t => t.Vector, t => t.Value);

                for (var i = 0; i < 6; i++)
                {
                    cubes = CycleCubes(ExpandCubes(cubes));
                }

                Console.WriteLine(cubes.Values.Where(c => c == '#').Count());
            }
            else
            {
                var cubes2 = input
                    .Select((row, y) => row.Select((cube, x) => (Vector: new Vector4(0, x, y, 0), Value: cube)))
                    .SelectMany(v => v)
                    .ToDictionary(t => t.Vector, t => t.Value);

                for (var i = 0; i < 6; i++)
                {
                    cubes2 = CycleCubes2(ExpandCubes2(cubes2));
                }

                Console.WriteLine(cubes2.Values.Where(c => c == '#').Count());
            }
        }

        Dictionary<Vector3, char> ExpandCubes(Dictionary<Vector3, char> cubes)
        {
            var newCubes = new Dictionary<Vector3, char>(cubes);

            var directions = Enumerable.Range(-1, 3).Select(
                x => Enumerable.Range(-1, 3).Select(
                    y => Enumerable.Range(-1, 3).Select(z => new Vector3(x, y, z))
                ).SelectMany(v => v)
            ).SelectMany(v => v);

            foreach (var cube in cubes)
            {
                foreach (var d in directions)
                {
                    var newVector = cube.Key + d;
                    newCubes[newVector] = cubes.ContainsKey(newVector) ? cubes[newVector] : '.';
                }
            }

            return newCubes;
        }

        Dictionary<Vector3, char> CycleCubes(Dictionary<Vector3, char> cubes)
        {
            var newCubes = new Dictionary<Vector3, char>(cubes);
            var directions = Enumerable.Range(-1, 3).Select(
                x => Enumerable.Range(-1, 3).Select(
                    y => Enumerable.Range(-1, 3).Select(z => new Vector3(x, y, z))
                ).SelectMany(v => v)
            ).SelectMany(v => v).Where(v => v != new Vector3(0, 0, 0));

            foreach (var cube in cubes)
            {
                var activeNeighbors = directions
                    .Where(d => cubes.ContainsKey(cube.Key + d))
                    .Select(d => cubes[cube.Key + d])
                    .Where(c => c == '#')
                    .Count();

                if (cube.Value == '#')
                {
                    newCubes[cube.Key] = activeNeighbors == 2 || activeNeighbors == 3 ? '#' : '.';
                }
                else if (cube.Value == '.')
                {
                    newCubes[cube.Key] = activeNeighbors == 3 ? '#' : '.';
                }
            }
            return newCubes;
        }

        void PrintCubes(Dictionary<Vector3, char> cubes)
        {
            foreach (var z in cubes.GroupBy(kv => kv.Key.Z).OrderBy(grp => grp.Key))
            {
                var layer = String.Join(
                    "\n",
                    z.GroupBy(kv => kv.Key.Y)
                        .OrderBy(grp => grp.Key)
                        .Select(
                            grp => new string(
                                grp.OrderBy(kv => kv.Key.X)
                                    .Select(kv => kv.Value)
                                    .ToArray()
                            )
                        )
                );
                Console.WriteLine($"z={z.Key}");
                Console.WriteLine(layer);
                Console.WriteLine();
            }
        }

        // PART 2
        Dictionary<Vector4, char> CycleCubes2(Dictionary<Vector4, char> cubes)
        {
            var newCubes = new Dictionary<Vector4, char>(cubes);
            var directions = Enumerable.Range(-1, 3).Select(
                x => Enumerable.Range(-1, 3).Select(
                    y => Enumerable.Range(-1, 3).Select(
                        z => Enumerable.Range(-1, 3).Select(
                            w => new Vector4(w, x, y, z)
                        )
                    ).SelectMany(v => v)
                ).SelectMany(v => v)
            ).SelectMany(v => v).Where(v => v != new Vector4(0, 0, 0, 0));

            foreach (var cube in cubes)
            {
                var activeNeighbors = directions
                    .Where(d => cubes.ContainsKey(cube.Key + d))
                    .Select(d => cubes[cube.Key + d])
                    .Where(c => c == '#')
                    .Count();

                if (cube.Value == '#')
                {
                    newCubes[cube.Key] = activeNeighbors == 2 || activeNeighbors == 3 ? '#' : '.';
                }
                else if (cube.Value == '.')
                {
                    newCubes[cube.Key] = activeNeighbors == 3 ? '#' : '.';
                }
            }
            return newCubes;
        }

        Dictionary<Vector4, char> ExpandCubes2(Dictionary<Vector4, char> cubes)
        {
            var newCubes = new Dictionary<Vector4, char>(cubes);

            var directions = Enumerable.Range(-1, 3).Select(
                x => Enumerable.Range(-1, 3).Select(
                    y => Enumerable.Range(-1, 3).Select(
                        z => Enumerable.Range(-1, 3).Select(
                            w => new Vector4(w, x, y, z)
                        )
                    ).SelectMany(v => v)
                ).SelectMany(v => v)
            ).SelectMany(v => v);

            foreach (var cube in cubes)
            {
                foreach (var d in directions)
                {
                    var newVector = cube.Key + d;
                    newCubes[newVector] = cubes.ContainsKey(newVector) ? cubes[newVector] : '.';
                }
            }

            return newCubes;
        }
    }
}
