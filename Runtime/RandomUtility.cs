using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MathUtility = Otz.Mathematics.MathUtility;
using DateTime = System.DateTime;
using Unity.Collections;

namespace Otz.Core
{
    public static class RandomUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Random GetDeterministicRandom(int v)
        {
            return Random.CreateFromIndex(MathUtility.GetUniqueUIntFromInt(v));
        }
        public static uint GetSeedFromCurrentTime()
        {
            return MathUtility.GetUniqueUIntFromInt(DateTime.Now.Millisecond);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetWeightedRandomIndex(float totalWeights, in NativeList<float> importances, ref Random random)
        {
            float decision = random.NextFloat(0f, totalWeights);
            totalWeights = 0f;
            for (int i = 0; i < importances.Length; i++)
            {
                totalWeights += importances[i];
                if(decision < totalWeights)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}