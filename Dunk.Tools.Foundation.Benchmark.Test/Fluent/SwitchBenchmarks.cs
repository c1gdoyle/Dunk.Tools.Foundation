using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Dunk.Tools.Foundation.Extensions;
using Dunk.Tools.Foundation.Fluent;

namespace Dunk.Tools.Foundation.Benchmark.Test.Fluent
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    public class SwitchBenchmarks
    {
        private int[] _numbers;
        private Dictionary<int, Action> _dictionary;

        [Params(10, 20, 50, 100)]
        public int Number { get; set; }

        [Benchmark]
        public void SwitchStatementBenchmarks()
        {
            foreach (int i in _numbers)
            {
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                    case 26:
                    case 27:
                    case 28:
                    case 29:
                    case 30:
                    case 31:
                    case 32:
                    case 33:
                    case 34:
                    case 35:
                    case 36:
                    case 37:
                    case 38:
                    case 39:
                    case 40:
                    case 41:
                    case 42:
                    case 43:
                    case 44:
                    case 45:
                    case 46:
                    case 47:
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                    case 58:
                    case 59:
                    case 60:
                    case 61:
                    case 62:
                    case 63:
                    case 64:
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                    case 70:
                    case 71:
                    case 72:
                    case 73:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                    case 90:
                    case 91:
                    case 92:
                    case 93:
                    case 94:
                    case 95:
                    case 96:
                    case 97:
                    case 98:
                    case 99:
                    case 100:
                        i.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        [Benchmark]
        public void SwitchMonadsBenchmarks()
        {
            foreach (int i in _numbers)
            {
                Switch<int>.On(i)
                    .Case(0, () => 0.ToString())
                    .Case(1, () => 1.ToString())
                    .Case(2, () => 2.ToString())
                    .Case(3, () => 3.ToString())
                    .Case(4, () => 4.ToString())
                    .Case(5, () => 5.ToString())
                    .Case(6, () => 6.ToString())
                    .Case(7, () => 7.ToString())
                    .Case(8, () => 8.ToString())
                    .Case(9, () => 9.ToString())
                    .Case(10, () => 10.ToString())
                    .Case(11, () => 11.ToString())
                    .Case(12, () => 12.ToString())
                    .Case(13, () => 13.ToString())
                    .Case(14, () => 14.ToString())
                    .Case(15, () => 15.ToString())
                    .Case(16, () => 16.ToString())
                    .Case(17, () => 17.ToString())
                    .Case(18, () => 18.ToString())
                    .Case(19, () => 19.ToString())
                    .Case(20, () => 10.ToString())
                    .Case(21, () => 21.ToString())
                    .Case(22, () => 22.ToString())
                    .Case(23, () => 23.ToString())
                    .Case(24, () => 24.ToString())
                    .Case(25, () => 25.ToString())
                    .Case(26, () => 26.ToString())
                    .Case(27, () => 27.ToString())
                    .Case(28, () => 28.ToString())
                    .Case(29, () => 29.ToString())
                    .Case(30, () => 30.ToString())
                    .Case(31, () => 31.ToString())
                    .Case(32, () => 32.ToString())
                    .Case(33, () => 33.ToString())
                    .Case(34, () => 34.ToString())
                    .Case(35, () => 35.ToString())
                    .Case(36, () => 36.ToString())
                    .Case(37, () => 37.ToString())
                    .Case(38, () => 38.ToString())
                    .Case(39, () => 39.ToString())
                    .Case(40, () => 40.ToString())
                    .Case(41, () => 41.ToString())
                    .Case(42, () => 42.ToString())
                    .Case(43, () => 43.ToString())
                    .Case(44, () => 44.ToString())
                    .Case(45, () => 45.ToString())
                    .Case(46, () => 46.ToString())
                    .Case(47, () => 47.ToString())
                    .Case(48, () => 48.ToString())
                    .Case(49, () => 49.ToString())
                    .Case(50, () => 50.ToString())
                    .Case(51, () => 51.ToString())
                    .Case(52, () => 52.ToString())
                    .Case(53, () => 53.ToString())
                    .Case(54, () => 54.ToString())
                    .Case(55, () => 55.ToString())
                    .Case(56, () => 56.ToString())
                    .Case(57, () => 57.ToString())
                    .Case(58, () => 58.ToString())
                    .Case(59, () => 59.ToString())
                    .Case(60, () => 60.ToString())
                    .Case(61, () => 61.ToString())
                    .Case(62, () => 62.ToString())
                    .Case(63, () => 63.ToString())
                    .Case(64, () => 64.ToString())
                    .Case(65, () => 65.ToString())
                    .Case(66, () => 66.ToString())
                    .Case(67, () => 67.ToString())
                    .Case(68, () => 68.ToString())
                    .Case(69, () => 69.ToString())
                    .Case(70, () => 70.ToString())
                    .Case(71, () => 71.ToString())
                    .Case(72, () => 72.ToString())
                    .Case(73, () => 73.ToString())
                    .Case(74, () => 74.ToString())
                    .Case(75, () => 75.ToString())
                    .Case(76, () => 76.ToString())
                    .Case(77, () => 77.ToString())
                    .Case(78, () => 78.ToString())
                    .Case(79, () => 79.ToString())
                    .Case(80, () => 80.ToString())
                    .Case(81, () => 81.ToString())
                    .Case(82, () => 82.ToString())
                    .Case(83, () => 83.ToString())
                    .Case(84, () => 84.ToString())
                    .Case(85, () => 85.ToString())
                    .Case(86, () => 86.ToString())
                    .Case(87, () => 87.ToString())
                    .Case(88, () => 88.ToString())
                    .Case(89, () => 89.ToString())
                    .Case(90, () => 90.ToString())
                    .Case(91, () => 91.ToString())
                    .Case(92, () => 92.ToString())
                    .Case(93, () => 93.ToString())
                    .Case(94, () => 94.ToString())
                    .Case(95, () => 95.ToString())
                    .Case(96, () => 96.ToString())
                    .Case(97, () => 97.ToString())
                    .Case(98, () => 98.ToString())
                    .Case(99, () => 99.ToString())
                    .Case(100, () => 100.ToString())
                    .Default(() => { });
            }
        }

        [Benchmark]
        public void DictionaryBenchmarks()
        {
            foreach (int i in _numbers)
            {
                Action action;
                if (_dictionary.TryGetValue(i, out action))
                {
                    action();
                }
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            _numbers = Enumerable.Range(0, Number)
                .Randomize()
                .ToArray();
            _dictionary =
               _numbers
               .ToDictionary(x => x, x => (Action)(() => x.ToString()));
        }
    }
}
